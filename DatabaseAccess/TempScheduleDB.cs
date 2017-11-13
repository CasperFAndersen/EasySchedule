using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace DatabaseAccess
{
    public class TempScheduleDB
    {
        
        public IEnumerable<TempSchedule> GetAll()
        {
            using (DbConnectionADO con = new DbConnectionADO())
            {
                con.OpenConnection();
                
            }
        }

        public void AddTempScheduleToDB(TempSchedule tSchedule)
        {
            throw new NotImplementedException();
        }

        public TempSchedule FindTempScheduleByName(string v)
        {
            throw new NotImplementedException();
        }
    }
}
