using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LapTop.Models
{
    public class Giohang
    {
        WEBEntities1 data = new WEBEntities1();
        public int iMahang { set; get; }
        public string sTenhang { set; get; }
        public string sAnhbia { set; get; }
        public Double dDongia { set; get; }
        public int iSoluong { set; get; }
        public Double dThanhtien
        {
            get { return iSoluong * dDongia; }

        }
        //Khoi tao gio hàng theo Masach duoc truyen vao voi Soluong mac dinh la 1
        public Giohang(int Mahang)
        {
            iMahang = Mahang;
            SanPham hang = data.SanPhams.Single(n => n.ma == iMahang);
            sTenhang = hang.ten;
            sAnhbia = hang.hinh;
            dDongia = double.Parse(hang.gia.ToString());
            iSoluong = 1;
        }
    }
}