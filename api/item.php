<?php
error_reporting(E_ALL);
ini_set('display_errors', 1);
#header("Content-Type: application/json; charset=utf-8");
require_once "php/conexion.php";

$method = $_SERVER["REQUEST_METHOD"];

switch ($method) {

    case "GET":
        if (isset($_GET['id'])) {
            $stmt = $conn->prepare("CALL sp_find_t001_item(?)");
            $stmt->execute([$_GET['id']]);
			
            $result = $stmt->fetch(PDO::FETCH_ASSOC);
			$stmt->closeCursor();
			echo json_encode($result);
        } else {
            $stmt = $conn->query("CALL sp_list_t001_item()");
            $result = $stmt->fetchAll(PDO::FETCH_ASSOC);
			$stmt->closeCursor();
			echo json_encode($result);
        }
        break;

    case "POST":
	try {
        $data = json_decode(file_get_contents("php://input"), true);	

		$items = $data["items"];		
        $conn->beginTransaction();
		$values = [];
		$params = [];
		
		foreach ($items as $item) {

        $values[] = "(?,?,?,?,?)";

		//$params[] = $item["f001_id"];
        $params[] = $item["f001_codigo_item"];
        $params[] = $item["f001_descripcion"];
		$params[] = $item["f001_habilitado"];
		$params[] = $item["f001_creacion"];
		$params[] = $item["f001_actualizacion"];
        
		}
		
		$sql = "
        INSERT INTO t001_items
        (
            f001_codigo_item
            ,f001_descripcion
			,f001_habilitado
			,f001_creacion
			,f001_actualizacion
        )
        VALUES " . implode(",", $values);
		
		$stmt = $conn->prepare($sql);
		
		$stmt->execute($params);
		
		$conn->commit();

		echo json_encode([
        //"ok" => true,
        //"procesados" => count($items)
		"mensaje" => "Procesado: $count($items)"
		]);
		/*
		$stmt = $conn->prepare("CALL sp_new_t001_item(?, ?, ?, ?)");
        $stmt->execute([
		$data["f001_codigo_item"]?? null, 
		$data["f001_descripcion"]?? null, 
		$data["f001_habilitado"]?? null, 
		$data["f001_creacion"]?? null
		]);
        $stmt->closeCursor();
		
		echo json_encode(["status" => "creado"]);
		*/
		} catch (PDOException $e) {
        http_response_code(500);
        echo json_encode(["mensaje" => $e->getMessage()]);
		}
		
        break;

    case "PUT":
        $data = json_decode(file_get_contents("php://input"), true);
        $stmt = $conn->prepare("CALL sp_update_t001_item(?,?,?,?,?)");
        $stmt->execute([
		$data["f001_id"]?? null, 
		$data["f001_codigo_item"]?? null, 
		$data["f001_descripcion"]?? null, 
		$data["f001_habilitado"]?? null, 
		$data["f001_actualizacion"]?? null
		]);
        
		
		$stmt->closeCursor();
		echo json_encode(["mensaje" => "actualizado"]);
        break;

    case "DELETE":
        $stmt = $conn->prepare("-");
        $stmt->execute([$_GET["-"]]);
        $stmt->closeCursor();
		echo json_encode(["mensaje" => "eliminado"]);
        break;

    default:
        http_response_code(405);
}


?>