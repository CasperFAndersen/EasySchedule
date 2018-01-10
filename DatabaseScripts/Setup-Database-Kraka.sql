use dmab0916_1062358;

--WorkPlace
create table Workplace(
    id int primary key identity(1,1),
    name varchar(50) not null,
    address varchar(100) not null,
    email varchar(70) not null,
    phone varchar(20) not null,
    constraint ck_phoneLengthOnWorkplace check(datalength(phone) >= 8),
)

--Department
create table Department(
    id int primary key identity(1,1),
    name varchar(50) not null,
    address varchar(100) not null,
    email varchar(70) not null,
    phone varchar(20) not null,
    workplaceId int foreign key references Workplace(id) not null,
    constraint ck_phoneLengthOnDepartment check(datalength(phone) >= 8),
)

--Employee
create table Employee(
    id int primary key identity(1,1),
    name varchar(50) not null,
    email varchar(70) not null,
    phone varchar(20) not null,
    noOfHours float not null,
    isAdmin bit not null,
    username varchar(40) not null unique,
    password varchar(40) not null,
    salt varchar(40) not null, 
    departmentId int foreign key references Department(id) not null,
    isEmployed bit not null,
    RV rowversion, 
    constraint ck_noOfHours_positive check(noOfHours >= 0),
    constraint ck_passwordLength check(datalength(password) >= 6)
)

--TemplateSchedule
create table TemplateSchedule(
    id int primary key identity(1,1),
    name varchar(50) not null,
    noOfWeeks int not null,
    departmentId int foreign key references Department(id),
    RV rowversion, 
    constraint ck_noOfWeeks_positive check(noOfWeeks >= 0),
)

--TemplateShift
create table TemplateShift(
    id int primary key identity(1,1),
    weekday varchar(10) not null,
    hours float not null,
    startTime time not null,
    weekNumber int not null,
    templateScheduleId int foreign key references TemplateSchedule(id),
    employeeId int foreign key references Employee(id),
    constraint ck_hoursTemplateShift_positive check(hours >= 0),
    constraint ck_weekNumber_positive check(weekNumber >= 0),
)

--Schedule
create table Schedule(
    id int primary key identity(1,1),
    startDate datetime not null,
    endDate datetime not null,
    departmentId int foreign key references Department(id),
    constraint ck_startBeforeEnd check(startDate <= endDate),
    constraint CK_Schedule_ValidateDates 
     check(dbo.ValidateEZScheduleDates(startDate, endDate, departmentId) = 1)
)

--Shift
create table ScheduleShift(
    id int primary key identity(1,1),
    startTime smalldatetime not null,
    hours float not null,
    scheduleId int foreign key references Schedule(id) not null,
    employeeId int foreign key references Employee(id) not null,
    isForSale bit not null,
    RV rowversion, 
    constraint ck_hoursShift_positive check(hours >= 0),
);
