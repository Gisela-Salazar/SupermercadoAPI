CREATE DATABASE SupermercadoDB;
GO
USE SupermercadoDB;
GO

CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(200) NOT NULL,
    Rol NVARCHAR(20) NOT NULL
);

CREATE TABLE Clientes (
    Id INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL
);

CREATE TABLE Productos (
    Id INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100) NOT NULL,
    Precio DECIMAL(10,2) NOT NULL
);

CREATE TABLE Compras (
    Id INT PRIMARY KEY IDENTITY,
    ClienteId INT NOT NULL FOREIGN KEY REFERENCES Clientes(Id),
    ProductoId INT NOT NULL FOREIGN KEY REFERENCES Productos(Id),
    Cantidad INT NOT NULL,
    FechaCompra DATETIME NOT NULL DEFAULT GETDATE()
);

-- Usuario inicial (para login en el API)
INSERT INTO Usuarios (Username, PasswordHash, Rol)
VALUES ('admin', '1234', 'Admin');

SELECT * FROM Usuarios
