CREATE DATABASE nutritec;

CREATE TABLE Administradores (
    ID SERIAL PRIMARY KEY,
    CorreoElectronico VARCHAR(320),
    Contrasena VARCHAR(20)
);

CREATE TABLE Clientes (
    ID SERIAL PRIMARY KEY,
    Nombre VARCHAR(40),
    Apellido1 VARCHAR(40),
    Apellido2 VARCHAR(40),
    Edad INTEGER,
    FechaNacimiento DATE,
    Peso INTEGER,
    IMC INTEGER,
    PaisResidencia VARCHAR(50),
    PesoActual INTEGER,
    Cintura INTEGER,
    PorcentajeMusculos INTEGER,
    Cuello INTEGER,
    Caderas INTEGER,
    PorcentajeGrasa INTEGER,
    ConsumoDiarioCalorias INTEGER,
    CorreoElectronico VARCHAR(100),
    Contrasena VARCHAR(50),
    NutricionistaID VARCHAR(12),
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
    ClienteID INTEGER,
    Nombre VARCHAR(40),
    Apellido1 VARCHAR(40),
    Apellido2 VARCHAR(40),
    Edad INTEGER,
    FechaNacimiento DATE,
    Peso INTEGER,
    IMC INTEGER,
    PaisResidencia VARCHAR(50),
    PesoActual INTEGER,
    Cintura INTEGER,
    PorcentajeMusculos INTEGER,
    Cuello INTEGER,
    Caderas INTEGER,
    PorcentajeGrasa INTEGER,
    ConsumoDiarioCalorias INTEGER,
    CorreoElectronico VARCHAR(100),
    Contrasena VARCHAR(50),
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
  ProductoID VARCHAR(40),
);

-- Crear tabla RegistroDiario
CREATE TABLE RegistroDiario (
  ID SERIAL PRIMARY KEY,
  ClienteID INTEGER,
  TiempoComidaID INTEGER,
  Fecha DATE,
  CantidadComsumida INTEGER
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
  ClienteID INTEGER,
  Fecha DATE,
  Comentario VARCHAR(5000)
 
);

-- Crear tabla TiempoComida
CREATE TABLE TiempoComida (
  ID SERIAL PRIMARY KEY,
  Nombre VARCHAR(40),
  PlanAlimentacionID INTEGER
);

-- Crear tabla TipoCobro
CREATE TABLE TipoCobro (
  ID SERIAL PRIMARY KEY,
  NombreTipoCobro VARCHAR(20)
);


-- Agregar clave externa a la tabla Clientes
ALTER TABLE Clientes
ADD FOREIGN KEY (NutricionistaID) REFERENCES Nutricionistas(Cedula);

-- Agregar clave externa a la tabla EstadoProductos
ALTER TABLE EstadoProductos
ADD FOREIGN KEY (ProductoID) REFERENCES Productos(CodigoBarra)

-- Agregar clave externa a la tabla Nutricionistas
ALTER TABLE Nutricionistas
ADD FOREIGN KEY (TipoCobroID) REFERENCES TiposCobro(ID);

-- Agregar clave externa a la tabla Pacientes
ALTER TABLE Pacientes
ADD FOREIGN KEY (ClienteID) REFERENCES Clientes(ID),
ADD FOREIGN KEY (NutricionistaID) REFERENCES Nutricionistas(Cedula);

-- Agregar clave externa a la tabla PlanesAlimentacion
ALTER TABLE PlanesAlimentacion
ADD FOREIGN KEY (NutricionistaID) REFERENCES Nutricionistas(Cedula);

-- Agregar clave externa a la tabla ProductosPlan
ALTER TABLE ProductosPlan
ADD FOREIGN KEY (ProductoID) REFERENCES Productos(CodigoBarra),
ADD FOREIGN KEY (TiempoComidaID) REFERENCES TiemposComida(ID);


-- Agregar clave externa a la tabla Receta
ALTER TABLE Receta
ADD FOREIGN KEY (ProductoID) REFERENCES Productos(CodigoBarra);

-- Agregar clave externa a la tabla RegistroDiario
ALTER TABLE RegistroDiario
ADD FOREIGN KEY (ClienteID) REFERENCES Clientes(ID),
ADD FOREIGN KEY (TiempoComidaID) REFERENCES TiemposComida(ID);

-- Agregar clave externa a la tabla ReporteCobro
ALTER TABLE ReporteCobro
ADD FOREIGN KEY (NutricionistaID) REFERENCES Nutricionistas(Cedula),
ADD FOREIGN KEY (TipoCobroID) REFERENCES TiposCobro(ID);

-- Agregar clave externa a la tabla Retroalimentacion
ALTER TABLE Retroalimentacion
ADD FOREIGN KEY (NutricionistaID) REFERENCES Nutricionistas(Cedula),
ADD FOREIGN KEY (ClienteID) REFERENCES Clientes(ID);

-- Agregar clave externa a la tabla TiempoComida
ALTER TABLE TiempoComida
ADD FOREIGN KEY (PlanAlimentacionID) REFERENCES PlanesAlimentacion(ID);


