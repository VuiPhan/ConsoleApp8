using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp8.DB;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            InsertOrder();
        }

        public static void InsertOrder()
        {
            ShopBanDoTheThaoNorthwindDataContext db = new ShopBanDoTheThaoNorthwindDataContext();
            for (int i = 0; i < 2; i++)
            {
                Random rand = new Random();
                int countTotalCustomer = db.Members.Count();
                int toSkipCustomer = rand.Next(0, countTotalCustomer);
                Member member = db.Members.Skip(toSkipCustomer).Take(1).First();

                // Xung đột 
                int countTotalZip = db.ZipCodes.Count();
                int toSkipZip = rand.Next(0, countTotalZip);
                ZipCode zip = db.ZipCodes.Skip(toSkipZip).Take(1).First();


                int countTotalShipper = db.ZipCodes.Count();
                int toSkipShipper = rand.Next(0, countTotalShipper);
                Shipper shipper = db.Shippers.Skip(toSkipShipper).Take(1).First();

                int StatusOrder = rand.Next(0, 5);


                Order order = new Order();
                order.IDMember = member.IDMember;
                order.IDZipCode = zip.IDZipCode;
                order.Status = (byte)StatusOrder;

                order.OrderedDate = RandomDay();
                db.Orders.InsertOnSubmit(order);    
                db.SubmitChanges();
            }
        }
        public static Random gen = new Random();
        public static DateTime RandomDay()
        {
            //DateTime start = new DateTime(2019, 1, 1);
            //int range = (DateTime.Today - start).Days;  
            //return start.AddDays(gen.Next(range));
            Random rand = new Random();
            //Note that Random.Next(int, int) is inclusive lower bound, exclusive upper bound

                DateTime myDateTime = new DateTime(2018, 1, 1,
                rand.Next(7, 11), rand.Next(0, 60), 0);
                    
            

            return myDateTime;




        }


    }
}
