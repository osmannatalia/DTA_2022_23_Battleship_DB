using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTA_2022_23_Battleship.Model.DataBase
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public bool IsAdministration { get; set; }
        public bool IsAсtive { get; set; }
        public DateTime BornDate { get; set; }
    }
}
