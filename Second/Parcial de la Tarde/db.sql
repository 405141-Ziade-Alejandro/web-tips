CREATE DATABASE ParcialSociosClub
GO
USE ParcialSociosClub
GO

CREATE TABLE Socios 
(
ID uniqueidentifier,
NOMBRE varchar(255),
APELLIDO varchar(255),
DNI int,
NOMBRE_DEPORTE varchar(255),
FECHA_CREACION datetime

CONSTRAINT PK_SOCIOS PRIMARY KEY (ID)
);

GO

INSERT INTO Socios (ID, NOMBRE, APELLIDO, DNI, NOMBRE_DEPORTE, FECHA_CREACION) VALUES 
('b54a9a8e-fff2-47fc-a78b-87d5c2267fd5', 'Agustin', 'Nieto', 41410430, 'Baseball', GETDATE()),
('a7504bc1-6b61-473e-986d-b85cba1917b8', 'Matias', 'Salgado', 43525016, 'League of Legends', GETDATE()),
('e14e7139-f956-4529-a433-4a5c9cfd82b0', 'Rulo', 'Castillo', 55555555, 'Valorant', GETDATE());
GO