-- Estructura y procedimientos para documentos de entrada RFID.
-- Ejecutar sobre la base de datos invrfid001.

CREATE TABLE IF NOT EXISTS t020_documentos (
    f020_id INT NOT NULL AUTO_INCREMENT,
    f020_tipo_documento VARCHAR(50) NOT NULL,
    f020_numero_documento VARCHAR(50) NOT NULL,
    f020_fecha_documento VARCHAR(50) NULL,
    f020_origen VARCHAR(50) NULL,
    f020_estado VARCHAR(50) NOT NULL DEFAULT 'PENDIENTE',
    f020_habilitado INT NOT NULL DEFAULT 1,
    f020_creacion VARCHAR(50) NULL,
    f020_actualizacion VARCHAR(50) NULL,
    PRIMARY KEY (f020_id),
    UNIQUE KEY uk_t020_documento (f020_tipo_documento, f020_numero_documento, f020_origen)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE IF NOT EXISTS t021_documentos_detalle (
    f021_id INT NOT NULL AUTO_INCREMENT,
    f021_id_documento INT NOT NULL,
    f021_id_barra INT NOT NULL,
    f021_id_ubicacion INT NOT NULL,
    f021_id_zona INT NOT NULL,
    f021_cantidad INT NOT NULL,
    f021_cantidad_epc_generada INT NOT NULL DEFAULT 0,
    f021_cantidad_impresa INT NOT NULL DEFAULT 0,
    f021_estado VARCHAR(50) NOT NULL DEFAULT 'PENDIENTE',
    f021_habilitado INT NOT NULL DEFAULT 1,
    f021_creacion VARCHAR(50) NULL,
    f021_actualizacion VARCHAR(50) NULL,
    PRIMARY KEY (f021_id),
    UNIQUE KEY uk_t021_documento_detalle (f021_id_documento, f021_id_barra, f021_id_ubicacion, f021_id_zona),
    KEY ix_t021_documento (f021_id_documento),
    KEY ix_t021_barra (f021_id_barra),
    KEY ix_t021_ubicacion (f021_id_ubicacion),
    KEY ix_t021_zona (f021_id_zona)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

DROP PROCEDURE IF EXISTS sp_find_t020_documentos;
DELIMITER $$
CREATE PROCEDURE sp_find_t020_documentos(
    IN p_f020_id INT
)
BEGIN
    SELECT
        d.*
    FROM t020_documentos d
    WHERE d.f020_id = p_f020_id;
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS sp_list_t020_documentos;
DELIMITER $$
CREATE PROCEDURE sp_list_t020_documentos()
BEGIN
    SELECT
        d.*
    FROM t020_documentos d
    ORDER BY d.f020_id DESC;
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS sp_new_t020_documentos;
DELIMITER $$
CREATE PROCEDURE sp_new_t020_documentos(
    IN p_f020_tipo_documento VARCHAR(50),
    IN p_f020_numero_documento VARCHAR(50),
    IN p_f020_fecha_documento VARCHAR(50),
    IN p_f020_origen VARCHAR(50),
    IN p_f020_estado VARCHAR(50),
    IN p_f020_habilitado INT,
    IN p_f020_creacion VARCHAR(50)
)
BEGIN
    INSERT INTO t020_documentos (
        f020_tipo_documento,
        f020_numero_documento,
        f020_fecha_documento,
        f020_origen,
        f020_estado,
        f020_habilitado,
        f020_creacion
    ) VALUES (
        p_f020_tipo_documento,
        p_f020_numero_documento,
        p_f020_fecha_documento,
        p_f020_origen,
        COALESCE(p_f020_estado, 'PENDIENTE'),
        COALESCE(p_f020_habilitado, 1),
        p_f020_creacion
    )
    ON DUPLICATE KEY UPDATE
        f020_fecha_documento = VALUES(f020_fecha_documento),
        f020_estado = VALUES(f020_estado),
        f020_habilitado = VALUES(f020_habilitado),
        f020_actualizacion = DATE_FORMAT(NOW(), '%Y-%m-%d %H:%i:%s');

    SELECT f020_id
    FROM t020_documentos
    WHERE f020_tipo_documento = p_f020_tipo_documento
      AND f020_numero_documento = p_f020_numero_documento
      AND IFNULL(f020_origen, '') = IFNULL(p_f020_origen, '')
    LIMIT 1;
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS sp_update_t020_documentos;
DELIMITER $$
CREATE PROCEDURE sp_update_t020_documentos(
    IN p_f020_id INT,
    IN p_f020_tipo_documento VARCHAR(50),
    IN p_f020_numero_documento VARCHAR(50),
    IN p_f020_fecha_documento VARCHAR(50),
    IN p_f020_origen VARCHAR(50),
    IN p_f020_estado VARCHAR(50),
    IN p_f020_habilitado INT,
    IN p_f020_actualizacion VARCHAR(50)
)
BEGIN
    UPDATE t020_documentos
    SET f020_tipo_documento = p_f020_tipo_documento,
        f020_numero_documento = p_f020_numero_documento,
        f020_fecha_documento = p_f020_fecha_documento,
        f020_origen = p_f020_origen,
        f020_estado = p_f020_estado,
        f020_habilitado = p_f020_habilitado,
        f020_actualizacion = COALESCE(p_f020_actualizacion, DATE_FORMAT(NOW(), '%Y-%m-%d %H:%i:%s'))
    WHERE f020_id = p_f020_id;
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS sp_new_t021_documentos_detalle;
DELIMITER $$
CREATE PROCEDURE sp_new_t021_documentos_detalle(
    IN p_f021_id_documento INT,
    IN p_f021_id_barra INT,
    IN p_f021_id_ubicacion INT,
    IN p_f021_id_zona INT,
    IN p_f021_cantidad INT,
    IN p_f021_cantidad_epc_generada INT,
    IN p_f021_cantidad_impresa INT,
    IN p_f021_estado VARCHAR(50),
    IN p_f021_habilitado INT,
    IN p_f021_creacion VARCHAR(50)
)
BEGIN
    INSERT INTO t021_documentos_detalle (
        f021_id_documento,
        f021_id_barra,
        f021_id_ubicacion,
        f021_id_zona,
        f021_cantidad,
        f021_cantidad_epc_generada,
        f021_cantidad_impresa,
        f021_estado,
        f021_habilitado,
        f021_creacion
    ) VALUES (
        p_f021_id_documento,
        p_f021_id_barra,
        p_f021_id_ubicacion,
        p_f021_id_zona,
        p_f021_cantidad,
        COALESCE(p_f021_cantidad_epc_generada, 0),
        COALESCE(p_f021_cantidad_impresa, 0),
        COALESCE(p_f021_estado, 'PENDIENTE'),
        COALESCE(p_f021_habilitado, 1),
        p_f021_creacion
    )
    ON DUPLICATE KEY UPDATE
        f021_cantidad = VALUES(f021_cantidad),
        f021_cantidad_epc_generada = VALUES(f021_cantidad_epc_generada),
        f021_cantidad_impresa = VALUES(f021_cantidad_impresa),
        f021_estado = VALUES(f021_estado),
        f021_habilitado = VALUES(f021_habilitado),
        f021_actualizacion = DATE_FORMAT(NOW(), '%Y-%m-%d %H:%i:%s');
END$$
DELIMITER ;
DROP PROCEDURE IF EXISTS sp_list_t020_documentos_resumen;
DELIMITER $$
CREATE PROCEDURE sp_list_t020_documentos_resumen(
    IN p_buscar VARCHAR(100)
)
BEGIN
    SELECT
        d.f020_id,
        d.f020_tipo_documento,
        d.f020_numero_documento,
        d.f020_fecha_documento,
        d.f020_origen,
        d.f020_estado,
        d.f020_habilitado,
        COALESCE(SUM(dd.f021_cantidad), 0) AS cantidad_total,
        COALESCE(SUM(dd.f021_cantidad_epc_generada), 0) AS cantidad_epc_generada,
        COALESCE(SUM(dd.f021_cantidad_impresa), 0) AS cantidad_impresa,
        COALESCE(SUM(dd.f021_cantidad - dd.f021_cantidad_epc_generada), 0) AS cantidad_pendiente_epc,
        COALESCE(SUM(dd.f021_cantidad - dd.f021_cantidad_impresa), 0) AS cantidad_pendiente_impresion
    FROM t020_documentos d
    LEFT JOIN t021_documentos_detalle dd ON dd.f021_id_documento = d.f020_id
    WHERE p_buscar IS NULL
       OR TRIM(p_buscar) = ''
       OR d.f020_tipo_documento LIKE CONCAT('%', p_buscar, '%')
       OR d.f020_numero_documento LIKE CONCAT('%', p_buscar, '%')
       OR d.f020_origen LIKE CONCAT('%', p_buscar, '%')
       OR d.f020_estado LIKE CONCAT('%', p_buscar, '%')
    GROUP BY
        d.f020_id,
        d.f020_tipo_documento,
        d.f020_numero_documento,
        d.f020_fecha_documento,
        d.f020_origen,
        d.f020_estado,
        d.f020_habilitado
    ORDER BY d.f020_id DESC;
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS sp_list_t021_documentos_detalle;
DELIMITER $$
CREATE PROCEDURE sp_list_t021_documentos_detalle(
    IN p_f021_id_documento INT
)
BEGIN
    SELECT
        dd.f021_id,
        dd.f021_id_documento,
        i.f001_codigo_item,
        i.f001_descripcion,
        b.f0011_barra,
        b.f0011_atributo_1,
        b.f0011_atributo_2,
        b.f0011_atributo_3,
        b.f0011_atributo_4,
        b.f0011_atributo_5,
        b.f0011_atributo_6,
        u.f004_codigo_ubicacion,
        u.f004_descripcion,
        z.f005_codigo_zona,
        z.f005_descripcion,
        dd.f021_cantidad,
        dd.f021_cantidad_epc_generada,
        dd.f021_cantidad_impresa,
        dd.f021_cantidad - dd.f021_cantidad_epc_generada AS cantidad_pendiente_epc,
        dd.f021_cantidad - dd.f021_cantidad_impresa AS cantidad_pendiente_impresion,
        dd.f021_estado
    FROM t021_documentos_detalle dd
    INNER JOIN t0011_barras b ON b.f0011_id = dd.f021_id_barra
    LEFT JOIN t001_items i ON i.f001_id = b.f0011_id_item
    LEFT JOIN t004_ubicaciones u ON u.f004_id = dd.f021_id_ubicacion
    LEFT JOIN t005_zonas z ON z.f005_id = dd.f021_id_zona
    WHERE dd.f021_id_documento = p_f021_id_documento
    ORDER BY dd.f021_id;
END$$
DELIMITER ;
