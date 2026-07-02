<?php
error_reporting(E_ALL);
ini_set('display_errors', 1);
#header("Content-Type: application/json; charset=utf-8");


$method = $_SERVER["REQUEST_METHOD"];

switch ($method) {

    case "GET":
	
	
	$response = [
        "status" => "ok",
        "database" => "connected"
    ];
	
    echo json_encode($response);
		
		
    break;

    default:
        http_response_code(405);
}


?>