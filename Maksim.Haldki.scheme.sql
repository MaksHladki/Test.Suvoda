use [Maksim.Hladki]
go

create table Country(
Id nvarchar(3) primary key,
Name nvarchar(128) not null
);

create table Depot(
Id int primary key identity(1,1),
Name nvarchar(128) not null,
CountryId nvarchar(3) not null,
constraint FK_Depot_Country foreign key (CountryId)
references Country(Id)
);

create table DrugType(
Id int primary key identity(1,1),
Name nvarchar(128) unique not null
);

create table DrugUnit(
Id nvarchar(128) primary key,
PickNumber int not null default 0,
DrugTypeId int not null,
DepotId int null,
constraint PickNumber_StartValue_Check check(PickNumber >= 0),
constraint FK_DrugUnit_DrugType foreign key (DrugTypeId) references DrugType(Id),
constraint FK_DrugUnit_Depot foreign key (DepotId) references Depot(Id)
);



