﻿using System;
using System.Data.SqlClient;
using Core;

namespace DatabaseAccess.Schedules
{
    public class ScheduleRepository : IScheduleRepository
    {
        public Schedule GetScheduleByCurrentDate(DateTime currentDate)
        {
            Schedule schRes = new Schedule();
            using(DbConnectionADO dbCon = new DbConnectionADO())
            {
                dbCon.OpenConnection();

                SqlCommand command = new SqlCommand("select * from Shift, Schedule WHERE shift.scheduleId = (SELECT Schedule.id from Schedule WHERE startTime = @param1)");
                command.Parameters.AddWithValue("@Param1", currentDate);

                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    schRes = BuildScheduleObject(reader);
                }
            }

            return schRes;
        }

        public Schedule BuildScheduleObject(SqlDataReader reader)
        {
            Schedule schedule = new Schedule();

            return schedule;
        }
    }
}
