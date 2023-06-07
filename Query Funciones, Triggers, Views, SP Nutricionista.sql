--SP para registar un nutricionista
CREATE OR REPLACE FUNCTION registrar_nutricionista(
    p_Cedula VARCHAR(12),
    p_Nombre VARCHAR(40),
    p_Apellido1 VARCHAR(40),
    p_Apellido2 VARCHAR(40),
    p_CodigoBarras VARCHAR(127),
    p_Edad INTEGER,
    p_FechaNacimiento DATE,
    p_Peso INTEGER,
    p_IMC INTEGER,
    p_Direccion VARCHAR(200),
    p_Foto BYTEA,
    p_NumTarjetaCredito VARCHAR(16),
    p_TipoCobroID INTEGER,
    p_CorreoElectronico VARCHAR(320),
    p_Contrasena VARCHAR(50)
)
RETURNS VOID AS $$
BEGIN
    INSERT INTO Nutricionistas (Cedula, Nombre, Apellido1, Apellido2, CodigoBarras, Edad, FechaNacimiento, Peso, IMC, Direccion, Foto, NumTarjetaCredito, TipoCobroID, CorreoElectronico, Contrasena)
    VALUES (p_Cedula, p_Nombre, p_Apellido1, p_Apellido2, p_CodigoBarras, p_Edad, p_FechaNacimiento, p_Peso, p_IMC, p_Direccion, p_Foto, p_NumTarjetaCredito, p_TipoCobroID, p_CorreoElectronico, p_Contrasena);
END;
$$ LANGUAGE plpgsql;

