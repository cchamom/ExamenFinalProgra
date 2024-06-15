-- Crear la base de datos
CREATE DATABASE ArticulosDB;
GO

-- Usar la base de datos
USE ArticulosDB;
GO

-- Crear la tabla 'articulos'
CREATE TABLE articulos (
    id INT IDENTITY(1,1) PRIMARY KEY,       -- ID autoincremental
    nombre NVARCHAR(255) NOT NULL,          -- Nombre del art�culo
    descripcion NVARCHAR(MAX) NOT NULL,     -- Descripci�n del art�culo
    precio DECIMAL(18,2) NOT NULL,          -- Precio del art�culo
    imagen VARBINARY(MAX) NULL              -- Imagen del art�culo (puede ser nula)
);
GO

-- Crear procedimiento almacenado para insertar un art�culo
CREATE PROCEDURE InsertArticulo
    @nombre NVARCHAR(255),
    @descripcion NVARCHAR(MAX),
    @precio DECIMAL(18,2),
    @imagen VARBINARY(MAX)
AS
BEGIN
    INSERT INTO articulos (nombre, descripcion, precio, imagen)
    VALUES (@nombre, @descripcion, @precio, @imagen);
END;
GO

-- Crear procedimiento almacenado para seleccionar un art�culo por ID
CREATE PROCEDURE SelectArticuloById
    @id INT
AS
BEGIN
    SELECT * FROM articulos WHERE id = @id;
END;
GO

-- Crear procedimiento almacenado para seleccionar todos los art�culos
CREATE PROCEDURE SelectAllArticulos
AS
BEGIN
    SELECT * FROM articulos;
END;
GO

-- Crear procedimiento almacenado para actualizar un art�culo
CREATE PROCEDURE UpdateArticulo
    @id INT,
    @nombre NVARCHAR(255),
    @descripcion NVARCHAR(MAX),
    @precio DECIMAL(18,2),
    @imagen VARBINARY(MAX)
AS
BEGIN
    UPDATE articulos
    SET nombre = @nombre, descripcion = @descripcion, precio = @precio, imagen = @imagen
    WHERE id = @id;
END;
GO

-- Crear procedimiento almacenado para eliminar un art�culo por ID
CREATE PROCEDURE DeleteArticulo
    @id INT
AS
BEGIN
    DELETE FROM articulos WHERE id = @id;
END;
GO

-- Insertar datos de ejemplo
INSERT INTO articulos (nombre, descripcion, precio, imagen)
VALUES ('Art�culo 1', 'Descripci�n del art�culo 1', 100.00, NULL),
       ('Art�culo 2', 'Descripci�n del art�culo 2', 200.00, NULL),
       ('Art�culo 3', 'Descripci�n del art�culo 3', 300.00, NULL);
GO
