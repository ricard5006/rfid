<?php
error_reporting(E_ALL);
ini_set('display_errors', 1);
header("Content-Type: application/json; charset=utf-8");
require_once "php/conexion.php";

$method = $_SERVER["REQUEST_METHOD"];

function ejecutarDocumento($conn, $documentoCarga) {
    if (!isset($documentoCarga["documento"]) || !isset($documentoCarga["detalles"]) || !is_array($documentoCarga["detalles"])) {
        throw new Exception("Estructura invalida. Se esperaba documento y detalles.");
    }

    $documento = $documentoCarga["documento"];
    $detalles = $documentoCarga["detalles"];

    if (count($detalles) === 0) {
        throw new Exception("El documento no tiene detalles.");
    }

    $stmt = $conn->prepare("CALL sp_new_t020_documentos(?, ?, ?, ?, ?, ?, ?)");
    $stmt->execute([
        $documento["f020_tipo_documento"] ?? null,
        $documento["f020_numero_documento"] ?? null,
        $documento["f020_fecha_documento"] ?? null,
        $documento["f020_origen"] ?? null,
        $documento["f020_estado"] ?? null,
        $documento["f020_habilitado"] ?? null,
        $documento["f020_creacion"] ?? null
    ]);

    $resultado = $stmt->fetch(PDO::FETCH_ASSOC);
    $stmt->closeCursor();

    if (!$resultado || !isset($resultado["f020_id"])) {
        throw new Exception("No fue posible obtener el id del documento.");
    }

    $idDocumento = (int)$resultado["f020_id"];
    $procesados = 0;

    foreach ($detalles as $detalle) {
        $stmtDetalle = $conn->prepare("CALL sp_new_t021_documentos_detalle(?, ?, ?, ?, ?, ?, ?, ?, ?, ?)");
        $stmtDetalle->execute([
            $idDocumento,
            $detalle["f021_id_barra"] ?? null,
            $detalle["f021_id_ubicacion"] ?? null,
            $detalle["f021_id_zona"] ?? null,
            $detalle["f021_cantidad"] ?? null,
            $detalle["f021_cantidad_epc_generada"] ?? 0,
            $detalle["f021_cantidad_impresa"] ?? 0,
            $detalle["f021_estado"] ?? "PENDIENTE",
            $detalle["f021_habilitado"] ?? 1,
            $detalle["f021_creacion"] ?? null
        ]);
        $stmtDetalle->closeCursor();
        $procesados++;
    }

    return [
        "f020_id" => $idDocumento,
        "detalles_procesados" => $procesados
    ];
}

switch ($method) {

    case "GET":
        try {
            if (isset($_GET['id'])) {
                $stmt = $conn->prepare("CALL sp_find_t020_documentos(?)");
                $stmt->execute([$_GET['id']]);
                $result = $stmt->fetch(PDO::FETCH_ASSOC);
                $stmt->closeCursor();
                echo json_encode($result);
            } else {
                $stmt = $conn->query("CALL sp_list_t020_documentos()");
                $result = $stmt->fetchAll(PDO::FETCH_ASSOC);
                $stmt->closeCursor();
                echo json_encode($result);
            }
        } catch (Exception $e) {
            http_response_code(500);
            echo json_encode(["mensaje" => $e->getMessage()]);
        }
        break;

    case "POST":
        try {
            $data = json_decode(file_get_contents("php://input"), true);

            if ($data === null) {
                throw new Exception("JSON invalido o vacio.");
            }

            $documentos = [];

            if (isset($data["documentos"]) && is_array($data["documentos"])) {
                $documentos = $data["documentos"];
            } else {
                // Compatibilidad con el formato anterior: cabecera plana sin detalles.
                $documentos[] = [
                    "documento" => $data,
                    "detalles" => []
                ];
            }

            if (count($documentos) === 0) {
                throw new Exception("No se recibieron documentos para procesar.");
            }

            $conn->beginTransaction();
            $resultado = [];
            $totalDetalles = 0;

            foreach ($documentos as $documentoCarga) {
                $procesado = ejecutarDocumento($conn, $documentoCarga);
                $resultado[] = $procesado;
                $totalDetalles += $procesado["detalles_procesados"];
            }

            $conn->commit();

            echo json_encode([
                "mensaje" => "Procesado",
                "documentos_procesados" => count($resultado),
                "detalles_procesados" => $totalDetalles,
                "documentos" => $resultado
            ]);
        } catch (Exception $e) {
            if ($conn->inTransaction()) {
                $conn->rollBack();
            }

            http_response_code(500);
            echo json_encode(["mensaje" => $e->getMessage()]);
        }
        break;

    case "PUT":
        try {
            $data = json_decode(file_get_contents("php://input"), true);
            $stmt = $conn->prepare("CALL sp_update_t020_documentos(?, ?, ?, ?, ?, ?, ?, ?)");
            $stmt->execute([
                $data["f020_id"] ?? null,
                $data["f020_tipo_documento"] ?? null,
                $data["f020_numero_documento"] ?? null,
                $data["f020_fecha_documento"] ?? null,
                $data["f020_origen"] ?? null,
                $data["f020_estado"] ?? null,
                $data["f020_habilitado"] ?? null,
                $data["f020_actualizacion"] ?? null
            ]);
            $stmt->closeCursor();
            echo json_encode(["mensaje" => "actualizado"]);
        } catch (Exception $e) {
            http_response_code(500);
            echo json_encode(["mensaje" => $e->getMessage()]);
        }
        break;

    case "DELETE":
        http_response_code(405);
        echo json_encode(["mensaje" => "Metodo DELETE no implementado"]);
        break;

    default:
        http_response_code(405);
        echo json_encode(["mensaje" => "Metodo no permitido"]);
        break;
}
?>