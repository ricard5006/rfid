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
	IN `p_f006_id_usuario` INT
)
BEGIN
SELECT * FROM t006_inventarios WHERE 
f006_id_usuario=p_f006_id_usuario;
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

-- Volcando estructura para procedimiento invrfid001.sp_find_t010_impresora
DELIMITER //
CREATE PROCEDURE `sp_find_t010_impresora`(
	IN `p_f010_id` INT
)
BEGIN
SELECT * FROM t010_impresora 
WHERE 
f010_id=p_f010_id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento invrfid001.sp_find_t020_documentos
DELIMITER //
CREATE PROCEDURE `sp_find_t020_documentos`(
	IN `p_f020_numero_documento` VARCHAR(50)
)
BEGIN
SELECT * FROM t020_documentos
WHERE f020_numero_documento=p_f020_numero_documento;
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

-- Volcando estructura para procedimiento invrfid001.sp_list_t010_impresora
DELIMITER //
CREATE PROCEDURE `sp_list_t010_impresora`()
BEGIN
SELECT * FROM t010_impresora;
END//
DELIMITER ;

-- Volcando estructura para procedimiento invrfid001.sp_list_t011_reader
DELIMITER //
CREATE PROCEDURE `sp_list_t011_reader`()
BEGIN
SELECT * FROM t011_reader;
END//
DELIMITER ;

-- Volcando estructura para procedimiento invrfid001.sp_list_t020_documentos
DELIMITER //
CREATE PROCEDURE `sp_list_t020_documentos`()
BEGIN
SELECT * FROM t020_documentos;
END//
DELIMITER ;

-- Volcando estructura para procedimiento invrfid001.sp_new_t001_item
DELIMITER //
CREATE PROCEDURE `sp_new_t001_item`(
	IN `p_f001_codigo_item` VARCHAR(50),
	IN `p_f001_descripcion` VARCHAR(50),
	IN `p_f001_habilitado` INT,
	IN `p_f001_creacion` VARCHAR(50)
)
BEGIN
INSERT INTO t001_items(
f001_codigo_item
,f001_descripcion
,f001_habilitado
,f001_creacion
)VALUES(
p_f001_codigo_item
,p_f001_descripcion
,p_f001_habilitado
,p_f001_creacion
);
END//
DELIMITER ;

-- Volcando estructura para procedimiento invrfid001.sp_new_t002_usuario
DELIMITER //
CREATE PROCEDURE `sp_new_t002_usuario`(
	IN `p_f002_usuario` VARCHAR(50),
	IN `p_f002_contrasena` VARCHAR(50),
	IN `p_f002_habilitado` INT,
	IN `p_f002_creacion` VARCHAR(50)
)
BEGIN
insert into t002_usuarios 
(
f002_usuario,

f002_contrasena,

f002_habilitado,

f002_creacion
)values(

p_f002_usuario,

MD5(p_f002_contrasena),

p_f002_habilitado,

p_f002_creacion);
END//
DELIMITER ;

-- Volcando estructura para procedimiento invrfid001.sp_new_t004_t005
DELIMITER //
CREATE PROCEDURE `sp_new_t004_t005`(
	IN `p_f004_codigo_ubicacion` VARCHAR(50),
	IN `p_f004_descripcion` VARCHAR(50),
	IN `p_f004_ciudad` VARCHAR(50),
	IN `p_f004_direccion` VARCHAR(50),
	IN `p_f005_codigo_zona` VARCHAR(50),
	IN `p_f005_descripcion` VARCHAR(50)
)
BEGIN

    DECLARE v_id_ubicacion INT;

    SELECT f004_id
    INTO v_id_ubicacion
    FROM t004_ubicaciones
    WHERE f004_codigo_ubicacion = p_f004_codigo_ubicacion
    LIMIT 1;

    IF v_id_ubicacion IS NULL THEN

        INSERT INTO t004_ubicaciones
        (
            f004_codigo_ubicacion,
            f004_descripcion,
            f004_ciudad,
            f004_direccion,
            f004_habilitado,
            f004_creacion
        )
        VALUES
        (
            p_f004_codigo_ubicacion,
            p_f004_descripcion,
            p_f004_ciudad,
            p_f004_direccion,
            1,
            NOW()
        );

        SET v_id_ubicacion = LAST_INSERT_ID();

    END IF;

    IF NOT EXISTS
    (
        SELECT 1
        FROM t005_zonas
        WHERE f005_id_ubicacion = v_id_ubicacion
        AND f005_codigo_zona = p_f005_codigo_zona
    )
    THEN

        INSERT INTO t005_zonas
        (
            f005_id_ubicacion,
            f005_codigo_zona,
            f005_descripcion,
            f005_habilitado,
            f005_creacion
        )
        VALUES
        (
            v_id_ubicacion,
            p_f005_codigo_zona,
            p_f005_descripcion,
            1,
            NOW()
        );

    END IF;

