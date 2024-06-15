-- Crear la base de datos
CREATE DATABASE ArticulosDB;
GO

-- Usar la base de datos
USE ArticulosDB;
GO

-- Crear la tabla 'articulos'
CREATE TABLE articulos (
    id INT IDENTITY(1,1) PRIMARY KEY,       -- ID autoincremental
    nombre NVARCHAR(255) NOT NULL,          -- Nombre del artículo
    descripcion NVARCHAR(MAX) NOT NULL,     -- Descripción del artículo
    precio DECIMAL(18,2) NOT NULL,          -- Precio del artículo
    imagen VARBINARY(MAX) NULL              -- Imagen del artículo (puede ser nula)
);
GO

-- Crear procedimiento almacenado para insertar un artículo
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

-- Crear procedimiento almacenado para seleccionar un artículo por ID
CREATE PROCEDURE SelectArticuloById
    @id INT
AS
BEGIN
    SELECT * FROM articulos WHERE id = @id;
END;
GO

-- Crear procedimiento almacenado para seleccionar todos los artículos
CREATE PROCEDURE SelectAllArticulos
AS
BEGIN
    SELECT * FROM articulos;
END;
GO

-- Crear procedimiento almacenado para actualizar un artículo
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

-- Crear procedimiento almacenado para eliminar un artículo por ID
CREATE PROCEDURE DeleteArticulo
    @id INT
AS
BEGIN
    DELETE FROM articulos WHERE id = @id;
END;
GO

-- Insertar datos de ejemplo
INSERT INTO articulos (nombre, descripcion, precio, imagen)
VALUES ('Artículo 1', 'Descripción del artículo 1', 100.00, NULL),
       ('Artículo 2', 'Descripción del artículo 2', 200.00, NULL),
       ('Artículo 3', 'Descripción del artículo 3', 300.00, NULL);
GO
