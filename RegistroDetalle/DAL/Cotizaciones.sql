create database CotizacioneDb
GO
Use CotizacioneDb
drop table Articulos
Create table Articulos
(	

	 ArticuloID int primary key identity(1,1),
       Nombre varchar(30),
       Descripcion varchar(max),
       Precio int,
       CantidadCotizada int,
       FehaVencimiento datetime
);
select * from Articulos

drop table Personas
create table Personas
(
	 PersonaID int primary key identity(1,1),
         Fecha datetime,
        Nombre varchar(30),
         Cedula varchar(15),
        Telefono varchar(15),
        Direccion varchar(max)
	
);

create table Cotizaciones(

  CotizacionId int primary key identity(1,1),
        Fecha datetime,
         Observaciones varchar(max),
        Monto int

);
drop table DetalleCotizacion
lo mismo viejo, no hiciste nada
create table DetalleCotizacions(
 ID int primary key identity(1,1),
       CotizacionID int,
         PersonaID int,
        ArticuloID int,
        Cantidad int,
         Precio int,
        Importe int,
        Descripcion varchar(max)

);
