using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTA_2022_23_Battleship.Model.DataBase
{
    public class Statistic
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int CountOfRounds { get; set; }
        public int Player1Score { get; set; }
        public int Player2Score { get; set; }
        public string Winer { get; set; }
        public bool IsVisible { get; set; }
    }
}
