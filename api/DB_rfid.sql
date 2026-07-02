-- --------------------------------------------------------
-- Host:                         localhost
-- Versión del servidor:         10.2.15-MariaDB - mariadb.org binary distribution
-- SO del servidor:              Win32
-- HeidiSQL Versión:             12.11.0.7065
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Volcando estructura de base de datos para invrfid001
CREATE DATABASE IF NOT EXISTS `invrfid001` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `invrfid001`;

-- Volcando estructura para procedimiento invrfid001.sp_find_t0011_barras
DELIMITER //
CREATE PROCEDURE `sp_find_t0011_barras`(
	IN `p_f0011_barra` VARCHAR(50)
)
BEGIN
SELECT * FROM t0011_barras WHERE f0011_barra=p_f0011_barra;
END//
DELIMITER ;

-- Volcando estructura para procedimiento invrfid001.sp_find_t001_item
DELIMITER //
CREATE PROCEDURE `sp_find_t001_item`(
	IN `p_f001_codigo_item` VARCHAR(50)
)
BEGIN
SELECT * FROM t001_items WHERE f001_codigo_item=p_f001_codigo_item;
END//
DELIMITER ;

-- Volcando estructura para procedimiento invrfid001.sp_find_t002_usuario
DELIMITER //
CREATE PROCEDURE `sp_find_t002_usuario`(
	IN `p_f002_id` VARCHAR(50)
)
BEGIN
SELECT * FROM t002_usuarios WHERE f002_id=p_f002_id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento invrfid001.sp_find_t003_epc
DELIMITER //
CREATE PROCEDURE `sp_find_t003_epc`(
	IN `p_f003_epc` VARCHAR(50)
)
BEGIN
SELECT * FROM t003_epc WHERE f003_epc=p_f003_epc;
END//
DELIMITER ;

-- Volcando estructura para procedimiento invrfid001.sp_find_t004_ubicaciones
DELIMITER //
CREATE PROCEDURE `sp_find_t004_ubicaciones`(
	IN `p_f004_codigo_ubicacion` VARCHAR(50)
)
BEGIN
SELECT * FROM t004_ubicaciones WHERE f004_codigo_ubicacion= p_f004_codigo_ubicacion;
END//
DELIMITER ;

-- Volcando estructura para procedimiento invrfid001.sp_find_t005_zona
DELIMITER //
CREATE PROCEDURE `sp_find_t005_zona`(
	IN `p_f005_codigo_zona` VARCHAR(50)
)
BEGIN
SELECT * FROM t005_zonas WHERE f005_codigo_zona= p_f005_codigo_zona;
END//
DELIMITER ;

-- Volcando estructura para procedimiento invrfid001.sp_find_t006_inventario
DELIMITER //
CREATE PROCEDURE `sp_find_t006_inventario`(
	IN `p_f006_id` INT
)
BEGIN
SELECT * FROM t006_inventarios WHERE f006_id=p_f006_id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento invrfid001.sp_find_t007_conteo
DELIMITER //
CREATE PROCEDURE `sp_find_t007_conteo`(
	IN `p_f007_id` INT
)
BEGIN
SELECT * FROM t007_conteo WHERE f007_id= p_f007_id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento invrfid001.sp_list_t0011_barras
DELIMITER //
CREATE PROCEDURE `sp_list_t0011_barras`()
BEGIN
SELECT * FROM t0011_barras;
END//
DELIMITER ;

-- Volcando estructura para procedimiento invrfid001.sp_list_t001_item
DELIMITER //
CREATE PROCEDURE `sp_list_t001_item`()
BEGIN
SELECT * FROM t001_items;
END//
DELIMITER ;

-- Volcando estructura para procedimiento invrfid001.sp_list_t002_usuarios
DELIMITER //
CREATE PROCEDURE `sp_list_t002_usuarios`()
BEGIN
SELECT * FROM t002_usuarios;
END//
DELIMITER ;

