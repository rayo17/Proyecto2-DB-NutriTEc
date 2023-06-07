--Store procedure para registar cliente
CREATE OR REPLACE PROCEDURE registrarcliente(
    p_ID INT,
    p_Nombre VARCHAR(40),
    p_Apellido1 VARCHAR(40),
    p_Apellido2 VARCHAR(40),
    p_Edad INT,
    p_FechaNacimiento DATE,
    p_Peso INT,
    p_IMC INT,
    p_PaisResidencia VARCHAR(50),
    p_PesoActual INT,
    p_Cintura INT,
    p_PorcentajeMusculos INT,
    p_Cuello INT,
    p_Caderas INT,
    p_PorcentajeGrasa INT,
    p_ConsumoDiarioCalorias INT,
    p_CorreoElectronico VARCHAR(100),
    p_Contrasena VARCHAR(50)
)
AS $$
BEGIN
        
    INSERT INTO "clientes" ("nombre", "apellido1", "apellido2", "edad", "fechanacimiento", "peso", "imc", "paisresidencia", "pesoactual", "cintura", "porcentajemusculos", "cuello", "caderas", "porcentajegrasa", "consumodiariocalorias", "correoelectronico", "contrasena")
    VALUES (p_Nombre, p_Apellido1, p_Apellido2, p_Edad, p_FechaNacimiento, p_Peso, p_IMC, p_PaisResidencia, p_PesoActual, p_Cintura, p_PorcentajeMusculos, p_Cuello, p_Caderas, p_PorcentajeGrasa, p_ConsumoDiarioCalorias, p_CorreoElectronico, p_Contrasena);
    
    
END;
$$ LANGUAGE plpgsql;


--SP para registar un cliente
CREATE OR REPLACE FUNCTION registrar_cliente(
    p_CorreoElectronico VARCHAR(320),
    p_Nombre VARCHAR(40),
    p_Apellido1 VARCHAR(40),
    p_Apellido2 VARCHAR(40),
    p_Edad INTEGER,
    p_FechaNacimiento DATE,
    p_Peso INTEGER,
    p_IMC INTEGER,
    p_PaisResidencia VARCHAR(50),
    p_ConsumoDiarioCalorias INTEGER,
    p_Contrasena VARCHAR(50)
)
RETURNS VOID AS $$
BEGIN
    INSERT INTO Clientes (CorreoElectronico, Nombre, Apellido1, Apellido2, Edad, FechaNacimiento, Peso, IMC, PaisResidencia, ConsumoDiarioCalorias, Contrasena)
    VALUES (p_CorreoElectronico, p_Nombre, p_Apellido1, p_Apellido2, p_Edad, p_FechaNacimiento, p_Peso, p_IMC, p_PaisResidencia, p_ConsumoDiarioCalorias, p_Contrasena);
END;
$$ LANGUAGE plpgsql;

--SP registrar medidas
CREATE OR REPLACE FUNCTION registrar_medidas(
    p_ID INTEGER,
    p_ClienteID Varchar(320),
    p_Fecha DATE,
    p_Cintura INTEGER,
    p_Cuello INTEGER,
    p_Caderas INTEGER,
    p_PorcentajeMusculo INTEGER,
    p_PorcentajeGrasa INTEGER,
    p_PesoActual INTEGER
)
RETURNS VOID AS $$
BEGIN
    INSERT INTO medidas (ClienteID, Fecha, Cintura, Cuello, Caderas, PorcentajeMusculo, PorcentajeGrasa, PesoActual)
    VALUES (p_ClienteID, p_Fecha, p_Cintura, p_Cuello, p_Caderas, p_PorcentajeMusculo, p_PorcentajeGrasa, p_PesoActual);
END;
$$ LANGUAGE plpgsql;

--SP para validar el login de cliente
CREATE OR REPLACE FUNCTION validarlogincliente(
    p_correo VARCHAR(320),
    p_contrasena VARCHAR(50)
)
RETURNS INTEGER AS $$
DECLARE
    login_count INTEGER;
    cliente_id INTEGER;
BEGIN
    

    SELECT COUNT(*) INTO login_count
    FROM Clientes
    WHERE correoelectronico = p_correo AND contrasena = p_contrasena;

    

    IF login_count > 0 THEN
        --SELECT ID INTO cliente_id
        --FROM Clientes
        --WHERE CorreoElectronico = p_correo;

        --INSERT INTO BitacoraGeneral (Fecha, CedulaID)
        --VALUES (cliente_id, NOW());
        RETURN 1;
    ELSE
        RETURN 0;
    END IF;
