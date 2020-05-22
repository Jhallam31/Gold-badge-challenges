using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOutings
{
    public enum OutingType { Golf =1, Bowling, Amusement_Park, Concert}
    public class Outing
    {
        public OutingType TypeOfOuting { get; set; }
        public int Attendees { get; set; }
        public DateTime OutingDate { get; set; }
        public double PerPersonCost { get; set; }
        public double OutingCost { get; set; }

        public Outing(OutingType typeOfOuting, int attendees, DateTime outingDate, double perPersonCost, double outingCost)
        {
            TypeOfOuting = typeOfOuting;
            Attendees = attendees;
            OutingDate = outingDate;
            PerPersonCost = perPersonCost;
            OutingCost = outingCost;
        }


    }
}
