using System.Collections.Generic;

namespace Core
{
    public class Workplace
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<Department> Departments { get; set; }
        #endregion

        public Workplace()
        {
            Departments = new List<Department>();
        }
    }
}
