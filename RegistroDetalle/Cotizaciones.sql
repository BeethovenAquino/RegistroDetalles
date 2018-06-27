create database CotizacioneDb
GO
Use CotizacioneDb
Create table Articulos
(	
	ArticuloID int primary key identity(1,1),
	Descripcion varchar(max),
	precio int,
	CantidadContizacion int,
	FechaVencimiento datetime
);