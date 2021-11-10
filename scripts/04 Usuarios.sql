-- Administrador --
DROP USER IF EXISTS 'administrador'@'localhost';
CREATE USER 'administrador'@'localhost' IDENTIFIED BY 'passadministrador';

GRANT SELECT ON elfifa.* TO 'administrador'@'localhost';
GRANT INSERT ON elfifa.Posicion TO 'administrador'@'localhost';
GRANT INSERT ON elfifa.Habilidad TO 'administrador'@'localhost';
GRANT INSERT ON elfifa.Futbolista TO 'administrador'@'localhost';

-- Jugador --
DROP USER IF EXISTS 'jugador'@'%';
CREATE USER 'jugador'@'%' IDENTIFIED BY 'passjugador';

GRANT SELECT ON elfifa.* TO 'jugador'@'%';

-- Sistema --
DROP USER IF EXISTS 'sistema'@'%';
CREATE USER 'sistema'@'%' IDENTIFIED BY 'passsistema';

GRANT SELECT ON elfifa.Usuario TO 'sistema'@'%';
GRANT SELECT ON elfifa.Futbolista TO 'sistema'@'%';
GRANT SELECT, INSERT, DELETE, UPDATE(compra, idComprador) ON elfifa.Transferencia TO 'sistema'@'%';