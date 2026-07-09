-- =====================================================
-- Migracion: columna f003_id_documento_detalle en t003_epc
-- =====================================================
ALTER TABLE `t003_epc`
  ADD COLUMN IF NOT EXISTS `f003_id_documento_detalle` int(11) DEFAULT NULL AFTER `f003_id_barra`;

-- =====================================================
-- SP: insertar EPC individual
-- =====================================================
DELIMITER //
CREATE PROCEDURE `sp_new_t003_epc`(
  IN `p_f003_id_barra` INT,
  IN `p_f003_id_documento_detalle` INT,
  IN `p_f003_epc` VARCHAR(50),
  IN `p_f003_impreso` INT,
  IN `p_f003_habilitado` INT,
  IN `p_f003_creacion` VARCHAR(50)
)
BEGIN
INSERT INTO t003_epc (
  f003_id_barra,
  f003_id_documento_detalle,
  f003_epc,
  f003_impreso,
  f003_habilitado,
  f003_creacion
) VALUES (
  p_f003_id_barra,
  p_f003_id_documento_detalle,
  p_f003_epc,
  p_f003_impreso,
  p_f003_habilitado,
  p_f003_creacion
);
END//

-- =====================================================
-- SP: listar EPCs por detalle de documento
-- =====================================================
CREATE PROCEDURE `sp_list_t003_epc_by_detalle`(
  IN `p_f021_id` INT
)
BEGIN
SELECT * FROM t003_epc WHERE f003_id_documento_detalle = p_f021_id;
END//

-- =====================================================
-- SP: actualizar estado de impresion de EPC
-- =====================================================
CREATE PROCEDURE `sp_update_t003_epc_impreso`(
  IN `p_f003_id` INT,
  IN `p_f003_impreso` INT,
  IN `p_f003_actualizacion` VARCHAR(50)
)
BEGIN
UPDATE t003_epc SET
  f003_impreso = p_f003_impreso,
  f003_actualizacion = p_f003_actualizacion
WHERE f003_id = p_f003_id;
END//

-- =====================================================
-- SP: obtener ultimo ID de EPC (para generacion secuencial)
-- =====================================================
CREATE PROCEDURE `sp_ultimo_id_t003_epc`()
BEGIN
SELECT * FROM t003_epc ORDER BY f003_id DESC LIMIT 1;
END//

-- =====================================================
-- SP: actualizar cantidad EPC generada en detalle documento
-- =====================================================
CREATE PROCEDURE `sp_update_t021_cantidad_epc_generada`(
  IN `p_f021_id` INT,
  IN `p_cantidad` INT,
  IN `p_actualizacion` VARCHAR(50)
)
BEGIN
UPDATE t021_documentos_detalle SET
  f021_cantidad_epc_generada = f021_cantidad_epc_generada + p_cantidad,
  f021_actualizacion = p_actualizacion
WHERE f021_id = p_f021_id;
END//

-- =====================================================
-- SP: listar EPCs pendientes de impresion por documento
-- =====================================================
CREATE PROCEDURE `sp_list_t003_epc_pendientes_by_documento`(
  IN `p_f020_id` INT
)
BEGIN
SELECT e.* FROM t003_epc e
INNER JOIN t021_documentos_detalle dd ON dd.f021_id = e.f003_id_documento_detalle
WHERE dd.f021_id_documento = p_f020_id AND e.f003_impreso = 0
ORDER BY e.f003_id;
END//

-- =====================================================
-- SP: actualizar cantidad impresa en detalle documento
-- =====================================================
CREATE PROCEDURE `sp_update_t021_cantidad_impresa`(
  IN `p_f021_id` INT,
  IN `p_cantidad` INT,
  IN `p_actualizacion` VARCHAR(50)
)
BEGIN
UPDATE t021_documentos_detalle SET
  f021_cantidad_impresa = f021_cantidad_impresa + p_cantidad,
  f021_actualizacion = p_actualizacion
WHERE f021_id = p_f021_id;
END//
DELIMITER ;

-- =====================================================
-- Tabla t012_formatos
-- =====================================================
CREATE TABLE IF NOT EXISTS `t012_formatos` (
  `f012_id` int(11) NOT NULL AUTO_INCREMENT,
  `f012_descripcion` varchar(100) DEFAULT NULL,
  `f012_formato` text DEFAULT NULL,
  `f012_habilitado` int(11) DEFAULT NULL,
  `f012_creacion` varchar(50) DEFAULT NULL,
  `f012_actualizacion` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`f012_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

DELIMITER //
CREATE PROCEDURE `sp_list_t012_formatos`()
BEGIN
SELECT * FROM t012_formatos;
END//

CREATE PROCEDURE `sp_find_t012_formatos`(
  IN `p_f012_id` INT
)
BEGIN
SELECT * FROM t012_formatos WHERE f012_id = p_f012_id;
END//

CREATE PROCEDURE `sp_new_t012_formatos`(
  IN `p_f012_descripcion` VARCHAR(100),
  IN `p_f012_formato` TEXT,
  IN `p_f012_habilitado` INT,
  IN `p_f012_creacion` VARCHAR(50)
)
BEGIN
INSERT INTO t012_formatos (
  f012_descripcion,
  f012_formato,
  f012_habilitado,
  f012_creacion
) VALUES (
  p_f012_descripcion,
  p_f012_formato,
  p_f012_habilitado,
  p_f012_creacion
);
END//

CREATE PROCEDURE `sp_update_t012_formatos`(
  IN `p_f012_id` INT,
  IN `p_f012_descripcion` VARCHAR(100),
  IN `p_f012_formato` TEXT,
  IN `p_f012_habilitado` INT,
  IN `p_f012_actualizacion` VARCHAR(50)
)
BEGIN
UPDATE t012_formatos SET
  f012_descripcion = p_f012_descripcion,
  f012_formato = p_f012_formato,
  f012_habilitado = p_f012_habilitado,
  f012_actualizacion = p_f012_actualizacion
WHERE f012_id = p_f012_id;
END//
DELIMITER ;
