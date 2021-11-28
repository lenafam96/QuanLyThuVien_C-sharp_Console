using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyThuVien
{
    class CreateMenu
    {
        public static void Create_Menu()
        {
            Console.Clear();
            List<string> yc = new List<string>();
            yc.Add("CHƯƠNG TRÌNH QUẢN LÝ THƯ VIỆN");
            yc.Add("1. Thêm sách mới");
            yc.Add("2. Xoá sách theo mã");
            yc.Add("3. Sửa thông tin sách");
            yc.Add("4. Tìm kiếm sách theo tên");
            yc.Add("5. Danh sách Sách");
            yc.Add("6. Thêm độc giả mới");
            yc.Add("7. Xoá độc giả theo mã");
            yc.Add("8. Sửa thông tin độc giả");
            yc.Add("9. Tìm kiếm độc giả");
            yc.Add("10. Danh sách độc giả");
            yc.Add("11. Tạo phiếu mượn sách");
            yc.Add("12. Tạo phiếu trả sách");
            yc.Add("13. Danh sách mượn sách trễ hạn");
            yc.Add("0. Thoát");
            yc.Add("Nhập lựa chọn: ");

            Console.WriteLine("\n\n");
            Console.WriteLine("{0,90}", "┌───────────────────────────────────────────────────────┐");
            Console.WriteLine("{0,33}│{1,55}│", "", "");
            Console.WriteLine("{0,33}│\t{1,-49}│", "", yc[0]);
            Console.WriteLine("{0,33}│{1,55}│", "", "");
            for (int i = 1; i < 15; i++)
                Console.WriteLine("{0,33}│\t\t{1,-41}│", "", yc[i]);
            Console.WriteLine("{0,33}│{1,55}│", "", "");
            Console.WriteLine("{0,90}", "└───────────────────────────────────────────────────────┘");
            Console.WriteLine("\n\n\n");
            Console.Write("{0,33}\t\t{1}", "", yc[15]);
        }
    }
}
