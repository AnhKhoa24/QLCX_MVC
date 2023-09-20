using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLCX.Models;
namespace NghiemTuc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        ///=========Loại Cây===================
        public ActionResult LoaiCayXem()
        {
            QuanLyCayXanhEntities1 db = new QuanLyCayXanhEntities1();

            List<LoaiCay> ds = db.LoaiCays.ToList();
            return View(ds);
        }
        public ActionResult LoaiCayThem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoaiCayThem(LoaiCay model, HttpPostedFileBase fName)
        {
            if (fName.ContentLength > 0)
            {
                string rootFolder = Server.MapPath("~/Photos/");
                string pathEmail = rootFolder + fName.FileName;
                fName.SaveAs(pathEmail);
                model.HinhAnh = fName.FileName;
            }
            QuanLyCayXanhEntities1 db = new QuanLyCayXanhEntities1();
            db.LoaiCays.Add(model);
            db.SaveChanges();
            return RedirectToAction("LoaiCayXem");
        }
        public ActionResult LoaiCaySua(int id)
        {
            QuanLyCayXanhEntities1 db = new QuanLyCayXanhEntities1();
            var model = db.LoaiCays.Find(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult LoaiCaySua(LoaiCay model, HttpPostedFileBase newFile, string oldFile)
        {
            if (newFile == null)
            {
                model.HinhAnh = oldFile;
            }
            else if (newFile.ContentLength > 0)
            {
                string rootFolder = Server.MapPath("~/Photos/");
                string pathEmail = rootFolder + newFile.FileName;
                newFile.SaveAs(pathEmail);
                model.HinhAnh = newFile.FileName;
                string imagePath = Server.MapPath("~/Photos/" + oldFile);
                System.IO.File.Delete(imagePath);
            }
            QuanLyCayXanhEntities1 db = new QuanLyCayXanhEntities1();
            var chages = db.LoaiCays.Find(model.MaLoaiCay);
            chages.MaLoaiCay = model.MaLoaiCay;
            chages.TenLoaiCay = model.TenLoaiCay;
            chages.XuatXu = model.XuatXu;
            chages.HinhAnh = model.HinhAnh;
            db.SaveChanges();
            return RedirectToAction("LoaiCayXem");
        }
        public ActionResult LoaiCayXoa(int id)
        {
            QuanLyCayXanhEntities1 db = new QuanLyCayXanhEntities1();
            var delete = db.LoaiCays.Find(id);
            return View(delete);
        }
        [HttpPost]
        public ActionResult LoaiCayXoa(LoaiCay model)
        {

            QuanLyCayXanhEntities1 db = new QuanLyCayXanhEntities1();
            var check_fist = db.DinhMucs.FirstOrDefault(m => m.LoaiCay == model.MaLoaiCay);
            var check_secon = db.Cays.SingleOrDefault(m => m.LoaiCay == model.MaLoaiCay);
            if(check_fist != null || check_secon != null)
            {
                TempData["ErrorMessage"] = "Không thể xóa loại cây này! Lỗi ràng buộc khóa ngoại";
                return RedirectToAction("LoaiCayXoa");
            }    
            var del = db.LoaiCays.Find(model.MaLoaiCay);
            string filename = del.HinhAnh;
            db.LoaiCays.Remove(del);
            db.SaveChanges();
            if (filename != null)
            {
                string imagePath = Server.MapPath("~/Photos/" + filename);
                System.IO.File.Delete(imagePath);
            }

            return RedirectToAction("LoaiCayXem");
        }

        ///============Định mức==========

        public ActionResult DinhMucXem()
        {
            QuanLyCayXanhEntities1 db = new QuanLyCayXanhEntities1();
            List<DinhMuc> ds = db.DinhMucs.ToList();
            return View(ds);
        }
        public ActionResult DinhMucThem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DinhMucThem(DinhMuc model)
        {
            QuanLyCayXanhEntities1 db = new QuanLyCayXanhEntities1();
            db.DinhMucs.Add(model);
            db.SaveChanges();
            return RedirectToAction("DinhMucXem");
        }
        public ActionResult DinhMucSua(int id1, int id2)
        {
            QuanLyCayXanhEntities1 db = new QuanLyCayXanhEntities1();
            var model = db.DinhMucs.SingleOrDefault(m => m.LoaiCay == id2 && m.TuoiCuaCay == id1);
            return View(model);
        }
        [HttpPost]
        public ActionResult DinhMucSua(DinhMuc model, int OldId, int OldAge)
        {
            QuanLyCayXanhEntities1 db = new QuanLyCayXanhEntities1();
            DinhMuc changes = db.DinhMucs.SingleOrDefault(m => m.LoaiCay == OldId && m.TuoiCuaCay == OldAge);
            changes.TienChamSoc = model.TienChamSoc;
            db.SaveChanges();
            return RedirectToAction("DinhMucXem");

        }
        public ActionResult DinhMucXoa(int id, int age)
        {
            QuanLyCayXanhEntities1 db = new QuanLyCayXanhEntities1();
            var delete = db.DinhMucs.SingleOrDefault(m => m.LoaiCay == id && m.TuoiCuaCay == age);
            return View(delete);
        }

        [HttpPost]
        public ActionResult DinhMucXoa(DinhMuc model)
        {
            QuanLyCayXanhEntities1 db = new QuanLyCayXanhEntities1();
            var delete = db.DinhMucs.SingleOrDefault(m => m.LoaiCay == model.LoaiCay && m.TuoiCuaCay == model.TuoiCuaCay);
            db.DinhMucs.Remove(delete);
            db.SaveChanges();
            return RedirectToAction("DinhMucXem");
        }
        //======Cây==========
        public ActionResult CayXem()
        {
            QuanLyCayXanhEntities1 db = new QuanLyCayXanhEntities1();
            List<Cay> ds = db.Cays.ToList();
            return View(ds);
        }
        public ActionResult CayThem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CayThem(Cay model)
        {
            QuanLyCayXanhEntities1 db = new QuanLyCayXanhEntities1();
            var temp = db.Cays.SingleOrDefault(m => m.STTCay == model.STTCay && m.MaDuong == model.MaDuong);
            if (temp != null)
            {
                ViewBag.error = "Đã tồn tại!!";
                return RedirectToAction("CayThem");
            }

            db.Cays.Add(model);
            db.SaveChanges();
            return RedirectToAction("CayXem");
        }
        public ActionResult CaySua(int stt, int md)
        {
            QuanLyCayXanhEntities1 db = new QuanLyCayXanhEntities1();
            var model = db.Cays.SingleOrDefault(m => m.STTCay == stt && m.MaDuong == md);
            return View(model);
        }
        [HttpPost]
        public ActionResult CaySua(Cay model)
        {
            QuanLyCayXanhEntities1 db = new QuanLyCayXanhEntities1();
            var change = db.Cays.SingleOrDefault(m => m.STTCay == model.STTCay && m.MaDuong == model.MaDuong);
            change.STTCay = model.STTCay;
            change.LoaiCay = model.LoaiCay;
            change.MaDuong = model.MaDuong;
            change.NgayChatBo = model.NgayChatBo;
            change.NgayTrong = model.NgayTrong;
            change.TuoiCayLucTrong = model.TuoiCayLucTrong;
            db.SaveChanges();
            return RedirectToAction("CayXem");
        }
        public ActionResult CayXoa(int stt, int md)
        {
            QuanLyCayXanhEntities1 db = new QuanLyCayXanhEntities1();
            var del = db.Cays.SingleOrDefault(m => m.STTCay == stt && m.MaDuong == md);
            return View(del);
        }
        [HttpPost]
        public ActionResult CayXoa(FormCollection f)
        {
            int stt = int.Parse(f["stt"]);
            int md = int.Parse(f["md"]);
            QuanLyCayXanhEntities1 db = new QuanLyCayXanhEntities1();
            var del = db.Cays.SingleOrDefault(m => m.STTCay == stt && m.MaDuong == md);
            db.Cays.Remove(del);
            db.SaveChanges();
            return RedirectToAction("CayXem");
        }



        //=====Con Đường========
        public ActionResult ConDuongXem()
        {
            QuanLyCayXanhEntities1 db = new QuanLyCayXanhEntities1();
            List<ConDuong> ds = db.ConDuongs.ToList();
            return View(ds);
        }
        public ActionResult ConDuongThem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ConDuongThem(ConDuong model)
        {
            QuanLyCayXanhEntities1 db = new QuanLyCayXanhEntities1();
            db.ConDuongs.Add(model);
            db.SaveChanges();
            return RedirectToAction("ConDuongXem");
        }
        public ActionResult ConDuongSua(int id)
        {
            QuanLyCayXanhEntities1 db = new QuanLyCayXanhEntities1();
            var model = db.ConDuongs.Find(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult ConDuongSua(ConDuong model)
        {
            QuanLyCayXanhEntities1 db = new QuanLyCayXanhEntities1();
            var changes = db.ConDuongs.Find(model.MaDuong);
            changes.ChieuDai = model.ChieuDai;
            changes.TenDuong = model.TenDuong;
            db.SaveChanges();
            return RedirectToAction("ConDuongXem");
        }
        public ActionResult ConDuongXoa(int id)
        {
            QuanLyCayXanhEntities1 db = new QuanLyCayXanhEntities1();
            var model = db.Cays.FirstOrDefault(m => m.MaDuong == id);
            return View(model);
        }
        [HttpPost]
        public ActionResult ConDuongXoa(ConDuong model)
        {
            QuanLyCayXanhEntities1 db = new QuanLyCayXanhEntities1();
            var check_first = db.Cays.FirstOrDefault(m => m.MaDuong == model.MaDuong);
            var check_second = db.ConDuongQuans.SingleOrDefault(m => m.MaDuong == model.MaDuong);
            if(check_first != null && check_second != null)
            {
                TempData["ErrorMessage"] = "Không thể xóa loại cây này! Lỗi ràng buộc khóa ngoại";
                return RedirectToAction("ConDuongXoa");
            }            
            var del = db.ConDuongs.Find(model.MaDuong);
            db.ConDuongs.Remove(del);
            db.SaveChanges();
            return RedirectToAction("ConDuongXem");
        }
        //=========Con Đường Quận========
        public ActionResult QuanXem()
        {
            QuanLyCayXanhEntities1 db = new QuanLyCayXanhEntities1();
            var model = db.ConDuongQuans.ToList();
            return View(model);
        }
        public ActionResult QuanThem()
        {
            return View();
        }

    }
}