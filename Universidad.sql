

drop database universidad
create database universidad
 use universidad

 

 create table Categoria(
 CaterogiaID int   IDENTITY(100,1) primary key, 
 Nombre  varchar (255),
 Descripcion varchar (255),
 Estado Bit )

  create table Tercero (
 TerceroID int primary key,
 Apellido  varchar(40),
 Nombres    varchar(40),
 FechaNacimiento Date, 
 Email varchar (70),
 Telefono varchar(15),
 Direccion  varchar(150),
 Estado bit
 )


create table Curso (
CursoID int IDENTITY(100,1) primary key,
Nombre  varchar(60),
CategoriaID int ,
Descripcion varchar(512),
Creditos int,
Horas  int ,
Costo  DECIMAL(6,2),
Estado BIT
FOREIGN KEY (CategoriaID) REFERENCES Categoria (CaterogiaID ));
 
 
 create table Estudiante (
 EstudianteID  int IDENTITY(1000,1)  primary key ,
 Codigo varchar(20),
 FOREIGN KEY (EstudianteID) REFERENCES Tercero (TerceroID));

create table Inscripcion(
Id_inscripcion Int  IDENTITY(100,1) primary key ,
 Grado varchar(60),
 Id_curso int,
 Id_estudiante int,
 fechar date,
 pago DECIMAL(6,2),
foreign key (Id_estudiante) references Estudiante (EstudianteID),
foreign key (Id_curso) references Curso (CursoID));

  create table Instructor (
  InstructorID  int  IDENTITY(200,1)  primary key,
 Codigo varchar(20),
 FOREIGN KEY (InstructorID) REFERENCES Tercero (TerceroID));



 create table Asignacion(
 Id_Asignacion Int   IDENTITY(300,1)primary key ,
 Id_curso int ,
 Id_instructor int ,
 Fecha date,
 foreign key (Id_curso) references Curso (CursoID),
 foreign key (Id_instructor)references Instructor (InstructorID));



 select * from Categoria

 drop table Tercero
 drop table Categoria
 drop table  Estudiante
  drop table 
   drop table Tercero
 drop table Tercero
    drop table Tercero
