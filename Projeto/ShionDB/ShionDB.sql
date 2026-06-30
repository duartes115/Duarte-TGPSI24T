CREATE DATABASE ShionDB;
GO

USE ShionDB;
GO

CREATE TABLE utilizadores (
    id INT IDENTITY(1,1) PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    email VARCHAR(150) NOT NULL UNIQUE,
    senha VARCHAR(255) NOT NULL
);

SELECT * FROM utilizadores;

ALTER TABLE utilizadores
ADD estado VARCHAR(20) NOT NULL DEFAULT 'Negado';

CREATE TABLE equipamentos (
    id INT IDENTITY(1,1) PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    tipo VARCHAR(100) NOT NULL
);
GO
SELECT * FROM equipamentos;



CREATE TABLE pedidos (
    idPedido INT IDENTITY(1,1) PRIMARY KEY,

    idUtilizador INT NOT NULL,

    estado VARCHAR(20) NOT NULL DEFAULT 'Negado',

    CONSTRAINT FK_Pedidos_Utilizadores
        FOREIGN KEY (idUtilizador)
        REFERENCES utilizadores(id),

    CONSTRAINT CK_Pedidos_Estado
        CHECK (estado IN ('Negado', 'Aceite'))
);
GO

CREATE TRIGGER TR_CriarPedidoAoRegistar
ON utilizadores
AFTER INSERT
AS
BEGIN
    INSERT INTO pedidos (idUtilizador, estado)
    SELECT id, 'Negado'
    FROM inserted;
END;
GO


CREATE TRIGGER TR_SincronizarEstadoPedido
ON pedidos
AFTER UPDATE
AS
BEGIN
    UPDATE u
    SET u.estado = i.estado
    FROM utilizadores u
    INNER JOIN inserted i
        ON u.id = i.idUtilizador;
END;
GO
ALTER TABLE pedidos
DROP CONSTRAINT FK_Pedidos_Utilizadores;

ALTER TABLE pedidos
ADD CONSTRAINT FK_Pedidos_Utilizadores
FOREIGN KEY (idUtilizador)
REFERENCES utilizadores(id)
ON DELETE CASCADE;

SELECT * FROM pedidos;

CREATE TABLE personal_trainers (
    idPersonal INT IDENTITY(1,1) PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    especialidade VARCHAR(100) NOT NULL,
    experiencia INT NOT NULL,
    formacao VARCHAR(150) NOT NULL,
    contacto VARCHAR(30) NOT NULL,
    email VARCHAR(150) NOT NULL UNIQUE
);
GO

SELECT * FROM personal_trainers;
SELECT * FROM pedidos;


