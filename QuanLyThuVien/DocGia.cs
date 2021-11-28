using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyThuVien
{
    class DocGia
    {
        private string ma_doc_gia;
        private string ten_doc_gia;
        private DateTime ngay_sinh;
        private string cmnd;

        public string Ma_doc_gia { get => ma_doc_gia; set => ma_doc_gia = value; }
        public string Ten_doc_gia { get => ten_doc_gia; set => ten_doc_gia = value; }
        public DateTime Ngay_sinh { get => ngay_sinh; set => ngay_sinh = value; }
        public string Cmnd { get => cmnd; set => cmnd = value; }

        public DocGia(string ma_doc_gia = null, string ten_doc_gia = null, DateTime? ngay_sinh = null, string cmnd = null)
        {
            this.ma_doc_gia = ma_doc_gia;
            this.ten_doc_gia = ten_doc_gia;
            this.ngay_sinh = ngay_sinh == null ? DateTime.Parse("1900-1-1") : (DateTime)ngay_sinh;
            this.cmnd = cmnd;
        }
        public void Nhap()
        {
            bool check = false;
            Console.Write("Nhập mã độc giả: ");
            this.ma_doc_gia = Console.ReadLine();
            Console.Write("Nhập họ tên độc giả: ");
            this.ten_doc_gia = Console.ReadLine();
            do
            {
                Console.Write("Nhập ngày sinh: ");
                check = DateTime.TryParse(Console.ReadLine(), out this.ngay_sinh);
            } while (!check);
            Console.Write("Nhập số CCCD/CMND: ");
            this.cmnd = Console.ReadLine();
        }
        public void Xuat()
        {
            Console.Write("{0,-15}{1,-30}{2,-13}{3,-12}│", "│ " + this.ma_doc_gia.ToUpper(), "│ " + this.ten_doc_gia.ToUpper(), "│ " + this.ngay_sinh.ToString("dd/MM/yyyy"), "│ " + this.cmnd);
        }
    }
}
