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
             Console.OutputEncoding = Encoding.UTF8;

            DateTime ngayDat, ngayXacNhan, ngayGiaoDVVC, ngayNhan;
            string IDMember, Phone, Email, FullName;
            string ZipCodeAddress;
            int IDZipCode, IDShipper;

            // INSERT DỮ LIỆU
            DateTime[] date = RandomDay();
            ngayDat = date[0]; ngayXacNhan = date[1]; ngayGiaoDVVC = date[2]; ngayNhan = date[3];
            // Thông tin khách hàng
            string[] Member = RandomMember();
            IDMember = Member[0]; Phone = Member[1]; Email = Member[2]; FullName = Member[3];
            //
            string[] ZipCode = RandomZipCode();
            IDZipCode = int.Parse(ZipCode[0]);
            ZipCodeAddress = ZipCode[1];
            //
            IDShipper = RandomShipper();

            // INSERT VÀO BẢNG ORDER
            ShopBanDoTheThaoNorthwindEntities1 db = new ShopBanDoTheThaoNorthwindEntities1();
            Order order = new Order();
            order.OrderedDate = ngayDat; order.ConfirmDate = ngayXacNhan;
            order.DeliveryDate = ngayGiaoDVVC; order.DeliveredDate = ngayNhan;

            order.IDMember = int.Parse(IDMember);
            order.PhoneNumber = Phone; order.FullName = FullName; order.Email = Email;

            order.IDZipCode = IDZipCode;
            order.Address = ZipCodeAddress;
            order.IDShipper = IDShipper;

            // Mã giả để insert :))
            order.TotalMoney = 100000; order.TotalAmount = 5000;
            order.Status = 4;
            order.ShopOrOnline = true;
            order.Notes = "Giao nhanh nha anh !";
            db.Orders.Add(order);
            db.SaveChanges();

            // CODE DƯỚI ĐÂY DÙNG ĐỂ TEST LẤY KẾT QUẢ HIỆN RA CONSOLE
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine("========== {0} TIME(S) =============",i+1);
            //    // 4 cột thời gian
            //    DateTime[] date = RandomDay();
            //    ngayDat = date[0]; ngayXacNhan = date[1]; ngayGiaoDVVC = date[2]; ngayNhan = date[3];
            //    // Thông tin khách hàng
            //    string[] Member = RandomMember();
            //    IDMember = Member[0];Phone = Member[1]; Email = Member[2]; FullName = Member[3];
            //    //
            //    string[] ZipCode = RandomZipCode();
            //    IDZipCode = int.Parse(ZipCode[0]);
            //    ZipCodeAddress = ZipCode[1];
            //    //
            //    IDShipper = RandomShipper();

            //    Console.WriteLine("ngayDat: {0} , ngayXacNhan: {1} , ngayGiaoDVVC: {2} , ngayNhan: {3}",
            //        ngayDat, ngayXacNhan, ngayGiaoDVVC, ngayNhan);
            //    Console.WriteLine("IDMember: {0} , Phone: {1}, Email: {2}, FullName: {3}",
            //        IDMember, Phone, Email, FullName);
            //    Console.WriteLine("IDZipCode: {0}, ZipCodeAddress: {1}, IDShipper: {2}",
            //        IDZipCode,ZipCodeAddress, IDShipper);
            //}
            Console.WriteLine("========================");
        }
         static DateTime[] RandomDay()
        {
            Console.OutputEncoding = Encoding.UTF8;
            // Biến begin lưu ngày bắt đầu là  ngày 1 tháng 1 năm 2018
            DateTime begin = new DateTime(2018, 1, 1);
            Random random = new Random(DateTime.Now.Millisecond);
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

            // return
            DateTime[] dt = new DateTime[4];
            dt[0] = ngayDat; dt[1] = ngayXacNhan; dt[2] = ngayGiaoDVVC; dt[3] = ngayNhanHang;

            return dt;
        }
        static void RandomProduct()
        {
            try
            {
                ShopBanDoTheThaoNorthwindEntities da = new ShopBanDoTheThaoNorthwindEntities();
                Random random = new Random(DateTime.Now.Millisecond);
                int k;
                do { k = random.Next(3, 37); }
                while (k == 25 || k == 26);
                var sp = (from s in da.Products
                          where s.ProductID == k
                          select new { ID = s.ProductID, Name = s.ProductName }).Distinct();

                foreach (var m in sp)
                {
                    Console.WriteLine(m.ID);
                    Console.WriteLine(m.Name);
                }
            }
            catch { }
           
        }
        static string[] RandomMember()
        {
            ShopBanDoTheThaoNorthwindEntities da = new ShopBanDoTheThaoNorthwindEntities();
            Random random = new Random(DateTime.Now.Millisecond);
            int k = random.Next(17, 515);// những khách hàng Công thêm, những khách hàng trước đó có những ID không có

            var sp = from s in da.Members
                     where s.IDMember == k
                     select new
                     {
                         IDMember = s.IDMember,
                         PhoneNumber = s.PhoneNumber,
                         Email = s.Email,
                         Fullname = s.FullName
                     };
            string[] Member = new string[5];
            // vòng for chạy 1 lần
            foreach (var m in sp)
            {
                Member[0] = m.IDMember.ToString();
                Member[1] = m.PhoneNumber;
                Member[2] = m.Email;
                Member[3] = m.Fullname;
            }
            return Member;
        }
        static int RandomShipper()
        {
            ShopBanDoTheThaoNorthwindEntities da = new ShopBanDoTheThaoNorthwindEntities();
            Random random = new Random(DateTime.Now.Millisecond);
            int k;
            k = random.Next(1,3);// chưa có dữ liệu thật nên tạm thời tạo 2 dòng để TEST

            var Shipper = from s in da.Shippers
                          where s.IDShipper == k
                          select new { IDShipper  = s.IDShipper };

            int[] id = new int[1];
            // vòng for chỉ chạy 1 lần
            foreach (var i in Shipper)
            {
                id[0] = i.IDShipper;
            }
            return id[0];
        }
        static string[] RandomZipCode()
        {
            ShopBanDoTheThaoNorthwindEntities da = new ShopBanDoTheThaoNorthwindEntities();
            Random random = new Random(DateTime.Now.Millisecond);
            int k;
            k = random.Next(1, 758);
            var ZipCode = from s in da.ZipCodes
                          where s.IDZipCode == k
                          select new { IDZipCode = s.IDZipCode,
                          Address = s.Wards+", "+s.District+", "+s.Province_City};
            string[] zipCode = new string[2];
            // vòng for chỉ chạy 1 lần
            foreach (var i in ZipCode)
            {
                zipCode[0] = i.IDZipCode.ToString();
                zipCode[1] = i.Address;
            }
            return zipCode;

        }
    }
}
