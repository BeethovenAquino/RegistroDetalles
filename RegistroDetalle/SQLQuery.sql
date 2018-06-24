create database CotizacionDb
GO
USE CotizacionDb
GO
create table Articulo
(	
	ArticuloID int primary key identity(1,1),
	Descripcion varchar(max),
	precio int,
	CantidadContizacion int,
	FechaVencimiento datetime
);