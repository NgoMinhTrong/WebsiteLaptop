using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Web;
using System.Web.Mvc;
using LapTop.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;
using System.Linq;

namespace LapTop.Controllers
{
    public class AdminController : Controller
    {
        WEBEntities1 db = new WEBEntities1();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SanPham(int? page)
        {
            return View();

        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            // Gán các giá trị người dùng nhập liệu cho các biến 
            var tendangnhap = collection["username"];
            var mk = collection["password"];
            if (String.IsNullOrEmpty(tendangnhap))
            {
                ViewData["Loi1"] = "Phải nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(mk))
            {
                ViewData["Loi2"] = "Phải nhập mật khẩu";
            }
            else
            {
                //Gán giá trị cho đối tượng được tạo mới (ad)        
                Admin ad = db.Admins.SingleOrDefault(n => n.UserAdmin == tendangnhap && n.PassAdmin == mk);

                if (ad != null)
                {
                    ViewBag.Thongbao = "Chúc mừng đăng nhập thành công"; 
                    Session["Taikhoanadmin"] = ad;
                    return RedirectToAction("Index", "Admin");
                }
                else
                    ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
            }
            return View();
        }
        [HttpGet]
        public ActionResult ThemmoiHang()
        {
            //Dua du lieu vao dropdownList
            //Lay ds tu tabke chu de, sắp xep tang dan trheo ten chu de, chon lay gia tri Ma CD, hien thi thi Tenchude
            ViewBag.maDanhMuc = new SelectList(db.DanhMucs.ToList().OrderBy(n => n.ten), "ma", "ten");
            ViewBag.maThuongHieu = new SelectList(db.thuongHieux.ToList().OrderBy(n => n.ten), "ma", "ten");
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemmoiHang(SanPham hang, HttpPostedFileBase fileUpload)
        {
            //Dua du lieu vao dropdownload
            ViewBag.maDanhMuc = new SelectList(db.DanhMucs.ToList().OrderBy(n => n.ten), "ma", "ten");
            ViewBag.maThuongHieu = new SelectList(db.thuongHieux.ToList().OrderBy(n => n.ten), "ma", "ten");
            //Kiem tra duong dan file
            if (fileUpload == null)
            {
                ViewBag.Thongbao = "Vui lòng chọn ảnh";
                return View();
            }
            //Them vao CSDL
            else
            {
                if (ModelState.IsValid)
                {
                    //Luu ten fie, luu y bo sung thu vien using System.IO;
                    var fileName = Path.GetFileName(fileUpload.FileName);
                    //Luu duong dan cua file
                    var path = Path.Combine(Server.MapPath("~/image_product"), fileName);
                    //Kiem tra hình anh ton tai chua?
                    if (System.IO.File.Exists(path))
                        ViewBag.Thongbao = "Hình ảnh đã tồn tại";
                    else
                    {
                        //Luu hinh anh vao duong dan
                        fileUpload.SaveAs(path);
                    }
                    hang.hinh = fileName;
                    //Luu vao CSDL
                    db.SanPhams.Add(hang);
                    db.SaveChanges();
                }
                return RedirectToAction("SanPham","Admin");


            }
        }
        //Hiển thị sản phẩm
        public ActionResult Chitiethang(int id)
        {
            //Lay ra doi tuong sach theo ma
            SanPham hang = db.SanPhams.SingleOrDefault(n => n.ma == id);
            ViewBag.ma = hang.ma;
            if (hang == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(hang);
        }
        
        public ActionResult xoa(int id)
        {
            //Lay ra doi tuong sach can xoa theo ma
            SanPham hang = db.SanPhams.SingleOrDefault(n => n.ma == id);
            ViewBag.Mahang = hang.ma;
            if (hang == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.SanPhams.Remove(hang);
            db.SaveChanges();
            return RedirectToAction("SanPham");
        }
        //Chinh sửa sản phẩm
        [HttpGet]
        public ActionResult Suahang(int id)
        {
            //Lay ra doi tuong sach theo ma
            SanPham hang = db.SanPhams.SingleOrDefault(n => n.ma == id);
            ViewBag.ma = hang.ma;
            if (hang == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Dua du lieu vao dropdownList
            //Lay ds tu tabke chu de, sắp xep tang dan trheo ten chu de, chon lay gia tri Ma CD, hien thi thi Tenchude
            ViewBag.MaCD = new SelectList(db.DanhMucs.ToList().OrderBy(n => n.ten), "ma", "ten", hang.ma);
            ViewBag.MaNXB = new SelectList(db.thuongHieux.ToList().OrderBy(n => n.ten), "ma", "ten", hang.ma);
            return View(hang);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Suahang(SanPham hang, HttpPostedFileBase fileUpload)
        {
            //Dua du lieu vao dropdownload
            ViewBag.MaCD = new SelectList(db.DanhMucs.ToList().OrderBy(n => n.ten), "ma", "ten");
            ViewBag.MaNCC = new SelectList(db.thuongHieux.ToList().OrderBy(n => n.ten), "ma", "ten");
            //Kiem tra duong dan file
            if (fileUpload == null)
            {
                ViewBag.Thongbao = "Vui lòng chọn ảnh bìa";
                return View();
            }
            //Them vao CSDL
            else
            {
                if (ModelState.IsValid)
                {
                    //Luu ten fie, luu y bo sung thu vien using System.IO;
                    var fileName = Path.GetFileName(fileUpload.FileName);
                    //Luu duong dan cua file
                    var path = Path.Combine(Server.MapPath("~/image_product"), fileName);
                    //Kiem tra hình anh ton tai chua?

                    fileUpload.SaveAs(path);

                    SanPham lp = db.SanPhams.SingleOrDefault(n => n.ma == hang.ma);
                    lp.ten = hang.ten;
                    lp.mota = hang.mota;
                    lp.hinh = fileName;
                    lp.gia = hang.gia;
                    lp.soluong = hang.soluong;
                    //Luu vao CSDL   
                    UpdateModel(hang);
                    db.SaveChanges();

                }
                return RedirectToAction("SanPham");
            }
        }
    }


}