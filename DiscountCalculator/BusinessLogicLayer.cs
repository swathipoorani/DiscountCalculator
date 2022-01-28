using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Configuration;

namespace DiscountCalculator
{
    public static class BusinessLogicLayer
    {
        public static bool ValidateUser(string username, string password)
        { 
            DataTable dt = new DataTable();
            bool contains;
            try
            {
                dt = DataAccessLayer.DBconn();
                if (dt != null && dt.Rows.Count > 0)
                {
                    contains = dt.AsEnumerable().Any(row => username == row.Field<string>("Username"));
                    if (contains)
                    {
                        var result = dt.AsEnumerable().Where(row => row.Field<string>("Username") == username).FirstOrDefault();

                        if (result != null)
                        {
                            if (result.Field<string>("password").Equals(password))
                                return true;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                DataAccessLayer.ErrorLogging(ex);
                Console.WriteLine("Please verify the input format");
                Console.ReadKey();
            }
            return false;
        }
        public static int DiscountCalculation(int OriginalPrice, int DiscountPercent)
        {
            int netAmount = 0;
            try
            {                
                if (DiscountPercent > 0)
                {
                    DiscountCalc calc = new DiscountCalc();
                    netAmount = OriginalPrice - ((OriginalPrice * DiscountPercent) / Constants.PERCENTVALUE);
                }
                else if (DiscountPercent == 0)
                {
                    netAmount = OriginalPrice;
                }
            }
            catch(Exception ex)
            {
                DataAccessLayer.ErrorLogging(ex);
                Console.WriteLine("Please verify the input format");
                Console.ReadKey();
            }            
            return netAmount; 
        }       
    }
}

