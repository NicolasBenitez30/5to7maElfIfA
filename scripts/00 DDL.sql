DROP DATABASE IF EXISTS ElFifa;
CREATE DATABASE ElFifa;

CREATE TABLE ElFifa.Usuario(
idUsuario MEDIUMINT NOT NULL,
nombreDeUsuario VARCHAR(15) NOT NULL,
nombre VARCHAR(45) NOT NULL,
    apellido VARCHAR(45) NOT NULL,
    contrasena CHAR(64) NOT NULL,
    monedas MEDIUMINT UNSIGNED NOT NULL,
    PRIMARY KEY (idUsuario),
CONSTRAINT UQ_Usuario_nombreDeUsuario UNIQUE (nombreDeUsuario)
);

CREATE TABLE ElFifa.Posicion(
idPosicion TINYINT NOT NULL,
posicion VARCHAR(45) NOT NULL,
    PRIMARY KEY (idPosicion),
CONSTRAINT UQ_Posicion_posicion UNIQUE (posicion)
);

CREATE TABLE ElFifa.Habilidad(
idHabilidad TINYINT NOT NULL,
habilidad VARCHAR(45) NOT NULL,
descripcion VARCHAR(45) NULL,
    PRIMARY KEY (idHabilidad),
CONSTRAINT UQ_Habilidad_habilidad UNIQUE (habilidad)
);

CREATE TABLE ElFifa.Futbolista(
idFutbolista SMALLINT NOT NULL,
nombre VARCHAR(45) NOT NULL,
apellido VARCHAR(45) NOT NULL,
    nacimiento DATE NOT NULL,
    velocidad TINYINT UNSIGNED NOT NULL,
remate TINYINT UNSIGNED NOT NULL,
pase TINYINT UNSIGNED NOT NULL,
defensa TINYINT UNSIGNED NOT NULL,
    idPosicion TINYINT NOT NULL,
    idHabilidad TINYINT NOT NULL,
    PRIMARY KEY (idFutbolista),
    CONSTRAINT FK_Futbolista_Posicion FOREIGN KEY (idPosicion) 
        REFERENCES ElFifa.Posicion (idPosicion) 
);

CREATE TABLE ElFifa.Posesion(
idUsuario MEDIUMINT NOT NULL,
idFutbolista SMALLINT NOT NULL,
    PRIMARY KEY (idUsuario, idFutbolista),
CONSTRAINT FK_Posesion_idUsuario 
FOREIGN KEY (idUsuario) 
        REFERENCES ElFifa.Usuario (idUsuario),
CONSTRAINT FK_Posesion_idFutbolista 
FOREIGN KEY (idFutbolista) 
        REFERENCES ElFifa.Futbolista (idFutbolista) 
);

CREATE TABLE ElFifa.FutbolistaHabilidad(
idHabilidad TINYINT NOT NULL,
idFutbolista SMALLINT NOT NULL,
    PRIMARY KEY (idHabilidad, idFutbolista),
CONSTRAINT FK_FutbolistaHabilidad_idHabilidad FOREIGN KEY (idHabilidad) 
        REFERENCES ElFifa.Habilidad (idHabilidad),
CONSTRAINT FK_FutbolistaHabilidad_idFutbolista FOREIGN KEY (idFutbolista) 
        REFERENCES ElFifa.Futbolista (idFutbolista) 
);

CREATE TABLE ElFifa.Transferencia(
publicacion DATETIME NOT NULL,
precio MEDIUMINT UNSIGNED NOT NULL,
compra DATETIME NULL,
    idComprador MEDIUMINT NULL,
    idVendedor MEDIUMINT NOT NULL,
    idFutbolista SMALLINT NOT NULL,
    PRIMARY KEY (publicacion, idVendedor,idFutbolista),
    CONSTRAINT FK_Transferencia_idVendedor FOREIGN KEY (idVendedor) 
        REFERENCES ElFifa.Usuario (idUsuario),
    CONSTRAINT FK_Transferencia_idComprador FOREIGN KEY (idComprador) 
        REFERENCES ElFifa.Usuario (idUsuario),
CONSTRAINT FK_Transferencia_idFutbolista FOREIGN KEY (idFutbolista) 
        REFERENCES ElFifa.Futbolista (idFutbolista)
);
