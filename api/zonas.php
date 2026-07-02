<?php
error_reporting(E_ALL);
ini_set('display_errors', 1);
#header("Content-Type: application/json; charset=utf-8");
require_once "php/conexion.php";

$method = $_SERVER["REQUEST_METHOD"];

switch ($method) {

    case "GET":
        if (isset($_GET['id'])) {
            $stmt = $conn->prepare("CALL sp_find_t005_zona(?)");
            $stmt->execute([$_GET['id']]);
			
            $result = $stmt->fetch(PDO::FETCH_ASSOC);
			$stmt->closeCursor();
			echo json_encode($result);
        } else {
            $stmt = $conn->query("CALL sp_list_t005_zona()");
            $result = $stmt->fetchAll(PDO::FETCH_ASSOC);
			$stmt->closeCursor();
			echo json_encode($result);
        }
        break;

    case "POST":
	try {
        $data = json_decode(file_get_contents("php://input"), true);	
		$stmt = $conn->prepare("CALL sp_new_t005_zona(?,?,?,?,?)");
		$items = $data["zonas"];		
        $conn->beginTransaction();
		
				
		foreach ($items as $item) {

        

		$stmt->execute([
		
		 $item["f005_id_ubicacion"]
         ,$item["f005_codigo_zona"]
		 ,$item["f005_descripcion"]
		 ,$item["f005_habilitado"] 
		 ,$item["f005_creacion"]
			
		
		]);
		
        while ($stmt->nextRowset()) {}
        
		}
		$conn->commit();
		
		
		$stmt->closeCursor();

		echo json_encode(["mensaje" => "Procesado ".count($items)]);
		
		} catch (PDOException $e) {
        http_response_code(500);
        echo json_encode(["mensaje" => $e->getMessage()]);
		}
		
        break;

    case "PUT":
        $data = json_decode(file_get_contents("php://input"), true);
        $stmt = $conn->prepare("CALL sp_update_t004_ubicaciones(?,?,?,?,?)");
        $stmt->execute([
		$data["f004_descripcion"]?? null, 
		$data["f004_ciudad"]?? null, 
		$data["f004_direccion"]?? null, 
		$data["f004_habilitado"]?? null, 
		$data["f004_actualizacion"]?? null
		]);
        
		
		$stmt->closeCursor();
		echo json_encode(["status" => "actualizado"]);
        break;

    case "DELETE":
        $stmt = $conn->prepare("-");
        $stmt->execute([$_GET["-"]]);
        $stmt->closeCursor();
		echo json_encode(["status" => "eliminado"]);
        break;

    default:
        http_response_code(405);
}


?>