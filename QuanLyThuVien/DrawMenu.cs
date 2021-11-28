using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyThuVien
{
    class DrawMenu
    {
        public static void XoaPhieuMuon(List<PhieuMuon> list, string ma_sach = null, string ma_doc_gia = null)
        {
            int index = 0;
            List<int> removeIndex = new List<int>();
            foreach (var item in list)
            {
                if (item.Ma_sach.ToUpper().Equals(ma_sach) || item.Ma_doc_gia.ToUpper().Equals(ma_doc_gia))
                {
                    removeIndex.Add(index);
                }
                index++;
            }
            foreach (var item in removeIndex)
            {
                list.RemoveAt(item);
            }
        }
        public static void TraSach(string ma_sach)
        {
            foreach (var item in Program.listPhieuMuon)
            {
                if (item.Ma_sach.Equals(ma_sach))
                    item.Check = true;
            }
        }
        public static void Menu()
        {
            int n;
            bool check = true;
            while (check)
            {
                CreateMenu.Create_Menu();
                n = !int.TryParse(Console.ReadLine(), out n) ? -1 : n;
                switch (n)
                {
                    case 1://Thêm sách mới
                        {
                            Console.Clear();
                            int nSach = 0;
                            bool checkSl = false;
                            while (!checkSl)
                            {
                                Console.Write("Nhập số lượng loại sách thêm vào thư viện: ");
                                checkSl = int.TryParse(Console.ReadLine(), out nSach);
                            }
                            Console.WriteLine("\nNhập thông tin cho từng loại sách:\n");
                            Console.WriteLine("───────────────────────────────────────────────────────");
                            for (int i = 0; i < nSach; i++)
                            {
                                Console.WriteLine("\n\tSách 0{0}", i + 1);
                                Sach tmp = new Sach();
                                tmp.Nhap();
                                Program.listSach.Add(tmp);
                            }
                            Console.WriteLine("───────────────────────────────────────────────────────");
                            Console.WriteLine("\n\nNhập thành công {0} loại sách!!!\n", nSach);
                            Console.ReadKey();
                            break;
                        }
                    case 2://Xoá sách
                        {
                            Sach tmp = new Sach();
                            Console.Clear();
                            Console.Write("Nhập mã sách cần xoá: ");
                            string ma_sach = Console.ReadLine();
                            bool flag = false;
                            DrawTable.HeadingSach();
                            foreach (var item in Program.listSach)
                            {
                                if (item.Ma_sach.Equals(ma_sach.ToUpper()))
                                {
                                    Console.Write("│ {0,-3}", "1");
                                    item.Xuat();
                                    Console.WriteLine();
                                    flag = true;
                                    tmp = item;
                                    break;
                                }
                            }
                            DrawTable.FootingSach();
                            if (!flag)
                                Console.WriteLine("Không tìm thấy sách!!!");
                            else
                            {
                                string xacnhan;
                                do
                                {
                                    Console.Write("Xác nhận xoá?(Y/N): ");
                                    xacnhan = Console.ReadLine();
                                } while (!xacnhan.ToLower().Equals("y") && !xacnhan.ToLower().Equals("n") && !xacnhan.ToLower().Equals("yes") && !xacnhan.ToLower().Equals("no"));
                                if (xacnhan.ToLower().Equals("y") || xacnhan.ToLower().Equals("yes"))
                                {
                                    Program.listSach.Remove(tmp);
                                    XoaPhieuMuon(Program.listPhieuMuon,ma_sach.ToUpper());
                                    Console.WriteLine("\n\n\nXoá thành công!!!");
                                }
                            }
                            Console.ReadKey();
                            break;
                        }
                    case 3://Sửa sách
                        {
                            Sach tmp = new Sach();
                            Console.Clear();
                            Console.Write("Nhập mã sách cần sửa thông tin: ");
                            string ma_sach = Console.ReadLine();
                            int flag = -1;
                            int index = 0;
                            DrawTable.HeadingSach();
                            foreach (var item in Program.listSach)
                            {
                                if (item.Ma_sach.Equals(ma_sach.ToUpper()))
                                {
                                    Console.Write("│ {0,-3}", "1");
                                    item.Xuat();
                                    Console.WriteLine();
                                    flag = index;
                                    tmp = item;
                                    break;
                                }
                                index++;
                            }
                            DrawTable.FootingSach();
                            if (flag == -1)
                                Console.WriteLine("Không tìm thấy sách!!!");
                            else
                            {
                                Console.WriteLine("\nCập nhật thông tin mới:\n");
                                Console.WriteLine("───────────────────────────────────────────────────────");
                                tmp.Nhap();
                                Program.listSach[flag] = tmp;
                                Console.WriteLine("───────────────────────────────────────────────────────");
                                foreach (var item in Program.listPhieuMuon)
                                {
                                    item.UpdateInfo(Program.listDocGia, Program.listSach, tmp, ma_sach);
                                }
                                foreach (var item in Program.listPhieuTra)
                                {
                                    item.UpdateInfo(Program.listDocGia, Program.listSach, tmp, ma_sach);
                                }
                                Console.WriteLine("\n\n\nSửa thông tin thành công!!!");
                            }
                            Console.ReadKey();
                            break;
                        }
                    case 4://Tìm kiếm sách
                        {
                            Sach tmp = new Sach();
                            Console.Clear();
                            Console.Write("Nhập tên sách cần tìm: ");
                            string ten_sach = Console.ReadLine();
                            bool flag = false;
                            int k = 1;
                            DrawTable.HeadingSach();
                            foreach (var item in Program.listSach)
                            {
                                if (item.Ten_sach.Contains(ten_sach.ToUpper()))
                                {
                                    Console.Write("│ {0,-3}", k++);
                                    item.Xuat();
                                    Console.WriteLine();
                                    flag = true;
                                    tmp = item;
                                }
                            }
                            DrawTable.FootingSach();
                            if (!flag)
                                Console.WriteLine("Không tìm thấy sách!!!");
                            Console.ReadKey();
                            break;
                        }
                    case 5://Hiện danh sách sách
                        {
                            Console.Clear();
                            int k = 1;
                            DrawTable.HeadingSach();
                            foreach (var item in Program.listSach)
                            {
                                Console.Write("│ {0,-3}", k++);
                                item.Xuat();
                                Console.WriteLine();
                            }
                            DrawTable.FootingSach();
                            Console.ReadKey();
                            break;
                        }
                    case 6://Thêm độc giả
                        {
                            Console.Clear();
                            int nDocGia = 0;
                            bool checkSl = false;
                            while (!checkSl)
                            {
                                Console.Write("Nhập số lượng độc giả: ");
                                checkSl = int.TryParse(Console.ReadLine(), out nDocGia);
                            }
                            Console.WriteLine("\nNhập thông tin cho từng độc giả:\n");
                            Console.WriteLine("───────────────────────────────────────────────────────");
                            for (int i = 0; i < nDocGia; i++)
                            {
                                Console.WriteLine("\n\tĐộc giả 0{0}", i + 1);
                                DocGia tmp = new DocGia();
                                tmp.Nhap();
                                Program.listDocGia.Add(tmp);
                            }
                            Console.WriteLine("───────────────────────────────────────────────────────");
                            Console.WriteLine("\n\nThêm thành công {0} độc giả!!!\n", nDocGia);
                            Console.ReadKey();
                            break;
                        }
                    case 7://Xoá đọc giả
                        {
                            DocGia tmp = new DocGia();
                            Console.Clear();
                            Console.Write("Nhập mã độc giả cần xoá: ");
                            string ma_doc_gia = Console.ReadLine();
                            bool flag = false;
                            DrawTable.HeadingDocGia();
                            foreach (var item in Program.listDocGia)
                            {
                                if (item.Ma_doc_gia.Equals(ma_doc_gia.ToUpper()))
                                {
                                    Console.Write("│ {0,-3}", "1");
                                    item.Xuat();
                                    Console.WriteLine();
                                    flag = true;
                                    tmp = item;
                                    break;
                                }
                            }
                            DrawTable.FootingDocGia();
                            if (!flag)
                                Console.WriteLine("Không tìm thấy độc giả!!!");
                            else
                            {
                                string xacnhan;
                                do
                                {
                                    Console.Write("Xác nhận xoá?(Y/N): ");
                                    xacnhan = Console.ReadLine();
                                } while (!xacnhan.ToLower().Equals("y") && !xacnhan.ToLower().Equals("n") && !xacnhan.ToLower().Equals("yes") && !xacnhan.ToLower().Equals("no"));
                                if (xacnhan.ToLower().Equals("y") || xacnhan.ToLower().Equals("yes"))
                                {
                                    Program.listDocGia.Remove(tmp);
                                    XoaPhieuMuon(Program.listPhieuMuon, null, ma_doc_gia.ToUpper());
                                    Console.WriteLine("\n\n\nXoá thành công!!!");
                                }
                            }
                            Console.ReadKey();
                            break;
                        }
                    case 8://Sửa độc giả
                        {
                            DocGia tmp = new DocGia();
                            Console.Clear();
                            Console.Write("Nhập mã độc giả cần sửa thông tin: ");
                            string ma_doc_gia = Console.ReadLine();
                            int flag = -1;
                            int index = 0;
                            DrawTable.HeadingDocGia();
                            foreach (var item in Program.listDocGia)
                            {
                                if (item.Ma_doc_gia.Equals(ma_doc_gia.ToUpper()))
                                {
                                    Console.Write("│ {0,-3}", "1");
                                    item.Xuat();
                                    Console.WriteLine();
                                    flag = index;
                                    tmp = item;
                                    break;
                                }
                                index++;
                            }
                            DrawTable.FootingDocGia();
                            if (flag == -1)
                                Console.WriteLine("Không tìm thấy độc giả!!!");
                            else
                            {
                                Console.WriteLine("\nCập nhật thông tin mới:\n");
                                Console.WriteLine("───────────────────────────────────────────────────────");
                                tmp.Nhap();
                                Program.listDocGia[flag] = tmp;
                                Console.WriteLine("───────────────────────────────────────────────────────");
                                foreach (var item in Program.listPhieuMuon)
                                {
                                    item.UpdateInfo(Program.listDocGia, Program.listSach, null, null, tmp, ma_doc_gia);
                                }
                                foreach (var item in Program.listPhieuTra)
                                {
                                    item.UpdateInfo(Program.listDocGia, Program.listSach, null, null, tmp, ma_doc_gia);
                                }
                                Console.WriteLine("\n\n\nSửa thông tin thành công!!!");
                            }
                            Console.ReadKey();
                            break;
                        }
                    case 9://Tìm kiếm độc giả
                        {
                            DocGia tmp = new DocGia();
                            Console.Clear();
                            Console.Write("Nhập tên độc giả cần tìm: ");
                            string ten_doc_gia = Console.ReadLine();
                            bool flag = false;
                            int k = 1;
                            DrawTable.HeadingDocGia();
                            foreach (var item in Program.listDocGia)
                            {
                                if (item.Ten_doc_gia.Contains(ten_doc_gia.ToUpper()))
                                {
                                    Console.Write("│ {0,-3}", k++);
                                    item.Xuat();
                                    Console.WriteLine();
                                    flag = true;
                                    tmp = item;
                                }
                            }
                            DrawTable.FootingDocGia();
                            if (!flag)
                                Console.WriteLine("Không tìm thấy độc giả!!!");
                            Console.ReadKey();
                            break;
                        }
                    case 10://Tìm kiếm độc giả
                        {
                            Console.Clear();
                            int k = 1;
                            DrawTable.HeadingDocGia();
                            foreach (var item in Program.listDocGia)
                            {
                                Console.Write("│ {0,-3}", k++);
                                item.Xuat();
                                Console.WriteLine();
                            }
                            DrawTable.FootingDocGia();
                            Console.ReadKey();
                            break;
                        }
                    case 11://Tạo phiếu mượn
                        {
                            Console.Clear();
                            int nPhieuMuon = 0;
                            bool checkSl = false;
                            while (!checkSl)
                            {
                                Console.Write("Nhập số lượng phiếu mượn cần tạo: ");
                                checkSl = int.TryParse(Console.ReadLine(), out nPhieuMuon);
                            }
                            Console.WriteLine("\nNhập thông tin cho từng phiếu mượn:\n");
                            Console.WriteLine("───────────────────────────────────────────────────────");
                            for (int i = 0; i < nPhieuMuon; i++)
                            {
                                Console.WriteLine("\n\tPhiếu mượn 0{0}", i + 1);
                                PhieuMuon tmp = new PhieuMuon();
                                tmp.Nhap();
                            }
                            Console.WriteLine("───────────────────────────────────────────────────────");
                            Console.WriteLine("\n\nTạo thành công {0} phiếu mượn!!!\n", nPhieuMuon);
                            Console.ReadKey();
                            break;
                        }
                    case 12://Tạo phiếu trả
                        {
                            Console.Clear();
                            int nPhieuTra = 0;
                            bool checkSl = false;
                            List<string> listMaSach = new List<string>();
                            while (!checkSl)
                            {
                                Console.Write("Nhập số lượng phiếu trả cần tạo: ");
                                checkSl = int.TryParse(Console.ReadLine(), out nPhieuTra);
                            }
                            Console.WriteLine("\nNhập thông tin cho từng phiếu trả:\n");
                            Console.WriteLine("───────────────────────────────────────────────────────");
                            for (int i = 0; i < nPhieuTra; i++)
                            {
                                Console.WriteLine("\n\tPhiếu mượn 0{0}", i + 1);
                                PhieuTra tmp = new PhieuTra();
                                tmp.Nhap();
                                tmp.UpdateInfo(Program.listDocGia,Program.listSach);
                                listMaSach.Add(tmp.Ma_sach.ToUpper());
                                Program.listPhieuTra.Add(tmp);
                                TraSach(tmp.Ma_sach);
                            }
                            Console.WriteLine("───────────────────────────────────────────────────────");
                            Console.WriteLine("\n\nTạo thành công {0} phiếu trả!!!\n", nPhieuTra);
                            Console.ReadKey();
                            break;
                        }
                    case 13://Danh sách mượn trễ
                        {
                            Console.Clear();
                            bool flag = false;
                            int k = 1;
                            Console.WriteLine("\n\n\n\t\t\t\t\t\t\tDANH SÁCH MƯỢN SÁCH TRỄ HẠN");
                            DrawTable.HeadingPhieuMuon();
                            foreach (var item in Program.listPhieuMuon)
                            {
                                if (item.So_ngay_qua_han!=0 && item.Check == false)
                                {
                                    Console.Write("│ {0,-3}", k++);
                                    item.Xuat();
                                    Console.WriteLine();
                                    flag = true;
                                }
                            }
                            DrawTable.FootingPhieuMuon();
                            if (!flag)
                                Console.WriteLine("Không tìm thấy Phiếu mượn!!!");
                            Console.ReadKey();
                            break;
                        }
                    case 0://Thoát
                        {
                            Console.Clear();
                            Console.WriteLine("\n\n\n");
                            Console.WriteLine("{0,90}", "┌───────────────────────────────────────────────────────┐");
                            Console.WriteLine("{0,33}│{1,55}│", "", "");
                            Console.WriteLine("{0,33}│\t\t   {1,-38}│", "", "KẾT THÚC CHƯƠNG TRÌNH!!!");
                            Console.WriteLine("{0,33}│{1,55}│", "", "");
                            Console.WriteLine("{0,90}", "└───────────────────────────────────────────────────────┘");
                            Console.WriteLine("\n\n\n");
                            Console.ReadKey();
                            check = false;
                            break;
                        }
                }
                _ = FileHandler.WriteToFileAsync();
            }
        }
    }
}
