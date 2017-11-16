use dmab0916_1062358;

--Insert Workplaces

insert into Workplace(name, address, email, phone) 
	values ('Meny', 'Aabybro Centret 12 9440 Aabybro', 'menyaabybro@meny.dk', '98241966')
insert into Workplace(name, address, email, phone) 
	values ('PostNord Terminal Aalborg', 'Postmestervej 1 9000 Aalborg', 'aalborg@postnord.dk', '70707030')
insert into Workplace(name, address, email, phone) 
	values ('Bilka Skalborg', 'Hobrovej 450 9200 Aalborg SV', 'aalborg@bilka.dk', '98797000')

--select * from workplace
--------------------------------------

--Insert Departments

insert into Department(name, address, email, phone, workplaceId) 
	values ('Kolonial', 'I butikken', 'butik@meny.dk', '98241966', (select id from workplace where name='Meny'))
insert into Department(name, address, email, phone, workplaceId) 
	values ('Pakkecentral', 'Ude bagved', 'pakaalborg@postnord.dk', '70707030', (select id from workplace where name='PostNord Terminal Aalborg'))
insert into Department(name, address, email, phone, workplaceId) 
	values ('Elektronik', 'Tat paa lageret', 'elektronikaalborg@bilka.dk', '70707030', (select id from workplace where name='Bilka Skalborg'))

--select * from department 
--------------------------------------

--Insert Employee

insert into Employee(name, email, phone, noOfHours, isAdmin, username, password, departmentId)
	values ('Mikkel Paulsen', 'mikkelpaulsen@gmail.com', '12345678', 9, 0, 'MikkelP', 'hardToCrack', (select id from department where name='Kolonial'))
insert into Employee(name, email, phone, noOfHours, isAdmin, username, password, departmentId)
	values ('Casper Froberg', 'casperfroberg@gmail.com', '87654321', 14, 1, 'FroBro', 'hejhej', (select id from department where name='Pakkecentral'))
insert into Employee(name, email, phone, noOfHours, isAdmin, username, password, departmentId)
	values ('Arne Ralston', 'arnegr@gmail.com', '23456789', 12, 0, 'ArneGR', 'JegErUngOgVildEndnu', (select id from department where name='PakkeCentral'))
insert into Employee(name, email, phone, noOfHours, isAdmin, username, password, departmentId)
	values ('Tobias Andersen', 'tobiasandersen@gmail.com', '98765432', 10, 1, 'TobiAs', 'CanYouGuessMyPass', (select id from department where name='Elektronik'))
insert into Employee(name, email, phone, noOfHours, isAdmin, username, password, departmentId)
	values ('Stefan Krabbe', 'stefankrabbe@gmail.com', '12093847', 30, 1, 'SKrabbe', 'ItsaHardHardLife', (select id from department where name='Kolonial'))

--select * from employee
--------------------------------------

--Insert TemplateSchedule

insert into TemplateSchedule(name, noOfWeeks, departmentId) 
	values ('Test', 1, (select id from department where name = 'Kolonial'))

--select * from TemplateSchedule
--------------------------------------

--Insert TemplateShift

insert into TemplateShift(weekday, hours, startTime, templateScheduleId, employeeId)
	values ('Tuesday', 10, '06:30:00', (select id from templateSchedule where name='Test'), (select id from Employee where name='Mikkel Paulsen'))

--select * from TemplateShift
--------------------------------------

--Insert Schedule

insert into Schedule(startDate, templateScheduleId) 
	values ('2017-11-14', (select id from templateSchedule where name='Test'))

--select * from Schedule
--------------------------------------

--Insert Shift

insert into Shift(startTime, hours, scheduleId, employeeId)
	values ('2017-11-15 06:30:00', 6, (select id from schedule where startDate='2017-11-14'), (select id from employee where name='Mikkel Paulsen'))

--select * from Shift
