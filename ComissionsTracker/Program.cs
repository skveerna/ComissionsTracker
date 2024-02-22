using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ComissionsTracker.Program;

namespace ComissionsTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetCursorPosition(7, 0);
            Console.WriteLine("---My Pricelist---");

            PriceList PricePosition = new PriceList("Head", 30);
            PriceList PricePosition1 = new PriceList("Half", 50);
            PriceList PricePosition2 = new PriceList("Full", 70);

            DateTime date = new DateTime(2024, 2, 20, 00, 00, 00);
            DateTime date1 = DateTime.Now;
            DateTime date2 = new DateTime(2024, 2, 23, 00, 00, 00);

            Comission Com = new Comission("Half", 15, "I need some g*re on picture", date, 50);
            Comission Com1 = new Comission("Full", 30, "I need detailed bckgr.", date1, 70);
            Comission Com2 = new Comission("Head", 0, "Nothing", date2, 30);



            PriceList[] FullPrice = new PriceList[] { PricePosition, PricePosition1, PricePosition2 };

            WeekPlan weekPlan = new WeekPlan();

            for (int i = 0; i < 3; i++)
            {
                FullPrice[i].ShowPricePositionInfo();
            }
            Console.SetCursorPosition(7, 4);
            Console.WriteLine("--------_--_------");


            Comission[] AllComissions = new Comission[] { Com, Com1, Com2 };
                        
            Console.WriteLine("\nMessage: U have a new comission request! (my congrats^)\nRead description");

            foreach (Comission comission in AllComissions)
            {
                Console.WriteLine("-- Comission request --");
                comission.ShowNewComissionInfo();
                Console.WriteLine("-------    -    -------");

                Console.WriteLine("So.. R U ready to take it? Y/N");

                ConsoleKeyInfo TakeComissionAnswer;
                TakeComissionAnswer = Console.ReadKey();

                switch (TakeComissionAnswer.Key)
                {
                    case ConsoleKey.Y:
                        Console.WriteLine("\nThis comission add to your Week Plan!");
                        comission.IsTaken = true;
                    break;
                    case ConsoleKey.N:

                        Console.WriteLine("\nSo..Okay..");
                    break;

                    default:
                        Console.WriteLine("\nWrong symbol. Try again.");
                    break;
                }

            }
            Console.WriteLine("Press any key to see your WeekPlan");
            Console.ReadKey();
            weekPlan.ShowWeekPlan(AllComissions);
        }
        public class PriceList
        {
            private string _comissionType;
            private int _commisionCost;

            public PriceList (string comissionType, int commisionCost)
            {
                _comissionType = comissionType;
                _commisionCost = commisionCost;
            }
            public void ShowPricePositionInfo()
            {
                Console.WriteLine($"      { _comissionType} cost {_commisionCost} dollars.");
            }
        }
        public class Comission
        {
            public string TypeOfComision;
            private int _comissionExtra;
            public string OrderDescription;
            public DateTime Deadline;
            private int _comissionCost;
            public bool IsTaken = false;

            public Comission(string typeOfComission, int comissionExtra, string orderDescription, DateTime deadline, int comissionCost)
            {
                TypeOfComision = typeOfComission;
                _comissionExtra = comissionExtra;
                OrderDescription = orderDescription;
                Deadline = deadline;
                _comissionCost = comissionCost;
            }

            public void ShowNewComissionInfo()
            {
                if (_comissionExtra > 0)
                    _comissionCost += _comissionExtra;
                
                Console.WriteLine($"Type: {TypeOfComision}" +
                    $"\n Extra elements: + {_comissionExtra} " +
                    $"\n Description: {OrderDescription}" +
                    $"\n Deadline: {Deadline} " +
                    $"\n Total Cost: {_comissionCost}");
            }
        }
        public class WeekPlan
        {
            static private  DateTime _today = DateTime.Now;
           
            public void ShowWeekPlan(Comission[] AllComissions)
            {
                Console.WriteLine($"-- Today {_today.ToLongDateString()}, {_today.DayOfWeek} --");

                for (int i = 0; i < AllComissions.Length; i++)
                {
                    if (AllComissions[i].IsTaken == true)
                    {
                        Console.WriteLine($"\nYour tasks on {AllComissions[i].Deadline} - ");
                        AllComissions[i].ShowNewComissionInfo();
                    }
                }
            }
        }
    }
}
