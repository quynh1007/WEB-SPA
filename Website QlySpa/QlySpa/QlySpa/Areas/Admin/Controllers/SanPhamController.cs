using QlySpa.Models.DAO;
using QlySpa.Models.EF;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QlySpa.Areas.Admin.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: Admin/SanPham
        // GET: SanPham
        public ActionResult Index(string NgayTH = "", int pageNum = 1, int pageSize = 8)
        {
            ViewBag.HienThi = "0";
            if (NgayTH != "")
            {
                ViewBag.HienThi = "1";
            }
            ViewBag.NgayTH = NgayTH;

            SanPhamDAO dao = new SanPhamDAO();
            if (!string.IsNullOrEmpty(NgayTH))
            {
                return View(dao.listLoaiDVByNgayTH(NgayTH, pageNum, pageSize));
            }

            return View(dao.lstjoin(pageNum, pageSize));
        }
        // create
        //[Authorize(Roles = "ADMIN")]
        public ActionResult Create()
        {
            SanPhamDAO dao = new SanPhamDAO();
            //QCDAO d = new QCDAO();
            //ViewBag.cat = dao.ListQC();
            return View();
        }
        [HttpPost]
        //[Authorize(Roles = "ADMIN")]
        public ActionResult Create(SanPham sp, HttpPostedFileBase photo)
        {
            var img = Path.GetFileName(photo.FileName);
            SanPham SanPham = new SanPham();
            SanPham.TenSP = sp.TenSP;
            SanPham.HSD = sp.HSD;
            SanPham.Gia = sp.Gia;
            SanPham.HSD = sp.HSD;
            // them san pham vao db
            if (ModelState.IsValid)
            {
                if (photo != null && photo.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/Areas/Admin/Content/images/"),
                                            System.IO.Path.GetFileName(photo.FileName));
                    photo.SaveAs(path);

                    SanPham.Anh = photo.FileName;
                    SanPhamDAO dao = new SanPhamDAO();
                    dao.Create(SanPham);
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View(SanPham);
            }
        }

        //[Authorize(Roles = "ADMIN")]
        public ActionResult Edit(int id)
        {
            List<SanPham> ls = new List<SanPham>();
            SanPhamDAO dao = new SanPhamDAO();
            //QCDAO d = new QCDAO();
            //ViewBag.cat = d.ListQC();
            SanPham sp = dao.FindProductByID(id);
            ViewBag.id = id;
            //ViewBag.NgayTH = "";
            //if (sp.NgayTH != null)
            //{
            //    var lstDate = sp.NgayTH.ToString().Split(' ');
            //    var strDate = lstDate[0];
            //    //String dt = DateTime.ParseExact(strDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture); ;
            //    //ViewBag.NgayDangKy = dt;
            //}

            //ViewBag.HanSuDung = "";
            //if (sp.HanSuDung != null)
            //{
            //    var lstDate = sp.HanSuDung.ToString().Split(' ');
            //    var strDate = lstDate[0];
            //    String dt = DateTime.ParseExact(strDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture); ;
            //    ViewBag.HanSuDung = dt;
            //}

            return View(sp);
        }

        [HttpPost]

        public ActionResult Edit(SanPham sp, int id, HttpPostedFileBase photo)
        {
            SanPhamDAO dao = new SanPhamDAO();
            SanPham SanPham = dao.FindProductByID(id);
            SanPham.TenSP = sp.TenSP;
            SanPham.NSX = sp.NSX;
            SanPham.Gia = sp.Gia;
            SanPham.HSD = (sp.HSD);
            //SanPham.Anh = DateTime.Now;
            if (ModelState.IsValid)
            {
                if (photo != null && photo.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/Areas/Admin/Content/images/"),
                                            System.IO.Path.GetFileName(photo.FileName));
                    photo.SaveAs(path);

                    SanPham.Anh = photo.FileName;

                }
                SanPhamDAO d = new SanPhamDAO();
                d.Edit(SanPham);
                return RedirectToAction("Index");
            }
            else
            {
                return View(SanPham);
            }
        }

        // delete
        [HttpPost]
        //[Authorize(Roles = "ADMIN")]
        public string Delete(int id)
        {
            SanPhamDAO dao = new SanPhamDAO();
            SanPham sp = new SanPham();
            sp = dao.FindProductByID(id);
            if (sp != null)
            {
                dao.Delete(id);
            }
            return "OK";
        }
        public ActionResult Details(int id)
        {

            SanPhamDAO dao = new SanPhamDAO();
            SanPham sp = dao.FindProductByID(id);

            return View(sp);
        }
    }
}