END//
DELIMITER ;

-- Volcando estructura para procedimiento invrfid001.sp_new_t004_ubicaciones
DELIMITER //
CREATE PROCEDURE `sp_new_t004_ubicaciones`(
	IN `p_f004_codigo_ubicacion` VARCHAR(50),
	IN `p_f004_descripcion` VARCHAR(50),
	IN `p_f004_ciudad` VARCHAR(50),
	IN `p_f004_direccion` VARCHAR(50),
	IN `p_f004_habilitado` INT,
	IN `p_f004_creacion` VARCHAR(50)
)
BEGIN
INSERT INTO t004_ubicaciones(
f004_codigo_ubicacion
,f004_descripcion
,f004_ciudad
,f004_direccion
,f004_habilitado
,f004_creacion
)VALUES(
p_f004_codigo_ubicacion
,p_f004_descripcion
,p_f004_ciudad
,p_f004_direccion
,p_f004_habilitado
,p_f004_creacion
)ON DUPLICATE KEY UPDATE
f004_descripcion = VALUES (f004_descripcion)
,f004_ciudad= VALUES (f004_ciudad)
,f004_direccion= VALUES (f004_direccion)
,f004_habilitado= VALUES (f004_habilitado)
,f004_actualizacion = NOW()
;
END//
DELIMITER ;

-- Volcando estructura para procedimiento invrfid001.sp_new_t005_zona
DELIMITER //
CREATE PROCEDURE `sp_new_t005_zona`(
	IN `p_f005_id_ubicacion` INT,
	IN `p_f005_codigo_zona` VARCHAR(50),
	IN `p_f005_descripcion` VARCHAR(50),
	IN `p_f005_habilitado` INT,
	IN `p_f005_creacion` VARCHAR(50)
)
BEGIN
INSERT INTO t005_zonas(
f005_id_ubicacion
,f005_codigo_zona
,f005_descripcion
,f005_habilitado
,f005_creacion
)VALUES(
p_f005_id_ubicacion
,p_f005_codigo_zona
,p_f005_descripcion
,p_f005_habilitado
,p_f005_creacion
);
END//
DELIMITER ;

-- Volcando estructura para procedimiento invrfid001.sp_new_t010_impresora
DELIMITER //
CREATE PROCEDURE `sp_new_t010_impresora`(
	IN `p_f010_impresora` VARCHAR(50),
	IN `p_f010_direccion` VARCHAR(50),
	IN `p_f010_habilitado` INT,
	IN `p_f010_creacion` VARCHAR(50)
)
BEGIN
INSERT INTO t010_impresora(
f010_impresora,
f010_direccion,
f010_habilitado,
f010_creacion
)VALUES(
p_f010_impresora,
p_f010_direccion,
p_f010_habilitado,
p_f010_creacion

);
END//
DELIMITER ;

-- Volcando estructura para procedimiento invrfid001.sp_new_t011_reader
DELIMITER //
CREATE PROCEDURE `sp_new_t011_reader`(
	IN `p_f011_reader` VARCHAR(50),
	IN `p_f011_direccion` VARCHAR(50),
	IN `p_f011_usuario` VARCHAR(50),
	IN `p_f011_contrasena` VARCHAR(50),
	IN `p_f011_habilitado` INT,
	IN `p_f011_creacion` VARCHAR(50)
)
BEGIN
INSERT INTO t011_reader(
f011_reader,
f011_direccion,
f011_usuario,
f011_contrasena,
f011_habilitado,
f011_creacion
)VALUES(
p_f011_reader,
p_f011_direccion,
p_f011_usuario,
p_f011_contrasena,
p_f011_habilitado,
p_f011_creacion
);
END//
DELIMITER ;

