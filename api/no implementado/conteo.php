<?php
error_reporting(E_ALL);
ini_set('display_errors', 1);
#header("Content-Type: application/json; charset=utf-8");
require_once "php/conexion.php";

$method = $_SERVER["REQUEST_METHOD"];

switch ($method) {

    case "GET":
        if (isset($_GET['id'])) {
            $stmt = $conn->prepare("CALL sp_find_t007_conteo(?)");
            $stmt->execute([$_GET['id']]);
			
            $result = $stmt->fetch(PDO::FETCH_ASSOC);
			$stmt->closeCursor();
			echo json_encode($result);
        } else {
            $stmt = $conn->query("CALL sp_list_t007_conteo()");
            $result = $stmt->fetchAll(PDO::FETCH_ASSOC);
			$stmt->closeCursor();
			echo json_encode($result);
        }
        break;

    case "POST":
	try {
        $data = json_decode(file_get_contents("php://input"), true);			
        $stmt = $conn->prepare("CALL sp_new_t006(?, ?, ?, ?, ?, ?, ?)");
        $stmt->execute([
		$data["f001_idUsuario"]?? null, 
		$data["f001_nombre"]?? null, 
		$data["f001_email"]?? null, 
		$data["f001_pass"]?? null, 
		$data["f001_perfil"]?? null, 
		$data["f001_habilitado"]?? null, 		
		$data["f001_fecha_creacion"]?? null
		]);
        $stmt->closeCursor();
		echo json_encode(["status" => "Inv. creado"]);
		} catch (PDOException $e) {
        http_response_code(500);
        echo json_encode(["error" => $e->getMessage()]);
		}
        break;

    case "PUT":
        $data = json_decode(file_get_contents("php://input"), true);
        $stmt = $conn->prepare("UPDATE t006_usuarios SET f001_idusuario = ?, f001_nombre = ?, f001_email = ?, f001_pass = ?,f001_fecha_actualizacion = ?   WHERE id = ?");
        $stmt->execute([$data["f001_idusuario"], $data["f001_nombre"], $data["f001_email"], $data["f001_pass"], $data["f001_fecha_actualizacion"], $_GET["id"]]);
        $stmt->closeCursor();
		echo json_encode(["status" => "Cliente actualizado"]);
        break;

    case "DELETE":
        $stmt = $conn->prepare("DELETE FROM t001_usuarios WHERE f001_idusuario = ?");
        $stmt->execute([$_GET["f001_idusuario"]]);
        $stmt->closeCursor();
		echo json_encode(["status" => "Cliente eliminado"]);
        break;

    default:
        http_response_code(405);
}


?>