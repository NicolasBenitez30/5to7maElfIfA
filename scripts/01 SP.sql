USE ElFifa $$
DELIMITER $$
CREATE PROCEDURE altaUsuario (unidUsuario MEDIUMINT, unnombreDeUsuario VARCHAR(15), unnombre VARCHAR(45), unapellido VARCHAR(45), uncontrasena CHAR(64), unmonedas MEDIUMINT UNSIGNED)
BEGIN
    INSERT INTO Usuario (idUsuario, nombreDeUsuario, nombre, apellido, contrasena, monedas)
            VALUES (unidUsuario, unnombreDeUsuario, unnombre, unapellido, uncontrasena, unmonedas);
END $$
DELIMITER $$
CREATE PROCEDURE altaPosesion (unidUsuario MEDIUMINT, unidFutbolista SMALLINT)
BEGIN
    INSERT INTO Posesion (idUsuario, idFutbolista)
                VALUES (unidUsuario, unidFutbolista);
END $$

DELIMITER $$
CREATE PROCEDURE altaFutbolista (unidFutbolista SMALLINT, unnombre VARCHAR(45), unapellido VARCHAR(45), unnacimiento DATE, unvelocidad TINYINT UNSIGNED, unremate TINYINT UNSIGNED, unpase TINYINT UNSIGNED, undefensa TINYINT UNSIGNED, unidPosicion TINYINT, unidHabilidad TINYINT)
BEGIN
    INSERT INTO Futbolista (idFutbolista, nombre, apellido, nacimiento, velocidad, remate, pase, defensa, idPosicion, idHabilidad)
                VALUES (unidFutbolista, unnombre, unapellido, unnacimiento, unvelocidad, unremate, unpase, undefensa, unidPosicion, unidHabilidad);
END $$

DELIMITER $$
CREATE PROCEDURE altaPosicion (OUT unidPosicion TINYINT, unaPosicion VARCHAR(45))
BEGIN
    INSERT INTO Posicion(posicion)
                VALUES (unaPosicion);
    
    SET unidPosicion = LAST_INSERT_ID();
END $$

DELIMITER $$
CREATE PROCEDURE altaFutbolistaHabilidad (unidHabilidad TINYINT, unidFutbolista SMALLINT) 
BEGIN
    INSERT INTO FutbolistaHabilidad (idHabilidad, idFutbolista)
                VALUES (unidHabilidad, unidFutbolista);
END $$

DELIMITER $$
CREATE PROCEDURE altaHabilidad (OUT unidHabilidad TINYINT, unHabilidad VARCHAR(45), unDescripcion VARCHAR(45))
BEGIN
    INSERT INTO Habilidad(habilidad, descripcion)
                VALUES (unHabilidad, unDescripcion);
                
    SET unidHabilidad = LAST_INSERT_ID();
END $$

DELIMITER $$
CREATE PROCEDURE publicar (unidVendedor MEDIUMINT, unidFutbolista MEDIUMINT, unprecio MEDIUMINT UNSIGNED)
BEGIN
    INSERT INTO Transferencia (idVendedor, idFutbolista, precio, publicacion)
                VALUES (unidVendedor, unidFutbolista, unprecio, now());
END $$

DELIMITER $$
CREATE PROCEDURE comprar (unpublicacion DATETIME, unidComprador MEDIUMINT)
BEGIN
    UPDATE Transferencia
    SET compra = now(), idComprador = unidComprador    
    WHERE unidComprador = idComprador AND unpublicacion = publicacion;
END $$

DELIMITER $$
CREATE PROCEDURE transferenciasActividas (unidFutbolista MEDIUMINT, 
                                            unpublicacion DATETIME)
BEGIN
    SELECT idFutbolista, publicacion
    FROM Transferencia
    WHERE unidFutbolista = idFutbolista AND unpublicacion = publicacion
    ORDER BY publicacion ASC;
END $$

DELIMITER $$
CREATE FUNCTION gananciasEntre (unidFutbolista SMALLINT,
                                unfechaInicio DATETIME,
                                unfechaFin DATETIME)
RETURNS MEDIUMINT UNSIGNED
BEGIN
    DECLARE GananciaE MEDIUMINT UNSIGNED;
    
    SELECT sum(precio) INTO GananciaE
    FROM Transferencia
    WHERE unidFutbolista = idFutbolista
    AND compra BETWEEN unfechaIncio AND unfechaFin;
    
    RETURN GananciaE;
END $$
