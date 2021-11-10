DELIMITER $$
CREATE TRIGGER befInsTransferencias BEFORE INSERT ON Transferencia
FOR EACH ROW
BEGIN
        IF (NOT EXISTS( SELECT *
                   FROM Posesion
                        WHERE idFutbolista = new.idFutbolista
                        AND idUsuario = new.idVendedor)) THEN
                        SIGNAL SQLSTATE '45000'
                        SET MESSAGE_TEXT = 'El usuario no posee a al 
futbolista';
        END IF;
END$$

DELIMITER $$
CREATE TRIGGER befUpdTransferencia BEFORE UPDATE ON Transferencia
FOR EACH ROW
BEGIN
        IF (NOT EXISTS (SELECT idUsuario, monedas
						FROM Usuario
						WHERE idUsuario = NEW.idComprador
						AND monedas < NEW.precio)) THEN
						SIGNAL SQLSTATE '45000'
						SET message_text = 'Monedas insuficientes';
		END IF;
        
        IF (EXISTS (SELECT *
					FROM posesion
					WHERE idUsuario = NEW.idComprador
					AND idFutbolista = NEW.idFutbolista)) THEN
                    SIGNAL SQLSTATE '45000'
					SET message_text = 'Ya tienes este futbolista en Posesion, no se realiza la compra';
		END IF;
END$$

DELIMITER $$
CREATE TRIGGER aftInsTransferencia AFTER UPDATE ON transferencia
FOR EACH ROW
BEGIN
        UPDATE Usuario
        SET monedas = monedas + NEW.precio
        WHERE idUsuario = NEW.idVendedor;
        
        UPDATE Posesion
        SET idFutbolista = NULL
        WHERE idUsuario = NEW.idVendedor
        AND idFutbolista = NEW.idFutbolista;
		
        UPDATE Usuario
        SET monedas = monedas - NEW.precio
        WHERE idUsuario = NEW.idComprador;
        
        UPDATE Posesion
        SET idFutbolista = NEW.idFutbolista
        WHERE idUsuario = NEW.idComprador;
        
END$$