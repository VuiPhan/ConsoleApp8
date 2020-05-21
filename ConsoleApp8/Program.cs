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
                int toSkip = rand.Next(0,10);
                Member member = db.Members.Skip(toSkip).Take(1).First();
                Order order = new Order();
                order.IDMember = member.IDMember;
                order.OrderedDate = RandomDay();
                db.Orders.InsertOnSubmit(order);
                db.SubmitChanges();
                //heyvuideptrai
                //heyvuideptrai
                //hello
                //heythaydoi
                // khi muon check in cai file nay len thoi
                // thi` làm như sau
                // và qua bên tab sync để commit lên 



            }
        }
        public static Random gen = new Random();
        public static DateTime RandomDay()
        {
            DateTime start = new DateTime(2019, 1, 1);
            int range = (DateTime.Today - start).Days;  
            return start.AddDays(gen.Next(range));
        }
        // Sau đây sẽ tạo ra một xung đột khi hai người cùng commit file lên.
        public static DateTime xungDotCuong()
        {
            DateTime start = new DateTime(2019, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }
        // Giờ qua máy t để check in lên 
        // Giờ khi mình tải code khi t commit lên nên nó bị xung đột, và nó sẽ bắt mình gộp code



    }
}
