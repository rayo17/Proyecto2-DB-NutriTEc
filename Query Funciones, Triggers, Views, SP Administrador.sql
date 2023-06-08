--SP para validar el login de administrador
CREATE OR REPLACE FUNCTION validarloginadministrador(
    p_correo VARCHAR(320),
    p_contrasena VARCHAR(50)
)
RETURNS INTEGER AS $$
DECLARE
    login_count INTEGER;
    administrador_id INTEGER;
BEGIN
    

    SELECT COUNT(*) INTO administrador_id
    FROM Administradores
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
