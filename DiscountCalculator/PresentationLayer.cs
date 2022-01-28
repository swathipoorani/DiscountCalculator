using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DiscountCalculator
{
    public class DiscountCalc
    {
        public static void Main(string[] args)
        {
            try
            { 
            Console.WriteLine("Enter your username");
            string username = Console.ReadLine();
            Console.WriteLine("Enter your password");
            string password = Console.ReadLine();
            
            bool validuser = BusinessLogicLayer.ValidateUser(username, password);

                if (!validuser)
                {
                    Console.WriteLine("Invalid Username or Password");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Enter the Gold Price");
                    int goldPrice = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the weight of an item (in grams)");
                    int weight = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Discount Applicable? Please type Y or N");
                    string discountApplicable = Console.ReadLine();

                    if (discountApplicable.ToUpper().Equals("Y"))
                    {
                        int TotalPrice = goldPrice * weight;
                        Console.WriteLine("Enter the Discount (in percentage without symbol)");
                        int DiscountValue = Convert.ToInt32(Console.ReadLine());
                        TotalPrice = BusinessLogicLayer.DiscountCalculation(TotalPrice, DiscountValue);
                        if (TotalPrice != 0)
                        {
                            Console.WriteLine("The total price of the item is " + TotalPrice);
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("The Discount should positive numeric value");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("The total price of the item is " + goldPrice * weight);
                        Console.ReadKey();
                    }
                }
            }
            catch(Exception ex)
            {
                DataAccessLayer.ErrorLogging(ex);
                Console.WriteLine("Error Occurred. Please check the input format.");
                Console.ReadKey();
            }
        }
    }
}

