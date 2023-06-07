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

--SP Crea una receta 
CREATE OR REPLACE FUNCTION crearreceta(
  pNombre VARCHAR(40),
  pTamanPorcion INTEGER,
  pEnergia INTEGER,
  pGrasa INTEGER,
  pSodio INTEGER,
  pCarbohidratos INTEGER,
  pProteina INTEGER,
  pVitaminas VARCHAR(150),
  pCalcio INTEGER,
  pHierro INTEGER
)
RETURNS VOID
LANGUAGE plpgsql
AS $$
DECLARE
  vRecetaID VARCHAR;
BEGIN
  -- Verificar si la receta ya existe
  SELECT nombre INTO vRecetaID
  FROM Receta
  WHERE Nombre = pNombre;
  
  IF vRecetaID IS NOT NULL THEN
    -- Actualizar los valores existentes de la receta
    UPDATE Receta
    SET taman_porcion = taman_porcion + pTamanPorcion,
        energia = energia + pEnergia,
        grasa = grasa + pGrasa,
        sodio = sodio + pSodio,
        carbohidratos = carbohidratos + pCarbohidratos,
        proteina = proteina + pProteina,
        calcio = calcio + pCalcio,
        hierro = hierro + pHierro
    WHERE nombre = vRecetaID;
    
    -- Agregar las nuevas vitaminas a la receta
    UPDATE Receta
    SET vitaminas = CONCAT(vitaminas, ', ', pVitaminas)
    WHERE nombre = vRecetaID
      AND NOT EXISTS (
        SELECT 1
        FROM regexp_split_to_table(vitaminas, ', ') AS v
        WHERE v = ANY (regexp_split_to_array(pVitaminas, ', '))
      );
  ELSE
    -- Crear una nueva receta
    INSERT INTO Receta (Nombre, taman_porcion, energia, grasa, sodio, carbohidratos, proteina, vitaminas, calcio, hierro)
    VALUES (pNombre, pTamanPorcion, pEnergia, pGrasa, pSodio, pCarbohidratos, pProteina, pVitaminas, pCalcio, pHierro);
  END IF;
END;
$$;


