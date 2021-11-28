using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace QuanLyThuVien
{
    class Program
    {
        public static List<Sach> listSach = new List<Sach>();
        public static List<DocGia> listDocGia = new List<DocGia>();
        public static List<PhieuMuon> listPhieuMuon = new List<PhieuMuon>();
        public static List<PhieuTra> listPhieuTra = new List<PhieuTra>();
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            CultureInfo.CurrentCulture = new CultureInfo("en-GB", false);
            FileHandler.ReadFromFile();
            DrawMenu.Menu();
        }
    }
}
