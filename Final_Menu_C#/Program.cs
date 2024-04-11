using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Final_Menu_C_
{
    public class KHACHHANG
    {
        public string MaKH;
        public string HoTen;
        public double SoDu;

        public KHACHHANG() { }

        public KHACHHANG(string maKH, string hoTen, double soDu)
        {
            MaKH = maKH;
            HoTen = hoTen;
            SoDu = soDu;
        }
        public void NhapKH()
        {
            do
            {
                Console.Write("Nhập mã khách hàng: ");
                MaKH = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(MaKH));

            do
            {
                Console.Write("Nhập họ tên khách hàng: ");
                HoTen = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(HoTen));

            do
            {
                Console.Write("Nhập số dư tài khoản: ");
                SoDu = double.Parse(Console.ReadLine());
            }
            while (SoDu < 0);
        }

        public void XuatKH()
        {
            Console.WriteLine("---------------------");
            Console.WriteLine("Mã khách hàng: {0}", MaKH);
            Console.WriteLine("Họ tên: {0}", HoTen);
            Console.WriteLine("Số dư tài khoản: {0}", SoDu);
        }
    }
    public class KHACHHANG_QLKH
    {
        public List<KHACHHANG> _DanhSachKH;

        public KHACHHANG_QLKH()
        {
            _DanhSachKH = new List<KHACHHANG>();
        }

        public void NhapDSKH(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Nhập thông tin khách hàng thứ {0}:", i + 1);
                KHACHHANG kh;
                do
                {
                    kh = new KHACHHANG();
                    kh.NhapKH();
                } while (KiemTraTrungTen(kh.HoTen));
                _DanhSachKH.Add(kh);
            }
        }

        public void XuatDSKH()
        {
            foreach (KHACHHANG kh in _DanhSachKH)
            {
                kh.XuatKH();
            }
        }

        public bool KiemTraTrungTen(string ten)
        {
            foreach (KHACHHANG kh in _DanhSachKH)
            {
                if (kh.HoTen == ten)
                {
                    Console.WriteLine("Tên khách hàng đã tồn tại!");
                    return true;
                }
            }
            return false;
        }

        public void TimKiemTheoSoDu(double a, double b)
        {
            Console.WriteLine("\nDanh sách khách hàng có số dư từ {0} đến {1}:", a, b);
            foreach (KHACHHANG kh in _DanhSachKH)
            {
                if (kh.SoDu >= a && kh.SoDu <= b)
                {
                    kh.XuatKH();
                }
                else
                {
                    Console.WriteLine("Không có ai trong khoảng đã nhập!");
                }
            }
        }

        public void SapXepTheoSoDuTangDan()
        {
            _DanhSachKH.Sort((kh1, kh2) => kh1.SoDu.CompareTo(kh2.SoDu));
        }
        public bool XoaTenKhachHang(string check)
        {
            foreach (KHACHHANG kh in _DanhSachKH)
            {
                if (kh.HoTen != check)
                {
                    kh.HoTen.Remove(1);
                    kh.XuatKH();
                }
            }
            return false;
        }
    }
        internal class Program
        {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            int choice;
            do
            {
                Console.WriteLine("======Chương trình  Menu Final C# =======");
                Console.WriteLine("1.Nhập xuất mảng 2 chiều");
                Console.WriteLine("2.Tạo Class KHACHHANG và nhập xuất dữ liệu");
                Console.WriteLine("3.Xây dựng  class KH_QLKH");
                Console.WriteLine("4.Thoát Chương Trình");
                Console.Write("Vui lòng chọn chức năng(chọn số): ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("1.Nhập xuất mảng 2 chiều");
                        CN1();
                        break;
                    case 2:
                        Console.Clear();

                        Console.InputEncoding = Encoding.UTF8;
                        Console.OutputEncoding = Encoding.UTF8;

                        Console.Write("Nhập số lượng khách hàng: ");
                        int n; n = int.Parse(Console.ReadLine());

                        KHACHHANG_QLKH kh = new KHACHHANG_QLKH();

                        kh.NhapDSKH(n);
                        kh.XuatDSKH();

                        break;
                    case 3:
                        Console.Clear();

                        Console.InputEncoding = Encoding.UTF8;
                        Console.OutputEncoding = Encoding.UTF8;

                        int m;
                        double a, b;

                        Console.Write("Nhập số lượng khách hàng: ");
                        m = int.Parse(Console.ReadLine());

                        KHACHHANG_QLKH ds = new KHACHHANG_QLKH();
                        ds.NhapDSKH(m);

                        Console.WriteLine("\nDanh sách khách hàng:");
                        ds.XuatDSKH();

                        Console.Write("\nNhập số dư bắt đầu: ");
                        a = double.Parse(Console.ReadLine());

                        Console.Write("\nNhập số dư kết thúc: ");
                        b = double.Parse(Console.ReadLine());

                        ds.TimKiemTheoSoDu(a, b);

                        Console.Write("Nhập tên khách hàng cần xóa:");

                        string check;
                        check = Console.ReadLine();

                        ds.XoaTenKhachHang(check);

                        Console.ReadKey();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                }

            } while (choice != 0);
        }
             static void CN1()
             {
                int m, n;


                Console.Write("Nhap số hàng m: ");
                m = int.Parse(Console.ReadLine());

                Console.Write("Nhap số cột n: ");
                n = int.Parse(Console.ReadLine());

                int[,] arr = new int[m, n];

                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write("Nhập phần tử [{0},{1}]: ", i, j);
                        arr[i, j] = int.Parse(Console.ReadLine());
                    }
                }

                Console.WriteLine("\nMảng vừa nhập(dùng foreach):");

                foreach (int item in arr)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine("\nMảng bạn vừa nhập(dùng for): ");
                for (int h = 0; h < arr.GetLength(0); h++)
                {
                    for (int g = 0; g < arr.GetLength(1); g++)
                    {
                        Console.Write(arr[h, g] + " ");
                    }
                }
            int min = arr[0, 0];

                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (arr[i, j] < min)
                        {
                            min = arr[i, j];
                        }
                    }
                }
                Console.WriteLine("\nPhần tử nhỏ nhất trong mảng là: " + min);
                Console.ReadKey();
                }
         
        }
 }

