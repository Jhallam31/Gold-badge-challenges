using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOutings
{
    public class Outings_Repository
    {
        public List<Outing> _outingsDirectory = new List<Outing>();

        public List<Outing> GetOutingsList()
        {
            return _outingsDirectory;
        }

        public void DisplayOuting(Outing outing, DateTime outingDate)
        {
            string datelabel = "Date";
            string typeLabel = "Outing Type";
            string attendeesLabel = "Attendees";
            string perPersonLabel = "Per Person Cost";
            string totalCostLabel = "Total Cost";


            string outingdateDisplay = outingDate.ToShortDateString();

            Console.WriteLine($"{datelabel,-15}{typeLabel,-20}{attendeesLabel,-15}{perPersonLabel,-20}{totalCostLabel,-20}\n" +
                $"{outingdateDisplay,-15}{outing.TypeOfOuting,-20}{ outing.Attendees,-15}{ outing.PerPersonCost,-20}{ outing.OutingCost,-20}");

        }
        public double CalculateGrandTotal()
        {
            double grandTotalCost = 0;

            foreach (Outing outing in _outingsDirectory)
            {
                grandTotalCost += outing.OutingCost;
            }
            return grandTotalCost;
        }
        public double CalculateOutingCostByType(OutingType outingType)
        {
            double outingTypeCost = 0;
            
                foreach (Outing outing in _outingsDirectory)
                {
                    if (outing.TypeOfOuting == outingType)
                    {
                        outingTypeCost += outing.OutingCost;
                    }
                }
            
            
            return outingTypeCost;
        }
        public void AddOutingToList(Outing outing)
        {
            _outingsDirectory.Add(outing);
        }
        public double SingleOutingTotalCost(double perPersonCost, int attendees)
        {
            double outingCostRough = (perPersonCost * Convert.ToDouble(attendees));
            double outingCost = Math.Round(outingCostRough, 2);
            return outingCost;
        }
    }
}