-- Volcando estructura para procedimiento invrfid001.sp_list_t003_epc
DELIMITER //
CREATE PROCEDURE `sp_list_t003_epc`()
BEGIN
SELECT * FROM t003_epc;
END//
DELIMITER ;

-- Volcando estructura para procedimiento invrfid001.sp_list_t004_ubicaciones
DELIMITER //
CREATE PROCEDURE `sp_list_t004_ubicaciones`()
BEGIN
SELECT * FROM t004_ubicaciones;
END//
DELIMITER ;

-- Volcando estructura para procedimiento invrfid001.sp_list_t005_zona
DELIMITER //
CREATE PROCEDURE `sp_list_t005_zona`()
BEGIN
SELECT * FROM t005_zonas;
END//
DELIMITER ;

-- Volcando estructura para procedimiento invrfid001.sp_list_t006_inventarios
DELIMITER //
CREATE PROCEDURE `sp_list_t006_inventarios`()
BEGIN
SELECT * FROM t006_inventarios;
END//
DELIMITER ;

-- Volcando estructura para procedimiento invrfid001.sp_list_t007_conteo
DELIMITER //
CREATE PROCEDURE `sp_list_t007_conteo`()
BEGIN
SELECT * FROM t007_conteo;
END//
DELIMITER ;

-- Volcando estructura para procedimiento invrfid001.sp_new_t002_usuario
DELIMITER //
CREATE PROCEDURE `sp_new_t002_usuario`(
	IN `p_nombre` VARCHAR(50),
	IN `p_contrasena` VARCHAR(50),
	IN `p_habilitado` INT,
	IN `p_creacion` VARCHAR(50)
)
BEGIN
insert into t002_usuarios 
(
f002_nombre,

f002_contrasena,

f002_habilitado,

f002_creacion
)values(

p_nombre,

MD5(p_contrasena),

p_habilitado,

p_creacion);
END//
DELIMITER ;

