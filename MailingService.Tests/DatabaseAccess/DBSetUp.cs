using System;
using System.Data.SqlClient;
using DatabaseAccess;

namespace Tests.DatabaseAccess
{
    public class DBSetUp
    {

        public static string startTimeWeek1;

        public static void SetUpDB()
        {
            startTimeWeek1 = GetCurrentStartTimeStringPlusDay(0);

            DropTables();
            CreateTables();
            InsertTestData();
        }

        public static string GetCurrentStartTimeStringPlusDay(int numOfDays)
        {
            DateTime currentDate = DateTime.Now;
            int day = (currentDate.DayOfWeek == DayOfWeek.Sunday) ? (currentDate.Day - 6) : (currentDate.Day - ((int)currentDate.DayOfWeek - 1));
            if (numOfDays < 5 && numOfDays > 0)
            {
                day += numOfDays;
            }

            return string.Format("{0}-{1}-{2}", currentDate.Year.ToString(), currentDate.Month.ToString(), day);
        }

        public static void DropTables()
        {

            using (SqlConnection conn = new DbConnectionADO().GetConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "drop table Shift; " +
                                      "drop table Schedule; " +
                                      "drop table TemplateShift; " +
                                      "drop table TemplateSchedule; " +
                                      "drop table Employee; " +
                                      "drop table Department; " +
                                      "drop table Workplace;";

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public static void CreateTables()
        {
            using (SqlConnection conn = new DbConnectionADO().GetConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = ""
                                      +

                                      //WorkPlace
                                      "create table Workplace(" +
                                      "id int primary key identity(1,1), " +
                                      "name varchar(50) not null, " +
                                      "address varchar(50) not null, " +
                                      "email varchar(50) not null, " +
                                      "phone varchar(20) not null); "

                                      +
                                      //Department
                                      "create table Department(" +
                                      "id int primary key identity(1,1), " +
                                      "name varchar(50) not null, " +
                                      "address varchar(50) not null, " +
                                      "email varchar(50) not null, " +
                                      "phone varchar(20) not null, " +
                                      "workplaceId int foreign key references Workplace(id)); "

                                      +
                                      //Employee
                                      "create table Employee(" +
                                      "id int primary key identity(1,1), " +
                                      "name varchar(50) not null, " +
                                      "email varchar(50) not null, " +
                                      "phone varchar(20) not null, " +
                                      "noOfHours float, " +
                                      "isAdmin bit, " +
                                      "username varchar(40), " +
                                      "password varchar(40), " +
                                      "departmentId int foreign key references Department(id), " +
                                      "isEmployed bit not null); "

                                      +
                                      //TemplateSchedule
                                      "create table TemplateSchedule(" +
                                      "id int primary key identity(1,1), " +
                                      "name varchar(50) not null, " +
                                      "noOfWeeks int, " +
                                      "departmentId int foreign key references Department(id)); "

                                      +
                                      //TemplateShift
                                      "create table TemplateShift(" +
                                      "id int primary key identity(1,1), " +
                                      "weekday varchar(20), " +
                                      "hours float, " +
                                      "startTime time, " +
                                      "weekNumber int, " +
                                      "templateScheduleId int foreign key references TemplateSchedule(id), " +
                                      "employeeId int foreign key references Employee(id)); "

                                      +
                                      //Schedule
                                      "create table Schedule(" +
                                      "id int primary key identity(1,1), " +
                                      "startDate datetime, " +
                                      "endDate datetime, " +
                                    //  "templateScheduleId int foreign key references TemplateSchedule(id), " +
                                      "departmentId int foreign key references Department(id)); "

                                      +
                                      //Shift
                                      "create table Shift(" +
                                      "id int primary key identity(1,1), " +
                                      "startTime smalldatetime, " +
                                      "hours float, " +
                                      "scheduleId int foreign key references Schedule(id), " +
                                      "employeeId int foreign key references Employee(id)); ";


                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void InsertTestData()
        {
            using (SqlConnection conn = new DbConnectionADO().GetConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = ""
                                      +
                                      //WorkPlace
                                      "insert into Workplace(name, address, email, phone) " +
                                      "values('Meny', 'Aabybro Centret 12 9440 Aabybro', 'menyaabybro@meny.dk', '98241966'); " +

                                      "insert into Workplace(name, address, email, phone) " +
                                      "values('PostNord Terminal Aalborg', 'Postmestervej 1 9000 Aalborg', 'aalborg@postnord.dk', '70707030'); " +

                                      "insert into Workplace(name, address, email, phone) " +
                                      "values('Bilka Skalborg', 'Hobrovej 450 9200 Aalborg SV', 'aalborg@bilka.dk', '98797000');"

                                      +
                                      //Department
                                      "insert into Department(name, address, email, phone, workplaceId) " +
                                      "values ('Kolonial', 'I butikken', 'butik@meny.dk', '98241966', (select id from workplace where name='Meny')); " +

                                      "insert into Department(name, address, email, phone, workplaceId) " +
                                      "values ('Pakkecentral', 'Ude bagved', 'pakaalborg@postnord.dk', '70707030', (select id from workplace where name='PostNord Terminal Aalborg')); " +

                                      "insert into Department(name, address, email, phone, workplaceId) " +
                                      "values ('Elektronik', 'Tat paa lageret', 'elektronikaalborg@bilka.dk', '70707030', (select id from workplace where name='Bilka Skalborg')); "

                                      +
                                      //Employee
                                      "insert into Employee(name, email, phone, noOfHours, isAdmin, username, password, departmentId, isEmployed) " +
                                      "values ('Mikkel Paulsen', 'mikkelpaulsen@gmail.com', '12345678', 9, 0, 'MikkelP', 'hardToCrack', (select id from department where name='Kolonial'), 1); " +

                                      "insert into Employee(name, email, phone, noOfHours, isAdmin, username, password, departmentId, isEmployed) " +
                                      "	values ('Casper Froberg', 'casperfroberg@gmail.com', '87654321', 14, 1, 'FroBro', 'hejhej', (select id from department where name='Kolonial'), 1); " +

                                      "insert into Employee(name, email, phone, noOfHours, isAdmin, username, password, departmentId, isEmployed) " +
                                      "	values ('Arne Ralston', 'arnegr@gmail.com', '23456789', 12, 0, 'ArneGR', 'JegErUngOgVildEndnu', (select id from department where name='PakkeCentral'), 1); " +

                                      "insert into Employee(name, email, phone, noOfHours, isAdmin, username, password, departmentId, isEmployed) " +
                                      "	values ('Tobias Andersen', 'tobiasandersen@gmail.com', '98765432', 10, 1, 'TobiAs', 'CanYouGuessMyPass', (select id from department where name='Pakkecentral'), 1); " +

                                      "insert into Employee(name, email, phone, noOfHours, isAdmin, username, password, departmentId, isEmployed)" +
                                      "values ('Stefan Krabbe', 'stefankrabbe@gmail.com', '12093847', 30, 1, 'SKrabbe', 'ItsaHardHardLife', (select id from department where name='Kolonial'), 1); "

                                      +
                                      //TemplateSchedule
                                      "insert into TemplateSchedule(name, noOfWeeks, departmentId) " +
                                      "values ('KolonialBasis', 1, (select id from department where name = 'Kolonial')); " +

                                      "insert into TemplateSchedule(name, noOfWeeks, departmentId) " +
                                      "values ('PakkeCentralJuletid', 1, (select id from department where name = 'Pakkecentral')); "

                                      +
                                      //TemplateShift
                                      "insert into TemplateShift(weekday, hours, startTime, weekNumber, templateScheduleId, employeeId) " +
                                      "values ('Tuesday', 10, '06:30:00', 1, (select id from templateSchedule where name='KolonialBasis'), (select id from Employee where name='Mikkel Paulsen')); "
                                      + 
                                      "insert into TemplateShift(weekday, hours, startTime, weekNumber, templateScheduleId, employeeId) " +
                                      "values ('Tuesday', 10, '06:30:00', 1, (select id from templateSchedule where name='PakkeCentralJuletid'), (select id from Employee where name='Tobias Andersen')); "

                                      +
                                      //Schedule
                                      "insert into Schedule(startDate, endDate, departmentId) " +
                                      "values ('2017-10-30', '2017-11-26', 1); " +

                                      "insert into Schedule(startDate, endDate,  departmentId) " +
                                      "values ('2017-11-27', '2017-12-18', 2); "

                                      +
                                      //Shift
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" +
                                      "values ('2017-10-30 08:00', 6, 1, (select id from employee where name='Mikkel Paulsen')); " +

                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" +
                                      "values ('2017-10-31 09:00', 4, 1, (select id from employee where name='Stefan Krabbe')); " +

                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" +
                                      "values ('2017-11-1 10:00', 8, 1, (select id from employee where name='Casper Froberg')); " +

                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" +
                                      "values ('2017-11-27 12:00', 4, 2, (select id from employee where name='Arne Ralston')); " +

                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" +
                                      "values ('2017-11-28 14:00', 7, 2, (select id from employee where name='Tobias Andersen')); " +

                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-05 15:00', 1, 1,  (select id from employee where name = 'Mikkel Paulsen')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-25 17:00', 3, 2,  (select id from employee where name = 'Mikkel Paulsen')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-17 15:00', 5, 1,  (select id from employee where name = 'Mikkel Paulsen')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-16 12:00', 7, 2,  (select id from employee where name = 'Mikkel Paulsen')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-12-08 09:00', 1, 1,  (select id from employee where name = 'Mikkel Paulsen')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-19 16:00', 9, 1,  (select id from employee where name = 'Mikkel Paulsen')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-09 10:00', 3, 2,  (select id from employee where name = 'Mikkel Paulsen')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-01 16:00', 4, 2, (select id from employee where name = 'Mikkel Paulsen')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-18 15:00', 5, 2,  (select id from employee where name = 'Mikkel Paulsen')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-25 08:00', 12, 2, (select id from employee where name = 'Mikkel Paulsen')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-12-05 08:00', 8, 2,  (select id from employee where name = 'Mikkel Paulsen')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-12-17 13:00', 3, 1,  (select id from employee where name = 'Mikkel Paulsen')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-12-12 11:00', 8, 1, (select id from employee where name = 'Mikkel Paulsen')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-02 07:00', 9, 1, (select id from employee where name = 'Mikkel Paulsen')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-04 17:00', 1, 1,  (select id from employee where name = 'Mikkel Paulsen')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-12-17 10:00', 5, 2,  (select id from employee where name = 'Mikkel Paulsen')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-12-07 14:00', 6, 1,  (select id from employee where name = 'Mikkel Paulsen')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-20 16:00', 1, 2,  (select id from employee where name = 'Mikkel Paulsen')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-25 13:00', 7, 1, (select id from employee where name = 'Mikkel Paulsen')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-12-05 14:00', 4, 2,  (select id from employee where name = 'Mikkel Paulsen')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-12-06 11:00', 7, 2, (select id from employee where name = 'Mikkel Paulsen')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-06 14:00', 6, 1, (select id from employee where name = 'Stefan Krabbe')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-16 15:00', 5, 2,  (select id from employee where name = 'Stefan Krabbe')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-06 15:00', 3, 2, (select id from employee where name = 'Stefan Krabbe')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-03 06:00', 10, 1,  (select id from employee where name = 'Stefan Krabbe')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-29 10:00', 8, 2, (select id from employee where name = 'Stefan Krabbe')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-12-27 07:00', 8, 2,  (select id from employee where name = 'Stefan Krabbe')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-22 07:00', 7, 2,  (select id from employee where name = 'Stefan Krabbe')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-12-14 09:00', 4, 1,  (select id from employee where name = 'Stefan Krabbe')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-12 08:00', 6, 2,  (select id from employee where name = 'Stefan Krabbe')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-21 16:00', 4, 2,  (select id from employee where name = 'Stefan Krabbe')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-06 06:00', 6, 1,  (select id from employee where name = 'Stefan Krabbe')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-17 08:00', 4, 1,  (select id from employee where name = 'Stefan Krabbe')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-30 10:00', 8, 2, (select id from employee where name = 'Stefan Krabbe')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-12-02 17:00', 3, 1,  (select id from employee where name = 'Stefan Krabbe')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-09 10:00', 6, 2,  (select id from employee where name = 'Stefan Krabbe')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-25 08:00', 9, 1,  (select id from employee where name = 'Stefan Krabbe')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-18 08:00', 6, 1,  (select id from employee where name = 'Stefan Krabbe')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-12-10 17:00', 3, 2,  (select id from employee where name = 'Stefan Krabbe')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-26 12:00', 8, 2,  (select id from employee where name = 'Stefan Krabbe')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-05 15:00', 5, 2,  (select id from employee where name = 'Stefan Krabbe')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-29 16:00', 4, 1, (select id from employee where name = 'Casper Froberg')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-10 16:00', 4, 1,  (select id from employee where name = 'Casper Froberg')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-12-03 14:00', 6, 2,  (select id from employee where name = 'Casper Froberg')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-12-17 13:00', 7, 2, (select id from employee where name = 'Casper Froberg')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-17 17:00', 3, 1,  (select id from employee where name = 'Casper Froberg')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-16 08:00', 8, 1,  (select id from employee where name = 'Casper Froberg')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-12 14:00', 6, 2,  (select id from employee where name = 'Casper Froberg')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-24 14:00', 4, 1,  (select id from employee where name = 'Casper Froberg')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-12-14 15:00', 5, 1, (select id from employee where name = 'Casper Froberg')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-22 15:00', 3, 1,  (select id from employee where name = 'Casper Froberg')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-03 10:00', 8, 1,  (select id from employee where name = 'Casper Froberg')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-13 09:00', 6, 2,  (select id from employee where name = 'Casper Froberg')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-12-16 17:00', 3, 2,  (select id from employee where name = 'Casper Froberg')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-16 13:00', 6, 2, (select id from employee where name = 'Casper Froberg')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-12-22 11:00', 7, 1,  (select id from employee where name = 'Casper Froberg')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-23 11:00', 6, 2,  (select id from employee where name = 'Casper Froberg')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-12-05 15:00', 4, 1,  (select id from employee where name = 'Casper Froberg')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-12-29 15:00', 2, 1,  (select id from employee where name = 'Casper Froberg')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-20 10:00', 4, 1,  (select id from employee where name = 'Casper Froberg')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-18 07:00', 9, 2,  (select id from employee where name = 'Casper Froberg')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-29 11:00', 5, 1, (select id from employee where name = 'Arne Ralston')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-01 10:00', 10, 1, (select id from employee where name = 'Arne Ralston')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-04 17:00', 3, 1, (select id from employee where name = 'Arne Ralston')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-23 15:00', 3, 1,  (select id from employee where name = 'Arne Ralston')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-09 11:00', 7, 2,  (select id from employee where name = 'Arne Ralston')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-12-08 09:00', 7, 1,  (select id from employee where name = 'Arne Ralston')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-09 17:00', 3, 2,  (select id from employee where name = 'Arne Ralston')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-28 10:00', 5, 2,  (select id from employee where name = 'Arne Ralston')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-29 09:00', 6, 1,  (select id from employee where name = 'Arne Ralston')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-12-24 11:00', 6, 1,  (select id from employee where name = 'Arne Ralston')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-12-19 17:00', 3, 2,  (select id from employee where name = 'Arne Ralston')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-07 08:00', 7, 1,  (select id from employee where name = 'Arne Ralston')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-12-06 06:00', 5, 1,  (select id from employee where name = 'Arne Ralston')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-26 08:00', 10, 1, (select id from employee where name = 'Arne Ralston')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-04 09:00', 6, 1,  (select id from employee where name = 'Arne Ralston')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-08 17:00', 3, 2,  (select id from employee where name = 'Arne Ralston')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-13 13:00', 6, 1,  (select id from employee where name = 'Arne Ralston')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-30 15:00', 5, 1,  (select id from employee where name = 'Arne Ralston')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-28 12:00', 8, 2, (select id from employee where name = 'Arne Ralston')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-12-06 11:00', 6, 1,  (select id from employee where name = 'Arne Ralston')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-14 14:00', 6, 2,  (select id from employee where name = 'Tobias Andersen')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-12-19 10:00', 9, 1,  (select id from employee where name = 'Tobias Andersen')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-15 14:00', 4, 1,  (select id from employee where name = 'Tobias Andersen')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-06 11:00', 7, 2,  (select id from employee where name = 'Tobias Andersen')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-12-09 16:00', 4, 2, (select id from employee where name = 'Tobias Andersen')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-03 09:00', 3, 1,  (select id from employee where name = 'Tobias Andersen')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-12-06 09:00', 3, 2,  (select id from employee where name = 'Tobias Andersen')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-21 12:00', 3, 2,  (select id from employee where name = 'Tobias Andersen')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-19 16:00', 4, 2,  (select id from employee where name = 'Tobias Andersen')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-06 09:00', 9, 2, (select id from employee where name = 'Tobias Andersen')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-12-03 11:00', 7, 1,  (select id from employee where name = 'Tobias Andersen')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-28 16:00', 4, 2,  (select id from employee where name = 'Tobias Andersen')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-15 16:00', 3, 2, (select id from employee where name = 'Tobias Andersen')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-17 14:00', 4, 2,  (select id from employee where name = 'Tobias Andersen')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-01 15:00', 5, 1, (select id from employee where name = 'Tobias Andersen')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-12-19 13:00', 4, 1,  (select id from employee where name = 'Tobias Andersen')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-24 09:00', 7, 2,  (select id from employee where name = 'Tobias Andersen')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-12-07 07:00', 10, 1, (select id from employee where name = 'Tobias Andersen')); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-04 12:00', 8, 2,  (select id from employee where name = 'Tobias Andersen')); ";


                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