-- Volcando estructura para procedimiento invrfid001.sp_new_t020_documentos
DELIMITER //
CREATE PROCEDURE `sp_new_t020_documentos`(
	IN `p_f020_tipo_documento` VARCHAR(50),
	IN `p_f020_numero_documento` VARCHAR(50),
	IN `p_f020_fecha_documento` VARCHAR(50),
	IN `p_f020_origen` VARCHAR(50),
	IN `p_f020_estado` VARCHAR(50),
	IN `p_f020_habilitado` INT,
	IN `p_f020_creacion` VARCHAR(50)
)
BEGIN
INSERT INTO t020_documentos
(
f020_tipo_documento,
f020_numero_documento,
f020_fecha_documento,
f020_origen,
f020_estado,
f020_habilitado,
f020_creacion
)VALUES(
p_f020_tipo_documento,
p_f020_numero_documento,
p_f020_fecha_documento,
p_f020_origen,
p_f020_estado,
p_f020_habilitado,
p_f020_creacion
);
END//
DELIMITER ;

-- Volcando estructura para procedimiento invrfid001.sp_update_t002_usuario
DELIMITER //
CREATE PROCEDURE `sp_update_t002_usuario`(
	IN `p_f002_id` INT,
	IN `p_f002_usuario` VARCHAR(50),
	IN `p_f002_contrasena` VARCHAR(50),
	IN `p_f002_habilitado` INT,
	IN `p_f002_actualizacion` VARCHAR(50)
)
BEGIN
UPDATE t002_usuarios
SET
f002_usuario = p_f002_usuario,
f002_contrasena= MD5(p_f002_contrasena),
f002_habilitado = p_f002_habilitado,
f002_actualizacion = p_f002_actualizacion
WHERE f002_id= p_f002_id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento invrfid001.sp_update_t004_ubicaciones
DELIMITER //
CREATE PROCEDURE `sp_update_t004_ubicaciones`(
	IN `p_f004_id` INT,
	IN `p_f004_descripcion` VARCHAR(50),
	IN `p_f004_ciudad` VARCHAR(50),
	IN `p_f004_direccion` VARCHAR(50),
	IN `p_f004_habilitado` INT,
	IN `p_f004_actualizacion` VARCHAR(50)
)
BEGIN
UPDATE t004_ubicaciones
SET f004_descripcion=p_f004_descripcion
,f004_ciudad=p_f004_ciudad
,f004_direccion=p_f004_direccion
,f004_habilitado=p_f004_habilitado
,f004_actualizacion=p_f004_actualizacion
WHERE
f004_id=p_f004_id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento invrfid001.sp_update_t010_impresora
DELIMITER //
CREATE PROCEDURE `sp_update_t010_impresora`(
	IN `p_f010_id` INT,
	IN `p_f010_impresora` VARCHAR(50),
	IN `p_f010_direccion` VARCHAR(50),
	IN `p_f010_habilitado` INT,
	IN `p_f010_actualizacion` VARCHAR(50)
)
BEGIN
UPDATE t010_impresora
SET

f010_impresora=p_f010_impresora,
f010_direccion=p_f010_direccion,
f010_habilitado=p_f010_habilitado,
f010_actualizacion=p_f010_actualizacion
WHERE
f010_id=p_f010_id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento invrfid001.sp_update_t011_reader
DELIMITER //
CREATE PROCEDURE `sp_update_t011_reader`(
	IN `p_f011_id` INT,
	IN `p_f011_reader` VARCHAR(50),
	IN `p_f011_direccion` VARCHAR(50),
	IN `p_f011_usuario` VARCHAR(50),
	IN `p_f011_contrasena` VARCHAR(50),
	IN `p_f011_habilitado` INT,
	IN `p_f011_actualizacion` VARCHAR(50)
)
BEGIN
UPDATE t011_reader
SET
f011_reader=p_f011_reader,
f011_direccion=p_f011_direccion,
f011_usuario=p_f011_usuario,
f011_contrasena=p_f011_contrasena,
f011_habilitado=p_f011_habilitado,
f011_actualizacion=p_f011_actualizacion
WHERE f011_id=p_f011_id;
END//
DELIMITER ;

