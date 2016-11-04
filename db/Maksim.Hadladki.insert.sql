use [Maksim.Hladki]
go

insert into [Country] values
	('ROU', 'Romania'),
	('USA', 'United States of America');

go


insert into [Depot] (Name, CountryId) values
	('Depot 1', 'ROU'),
	('Depot 2', 'USA');

go

insert into [DrugType] (Name) values
	('A'),
	('B');

go

IF OBJECT_ID('RandomNumberGenerator') IS NOT NULL
DROP PROC RandomNumberGenerator
go

CREATE procedure  RandomNumberGenerator @Min INT, @Max INT, @Result int output  
AS
BEGIN
    IF NOT (@Min < @Max) RETURN -1
    SELECT @Result = ROUND(((@Max - @Min) * RAND() + @Min), 0)
END

go



declare @RowCount int
declare @DrugTypeId int
declare @PickNumber int
declare @DrugUnitId int
set @RowCount = 0

WHILE @RowCount < 100
BEGIN
	exec RandomNumberGenerator @Min = 1000, @Max = 100000, @Result = @DrugUnitId output;
	exec RandomNumberGenerator @Min = 1, @Max = 2, @Result = @DrugTypeId output;
	exec RandomNumberGenerator @Min = 0, @Max = 10, @Result = @PickNumber output;
	
	--print cast(@DrugUnitId as nvarchar) + '--' + cast(@DrugTypeId as nvarchar) + '--' + cast(@PickNumber as nvarchar);
	
	INSERT INTO DrugUnit (Id,PickNumber,DrugTypeId)
	VALUES (@DrugUnitId,@PickNumber, @DrugTypeId);
		
	SET @RowCount = @RowCount + 1
END