<?php
error_reporting(E_ALL);
ini_set('display_errors', 1);
#header("Content-Type: application/json; charset=utf-8");
require_once "php/conexion.php";

$method = $_SERVER["REQUEST_METHOD"];

switch ($method) {

    case "GET":
        if (isset($_GET['max']) && $_GET['max'] == '1') {
            $stmt = $conn->query("CALL sp_ultimo_id_t003_epc()");
            $result = $stmt->fetch(PDO::FETCH_ASSOC);
            $stmt->closeCursor();
            echo json_encode($result);
        } elseif (isset($_GET['id_documento']) && isset($_GET['pendientes']) && $_GET['pendientes'] == '1') {
            $stmt = $conn->prepare("CALL sp_list_t003_epc_pendientes_by_documento(?)");
            $stmt->execute([$_GET['id_documento']]);
            $result = $stmt->fetchAll(PDO::FETCH_ASSOC);
            $stmt->closeCursor();
            echo json_encode($result);
        } elseif (isset($_GET['id_detalle'])) {
            $stmt = $conn->prepare("CALL sp_list_t003_epc_by_detalle(?)");
            $stmt->execute([$_GET['id_detalle']]);
            $result = $stmt->fetchAll(PDO::FETCH_ASSOC);
            $stmt->closeCursor();
            echo json_encode($result);
        } elseif (isset($_GET['id'])) {
            $stmt = $conn->prepare("CALL sp_find_t003_epc(?)");
            $stmt->execute([$_GET['id']]);
            $result = $stmt->fetch(PDO::FETCH_ASSOC);
            $stmt->closeCursor();
            echo json_encode($result);
        } else {
            $stmt = $conn->query("CALL sp_list_t003_epc()");
            $result = $stmt->fetchAll(PDO::FETCH_ASSOC);
            $stmt->closeCursor();
            echo json_encode($result);
        }
        break;

    case "POST":
        try {
            $data = json_decode(file_get_contents("php://input"), true);

            $items = $data["epcs"];
            $detalles = $data["detalles"] ?? [];
            $conn->beginTransaction();

            $values = [];
            $params = [];

            foreach ($items as $item) {
                $values[] = "(?,?,?,?,?,?)";

                $params[] = $item["f003_id_barra"];
                $params[] = $item["f003_id_documento_detalle"];
                $params[] = $item["f003_epc"];
                $params[] = $item["f003_impreso"];
                $params[] = $item["f003_habilitado"];
                $params[] = $item["f003_creacion"];
            }

            $sql = "
            INSERT INTO t003_epc
            (
                f003_id_barra,
                f003_id_documento_detalle,
                f003_epc,
                f003_impreso,
                f003_habilitado,
                f003_creacion
            )
            VALUES " . implode(",", $values);

            $stmt = $conn->prepare($sql);
            $stmt->execute($params);

            foreach ($detalles as $detalle) {
                $stmtDet = $conn->prepare("CALL sp_update_t021_cantidad_epc_generada(?, ?, ?)");
                $stmtDet->execute([
                    $detalle["f021_id"],
                    $detalle["cantidad"],
                    $detalle["actualizacion"] ?? null
                ]);
                $stmtDet->closeCursor();
            }

            $conn->commit();

            echo json_encode([
                "mensaje" => "Procesado: " . count($items)
            ]);
        } catch (PDOException $e) {
            if ($conn->inTransaction()) {
                $conn->rollBack();
            }
            http_response_code(500);
            echo json_encode(["mensaje" => $e->getMessage()]);
        }
        break;

    case "PUT":
        $data = json_decode(file_get_contents("php://input"), true);

        if (isset($data["epcs"]) && is_array($data["epcs"])) {
            $conn->beginTransaction();
            $stmt = $conn->prepare("CALL sp_update_t003_epc_impreso(?,?,?)");

            foreach ($data["epcs"] as $epc) {
                $stmt->execute([
                    $epc["f003_id"] ?? null,
                    $epc["f003_impreso"] ?? null,
                    $epc["f003_actualizacion"] ?? null
                ]);
                $stmt->closeCursor();
            }

            $detalles = $data["detalles"] ?? [];
            foreach ($detalles as $detalle) {
                $stmtDet = $conn->prepare("CALL sp_update_t021_cantidad_impresa(?, ?, ?)");
                $stmtDet->execute([
                    $detalle["f021_id"],
                    $detalle["cantidad"],
                    $detalle["actualizacion"] ?? null
                ]);
                $stmtDet->closeCursor();
            }

            $conn->commit();
            echo json_encode(["mensaje" => "actualizados: " . count($data["epcs"])]);
        } else {
            $stmt = $conn->prepare("CALL sp_update_t003_epc_impreso(?,?,?)");
            $stmt->execute([
                $data["f003_id"] ?? null,
                $data["f003_impreso"] ?? null,
                $data["f003_actualizacion"] ?? null
            ]);
            $stmt->closeCursor();
            echo json_encode(["mensaje" => "actualizado"]);
        }
        break;

    case "DELETE":
        http_response_code(405);
        echo json_encode(["mensaje" => "Metodo DELETE no implementado"]);
        break;

    default:
        http_response_code(405);
}
?>
