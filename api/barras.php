<?php
error_reporting(E_ALL);
ini_set('display_errors', 1);
#header("Content-Type: application/json; charset=utf-8");
require_once "php/conexion.php";

$method = $_SERVER["REQUEST_METHOD"];

switch ($method) {

    case "GET":
        if (isset($_GET['id'])) {
            $stmt = $conn->prepare("CALL sp_find_t0011_barras(?)");
            $stmt->execute([$_GET['id']]);
			
            $result = $stmt->fetch(PDO::FETCH_ASSOC);
			$stmt->closeCursor();
			echo json_encode($result);
        } else {
            $stmt = $conn->query("CALL sp_list_t0011_barras()");
            $result = $stmt->fetchAll(PDO::FETCH_ASSOC);
			$stmt->closeCursor();
			echo json_encode($result);
        }
        break;

    case "POST":
	try {
        $data = json_decode(file_get_contents("php://input"), true);	

		$items = $data["barras"];		
        $conn->beginTransaction();
		$values = [];
		$params = [];
		
		foreach ($items as $item) {

        $values[] = "(?,?,?,?,?,?,?,?,?,?)";

		$params[] = $item["f0011_id_item"];
        $params[] = $item["f0011_barra"];
        $params[] = $item["f0011_atributo_1"];
		$params[] = $item["f0011_atributo_2"];
		$params[] = $item["f0011_atributo_3"];
		$params[] = $item["f0011_atributo_4"];
		$params[] = $item["f0011_atributo_5"];
		$params[] = $item["f0011_atributo_6"];		
        $params[] = $item["f0011_habilitado"];
		$params[] = $item["f0011_creacion"];
		}
		
		$sql = "
        INSERT INTO t0011_barras
        (
            f0011_id_item
            ,f0011_barra
			,f0011_atributo_1
			,f0011_atributo_2
			,f0011_atributo_3
			,f0011_atributo_4
			,f0011_atributo_5
			,f0011_atributo_6			
			,f0011_habilitado			
			,f0011_creacion
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
        $stmt = $conn->prepare("CALL sp_update_t0011_barras(?,?,?,?,?,?,?,?,?)");
        $stmt->execute([
		$data["f001_id"]?? null, 
		$data["f0011_atributo_1"]?? null, 
		$data["f0011_atributo_2"]?? null,
		$data["f0011_atributo_3"]?? null,	
		$data["f0011_atributo_4"]?? null,
		$data["f0011_atributo_5"]?? null,
		$data["f0011_atributo_6"]?? null,
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