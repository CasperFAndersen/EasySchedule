--WorkPlace
insert into Workplace(name, address, email, phone) 
values('Meny', 'Aabybro Centret 12 9440 Aabybro', 'menyaabybro@meny.dk', '98241966'); 

insert into Workplace(name, address, email, phone) 
values('PostNord Terminal Aalborg', 'Postmestervej 1 9000 Aalborg', 'aalborg@postnord.dk', '70707030'); 

insert into Workplace(name, address, email, phone) 
values('Bilka Skalborg', 'Hobrovej 450 9200 Aalborg SV', 'aalborg@bilka.dk', '98797000');

--Department
insert into Department(name, address, email, phone, workplaceId) 
values ('Kolonial', 'I butikken', 'butik@meny.dk', '98241966', (select id from workplace where name='Meny')); 

insert into Department(name, address, email, phone, workplaceId) 
values ('Pakkecentral', 'Ude bagved', 'pakaalborg@postnord.dk', '70707030', (select id from workplace where name='PostNord Terminal Aalborg')); 

insert into Department(name, address, email, phone, workplaceId) 
values ('Elektronik', 'Tat paa lageret', 'elektronikaalborg@bilka.dk', '70707030', (select id from workplace where name='Bilka Skalborg')); 

--Employee
insert into Employee(name, email, phone, noOfHours, isAdmin, username, password, salt, departmentId, isEmployed) 
values ('Mikkel Paulsen', 'mikkelpaulsen@gmail.com', '12345678', 9, 0, 'MikkelP', '93d3c0e5006d12620470cac6c7b8aa54', 'gtieo',  (select id from department where name='Kolonial'), 1); 

insert into Employee(name, email, phone, noOfHours, isAdmin, username, password, salt, departmentId, isEmployed) 
	values ('Casper Froberg', 'casperfroberg@gmail.com', '87654321', 14, 1, 'FroBro', '0b8d4715792e77e4d79f8c2c59bb7011', 'ffppe', (select id from department where name='Kolonial'), 1); 

insert into Employee(name, email, phone, noOfHours, isAdmin, username, password, salt, departmentId, isEmployed) 
	values ('Arne Ralston', 'arnegr@gmail.com', '23456789', 12, 0, 'ArneGR', 'ce564c92fc36e62b5a3bbd177a16738e', 'epfel', (select id from department where name='PakkeCentral'), 1); 

insert into Employee(name, email, phone, noOfHours, isAdmin, username, password, salt, departmentId, isEmployed) 
	values ('Tobias Andersen', 'tobiasandersen@gmail.com', '98765432', 10, 1, 'TobiAs', 'f37a6ff9c4f3ba758249d75a8bd65120', 'gepge', (select id from department where name='Pakkecentral'), 1); 

insert into Employee(name, email, phone, noOfHours, isAdmin, username, password, salt, departmentId, isEmployed)
values ('Stefan Krabbe', 'stefankrabbe@gmail.com', '12093847', 30, 1, 'SKrabbe', 'a63c6b68454d1b13ea6471f287eba37b', 'fptdv', (select id from department where name='Kolonial'), 1); 


--TemplateSchedule
insert into TemplateSchedule(name, noOfWeeks, departmentId) 
values ('KolonialBasis', 1, (select id from department where name = 'Kolonial')); 

insert into TemplateSchedule(name, noOfWeeks, departmentId) 
values ('PakkeCentralJuletid', 1, (select id from department where name = 'Pakkecentral')); 

--TemplateShift
insert into TemplateShift(weekday, hours, startTime, weekNumber, templateScheduleId, employeeId) 
values ('Tuesday', 10, '06:30:00', 1, (select id from templateSchedule where name='KolonialBasis'), (select id from Employee where name='Mikkel Paulsen')); 

insert into TemplateShift(weekday, hours, startTime, weekNumber, templateScheduleId, employeeId) 
values ('Tuesday', 10, '06:30:00', 1, (select id from templateSchedule where name='PakkeCentralJuletid'), (select id from Employee where name='Tobias Andersen')); 

--Schedule
insert into Schedule(startDate, endDate, departmentId) 
values ('2017-10-30', '2017-12-10', 1); 

insert into Schedule(startDate, endDate,  departmentId) 
values ('2017-11-27', '2017-12-18', 2); 

--Shift
insert into Shift(startTime, hours, scheduleId, employeeId, isForSale) values('2017-11-06 15:00', 5, 1, (select id from employee where name = 'Mikkel Paulsen'), 1); 
insert into shift(starttime, hours, scheduleId, employeeId, isForSale) values('2017-11-24 17:00', 3, 1, (select id from employee where name = 'mikkel paulsen'), 0); 
insert into shift(starttime, hours, scheduleId, employeeId, isForSale) values('2017-11-17 15:00', 5, 1, (select id from employee where name = 'mikkel paulsen'), 0); 
insert into shift(starttime, hours, scheduleId, employeeId, isForSale) values('2017-11-16 12:00', 7, 1, (select id from employee where name = 'mikkel paulsen'), 1); 
insert into Shift(startTime, hours, scheduleId, employeeId, isForSale) values('2017-10-30 09:00', 2, 1, (select id from employee where name = 'Mikkel Paulsen'), 0);
