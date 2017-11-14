use dmab0916_1062358;

create table Workplace(
	id int primary key identity(1,1),
	name varchar(50) not null,
	address varchar(50) not null,
	email varchar(50) not null,
	phone varchar(20) not null
)

create table Department(
	id int primary key identity(1,1),
	name varchar(50) not null,
	address varchar(50) not null,
	email varchar(50) not null,
	phone varchar(20) not null,
	workplaceId int foreign key references Workplace(id)
)

create table Employee(
	id int primary key identity(1,1),
	name varchar(50) not null,
	email varchar(50) not null,
	phone varchar(20) not null,
	noOfHours float,
	isAdmin bit,
	username varchar(40),
	password varchar(40),
	departmentId int foreign key references Department(id) 
)

create table TemplateSchedule(
	id int primary key identity(1,1),
	name varchar(50) not null,
	noOfWeeks int,
	departmentId int foreign key references Department(id) 
)

create table TemplateShift(
	id int primary key identity(1,1),
	weekNumber int,
	hours float, 
	startTime time,
	templateScheduleId int foreign key references TemplateSchedule(id),
	employeeId int foreign key references Employee(id) 
)

create table Schedule(
	id int primary key identity(1,1),
	startDate smalldatetime,
	templateScheduleId int foreign key references TemplateSchedule(id)
)

create table Shift(
	id int primary key identity(1,1),
	date date,
	hours float,
	startTime time,
	scheduleId int foreign key references Schedule(id),
	employeeId int foreign key references Employee(id)
)
