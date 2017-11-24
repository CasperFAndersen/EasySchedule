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
                                      "templateScheduleId int foreign key references TemplateSchedule(id), " +
                                      "employeeId int foreign key references Employee(id)); "

                                      +
                                      //Schedule
                                      "create table Schedule(" +
                                      "id int primary key identity(1,1), " +
                                      "startDate smalldatetime, " +
                                      "templateScheduleId int foreign key references TemplateSchedule(id), " +
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
                                      "insert into TemplateShift(weekday, hours, startTime, templateScheduleId, employeeId) " +
                                      "values ('Tuesday', 10, '06:30:00', (select id from templateSchedule where name='KolonialBasis'), (select id from Employee where name='Mikkel Paulsen')); "
                                      + 
                                      "insert into TemplateShift(weekday, hours, startTime, templateScheduleId, employeeId) " +
                                      "values ('Tuesday', 10, '06:30:00', (select id from templateSchedule where name='PakkeCentralJuletid'), (select id from Employee where name='Tobias Andersen')); "

                                      +
                                      //Schedule
                                      "insert into Schedule(startDate, templateScheduleId, departmentId) " +
                                      "values ('" + startTimeWeek1 + "', (select id from templateSchedule where name='KolonialBasis'), 1); " +

                                      "insert into Schedule(startDate, templateScheduleId, departmentId) " +
                                      "values ('" + startTimeWeek1 + "', (select id from templateSchedule where name='PakkeCentralJuletid'), 2); "

                                      +
                                      //Shift
                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" +
                                      "values ('" + GetCurrentStartTimeStringPlusDay(2) + " 08:00', 6, (select id from schedule where startDate='" + startTimeWeek1 + "' AND departmentId = 1), (select id from employee where name='Mikkel Paulsen')); " +

                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" +
                                      "values ('" + GetCurrentStartTimeStringPlusDay(0) + " 09:00', 4, (select id from schedule where startDate='" + startTimeWeek1 + "' AND departmentId = 1), (select id from employee where name='Stefan Krabbe')); " +

                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" +
                                      "values ('" + GetCurrentStartTimeStringPlusDay(4) + " 10:00', 8, (select id from schedule where startDate='" + startTimeWeek1 + "' AND departmentId = 1), (select id from employee where name='Casper Froberg')); " +

                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" +
                                      "values ('" + GetCurrentStartTimeStringPlusDay(1) + " 12:00', 4, (select id from schedule where startDate='" + startTimeWeek1 + "' AND departmentId = 2), (select id from employee where name='Arne Ralston')); " +

                                      "insert into Shift(startTime, hours, scheduleId, employeeId)" +
                                      "values ('" + GetCurrentStartTimeStringPlusDay(2) + " 14:00', 7, (select id from schedule where startDate='" + startTimeWeek1 + "' AND departmentId = 2), (select id from employee where name='Tobias Andersen')); ";
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