-- Volcando estructura para tabla invrfid001.t000_configuracion
CREATE TABLE IF NOT EXISTS `t000_configuracion` (
  `f000_id` int(11) NOT NULL AUTO_INCREMENT,
  KEY `f000_idconfiguracion` (`f000_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- La exportación de datos fue deseleccionada.

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
  `f0011_habilitado` int(11) DEFAULT NULL,
  `f0011_creacion` varchar(50) DEFAULT NULL,
  `f0011_actualizacion` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`f0011_id`) USING BTREE,
  UNIQUE KEY `f0011_barra` (`f0011_barra`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=latin1;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla invrfid001.t001_items
CREATE TABLE IF NOT EXISTS `t001_items` (
  `f001_id` int(11) NOT NULL AUTO_INCREMENT,
  `f001_codigo_item` varchar(50) DEFAULT NULL,
  `f001_descripcion` varchar(50) DEFAULT NULL,
  `f001_habilitado` int(11) DEFAULT NULL,
  `f001_creacion` varchar(50) DEFAULT NULL,
  `f001_actualizacion` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`f001_id`),
  UNIQUE KEY `f001_codigo_item` (`f001_codigo_item`)
) ENGINE=InnoDB AUTO_INCREMENT=34 DEFAULT CHARSET=latin1;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla invrfid001.t002_usuarios
CREATE TABLE IF NOT EXISTS `t002_usuarios` (
  `f002_id` int(11) NOT NULL AUTO_INCREMENT,
  `f002_usuario` varchar(50) DEFAULT NULL,
  `f002_contrasena` varchar(50) DEFAULT NULL,
  `f002_habilitado` int(1) NOT NULL,
  `f002_creacion` varchar(50) DEFAULT NULL,
  `f002_actualizacion` varchar(50) DEFAULT NULL,
  KEY `f001_idusuario` (`f002_id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=latin1;

-- La exportación de datos fue deseleccionada.

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

-- La exportación de datos fue deseleccionada.

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
  PRIMARY KEY (`f004_id`),
  UNIQUE KEY `f004_codigo_ubicacion` (`f004_codigo_ubicacion`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- La exportación de datos fue deseleccionada.

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
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1 COMMENT='(bodega_tienda/piso_venta/etc)';

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla invrfid001.t006_inventarios
CREATE TABLE IF NOT EXISTS `t006_inventarios` (
  `f006_id` int(11) NOT NULL AUTO_INCREMENT,
  `f006_descripcion` varchar(100) DEFAULT NULL,
  `f006_id_usuario` int(11) DEFAULT NULL,
  `f006_id_item` int(11) DEFAULT NULL,
  `f006_id_ubicacion` int(11) DEFAULT NULL,
  `f006_id_zona` int(11) DEFAULT NULL,
  `f006_tipo_inv` varchar(100) DEFAULT NULL,
  `f006_estado_sesion` varchar(100) DEFAULT NULL,
  `f006_nota` varchar(100) DEFAULT NULL,
  `f006_creacion` varchar(100) DEFAULT NULL,
  `f006_actualizacion` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`f006_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- La exportación de datos fue deseleccionada.

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

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla invrfid001.t010_impresora
CREATE TABLE IF NOT EXISTS `t010_impresora` (
  `f010_id` int(11) NOT NULL AUTO_INCREMENT,
  `f010_impresora` varchar(50) DEFAULT NULL,
  `f010_direccion` varchar(50) DEFAULT NULL,
  `f010_habilitado` int(11) DEFAULT NULL,
  `f010_creacion` varchar(50) DEFAULT NULL,
  `f010_actualizacion` varchar(50) DEFAULT NULL,
  KEY `f010_id` (`f010_id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla invrfid001.t011_reader
CREATE TABLE IF NOT EXISTS `t011_reader` (
  `f011_id` int(11) NOT NULL AUTO_INCREMENT,
  `f011_reader` varchar(50) DEFAULT NULL,
  `f011_direccion` varchar(50) DEFAULT NULL,
  `f011_usuario` varchar(50) DEFAULT NULL,
  `f011_contrasena` varchar(50) DEFAULT NULL,
  `f011_habilitado` int(11) DEFAULT NULL,
  `f011_creacion` varchar(50) DEFAULT NULL,
  `f011_actualizacion` varchar(50) DEFAULT NULL,
  KEY `f011_id` (`f011_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- La exportación de datos fue deseleccionada.

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