END;
$$ LANGUAGE plpgsql;



-- SP para eliminar a un cliente
CREATE OR REPLACE FUNCTION eliminar_cliente(
    p_CorreoElectronico VARCHAR(320)
)
RETURNS VOID AS $$
BEGIN
    DELETE FROM Clientes WHERE correoelectronico = p_CorreoElectronico;
END;
$$ LANGUAGE plpgsql;

--SP para agregar el registro diario
CREATE OR REPLACE FUNCTION insertar_registro_diario(
    p_ID INTEGER,
    p_ClienteID VARCHAR(320),
    p_TiempoComidaID INTEGER,
    p_Fecha DATE,
    p_ProductoID VARCHAR(40)
)
RETURNS VOID AS $$
BEGIN
    INSERT INTO RegistroDiario (ClienteID, TiempoComidaID, Fecha, ProductoID)
    VALUES (p_ClienteID, p_TiempoComidaID, p_Fecha, p_ProductoID);
END;
$$ LANGUAGE plpgsql;




--Tigger que impide una insersion en caso de que la fecha de nacimiento no coincida con la edad
CREATE OR REPLACE FUNCTION validar_fecha_edad()
RETURNS TRIGGER AS $$
DECLARE
    fecha_nacimiento date;
    edad_calculada integer;
BEGIN
    fecha_nacimiento := NEW.FechaNacimiento;
    edad_calculada := EXTRACT(YEAR FROM age(current_date, fecha_nacimiento));

    IF edad_calculada <> NEW.Edad THEN
        RAISE EXCEPTION 'Error: La fecha de nacimiento no coincide con la edad';
    END IF;

    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER validar_fecha_edad_trigger
BEFORE INSERT ON Clientes
FOR EACH ROW
EXECUTE FUNCTION validar_fecha_edad();


DROP FUNCTION ObtenerMedidasPorPeriodo
--SP para obtener los registros de las medidas de un periodo en concreto
CREATE OR REPLACE FUNCTION ObtenerMedidasPorClienteYPeriodo(
  p_clienteid VARCHAR(320),
  p_fechainicio DATE,
  p_fechafinal DATE
) 
RETURNS SETOF Medidas
AS $$
BEGIN
  RETURN QUERY
    SELECT *
    FROM Medidas
    WHERE ClienteID = p_clienteid
      AND Fecha BETWEEN p_fechainicio AND p_fechafinal
    ORDER BY Fecha;
END;
$$ LANGUAGE plpgsql;


-- SP para visualizar los planes asignados drop function visualizarPlanesPacientes
CREATE OR REPLACE FUNCTION visualizarPlanesPacientes(
    p_ClienteID VARCHAR(320)
)
RETURNS TABLE (
    "Paciente" VARCHAR(320),
    "Nutricionista" VARCHAR(12),
    "Nombre Plan" VARCHAR(40),
    "Fecha Inicio" DATE,
    "Fecha Finalizacion" DATE,
    "Calorias Totales" INTEGER,
    "Nombre Producto" VARCHAR(40),
    "Nombre receta" VARCHAR(40),
    "Tiempo Comida" VARCHAR(40)
) AS $$
BEGIN
    RETURN QUERY
    SELECT p.clienteid, p.nutricionistaid, p.planid, p.fechainicio, p.fechafinalizacion, pa.caloriastotalplan, pr.nombre, pp.recetaid, tp.nombre
    FROM (((Planes AS p
    INNER JOIN PlanesAlimentacion AS pa ON p.planid = pa.nombreplan)
    INNER JOIN ProductosPlan AS pp ON p.planid = pp.planid)
    INNER JOIN TiempoComida AS tp ON pp.TiempoComidaID = tp.id)
    INNER JOIN Productos AS pr ON pp.productoid = pr.codigobarra
    WHERE p.clienteid = p_ClienteID
    AND NOW() BETWEEN p.fechainicio AND p.fechafinalizacion;
END;
$$ LANGUAGE plpgsql;





SELECT visualizarPlanesPacientes('irodriguezcr1020@gmail.com');


