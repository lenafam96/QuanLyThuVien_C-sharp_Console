using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyThuVien
{
    class Phieu
    {
        private string ma_phieu;
        private string ma_doc_gia;
        private string ten_doc_gia;
        private string ma_sach;
        private string ten_sach;
        private DateTime ngay_muon;

        public string Ma_phieu { get => ma_phieu; set => ma_phieu = value; }
        public string Ma_doc_gia { get => ma_doc_gia; set => ma_doc_gia = value; }
        public string Ten_doc_gia { get => ten_doc_gia; set => ten_doc_gia = value; }
        public string Ma_sach { get => ma_sach; set => ma_sach = value; }
        public string Ten_sach { get => ten_sach; set => ten_sach = value; }
        public DateTime Ngay_muon { get => ngay_muon; set => ngay_muon = value; }

        public Phieu(string ma_phieu = null, string ma_doc_gia = null, string ten_doc_gia = null, string ma_sach = null, string ten_sach = null, DateTime? ngay_muon = null)
        {
            this.ma_phieu = ma_phieu;
            this.ma_doc_gia = ma_doc_gia;
            this.ten_doc_gia = ten_doc_gia;
            this.ma_sach = ma_sach;
            this.ten_sach = ten_sach;
            this.ngay_muon = ngay_muon == null ? DateTime.Parse("1900-1-1") : (DateTime)ngay_muon;
        }

        public void Nhap()
        {
            bool check = false;
            Console.Write("Nhập mã phiếu: ");
            this.ma_phieu = Console.ReadLine();
            Console.Write("Nhập mã độc giả: ");
            this.ma_doc_gia = Console.ReadLine();
            Console.Write("Nhập mã sách: ");
            this.ma_sach = Console.ReadLine();
            do
            {
                Console.Write("Nhập ngày mượn: ");
                check = DateTime.TryParse(Console.ReadLine(), out this.ngay_muon);
            } while (!check);
        }
        public void Xuat()
        {
            Console.Write("{0,-10}{1,-15}{2,-30}{3,-10}{4,-30}{5,-13}", "│ " + this.ma_phieu.ToUpper(), "│ " + this.ma_doc_gia.ToUpper(), "│ " + this.ten_doc_gia.ToUpper(), "│ " + this.ma_sach.ToUpper(), "│ " + this.ten_sach.ToUpper(), "│ " + this.ngay_muon.ToString("dd/MM/yyyy"));
        }
        public void UpdateInfo(List<DocGia> docGia, List<Sach> sach, Sach sach_moi = null, string ma_sach_cu = null, DocGia doc_gia_moi = null, string ma_doc_gia_cu = null)
        {
            if(sach_moi != null)
            {
                foreach (var item in docGia)
                {
                    if (item.Ma_doc_gia == this.ma_doc_gia)
                    {
                        this.ten_doc_gia = item.Ten_doc_gia;
                        break;
                    }
                }
                if (this.ma_sach.ToUpper().Equals(ma_sach_cu))
                {
                    this.ma_sach = sach_moi.Ma_sach;
                    this.ten_sach = sach_moi.Ten_sach;
                }
                return;
            } 
            if (doc_gia_moi != null)
            {
                if (this.ma_doc_gia.ToUpper().Equals(ma_doc_gia_cu))
                {
                    this.ma_doc_gia = doc_gia_moi.Ma_doc_gia;
                    this.ten_doc_gia = doc_gia_moi.Ten_doc_gia;
                }
                foreach (var item in sach)
                {
                    if (item.Ma_sach == this.ma_sach)
                    {
                        this.ten_sach = item.Ten_sach;
                        break;
                    }
                }
                return;
            }
            foreach (var item in docGia)
            {
                if (item.Ma_doc_gia == this.ma_doc_gia)
                {
                    this.ten_doc_gia = item.Ten_doc_gia;
                    break;
                }
            }
            foreach (var item in sach)
            {
                if (item.Ma_sach == this.ma_sach)
                {
                    this.ten_sach = item.Ten_sach;
                    break;
                }
            }
        }
    }

    class PhieuMuon : Phieu
    {
        private int so_ngay_qua_han;
        private int tien_phat;
        private bool check;

        public int So_ngay_qua_han { get => so_ngay_qua_han; set => so_ngay_qua_han = value; }
        public int Tien_phat { get => tien_phat; set => tien_phat = value; }
        public bool Check { get => check; set => check = value; }

        public PhieuMuon(string ma_phieu = null, string ma_doc_gia = null, string ma_sach = null, DateTime? ngay_muon = null, bool? check = null)
        {
            base.Ma_phieu = ma_phieu;
            base.Ma_doc_gia = ma_doc_gia;
            base.Ma_sach = ma_sach;
            base.Ngay_muon = ngay_muon == null ? DateTime.Parse("1900-1-1") : (DateTime)ngay_muon;
            this.so_ngay_qua_han = (DateTime.Now - base.Ngay_muon.AddDays(7)).Days;
            this.tien_phat = this.so_ngay_qua_han > 0 ? this.so_ngay_qua_han * 2000 : 0;
            this.check = (bool)check;
        }
        public void Xuat()
        {
            base.Xuat();
            Console.Write("{0,-20}{1,-12}│", "│ " + this.so_ngay_qua_han, "│ " + this.tien_phat);
        }
    }

    class PhieuTra : Phieu
    {
        private DateTime ngay_tra;
        private int tien_phat;

        
        public int Tien_phat { get => tien_phat; set => tien_phat = value; }
        public DateTime Ngay_tra { get => ngay_tra; set => ngay_tra = value; }

        public PhieuTra(string ma_phieu = null, string ma_doc_gia = null, string ma_sach = null, DateTime? ngay_muon = null, DateTime? ngay_tra = null)
        {
            base.Ma_phieu = ma_phieu;
            base.Ma_doc_gia = ma_doc_gia;
            base.Ma_sach = ma_sach;
            base.Ngay_muon = ngay_muon == null ? DateTime.Parse("1900-1-1") : (DateTime)ngay_muon;
            this.Ngay_tra = ngay_tra == null ? DateTime.Parse("1900-1-1") : (DateTime)ngay_tra;
            var result = this.ngay_tra - this.Ngay_muon;
            this.tien_phat = result.Days>0?result.Days * 2000:0;
        }
        public void Nhap()
        {
            base.Nhap();
            bool check = false;
            do
            {
                Console.Write("Nhập ngày trả: ");
                check = DateTime.TryParse(Console.ReadLine(), out this.ngay_tra);
            } while (!check);
        }
        public void Xuat()
        {
            base.Xuat();
            Console.Write("{0,-15}{1,-15} │", this.ngay_tra, this.tien_phat);
        }
    }
}
