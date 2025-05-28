/*Creacion de diagrama entidad relación
Creación de las tablas con sus pk's y fk's
crear los scripts de insert, update y delete de cada unas de las tablas.
Debe hacer un informe que muestre la imagen del diseño de ER
Subir un script de la base de datos y de cada uno de los DML realizado.
*/

CREATE DATABASE AppTaxi

USE AppTaxi

CREATE TABLE Taxi (
Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
Placa NVARCHAR(10) NOT NULL UNIQUE
);
CREATE TABLE Usuario (
Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
Documento NVARCHAR(20) NOT NULL UNIQUE,
Nombre NVARCHAR(50) NOT NULL,
Apellido NVARCHAR(50) NOT NULL
);
CREATE TABLE Viaje (
Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
FechaInicio DATETIME NOT NULL,
FechaFin DATETIME NULL,
Desde NVARCHAR(100) NOT NULL,
Hasta NVARCHAR(100) NOT NULL,
Calificacion CHAR,  --Calificacion entre 1 y 5
IdTaxi INT NOT NULL,
IdUsuario INT NOT NULL,
FOREIGN KEY (IdTaxi) REFERENCES Taxi(Id),
FOREIGN KEY (IdUsuario) REFERENCES Usuario(Id)
);
CREATE TABLE DetalleViaje (
Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
Fecha DATETIME NOT NULL,
Latitude DECIMAL(9,6) NOT NULL,
Longitude DECIMAL(9,6) NOT NULL,
IdViaje INT NOT NULL,
FOREIGN KEY (IdViaje) REFERENCES Viaje(Id)
);
CREATE TABLE GrupoUsuarios (
Id INT PRIMARY KEY IDENTITY(1,1)
);
CREATE TABLE GrupoUsuariosDetalle (
Id INT PRIMARY KEY IDENTITY(1,1),
IdGrupoUsuarios INT NOT NULL,
IdUsuario INT NOT NULL,
FOREIGN KEY (IdGrupoUsuarios) REFERENCES GrupoUsuarios(Id),
FOREIGN KEY (IdUsuario) REFERENCES Usuario(Id)
);


--Taxi
INSERT INTO Taxi (Placa) VALUES ('ABC-123'), ('XYZ-789');
UPDATE Taxi SET Placa = 'DEF-456' WHERE Id = 1;
DELETE FROM Taxi WHERE Id = 2;

--Usuario
INSERT INTO Usuario (Documento, Nombre, Apellido) VALUES ('123456789', 'Jennifer', 'Espinal'), ('987654321', 'Carlos', 'Ramírez');
UPDATE Usuario SET Nombre = 'Jeni', Apellido = 'Ciprián' WHERE Id = 1;
DELETE FROM Usuario WHERE Id = 2;

-- Viaje
INSERT INTO Viaje (FechaInicio, FechaFin, Desde, Hasta, Calificacion, IdTaxi, IdUsuario) 
VALUES ('2025-05-10 08:00:00', '2025-05-10 08:30:00', 'Villa Verde', 'La Romana', 5, 1, 1);
UPDATE Viaje SET Calificacion = 4 WHERE Id = 1;
DELETE FROM Viaje WHERE Id = 1;

-- DetalleViaje
INSERT INTO DetalleViaje (Fecha, Latitude, Longitude, IdViaje) 
VALUES ('2025-05-10 08:15:00', 18.4265, -68.9650, 1);
UPDATE DetalleViaje SET Latitude = 18.4300, Longitude = -68.9600 WHERE Id = 1;
DELETE FROM DetalleViaje WHERE Id = 1;

-- GrupoUsuarios
INSERT INTO GrupoUsuarios DEFAULT VALUES;
UPDATE GrupoUsuarios SET Id = 1 WHERE Id = 1;
DELETE FROM GrupoUsuarios WHERE Id = 1;

-- GrupoUsuariosDetalle
INSERT INTO GrupoUsuariosDetalle (IdGrupoUsuarios, IdUsuario) VALUES (1, 1);
UPDATE GrupoUsuariosDetalle SET IdUsuario = 2 WHERE Id = 1;
DELETE FROM GrupoUsuariosDetalle WHERE Id = 1;
