using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyThuVien
{
    class Sach
    {
        private string ma_sach;
        private string ten_sach;
        private string tac_gia;
        private string nha_xuat_ban;
        private int gia_sach;

        public string Ma_sach { get => ma_sach; set => ma_sach = value; }
        public string Ten_sach { get => ten_sach; set => ten_sach = value; }
        public string Tac_gia { get => tac_gia; set => tac_gia = value; }
        public string Nha_xuat_ban { get => nha_xuat_ban; set => nha_xuat_ban = value; }
        public int Gia_sach { get => gia_sach; set => gia_sach = value; }

        public Sach(string ma_sach = null, string ten_sach = null, string tac_gia = null, string nha_xuat_ban = null, int gia_sach = 0, int so_luong = 0)
        {
            this.ma_sach = ma_sach;
            this.ten_sach = ten_sach;
            this.tac_gia = tac_gia;
            this.nha_xuat_ban = nha_xuat_ban;
            this.gia_sach = gia_sach;
        }

        public void Nhap()
        {
            bool check = false;
            Console.Write("Nhập mã sách: ");
            this.ma_sach = Console.ReadLine();
            Console.Write("Nhập tên sách: ");
            this.ten_sach = Console.ReadLine();
            Console.Write("Nhập tên tác giả: ");
            this.tac_gia = Console.ReadLine();
            Console.Write("Nhập tên nhà xuất bản: ");
            this.nha_xuat_ban = Console.ReadLine();
            do
            {
                Console.Write("Nhập số giá sách: ");
                check = int.TryParse(Console.ReadLine(), out this.gia_sach);
            } while (!check);
        }
        public void Xuat()
        {
            Console.Write("{0,-10}{1,-30}{2,-20}{3,-20}{4,-15}│", "│ " + this.ma_sach.ToUpper(), "│ " + this.ten_sach.ToUpper(), "│ " + this.tac_gia.ToUpper(), "│ " + this.nha_xuat_ban, "│ " + this.gia_sach);
        }

    }

}
