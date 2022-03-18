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
    public class ServiceTypeController : Controller
    {
        // GET: Admin/ServiceType
        // GET: ServiceType
        public ActionResult Index(string NgayTH = "", int pageNum = 1, int pageSize = 8)
        {
            ViewBag.HienThi = "0";
            if (NgayTH != "")
            {
                ViewBag.HienThi = "1";
            }
            ViewBag.NgayTH = NgayTH;

            ServiceTypeDAO dao = new ServiceTypeDAO();
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
            ServiceTypeDAO dao = new ServiceTypeDAO();
            //QCDAO d = new QCDAO();
            //ViewBag.cat = dao.ListQC();
            return View();
        }
        [HttpPost]
        //[Authorize(Roles = "ADMIN")]
        public ActionResult Create(LoaiDichVu sp, HttpPostedFileBase photo)
        {
            var img = Path.GetFileName(photo.FileName);
            LoaiDichVu ServiceType = new LoaiDichVu();
            ServiceType.tenLoaiDV = sp.tenLoaiDV;
            ServiceType.NgayTao= DateTime.Now;
            ServiceType.NgayCapNhat = DateTime.Now;
            ServiceType.Gia = sp.Gia;
            ServiceType.NgayTH = sp.NgayTH;
            // them san pham vao db
            if (ModelState.IsValid)
            {
                if (photo != null && photo.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/Areas/Admin/Content/images/"),
                                            System.IO.Path.GetFileName(photo.FileName));
                    photo.SaveAs(path);

                    ServiceType.Anh = photo.FileName;
                    ServiceTypeDAO dao = new ServiceTypeDAO();
                    dao.Create(ServiceType);
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View(ServiceType);
            }
        }

        //[Authorize(Roles = "ADMIN")]
        public ActionResult Edit(int id)
        {
            List<LoaiDichVu> ls = new List<LoaiDichVu>();
            ServiceTypeDAO dao = new ServiceTypeDAO();
            //QCDAO d = new QCDAO();
            //ViewBag.cat = d.ListQC();
            LoaiDichVu sp = dao.FindProductByID(id);
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

        public ActionResult Edit(LoaiDichVu sp, int id, HttpPostedFileBase photo)
        {
            ServiceTypeDAO dao = new ServiceTypeDAO();
            LoaiDichVu ServiceType = dao.FindProductByID(id);
            ServiceType.tenLoaiDV = sp.tenLoaiDV;
            ServiceType.NgayTH = sp.NgayTH;
            ServiceType.Gia = sp.Gia;
            ServiceType.NgayTao = (sp.NgayTao);
            ServiceType.NgayCapNhat = DateTime.Now;
            if (ModelState.IsValid)
            {
                if (photo != null && photo.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/Areas/Admin/Content/images/"),
                                            System.IO.Path.GetFileName(photo.FileName));
                    photo.SaveAs(path);

                    ServiceType.Anh = photo.FileName;

                }
                ServiceTypeDAO d = new ServiceTypeDAO();
                d.Edit(ServiceType);
                return RedirectToAction("Index");
            }
            else
            {
                return View(ServiceType);
            }
        }

        // delete
        [HttpPost]
        //[Authorize(Roles = "ADMIN")]
        public string Delete(int id)
        {
            ServiceTypeDAO dao = new ServiceTypeDAO();
            LoaiDichVu sp = new LoaiDichVu();
            sp = dao.FindProductByID(id);
            if (sp != null)
            {
                dao.Delete(id);
            }
            return "OK";
        }
        public ActionResult Details(int id)
        {

            ServiceTypeDAO dao = new ServiceTypeDAO();
            LoaiDichVu sp = dao.FindProductByID(id);

            return View(sp);
        }
    }
}