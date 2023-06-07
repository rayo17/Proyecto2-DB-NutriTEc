--SP para insertar tiempo comida
CREATE OR REPLACE FUNCTION insertartiempocomida(
    p_ID INT,
    p_NombreTiempo VARCHAR(40)
)
RETURNS VOID AS $$
BEGIN
    INSERT INTO TiempoComida (Nombre)
    VALUES (p_NombreTiempo);
END;
$$ LANGUAGE plpgsql;

--SP para insertar/crear producto
CREATE OR REPLACE FUNCTION crear_producto(
    p_codigo_barra VARCHAR(40),
    p_nombre VARCHAR(40),
    p_taman_porcion INTEGER,
    p_energia INTEGER,
    p_grasa INTEGER,
    p_sodio INTEGER,
    p_carbohidratos INTEGER,
    p_proteina INTEGER,
    p_vitaminas VARCHAR(150),
    p_calcio INTEGER,
    p_hierro INTEGER,
    p_descripcion VARCHAR(200),
    p_estado_producto BOOLEAN
)
RETURNS VOID AS $$
BEGIN
    INSERT INTO Productos (CodigoBarra, Nombre, taman_porcion, energia, grasa, sodio, carbohidratos, proteina, vitaminas, calcio, hierro, descripcion, EstadoProducto)
    VALUES (p_codigo_barra, p_nombre, p_taman_porcion, p_energia, p_grasa, p_sodio, p_carbohidratos, p_proteina, p_vitaminas, p_calcio, p_hierro, p_descripcion, FALSE);
END;
$$ LANGUAGE plpgsql;

--View para mostar los productos disponibles
CREATE OR REPLACE VIEW productosdisponibles AS
SELECT *
FROM Productos
WHERE EstadoProducto = TRUE;

