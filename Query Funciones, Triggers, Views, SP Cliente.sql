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

--Funcion para registar un cliente
CREATE OR REPLACE FUNCTION registrar_cliente(
    p_ID INT,
    p_Nombre VARCHAR(40),
    p_Apellido1 VARCHAR(40),
    p_Apellido2 VARCHAR(40),
    p_Edad INTEGER,
    p_FechaNacimiento DATE,
    p_Peso INTEGER,
    p_IMC INTEGER,
    p_PaisResidencia VARCHAR(50),
    p_PesoActual INTEGER,
    p_Cintura INTEGER,
    p_PorcentajeMusculos INTEGER,
    p_Cuello INTEGER,
    p_Caderas INTEGER,
    p_PorcentajeGrasa INTEGER,
    p_ConsumoDiarioCalorias INTEGER,
    p_CorreoElectronico VARCHAR(100),
    p_Contrasena VARCHAR(50)
)
RETURNS VOID AS $$
BEGIN
    INSERT INTO Clientes (Nombre, Apellido1, Apellido2, Edad, FechaNacimiento, Peso, IMC, PaisResidencia, PesoActual, Cintura, PorcentajeMusculos, Cuello, Caderas, PorcentajeGrasa, ConsumoDiarioCalorias, CorreoElectronico, Contrasena)
    VALUES (p_Nombre, p_Apellido1, p_Apellido2, p_Edad, p_FechaNacimiento, p_Peso, p_IMC, p_PaisResidencia, p_PesoActual, p_Cintura, p_PorcentajeMusculos, p_Cuello, p_Caderas, p_PorcentajeGrasa, p_ConsumoDiarioCalorias, p_CorreoElectronico, p_Contrasena);
END;
$$ LANGUAGE plpgsql;

--Funcion para validar el login de cliente
CREATE VIEW logincliente AS
SELECT CorreoElectronico, Contrasena
FROM Clientes;


SELECT * FROM logincliente;

DROP FUNCTION IF EXISTS validarlogincliente;

SELECT validar_login_cliente('pedro.djua@example.com', 'password1');