-- Volcando estructura para tabla invrfid001.t000_configuracion
CREATE TABLE IF NOT EXISTS `t000_configuracion` (
  `f000_id` int(11) NOT NULL AUTO_INCREMENT,
  KEY `f000_idconfiguracion` (`f000_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Volcando datos para la tabla invrfid001.t000_configuracion: ~0 rows (aproximadamente)
DELETE FROM `t000_configuracion`;

-- Volcando estructura para tabla invrfid001.t0011_barras
CREATE TABLE IF NOT EXISTS `t0011_barras` (
  `f0011_id` int(11) NOT NULL AUTO_INCREMENT,
  `f0011_id_item` int(11) DEFAULT NULL,
  `f0011_barra` varchar(50) DEFAULT NULL,
  `f0011_atributo_1` varchar(50) DEFAULT NULL,
  `f0011_atributo_2` varchar(50) DEFAULT NULL,
  `f0011_atributo_3` varchar(50) DEFAULT NULL,
  `f0011_atributo_4` varchar(50) DEFAULT NULL,
  `f0011_atributo_5` varchar(50) DEFAULT NULL,
  `f0011_atributo_6` varchar(50) DEFAULT NULL,
  `f0011_cantidad` int(11) DEFAULT NULL,
  `f0011_habilitado` int(11) DEFAULT NULL,
  `f0011_creacion` varchar(50) DEFAULT NULL,
  `f0011_actualizacion` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`f0011_id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- Volcando datos para la tabla invrfid001.t0011_barras: ~3 rows (aproximadamente)
DELETE FROM `t0011_barras`;
INSERT INTO `t0011_barras` (`f0011_id`, `f0011_id_item`, `f0011_barra`, `f0011_atributo_1`, `f0011_atributo_2`, `f0011_atributo_3`, `f0011_atributo_4`, `f0011_atributo_5`, `f0011_atributo_6`, `f0011_cantidad`, `f0011_habilitado`, `f0011_creacion`, `f0011_actualizacion`) VALUES
	(1, 1, '7701547891436', 'BLANCO', 'XL', NULL, NULL, NULL, NULL, 5, 1, '2026-02-24 12:00:00', '2026-02-24 12:00:00'),
	(2, 1, '7701547891528', 'BLANCO', 'L', NULL, NULL, NULL, NULL, 3, 1, '2026-02-24 12:00:00', '2026-02-24 12:00:00'),
	(3, 2, '7701547891344', 'AZUL', 'L', NULL, NULL, NULL, NULL, 3, 1, '2026-02-26 12:00:00', '2026-02-26 12:00:00');

-- Volcando estructura para tabla invrfid001.t001_items
CREATE TABLE IF NOT EXISTS `t001_items` (
  `f001_id` int(11) NOT NULL AUTO_INCREMENT,
  `f001_codigo_item` varchar(50) DEFAULT NULL,
  `f001_descripcion` varchar(50) DEFAULT NULL,
  `f001_habilitado` int(11) DEFAULT NULL,
  `f001_creacion` varchar(50) DEFAULT NULL,
  `f001_actualizacion` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`f001_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- Volcando datos para la tabla invrfid001.t001_items: ~2 rows (aproximadamente)
DELETE FROM `t001_items`;
INSERT INTO `t001_items` (`f001_id`, `f001_codigo_item`, `f001_descripcion`, `f001_habilitado`, `f001_creacion`, `f001_actualizacion`) VALUES
	(1, '1001', 'CAMISA POLO', 1, '2026-02-24 12:00:00', '2026-02-24 12:00:00'),
	(2, '2001', 'PANTALONETA PLAYERA', 1, '2026-02-26 12:00:00', '2026-02-26 12:00:00');

-- Volcando estructura para tabla invrfid001.t002_usuarios
CREATE TABLE IF NOT EXISTS `t002_usuarios` (
  `f002_id` int(11) NOT NULL AUTO_INCREMENT,
  `f002_usuario` varchar(50) DEFAULT NULL,
  `f002_contrasena` varchar(50) DEFAULT NULL,
  `f002_habilitado` int(1) DEFAULT NULL,
  `f002_creacion` varchar(50) DEFAULT NULL,
  `f002_actualizacion` varchar(50) DEFAULT NULL,
  KEY `f001_idusuario` (`f002_id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- Volcando datos para la tabla invrfid001.t002_usuarios: ~2 rows (aproximadamente)
DELETE FROM `t002_usuarios`;
INSERT INTO `t002_usuarios` (`f002_id`, `f002_usuario`, `f002_contrasena`, `f002_habilitado`, `f002_creacion`, `f002_actualizacion`) VALUES
	(1, 'Ricardo', '12345', 1, '2026-02-24 12:00:00', '2026-02-24 12:00:00'),
	(2, 'john', '123456', 1, '2026-02-24 12:00:00', '2026-02-24 12:00:00');

-- Volcando estructura para tabla invrfid001.t003_epc
CREATE TABLE IF NOT EXISTS `t003_epc` (
  `f003_id` int(11) NOT NULL AUTO_INCREMENT,
  `f003_id_barra` int(11) DEFAULT NULL,
  `f003_epc` varchar(50) DEFAULT NULL,
  `f003_impreso` int(11) DEFAULT NULL,
  `f003_habilitado` int(11) DEFAULT NULL,
  `f003_creacion` varchar(50) DEFAULT NULL,
  `f003_actualizacion` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`f003_id`),
  UNIQUE KEY `f003_epc` (`f003_epc`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=latin1;

-- Volcando datos para la tabla invrfid001.t003_epc: ~11 rows (aproximadamente)
DELETE FROM `t003_epc`;
INSERT INTO `t003_epc` (`f003_id`, `f003_id_barra`, `f003_epc`, `f003_impreso`, `f003_habilitado`, `f003_creacion`, `f003_actualizacion`) VALUES
	(1, 1, '30342F01A84D10974876E801', 1, 1, '2026-02-24 12:00:00', '2026-02-24 12:00:00'),
	(5, 1, '30342F01A84D10974876E802', 1, 1, '2026-02-24 12:00:00', '2026-02-24 12:00:00'),
	(6, 1, '30342F01A84D10974876E803', 1, 1, '2026-02-24 12:00:00', '2026-02-24 12:00:00'),
	(7, 1, '30342F01A84D10974876E804', 1, 1, '2026-02-24 12:00:00', '2026-02-24 12:00:00'),
	(8, 1, '30342F01A84D10974876E805', 1, 1, '2026-02-24 12:00:00', '2026-02-24 12:00:00'),
	(11, 3, '30342F01A84D10574876E801', 1, 1, '2026-02-24 12:00:00', '2026-02-24 12:00:00'),
	(12, 3, '30342F01A84D10574876E802', 1, 1, '2026-02-24 12:00:00', '2026-02-24 12:00:00'),
	(13, 3, '30342F01A84D10574876E803', 1, 1, '2026-02-24 12:00:00', '2026-02-24 12:00:00'),
	(14, 2, '30342F01A84D10D74876E801', 1, 1, '2026-02-24 12:00:00', '2026-02-24 12:00:00'),
	(15, 2, '30342F01A84D10D74876E802', 1, 1, '2026-02-24 12:00:00', '2026-02-24 12:00:00'),
	(16, 2, '30342F01A84D10D74876E803', 1, 1, '2026-02-24 12:00:00', '2026-02-24 12:00:00');

-- Volcando estructura para tabla invrfid001.t004_ubicaciones
CREATE TABLE IF NOT EXISTS `t004_ubicaciones` (
  `f004_id` int(11) NOT NULL AUTO_INCREMENT,
  `f004_codigo_ubicacion` varchar(50) DEFAULT NULL,
  `f004_descripcion` varchar(50) DEFAULT NULL,
  `f004_ciudad` varchar(50) DEFAULT NULL,
  `f004_direccion` varchar(50) DEFAULT NULL,
  `f004_habilitado` int(11) DEFAULT NULL,
  `f004_creacion` varchar(50) DEFAULT NULL,
  `f004_actualizacion` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`f004_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- Volcando datos para la tabla invrfid001.t004_ubicaciones: ~3 rows (aproximadamente)
DELETE FROM `t004_ubicaciones`;
INSERT INTO `t004_ubicaciones` (`f004_id`, `f004_codigo_ubicacion`, `f004_descripcion`, `f004_ciudad`, `f004_direccion`, `f004_habilitado`, `f004_creacion`, `f004_actualizacion`) VALUES
	(1, '001', 'ETIMARCAS SAS', 'CALI', 'CLLE 38AN 4N 183', 1, '2026-02-24 12:00:00', '2026-02-24 12:00:00'),
	(2, '002', 'ETIMARCAS GAV', 'MEDELLIN', '-', 1, '2026-02-24 12:00:00', '2026-02-24 12:00:00'),
	(3, '003', 'ETIMARCAS SAS', 'CALI', 'B. MANZANARES', 1, '2026-02-24 12:00:00', '2026-02-24 12:00:00');

-- Volcando estructura para tabla invrfid001.t005_zonas
CREATE TABLE IF NOT EXISTS `t005_zonas` (
  `f005_id` int(11) NOT NULL AUTO_INCREMENT,
  `f005_id_ubicacion` int(11) DEFAULT NULL,
  `f005_codigo_zona` varchar(50) DEFAULT NULL,
  `f005_descripcion` varchar(50) DEFAULT NULL,
  `f005_habilitado` int(11) DEFAULT NULL,
  `f005_creacion` varchar(50) DEFAULT NULL,
  `f005_actualizacion` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`f005_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1 COMMENT='(bodega_tienda/piso_venta/etc)';

-- Volcando datos para la tabla invrfid001.t005_zonas: ~5 rows (aproximadamente)
DELETE FROM `t005_zonas`;
INSERT INTO `t005_zonas` (`f005_id`, `f005_id_ubicacion`, `f005_codigo_zona`, `f005_descripcion`, `f005_habilitado`, `f005_creacion`, `f005_actualizacion`) VALUES
	(1, 1, '02', 'BODEGA', 1, '2026-02-24 12:00:00', '2026-02-24 12:00:00'),
	(2, 1, '01', 'PTO VENTA', 1, '2026-02-24 12:00:00', '2026-02-24 12:00:00'),
	(3, 3, '02', 'BODEGA', 1, '2026-02-24 12:00:00', '2026-02-24 12:00:00'),
	(4, 2, '02', 'BODEGA', 1, '2026-02-24 12:00:00', '2026-02-24 12:00:00'),
	(5, 2, '01', 'PTO VENTA', 1, '2026-02-24 12:00:00', '2026-02-24 12:00:00');

-- Volcando estructura para tabla invrfid001.t006_inventarios
CREATE TABLE IF NOT EXISTS `t006_inventarios` (
  `f006_id` int(11) NOT NULL AUTO_INCREMENT,
  `f006_descripcion` varchar(100) DEFAULT NULL,
  `f006_id_usuario` int(11) DEFAULT NULL,
  `f006_id_item` int(11) DEFAULT NULL,
  `f006_ubicacion` int(11) DEFAULT NULL,
  `f006_zona` int(11) DEFAULT NULL,
  `f006_tipo_inv` varchar(100) DEFAULT NULL,
  `f006_estado_sesion` varchar(100) DEFAULT NULL,
  `f006_nota` varchar(100) DEFAULT NULL,
  `f006_creacion` varchar(100) DEFAULT NULL,
  `f006_actualizacion` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`f006_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- Volcando datos para la tabla invrfid001.t006_inventarios: ~1 rows (aproximadamente)
DELETE FROM `t006_inventarios`;
INSERT INTO `t006_inventarios` (`f006_id`, `f006_descripcion`, `f006_id_usuario`, `f006_id_item`, `f006_ubicacion`, `f006_zona`, `f006_tipo_inv`, `f006_estado_sesion`, `f006_nota`, `f006_creacion`, `f006_actualizacion`) VALUES
	(1, 'INVENTARIO DEL PTO DE VENTA', 1, 1, NULL, NULL, 'RFID', 'ABIERTO', 'PRUEBAS DE BD', '2026-02-24 12:00:00', '2026-02-24 12:00:00');

-- Volcando estructura para tabla invrfid001.t007_conteo
CREATE TABLE IF NOT EXISTS `t007_conteo` (
  `f007_id` int(11) NOT NULL AUTO_INCREMENT,
  `f007_id_inventario` int(11) DEFAULT NULL,
  `f007_EPC` varchar(50) DEFAULT NULL,
  `f007_codigo_barras` varchar(50) DEFAULT NULL,
  `f007_tipo_inv` varchar(50) DEFAULT NULL,
  `f007_cantidad` int(11) DEFAULT NULL,
  `f006_nota` varchar(50) DEFAULT NULL,
  `f007_creacion` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`f007_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Volcando datos para la tabla invrfid001.t007_conteo: ~0 rows (aproximadamente)
DELETE FROM `t007_conteo`;

-- Volcando estructura para tabla invrfid001.t008_item_zona
CREATE TABLE IF NOT EXISTS `t008_item_zona` (
  `f008_id` int(11) DEFAULT NULL,
  `f008_id_barras` int(11) NOT NULL DEFAULT 0,
  `f008_id_epc` int(11) NOT NULL DEFAULT 0,
  `f008_id_zona` int(11) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Volcando datos para la tabla invrfid001.t008_item_zona: ~5 rows (aproximadamente)
DELETE FROM `t008_item_zona`;
INSERT INTO `t008_item_zona` (`f008_id`, `f008_id_barras`, `f008_id_epc`, `f008_id_zona`) VALUES
	(2, 1, 8, 1),
	(2, 1, 1, 2),
	(2, 1, 5, 2),
	(2, 1, 6, 2),
	(2, 1, 7, 2),
	(3, 3, 11, 2),
	(3, 3, 12, 2),
	(3, 3, 13, 2),
	(4, 2, 14, 2),
	(4, 2, 15, 2),
	(4, 2, 16, 2);

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
