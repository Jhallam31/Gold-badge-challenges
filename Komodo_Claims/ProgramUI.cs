using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Komodo_Claims
{
    public class ProgramUI
    {
        public readonly ClaimRepository _repo = new ClaimRepository();
        public Queue<Claim> _claimDirectory = new Queue<Claim>();

        public void Run()
        {
            Console.Clear();
            SeedQueue();
            RunMenu();
        }
        public void RunMenu()
        {
            Console.Clear();
            bool continueToRun = true;
            while (continueToRun)
            {
                string pagetitle = "Komodo Insurance Company";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (pagetitle.Length / 2)) + "}", pagetitle));
                
                Console.WriteLine(
                    "\n" +
                    "\n" +
                    "Select a task:\n" +
                    "1. See all Claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit");

                string selection = Console.ReadLine();
                switch (selection)
                {
                    case "1":
                        Console.Clear();
                        ShowAllClaims();
                        Console.WriteLine("\n"+
                            "\n"+
                            "Press any key to return to the task menu");
                        Console.ReadKey();
                        break;

                    case "2":
                        Console.Clear();
                        Claim claim = _repo.GetNextClaim();
                        DateTime dateOfIncident = claim.DateOfIncident;
                        DateTime dateOfClaim = claim.DateOfClaim;


                        Console.WriteLine("Next claim in queue:\n"+
                            "\n");
                        _repo.DisplayClaim(claim, dateOfIncident, dateOfClaim);

                        Console.WriteLine("\n"+
                            "Would you like to handle this claim now (y/n)?");
                        if (Console.ReadKey().Key == ConsoleKey.Y)
                        {
                            Console.Clear();
                            _repo.HandleNextClaim();
                            Console.WriteLine("Claim handled. Press any key to return to the selection menu.");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Claim returned to queue. Press any key to return to the main menu.");
                            Console.ReadKey();
                        }
                        break;

                    case "3":
                        Console.Clear();
                        InputNewClaim();

                        Console.WriteLine($"Claim successfully added!\n"+
                            "Press any key to return to the main menu.");
                        Console.ReadKey();
                        
                        
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Are you sure you want to exit?\n" +
                            "Press Y to quit. Otherwise, press Enter to go back to the selection menu.");
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
        
        private void ShowAllClaims()
        {
            Console.Clear();
            Queue<Claim> listofclaims = _repo.GetClaimsQueue();

            if (_claimDirectory.Count != 0)
            {

            foreach (Claim claim in listofclaims)
            {
                DateTime dateOfIncident= claim.DateOfIncident;
                DateTime dateOfClaim= claim.DateOfClaim;

                _repo.DisplayClaim(claim, dateOfIncident, dateOfClaim);
            }

            }
            else
            {
                Console.WriteLine("There are currently no claims in the queue.\n"+
                    "Press any key to return to the main menu.");
                Console.ReadKey();
            }
        }
        private void SeedQueue()
        {
            DateTime seedDateIncident = new DateTime(2018, 04, 25);
            DateTime seedDateClaim = new DateTime(2018, 04, 27);
            Claim exsistingClaim = new Claim(1, ClaimType.car, "Car accident on 464", 400.00, seedDateIncident, seedDateClaim, true);

            _repo.AddClaimToQueue(exsistingClaim);
        }
        public void InputNewClaim()
        {
            

            //Add ClaimID
            Console.Clear();
            Console.WriteLine("Adding new claim to queue.\n" +
                "\n" +
                "Enter Claim ID:");

            int claimID = Convert.ToInt32(Console.ReadLine());


            Console.Clear();
            Console.WriteLine($" Claim ID set to {claimID}.\n" +
                $"Press any key to continue.");

            Console.ReadKey();

            //Add claim type
            Console.Clear();
            Console.WriteLine("Available claim types: \n" +
                "\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft\n" +
                "\n" +
                "Enter the number of your selection");

            string claimTypeChoice = Console.ReadLine();

            int claimTypeID = Convert.ToInt32(claimTypeChoice);

            ClaimType claimType = (ClaimType) claimTypeID;

            Console.Clear();
            

            // Add description
            Console.Clear();
            Console.WriteLine("Write a short description of the incident.");
            string description = Console.ReadLine();

            //Add claimAmount
            Console.Clear();
            Console.WriteLine("Enter the total dollar amount of the claim");
            double claimAmount = Convert.ToDouble(Console.ReadLine());

            //Add incident Date
            Console.Clear();
            Console.Write("Enter the incident month (MM): ");
            int month = int.Parse(Console.ReadLine());
            Console.Write("Enter the incident day (DD): ");
            int day = int.Parse(Console.ReadLine());
            Console.Write("Enter the incident year (YYYY): ");
            int year = int.Parse(Console.ReadLine());

            DateTime dateOfIncident = new DateTime(year, month, day);
            string accidentdateDisplay = dateOfIncident.ToShortDateString();
            Console.WriteLine($" Incident date set to: {accidentdateDisplay}\n" +
                $"Press any key to continue");
            Console.ReadKey();


            //Add claim date

            Console.Clear();
            Console.Write("Enter the month the claim was initiated (MM): ");
            int claimMonth = int.Parse(Console.ReadLine());
            Console.Write("Enter the day the claim was initiated (DD): ");
            int claimDay = int.Parse(Console.ReadLine());
            Console.Write("Enter the year the claim was initiated (YYYY): ");
            int claimYear = int.Parse(Console.ReadLine());

            DateTime dateOfClaim = new DateTime(claimYear, claimMonth, claimDay);
            string claimdateDisplay = dateOfClaim.ToShortDateString();
            Console.WriteLine($" Incident date set to: {claimdateDisplay}\n" +
                $"Press any key to continue");
            Console.ReadKey();

            //Claim is valid?

            bool claimIsValid = _repo.IsClaimValid(dateOfClaim, dateOfIncident);
            if (claimIsValid == true)
            {
                Console.Clear();
                Console.WriteLine("This claim is valid\n" +
                    "\n");
                Console.ReadKey();
            }
            
            
            Claim claim = new Claim(claimID, claimType, description,claimAmount, dateOfIncident, dateOfClaim, claimIsValid);

            _repo.AddClaimToQueue(claim);
        }
    }
}
