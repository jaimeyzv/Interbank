create database Intercorp
go

use Intercorp
go

create table [dbo].[Client]
(
	ClientId	int identity(1, 1) not null,
	Name		varchar(50) not null,
	Lastname	varchar(50) not null,
	Age			int not null,
	Birthday	date not null
);
go

Select * from [dbo].[Client]