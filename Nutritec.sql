--CREATE DATABASE nutritec;

CREATE TABLE Administradores (
    ID SERIAL PRIMARY KEY,
    CorreoElectronico VARCHAR(320),
    Contrasena VARCHAR(20)
);



CREATE TABLE Clientes (
    CorreoElectronico VARCHAR(320) PRIMARY KEY,
    Nombre VARCHAR(40),
    Apellido1 VARCHAR(40),
    Apellido2 VARCHAR(40),
    Edad INTEGER,
    FechaNacimiento DATE,
    Peso INTEGER,
    IMC INTEGER,
    PaisResidencia VARCHAR(50),
    ConsumoDiarioCalorias INTEGER,
    Contrasena VARCHAR(50)
);


CREATE TABLE Medidas (
  ID SERIAL PRIMARY KEY,
  ClienteID VARCHAR(320),
  Fecha DATE,
  Cintura INTEGER,
  Cuello INTEGER,
  Caderas INTEGER,
  PorcentajeMusculo INTEGER,
  PorcentajeGrasa INTEGER,
  PesoActual INTEGER
);




CREATE TABLE BitacoraGeneral (
    ID SERIAL PRIMARY KEY,
    ClienteID VARCHAR(320),
    Fecha TIMESTAMP
);






CREATE TABLE EstadoProductos (
    ID SERIAL PRIMARY KEY,
    ProductoID VARCHAR(40),
    FechaAprobacion DATE,
    Estado BOOLEAN
);

CREATE TABLE Nutricionistas (
    Cedula VARCHAR(12) PRIMARY KEY,
    Nombre VARCHAR(40),
    Apellido1 VARCHAR(40),
    Apellido2 VARCHAR(40),
    CododigoBarras VARCHAR(127),
    Edad INTEGER,
    FechaNacimiento DATE,
    Peso INTEGER,
    IMC INTEGER,
    Direccion VARCHAR(200),
    Foto BYTEA,
    NumTarjetaCredito VARCHAR(16),
    TipoCobroID INTEGER,
    CorreoElectronico VARCHAR(320),
    Contrasena VARCHAR(20)
);


CREATE TABLE Pacientes (
    ID SERIAL PRIMARY KEY,
    ClienteID VARCHAR(320),
    NutricionistaID VARCHAR(12)
);



CREATE TABLE PlanesAlimentacion (
    ID SERIAL PRIMARY KEY,
    NombrePlan VARCHAR(40),
    NutricionistaID VARCHAR(12),
    CaloriasTotalPlan INTEGER
);



CREATE TABLE Productos (
    CodigoBarra VARCHAR(40) PRIMARY KEY,
    Nombre VARCHAR(40),
    taman_porcion INTEGER,
    energia INTEGER,
    grasa INTEGER,
    sodio INTEGER,
    carbohidratos INTEGER,
    proteina INTEGER,
    vitaminas VARCHAR(150),
    calcio INTEGER,
    hierro INTEGER,
    descripcion VARCHAR(200),
    EstadoProducto BOOLEAN
);


CREATE TABLE ProductosPlan (
    ID SERIAL PRIMARY KEY,
    ProductoID VARCHAR(40),
    TiempoComidaID INTEGER
);


-- Crear tabla Receta
CREATE TABLE Receta (
  ID SERIAL PRIMARY KEY,
  Nombre VARCHAR(40),
  CaloriasTotalesReceta INTEGER,
  ProductoID VARCHAR(40)
);


-- Crear tabla RegistroDiario
CREATE TABLE RegistroDiario (
  ID SERIAL PRIMARY KEY,
  ClienteID VARCHAR(320),
  TiempoComidaID INTEGER,
  Fecha DATE,
  CantidadComsumida INTEGER,
  ProductoID VARCHAR(40)
);




-- Crear tabla ReporteCobro
CREATE TABLE ReporteCobro (
  ID SERIAL PRIMARY KEY,
  NutricionistaID VARCHAR(50),
  TipoCobroID INTEGER,
  MontoTotal INTEGER,
  Descuento INTEGER,
  MontoCobrar INTEGER
);


-- Crear tabla Retroalimentacion
CREATE TABLE Retroalimentacion (
  ID SERIAL PRIMARY KEY,
  NutricionistaID VARCHAR(12),
  ClienteID VARCHAR(320),
  Fecha DATE,
  Comentario VARCHAR(5000)
 
);



