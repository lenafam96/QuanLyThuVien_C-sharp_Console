using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace QuanLyThuVien
{
    class FileHandler
    {
        public static void ReadFromFile()
        {
            List<string> listLineSach = new List<string>(System.IO.File.ReadAllLines("listSach.txt"));
            List<string> listLineDocGia = new List<string>(System.IO.File.ReadAllLines("listDocGia.txt"));
            List<string> listLinePhieuMuon = new List<string>(System.IO.File.ReadAllLines("listPhieuMuon.txt"));
            List<string> listLinePhieuTra = new List<string>(System.IO.File.ReadAllLines("listPhieuTra.txt"));
            foreach (var item in listLineSach)
            {
                string[] arr = item.Split(",");
                if(!arr[0].Equals(""))
                {
                    Sach tmp = new Sach(arr[0].ToUpper(), arr[1].ToUpper(), arr[2].ToUpper(), arr[3].ToUpper(), int.Parse(arr[4]));
                    Program.listSach.Add(tmp);
                }
            }
            foreach (var item in listLineDocGia)
            {
                string[] arr = item.Split(",");
                if(!arr[0].Equals(""))
                {
                    DocGia tmp = new DocGia(arr[0].ToUpper(), arr[1].ToUpper(), DateTime.Parse(arr[2].ToUpper()), arr[3].ToUpper());
                    Program.listDocGia.Add(tmp);
                }
            }
            foreach (var item in listLinePhieuMuon)
            {
                string[] arr = item.Split(",");
                if(!arr[0].Equals(""))
                {
                    PhieuMuon tmp = new PhieuMuon(arr[0].ToUpper(), arr[1].ToUpper(), arr[2].ToUpper(), DateTime.Parse(arr[3]),bool.Parse(arr[4]));
                    tmp.UpdateInfo(Program.listDocGia, Program.listSach);
                    Program.listPhieuMuon.Add(tmp);
                }
            }
            foreach (var item in listLinePhieuTra)
            {
                string[] arr = item.Split(",");
                if(!arr[0].Equals(""))
                {
                    PhieuTra tmp = new PhieuTra(arr[0].ToUpper(), arr[1].ToUpper(), arr[2].ToUpper(), DateTime.Parse(arr[3]), DateTime.Parse(arr[4]));
                    tmp.UpdateInfo(Program.listDocGia, Program.listSach);
                    Program.listPhieuTra.Add(tmp);
                }
            }
        }
        public static async Task WriteToFileAsync()
        {
            List<string> listLineSach = new List<string>();
            List<string> listLineDocGia = new List<string>();
            List<string> listLinePhieuMuon = new List<string>();
            List<string> listLinePhieuTra = new List<string>();
            foreach (var item in Program.listSach)
            {
                string line = item.Ma_sach.ToUpper() + "," + item.Ten_sach.ToUpper() + "," + item.Tac_gia.ToUpper() + "," + item.Nha_xuat_ban.ToUpper() + "," + item.Gia_sach;
                listLineSach.Add(line);
            }
            foreach (var item in Program.listDocGia)
            {
                string line = item.Ma_doc_gia.ToUpper() + "," + item.Ten_doc_gia.ToUpper() + "," + item.Ngay_sinh.ToString("dd MM yyyy") + "," + item.Cmnd;
                listLineDocGia.Add(line);
            }
            foreach (var item in Program.listPhieuMuon)
            {
                string line = item.Ma_phieu.ToUpper() + "," + item.Ma_doc_gia.ToUpper() + "," + item.Ma_sach.ToUpper() + "," + item.Ngay_muon.ToString("dd MM yyyy") + "," + item.Check;
                listLinePhieuMuon.Add(line);
            }
            foreach (var item in Program.listPhieuTra)
            {
                string line = item.Ma_phieu.ToUpper() + "," + item.Ma_doc_gia.ToUpper() + "," + item.Ma_sach.ToUpper() + "," + item.Ngay_muon.ToString("dd MM yyyy") + "," + item.Ngay_tra.ToString("dd MM yyyy");
                listLinePhieuTra.Add(line);
            }
            string[] arrSach = listLineSach.ToArray();
            string[] arrDocGia = listLineDocGia.ToArray();
            string[] arrPhieuMuon = listLinePhieuMuon.ToArray();
            string[] arrPhieuXuat = listLinePhieuTra.ToArray();
            await File.WriteAllLinesAsync("listSach.txt", arrSach);
            await File.WriteAllLinesAsync("listDocGia.txt", arrDocGia);
            await File.WriteAllLinesAsync("listPhieuMuon.txt", arrPhieuMuon);
            await File.WriteAllLinesAsync("listPhieuTra.txt", arrPhieuXuat);
        }
    }
}
