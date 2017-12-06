using System;
using System.Data.SqlClient;
using DatabaseAccess;

namespace Tests.DatabaseAccess
{
    public class DbSetUp
    {
        public static void SetUpDb()
        {
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

            return string.Format("{0}-{1}-{2}", currentDate.Year, currentDate.Month, day);
        }

        public static void DropTables()
        {

            using (SqlConnection connection = new DbConnection().GetConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "drop table Shift; " +
                                      "drop table Schedule; " +
                                      "drop table TemplateShift; " +
                                      "drop table TemplateSchedule; " +
                                      "drop table Employee; " +
                                      "drop table Department; " +
                                      "drop table Workplace;";

                    command.ExecuteNonQuery();

                }
            }
        }

        public static void CreateTables()
        {
            using (SqlConnection connection = new DbConnection().GetConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText =
                        //WorkPlace
                        "create table Workplace(" +
                        "id int primary key identity(1,1)," +
                        "name varchar(50) not null," +
                        "address varchar(100) not null," +
                        "email varchar(70) not null," +
                        "phone varchar(20) not null," +
                        "constraint ck_phoneLengthOnWorkplace check(datalength(phone) >= 8)," +
                        ")"
                        +
                        //Department
                        "create table Department(" +
                        "id int primary key identity(1,1)," +
                        "name varchar(50) not null," +
                        "address varchar(100) not null," +
                        "email varchar(70) not null," +
                        "phone varchar(20) not null," +
                        "workplaceId int foreign key references Workplace(id) not null," +
                        "constraint ck_phoneLengthOnDepartment check(datalength(phone) >= 8)," +
                        ")"
                        +
                        //Employee
                        "create table Employee(" +
                        "id int primary key identity(1,1)," +
                        "name varchar(50) not null," +
                        "email varchar(70) not null," +
                        "phone varchar(20) not null," +
                        "noOfHours float not null," +
                        "isAdmin bit not null," +
                        "username varchar(40) not null," +
                        "salt varchar(20) not null," +
                        "password varchar(40) not null," +
                        "departmentId int foreign key references Department(id) not null," +
                        "isEmployed bit not null," +
                        "constraint ck_noOfHours_positive check(noOfHours >= 0)," +
                        "constraint ck_passwordLength check(datalength(password) >= 6)" +
                        ")"
                        +
                        //TemplateSchedule
                        "create table TemplateSchedule(" +
                        "id int primary key identity(1,1)," +
                        "name varchar(50) not null," +
                        "noOfWeeks int not null," +
                        "departmentId int foreign key references Department(id)," +
                        "constraint ck_noOfWeeks_positive check(noOfWeeks >= 0)," +
                        ")"
                        +
                        //TemplateShift
                        "create table TemplateShift(" +
                        "id int primary key identity(1,1)," +
                        "weekday varchar(10) not null," +
                        "hours float not null," +
                        "startTime time not null," +
                        "weekNumber int not null," +
                        "templateScheduleId int foreign key references TemplateSchedule(id)," +
                        "employeeId int foreign key references Employee(id)," +
                        "constraint ck_hoursTemplateShift_positive check(hours >= 0)," +
                        "constraint ck_weekNumber_positive check(weekNumber >= 0)," +
                        ")"
                        +
                        //Schedule
                        "create table Schedule(" +
                        "id int primary key identity(1,1)," +
                        "startDate datetime not null," +
                        "endDate datetime not null," +
                        "departmentId int foreign key references Department(id)," +
                        "constraint ck_startBeforeEnd check(startDate <= endDate)," +
                        ")"
                        +
                        //Shift
                        "create table Shift(" +
                            "id int primary key identity(1,1)," +
                            "startTime smalldatetime not null," +
                            "hours float not null," +
                            "scheduleId int foreign key references Schedule(id) not null," +
                            "employeeId int foreign key references Employee(id) not null," +
                            "isForSale bit not null," +
                            "constraint ck_hoursShift_positive check(hours >= 0)," +
                        ")";

                    command.ExecuteNonQuery();
                }
            }
        }

        public static void InsertTestData()
        {
            using (SqlConnection connection = new DbConnection().GetConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText =
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
                                      "insert into Employee(name, email, phone, noOfHours, isAdmin, username, password, salt, departmentId, isEmployed) " +
                                      "values ('Mikkel Paulsen', 'mikkelpaulsen@gmail.com', '12345678', 9, 0, 'MikkelP', '93d3c0e5006d12620470cac6c7b8aa54', 'gtieo',  (select id from department where name='Kolonial'), 1); " +

                                      "insert into Employee(name, email, phone, noOfHours, isAdmin, username, password, salt, departmentId, isEmployed) " +
                                      "	values ('Casper Froberg', 'casperfroberg@gmail.com', '87654321', 14, 1, 'FroBro', '0b8d4715792e77e4d79f8c2c59bb7011', 'ffppe', (select id from department where name='Kolonial'), 1); " +

                                      "insert into Employee(name, email, phone, noOfHours, isAdmin, username, password, salt, departmentId, isEmployed) " +
                                      "	values ('Arne Ralston', 'arnegr@gmail.com', '23456789', 12, 0, 'ArneGR', 'ce564c92fc36e62b5a3bbd177a16738e', 'epfel', (select id from department where name='PakkeCentral'), 1); " +

                                      "insert into Employee(name, email, phone, noOfHours, isAdmin, username, password, salt, departmentId, isEmployed) " +
                                      "	values ('Tobias Andersen', 'tobiasandersen@gmail.com', '98765432', 10, 1, 'TobiAs', 'f37a6ff9c4f3ba758249d75a8bd65120', 'gepge', (select id from department where name='Pakkecentral'), 1); " +

                                      "insert into Employee(name, email, phone, noOfHours, isAdmin, username, password, salt, departmentId, isEmployed)" +
                                      "values ('Stefan Krabbe', 'stefankrabbe@gmail.com', '12093847', 30, 1, 'SKrabbe', 'a63c6b68454d1b13ea6471f287eba37b', 'fptdv', (select id from department where name='Kolonial'), 1); "

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
                                      "values ('2017-10-30', '2017-12-10', 1); " +

                                      "insert into Schedule(startDate, endDate,  departmentId) " +
                                      "values ('2017-11-27', '2017-12-18', 2); "
                                      +
                                      //Shift

                                      "insert into Shift(startTime, hours, scheduleId, employeeId, isForSale)" + " values('2017-11-06 15:00', 5, 1,  (select id from employee where name = 'Mikkel Paulsen'), 1); " +
                                      "insert into shift(starttime, hours, scheduleid, employeeid, isForSale)" + " values('2017-11-24 17:00', 3, 1,  (select id from employee where name = 'mikkel paulsen'), 0); " +
                                      "insert into shift(starttime, hours, scheduleid, employeeid, isForSale)" + " values('2017-11-17 15:00', 5, 1,  (select id from employee where name = 'mikkel paulsen'), 0); " +
                                      "insert into shift(starttime, hours, scheduleid, employeeid, isForSale)" + " values('2017-11-16 12:00', 7, 1,  (select id from employee where name = 'mikkel paulsen'), 1); " +
                                      "insert into Shift(startTime, hours, scheduleId, employeeId, isForSale)" + " values('2017-10-30 09:00', 2, 1,  (select id from employee where name = 'Mikkel Paulsen'), 0); ";
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-19 16:00', 9, 1,  (select id from employee where name = 'Mikkel Paulsen')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-09 10:00', 3, 1,  (select id from employee where name = 'Mikkel Paulsen')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-01 16:00', 4, 1, (select id from employee where name = 'Mikkel Paulsen')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-18 15:00', 5, 1,  (select id from employee where name = 'Mikkel Paulsen')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-25 08:00', 12, 1, (select id from employee where name = 'Mikkel Paulsen')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-05 08:00', 8, 1,  (select id from employee where name = 'Mikkel Paulsen')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-17 13:00', 3, 1,  (select id from employee where name = 'Mikkel Paulsen')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-12 11:00', 8, 1, (select id from employee where name = 'Mikkel Paulsen')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-02 07:00', 9, 1, (select id from employee where name = 'Mikkel Paulsen')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-04 17:00', 1, 1,  (select id from employee where name = 'Mikkel Paulsen')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-17 10:00', 5, 1,  (select id from employee where name = 'Mikkel Paulsen')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-07 14:00', 6, 1,  (select id from employee where name = 'Mikkel Paulsen')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-20 16:00', 1, 1,  (select id from employee where name = 'Mikkel Paulsen')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-25 13:00', 7, 1, (select id from employee where name = 'Mikkel Paulsen')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-05 14:00', 4, 1,  (select id from employee where name = 'Mikkel Paulsen')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-06 11:00', 7, 1, (select id from employee where name = 'Mikkel Paulsen')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-06 14:00', 6, 1, (select id from employee where name = 'Stefan Krabbe')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-16 15:00', 5, 1,  (select id from employee where name = 'Stefan Krabbe')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-06 15:00', 3, 1, (select id from employee where name = 'Stefan Krabbe')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-03 06:00', 10, 1,  (select id from employee where name = 'Stefan Krabbe')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-29 10:00', 8, 1, (select id from employee where name = 'Stefan Krabbe')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-26 07:00', 8, 1,  (select id from employee where name = 'Stefan Krabbe')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-22 07:00', 7, 1,  (select id from employee where name = 'Stefan Krabbe')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-14 09:00', 4, 1,  (select id from employee where name = 'Stefan Krabbe')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-12 08:00', 6, 1,  (select id from employee where name = 'Stefan Krabbe')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-21 16:00', 4, 1,  (select id from employee where name = 'Stefan Krabbe')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-06 06:00', 6, 1,  (select id from employee where name = 'Stefan Krabbe')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-17 08:00', 4, 1,  (select id from employee where name = 'Stefan Krabbe')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-25 10:00', 8, 1, (select id from employee where name = 'Stefan Krabbe')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-02 17:00', 3, 1,  (select id from employee where name = 'Stefan Krabbe')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-09 10:00', 6, 1,  (select id from employee where name = 'Stefan Krabbe')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-25 08:00', 9, 1,  (select id from employee where name = 'Stefan Krabbe')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-18 08:00', 6, 1,  (select id from employee where name = 'Stefan Krabbe')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-10 17:00', 3, 1,  (select id from employee where name = 'Stefan Krabbe')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-26 12:00', 8, 1,  (select id from employee where name = 'Stefan Krabbe')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-05 15:00', 5, 1,  (select id from employee where name = 'Stefan Krabbe')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-29 16:00', 4, 1, (select id from employee where name = 'Casper Froberg')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-10 16:00', 4, 1,  (select id from employee where name = 'Casper Froberg')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-03 14:00', 6, 1,  (select id from employee where name = 'Casper Froberg')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-17 13:00', 7, 1, (select id from employee where name = 'Casper Froberg')); ";
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-17 17:00', 3, 1,  (select id from employee where name = 'Casper Froberg')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-16 08:00', 8, 1,  (select id from employee where name = 'Casper Froberg')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-12 14:00', 6, 1,  (select id from employee where name = 'Casper Froberg')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-24 14:00', 4, 1,  (select id from employee where name = 'Casper Froberg')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-14 15:00', 5, 1, (select id from employee where name = 'Casper Froberg')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-22 15:00', 3, 1,  (select id from employee where name = 'Casper Froberg')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-03 10:00', 8, 1,  (select id from employee where name = 'Casper Froberg')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-13 09:00', 6, 1,  (select id from employee where name = 'Casper Froberg')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-16 17:00', 3, 1,  (select id from employee where name = 'Casper Froberg')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-16 13:00', 6, 1, (select id from employee where name = 'Casper Froberg')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-22 11:00', 7, 1,  (select id from employee where name = 'Casper Froberg')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-23 11:00', 6, 1,  (select id from employee where name = 'Casper Froberg')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-05 15:00', 4, 1,  (select id from employee where name = 'Casper Froberg')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-29 15:00', 2, 1,  (select id from employee where name = 'Casper Froberg')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-20 10:00', 4, 1,  (select id from employee where name = 'Casper Froberg')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-18 07:00', 9, 2,  (select id from employee where name = 'Casper Froberg')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-18 11:00', 5, 2, (select id from employee where name = 'Arne Ralston')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-01 10:00', 10,2, (select id from employee where name = 'Arne Ralston')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-04 17:00', 3, 2, (select id from employee where name = 'Arne Ralston')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-23 15:00', 3, 2,  (select id from employee where name = 'Arne Ralston')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-09 11:00', 7, 2,  (select id from employee where name = 'Arne Ralston')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-08 09:00', 7, 2,  (select id from employee where name = 'Arne Ralston')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-09 17:00', 3, 2,  (select id from employee where name = 'Arne Ralston')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-28 10:00', 5, 2,  (select id from employee where name = 'Arne Ralston')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-22 09:00', 6, 2,  (select id from employee where name = 'Arne Ralston')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-24 11:00', 6, 2,  (select id from employee where name = 'Arne Ralston')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-19 17:00', 3, 2,  (select id from employee where name = 'Arne Ralston')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-07 08:00', 7, 2,  (select id from employee where name = 'Arne Ralston')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-12-06 06:00', 5, 2,  (select id from employee where name = 'Arne Ralston')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-26 08:00', 10,2, (select id from employee where name = 'Arne Ralston')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-04 09:00', 6, 2,  (select id from employee where name = 'Arne Ralston')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-08 17:00', 3, 2,  (select id from employee where name = 'Arne Ralston')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-13 13:00', 6, 2,  (select id from employee where name = 'Arne Ralston')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-30 15:00', 5, 2,  (select id from employee where name = 'Arne Ralston')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-28 12:00', 8, 2, (select id from employee where name = 'Arne Ralston')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-12-06 11:00', 6, 2,  (select id from employee where name = 'Arne Ralston')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-14 14:00', 6, 2,  (select id from employee where name = 'Tobias Andersen')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-12-18 10:00', 9, 2,  (select id from employee where name = 'Tobias Andersen')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-15 14:00', 4, 2,  (select id from employee where name = 'Tobias Andersen')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-06 11:00', 7, 2,  (select id from employee where name = 'Tobias Andersen')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-12-09 16:00', 4, 2, (select id from employee where name = 'Tobias Andersen')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-03 09:00', 3, 2,  (select id from employee where name = 'Tobias Andersen')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-12-06 09:00', 3, 2,  (select id from employee where name = 'Tobias Andersen')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-21 12:00', 3, 2,  (select id from employee where name = 'Tobias Andersen')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-19 16:00', 4, 2,  (select id from employee where name = 'Tobias Andersen')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-06 09:00', 9, 2, (select id from employee where name = 'Tobias Andersen')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-12-03 11:00', 7, 2,  (select id from employee where name = 'Tobias Andersen')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-28 16:00', 4, 2,  (select id from employee where name = 'Tobias Andersen')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-15 16:00', 3, 2, (select id from employee where name = 'Tobias Andersen')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-17 14:00', 4, 2,  (select id from employee where name = 'Tobias Andersen')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-01 15:00', 5, 2, (select id from employee where name = 'Tobias Andersen')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-12-19 13:00', 4, 2,  (select id from employee where name = 'Tobias Andersen')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-11-24 09:00', 7, 2,  (select id from employee where name = 'Tobias Andersen')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-12-07 07:00', 10,2, (select id from employee where name = 'Tobias Andersen')); " +
                    //"insert into Shift(startTime, hours, scheduleId, employeeId)" + " values('2017-10-04 12:00', 8, 2,  (select id from employee where name = 'Tobias Andersen')); ";

                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
