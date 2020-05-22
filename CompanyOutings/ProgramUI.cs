using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CompanyOutings
{
    public class ProgramUI
    {
        public readonly Outings_Repository _repo = new Outings_Repository();


        public void Run()
        {
            RunMenu();
        }

        public void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {

                Console.WriteLine("Company Outings Directory\n" +
                    "\n" +
                    "Please make a selection:\n" +
                    "1. View all company outings\n" +
                    "2. Add new company outing\n" +
                    "3. View total outing cost by type of outing\n" +
                    "4. View total cost of all outings\n" +
                    "5. Exit");

                string menuSelection = Console.ReadLine();
                switch (menuSelection)
                {
                    case "1":
                        ShowAllOutings();
                        Console.Clear();

                        break;

                    case "2":
                        InputNewOuting();
                        break;

                    case "3":
                        Console.WriteLine("Choose the outing type from below:\n" +
                    "1. Golf\n" +
                    "2. Bowling\n" +
                    "3. Amusement Park\n" +
                    "4. Concert");

                        string outingTypeChoice = Console.ReadLine();
                        int outingTypeID = Convert.ToInt32(outingTypeChoice);
                        OutingType outingType = (OutingType)outingTypeID;
                        if (_repo._outingsDirectory.Count != 0)
                        {

                            double outingTypeCost = _repo.CalculateOutingCostByType(outingType);
                            Console.Clear();
                            Console.WriteLine($"Total cost of {outingType} outings:\n" +
                                $" ${outingTypeCost}");
                            Console.WriteLine("Press any key to return to the menu");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine($"There are no {outingType} outings in the directory.\n" +
                                $"Press any key to continue");
                            Console.ReadKey();
                            Console.Clear();
                        }


                        break;

                    case "4":
                        Console.Clear();
                        double GrandTotalCost = _repo.CalculateGrandTotal();
                        Console.WriteLine($"Total cost of all outings:\n" +
                            $"${GrandTotalCost}\n" +
                            $"\n" +
                            $"Press any key to return to the menu");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "5":
                        Console.Clear();
                        Console.WriteLine("Are you sure you want to exit?\n" +
                            "Enter Y to quit. Otherwise, press Enter to go back to the selection menu.");
                        switch (Console.ReadLine())
                        {
                            case "y":
                                continueToRun = false;
                                Console.WriteLine("GoodBye!");

                                Thread.Sleep(2000);
                                break;

                        }

                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid selection, press any key to try again");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private void ShowAllOutings()
        {
            Console.Clear();
            List<Outing> listOfOutings = _repo.GetOutingsList();

            if (_repo._outingsDirectory.Count != 0)
            {

                foreach (Outing outing in listOfOutings)
                {

                    _repo.DisplayOuting(outing, outing.OutingDate);
                    Console.ReadKey();

                }

            }
            else
            {
                Console.WriteLine("There are no outings to view. Press any key to return to the menu");
                Console.ReadKey();
            }
        }

        public void InputNewOuting()
        {
            //Add outing date
            Console.Clear();
            Console.Write("Enter the outing month (MM): ");
            int month = int.Parse(Console.ReadLine());
            Console.Write("Enter the outing day (DD): ");
            int day = int.Parse(Console.ReadLine());
            Console.Write("Enter the outing year (YYYY): ");
            int year = int.Parse(Console.ReadLine());

            DateTime outingDate = new DateTime(year, month, day);
            string outingdateDisplay = outingDate.ToShortDateString();
            Console.Clear();
            Console.WriteLine($" Outing date set to: {outingdateDisplay}\n" +
                $"Press any key to continue");
            Console.ReadKey();

            //Add outing type
            Console.WriteLine("Select the type of outing from below:\n" +
                "1. Golf\n" +
                "2. Bowling\n" +
                "3. Amusement Park\n" +
                "4. Concert");

            string outingTypeChoice = Console.ReadLine();

            int outingTypeID = Convert.ToInt32(outingTypeChoice);

            OutingType outingType = (OutingType)outingTypeID;
            Console.Clear();
            Console.WriteLine($"Outing type set to {outingType}\n" +
                $"Press any key to continue");
            Console.ReadKey();

            Console.Clear();


            //Add outing attendees
            Console.WriteLine("What was the number of attendees?");

            int attendees = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"Thank you. Attendees set to {attendees}.\n" +
                $"\n" +
               $"Press any key to continue");
            Console.ReadKey();


            //Add outing cost per person
            Console.Clear();
            Console.WriteLine("What was the per-person cost of this outing?");
            double perPersonCost = Convert.ToDouble(Console.ReadLine());
            double outingCost = _repo.SingleOutingTotalCost(perPersonCost, attendees);

            Console.Clear();
            Console.WriteLine($"Per-person cost: ${perPersonCost}\n" +
                $"Total outing cost: ${outingCost}\n" +
               $"Press any key to continue");





            Console.ReadKey();

            Outing outing = new Outing(outingType, attendees, outingDate, perPersonCost, outingCost);
            _repo.AddOutingToList(outing);

            Console.Clear();
            Console.WriteLine("Outing successfully added to directory");
        }

    }
}

