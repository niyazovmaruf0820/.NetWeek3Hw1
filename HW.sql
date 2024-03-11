create table Customers
(
	Id serial primary key,
	Name varchar
);


create table Orders
(
	Id serial primary key,
	CustomerId int references Customers(Id),
	Total decimal
);

create table Menu
(
	Id serial primary key,
	FoodName varchar,
	Price decimal
);

create table OrderItems
(
	Id serial primary key,
	OrderId int references Orders(Id),
	MenuId int references Menu(Id),
	Quantity int,
	UnitPrice decimal
);

