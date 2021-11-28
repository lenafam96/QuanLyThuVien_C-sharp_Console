using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyThuVien
{
    class DrawTable
    {
        public static void HeadingSach()
        {
            Console.WriteLine("\n\n\n");
            Console.WriteLine("{0}", "┌────┬─────────┬─────────────────────────────┬───────────────────┬───────────────────┬──────────────┐");
            Console.WriteLine("{0,-5}{1,-10}{2,-30}{3,-20}{4,-20}{5,-15}│", "│STT", "│ Mã sách", "│ Tên sách", "│ Tên tác giả", "│ Nhà xuất bản", "│ Giá sách");
            Console.WriteLine("{0}", "├────┼─────────┼─────────────────────────────┼───────────────────┼───────────────────┼──────────────┤");
        }
        public static void FootingSach()
        {
            Console.WriteLine("{0}", "└────┴─────────┴─────────────────────────────┴───────────────────┴───────────────────┴──────────────┘");
            Console.WriteLine("\n\n\n");
        }
        public static void HeadingDocGia()
        {
            Console.WriteLine("\n\n\n");
            Console.WriteLine("{0}", "┌────┬──────────────┬─────────────────────────────┬────────────┬───────────┐");
            Console.WriteLine("{0,-5}{1,-15}{2,-30}{3,-13}{4,-12}│", "│STT", "│ Mã độc giả", "│ Tên độc giả", "│ Ngày sinh", "│ CCCD/CMND");
            Console.WriteLine("{0}", "├────┼──────────────┼─────────────────────────────┼────────────┼───────────┤");
        }
        public static void FootingDocGia()
        {
            Console.WriteLine("{0}", "└────┴──────────────┴─────────────────────────────┴────────────┴───────────┘");
            Console.WriteLine("\n\n\n");
        }
        public static void HeadingPhieuMuon()
        {
            Console.WriteLine("\n\n\n");
            Console.WriteLine("{0}", "┌────┬─────────┬──────────────┬─────────────────────────────┬─────────┬─────────────────────────────┬────────────┬───────────────────┬───────────┐");
            Console.WriteLine("{0,-5}{1,-10}{2,-15}{3,-30}{4,-10}{5,-30}{6,-13}{7,-20}{8,-12}│", "│STT", "│Mã phiếu", "│ Mã độc giả", "│ Tên độc giả", "│ Mã sách", "│ Tên sách", "│ Ngày mượn", "│ Số ngày quá hạn", "│ Tiền phạt");
            Console.WriteLine("{0}", "├────┼─────────┼──────────────┼─────────────────────────────┼─────────┼─────────────────────────────┼────────────┼───────────────────┼───────────┤");
        }
        public static void FootingPhieuMuon()
        {
            Console.WriteLine("{0}", "└────┴─────────┴──────────────┴─────────────────────────────┴─────────┴─────────────────────────────┴────────────┴───────────────────┴───────────┘");
            Console.WriteLine("\n\n\n");
        }
    }
}
