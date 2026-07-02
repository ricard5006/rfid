<?php
error_reporting(E_ALL);
ini_set('display_errors', 1);
#header("Content-Type: application/json; charset=utf-8");
require_once "php/conexion.php";

$method = $_SERVER["REQUEST_METHOD"];

switch ($method) {

    case "GET":
        if (isset($_GET['id'])) {
            $stmt = $conn->prepare("CALL sp_find_t002_usuario(?)");
            $stmt->execute([$_GET['id']]);
			
            $result = $stmt->fetch(PDO::FETCH_ASSOC);
			$stmt->closeCursor();
			echo json_encode($result);
        } else {
            $stmt = $conn->query("CALL sp_list_t002_usuarios()");
            $result = $stmt->fetchAll(PDO::FETCH_ASSOC);
			$stmt->closeCursor();
			echo json_encode($result);
        }
        break;

    case "POST":
	try {
        $data = json_decode(file_get_contents("php://input"), true);	
		
		
        $stmt = $conn->prepare("CALL sp_new_t002_usuario(?, ?, ?, ?)");
        $stmt->execute([		
		$data["f002_usuario"]?? null, 		
		$data["f002_contrasena"]?? null, 		
		$data["f002_habilitado"]?? null, 		
		$data["f002_creacion"]?? null
		]);
        $stmt->closeCursor();
		echo json_encode(["status" => "creado"]);
		} catch (PDOException $e) {
        http_response_code(500);
        echo json_encode(["error" => $e->getMessage()]);
		}
        break;

    case "PUT":
        $data = json_decode(file_get_contents("php://input"), true);
        $stmt = $conn->prepare("CALL sp_update_t002_usuario(?, ?, ?, ?, ?)");
        $stmt->execute([
		$data["f002_id"]?? null, 
		$data["f002_usuario"]?? null, 
		$data["f002_contrasena"]?? null, 
		$data["f002_habilitado"]?? null,
		$data["f002_actualizacion"]?? null
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