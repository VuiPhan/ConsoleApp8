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
             Console.OutputEncoding = Encoding.UTF8;
            // Biến begin lưu ngày bắt đầu là  ngày 1 tháng 1 năm 2018
            DateTime begin = new DateTime(2018, 1, 1);
            Random random = new Random();
            int num = 0;
            // NGÀY ĐẶT
            DateTime ngayDat = new DateTime();
            int gio, phut; // lưu giờ và phút của ngayDat
            // NGÀY XÁC NHẬN
            DateTime ngayXacNhan = new DateTime();
            int gioXacNhan, phutXacNhan; // lưu giờ và phút của ngayXacNhan
            // NGÀY GIAO CHO ĐƠN VỊ VẬN CHUYỂN
            DateTime ngayGiaoDVVC = new DateTime();
            int gioGiaoDVVC, phutGiaoDVVC; // lưu giờ và phút của ngayGiaoDVVC
            // NGÀY KHÁCH HÀNG NHẬN ĐƯỢC HÀNG
            DateTime ngayNhanHang = new DateTime();
            int gioNhanHang, phutNhanHang; // lưu giờ và phút của ngayNhanHang
            for (int i = 0; i < 1000; i++)
            {
                // random ra ngày đặt hàng
                num = random.Next(801);
                ngayDat = begin.AddDays(num);
                // random ra giờ, phút đặt hàng
                gio = random.Next(24); // chạy từ 0 đến 23
                phut = random.Next(60); // chạy từ 0 đến 59
                ngayDat = ngayDat.AddHours(gio);
                ngayDat = ngayDat.AddMinutes(phut);

                // random ra giờ và phút ngày xác nhận ( = ngày đặt  + (randrom trong 1-10 tiếng))
                gioXacNhan = random.Next(10);// từ 0 đến 9 giờ
                phutXacNhan = random.Next(60); // từ 0 đến 59
                // ngày xác nhận
                ngayXacNhan = ngayDat.AddHours(gioXacNhan).AddMinutes(phutXacNhan);

                // random ra ngày giao cho đơn vị vận chuyển = ngày xác nhận  + (randrom trong 10-30 tiếng).
                gioGiaoDVVC = random.Next(10, 30);// từ 10 đến 29
                phutGiaoDVVC = random.Next(60); // từ 0 đến 60

                ngayGiaoDVVC = ngayXacNhan.AddHours(gioGiaoDVVC).AddMinutes(phutGiaoDVVC);

                // random ra ngày khách hàng nhận hàng = ngày giao cho đơn vị vận chuyển + (randrom trong 48 - 60 tiếng).
                gioNhanHang = random.Next(48, 60);// từ 48 đến 59
                phutNhanHang = random.Next(60); // từ 0 đến 60

                ngayNhanHang = ngayGiaoDVVC.AddHours(gioNhanHang).AddMinutes(phutNhanHang);

                string s= String.Format(" Ngày Đặt : {0,10}\n Ngày Xác Nhận: {1}\n Ngày Giao DVVC: {2}\n Ngày Nhận: {3}\n" +
                    "===================================\n",
                    ngayDat, ngayXacNhan, ngayGiaoDVVC, ngayNhanHang);
                Console.WriteLine(s);
            }
            Console.ReadKey();



        }
        



    }
}