-- Crear tabla TiempoComida
CREATE TABLE TiempoComida (
  ID SERIAL PRIMARY KEY,
  Nombre VARCHAR(40)
);




-- Crear tabla TipoCobro
CREATE TABLE TipoCobro (
  ID SERIAL PRIMARY KEY,
  NombreTipoCobro VARCHAR(20)
);




-- Agregar clave externa a la tabla EstadoProductos
ALTER TABLE EstadoProductos
ADD FOREIGN KEY (ProductoID) REFERENCES Productos(CodigoBarra)
ON DELETE CASCADE;

-- Agregar clave externa a la tabla Nutricionistas
ALTER TABLE Nutricionistas
ADD FOREIGN KEY (TipoCobroID) REFERENCES TipoCobro(ID)
ON DELETE CASCADE;

-- Agregar clave externa a la tabla Pacientes
ALTER TABLE Pacientes
ADD FOREIGN KEY (ClienteID) REFERENCES Clientes(CorreoElectronico)
ON DELETE CASCADE;

ALTER TABLE Pacientes
ADD FOREIGN KEY (NutricionistaID) REFERENCES Nutricionistas(Cedula)
ON DELETE CASCADE;



-- Agregar clave externa a la tabla PlanesAlimentacion
ALTER TABLE PlanesAlimentacion
ADD FOREIGN KEY (NutricionistaID) REFERENCES Nutricionistas(Cedula)
ON DELETE CASCADE;



-- Agregar clave externa a la tabla ProductosPlan
ALTER TABLE ProductosPlan
ADD FOREIGN KEY (ProductoID) REFERENCES Productos(CodigoBarra)
ON DELETE CASCADE;

ALTER TABLE ProductosPlan
ADD FOREIGN KEY (TiempoComidaID) REFERENCES TiempoComida(ID)
ON DELETE CASCADE;



-- Agregar clave externa a la tabla Receta
ALTER TABLE Receta
ADD FOREIGN KEY (ProductoID) REFERENCES Productos(CodigoBarra)
ON DELETE CASCADE;



-- Agregar clave externa a la tabla RegistroDiario
ALTER TABLE RegistroDiario
ADD FOREIGN KEY (ClienteID) REFERENCES Clientes(CorreoElectronico)
ON DELETE CASCADE;

ALTER TABLE RegistroDiario
ADD FOREIGN KEY (TiempoComidaID) REFERENCES TiempoComida(ID)
ON DELETE CASCADE;

ALTER TABLE RegistroDiario
ADD FOREIGN KEY (ProductoID) REFERENCES Productos(CodigoBarra)
ON DELETE CASCADE;

-- Agregar clave externa a la tabla ReporteCobro
ALTER TABLE ReporteCobro
ADD FOREIGN KEY (NutricionistaID) REFERENCES Nutricionistas(Cedula),
ADD FOREIGN KEY (TipoCobroID) REFERENCES TipoCobro(ID)
ON DELETE CASCADE;

-- Agregar clave externa a la tabla Retroalimentacion
ALTER TABLE Retroalimentacion
ADD FOREIGN KEY (NutricionistaID) REFERENCES Nutricionistas(Cedula)
ON DELETE CASCADE;

ALTER TABLE Retroalimentacion
ADD FOREIGN KEY (ClienteID) REFERENCES Clientes(CorreoElectronico)
ON DELETE CASCADE;


--Agregar clave externa a la tabla Medidas
ALTER TABLE Medidas
ADD FOREIGN KEY (ClienteID) REFERENCES Clientes(CorreoElectronico)
ON DELETE CASCADE;

--Agregar clave externa a la tabla BitacoraGeneral
ALTER TABLE BitacoraGeneral
ADD FOREIGN KEY (ClienteID) REFERENCES Clientes(CorreoElectronico)
ON DELETE CASCADE;

-- Insersion de valores de los responsables administradores
INSERT INTO Administradores(CorreoElectronico, Contrasena)
VALUES ('irodriguezcr1@gmail.com', 'admin1234');

INSERT INTO Administradores(CorreoElectronico, Contrasena)
VALUES ('rayo@gmail.com', 'admin1234');