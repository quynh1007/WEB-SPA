using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QlySpa.Models.EF;
using QlySpa.Models.DAO;



namespace QlySpa.Areas.Admin.Controllers
{
    public class ServiceController : Controller
    {
        private SpaDBContext db = new SpaDBContext();
        // GET: QlySpa
        public ActionResult Index(string CN, int pageNum = 1, int pageSize = 10)
        {
            //ViewBag.Thang = Thang;
            //ViewBag.Tuan = Tuan;
            ViewBag.CN = CN;
            ServiceDAO dao = new ServiceDAO();

            //if (!string.IsNullOrEmpty(Thang) && string.IsNullOrEmpty(Tuan) && !string.IsNullOrEmpty(CN))
            //{
            //    return View(dao.lstSearchByThang(Thang, Convert.ToInt32(CN), pageNum, pageSize));
            //}
            //if (string.IsNullOrEmpty(Thang) && !string.IsNullOrEmpty(Tuan) && !string.IsNullOrEmpty(CN))
            //{
            //    return View(dao.lstSearchByTuan(Tuan, Convert.ToInt32(CN), pageNum, pageSize));
            //}
            //if (!string.IsNullOrEmpty(Thang) && string.IsNullOrEmpty(Tuan) && string.IsNullOrEmpty(CN))
            //{
            //    return View(dao.lstSearchAllByThang(Thang, pageNum, pageSize));
            //}
            //if (string.IsNullOrEmpty(Thang) && !string.IsNullOrEmpty(Tuan) && string.IsNullOrEmpty(CN))
            //{
            //    return View(dao.lstSearchAllByTuan(Tuan, pageNum, pageSize));
            //}

            return View(dao.lstjoin(pageNum, pageSize));
        }
        //[Authorize(Roles = "ADMIN")]
        public ActionResult Create()
        {
            ServiceDAO dao = new ServiceDAO();
            //CongviecDAO d = new CongviecDAO();
            //ViewBag.macv = d.ListCongviec();
            //SanphamDAO da = new SanphamDAO();
            //ViewBag.spad = da.ListSanpham();
            //CongnhanDAO dai = new CongnhanDAO();
            // ViewBag.macn = dao.ListCongnhan();
            return View();
        }
        [HttpPost]
        //[Authorize(Roles = "ADMIN")]
        public ActionResult Create(DichVu a)
        {
            //thêm dữ liệu vào bảng đầu mục công việc
            //DAU_MUC_CV daumuccv = new DAU_MUC_CV();
            //daumuccv.MaCV = Convert.ToInt32(macv);
            //daumuccv.SLThucTe = Convert.ToDouble(sltt);
            //daumuccv.SoLoSP = Convert.ToInt32(slsp);
            //daumuccv.SPApDung = Convert.ToInt32(spad);
            //db.DAU_MUC_CV.Add(daumuccv);
            //db.SaveChanges();

            //// thêm dữ liệu vào bảng nhóm thực hiện khoán           
            //NHOM_THUC_HIEN_KHOAN nhomthk = new NHOM_THUC_HIEN_KHOAN();
            //nhomthk.SLThanhVien = Convert.ToInt32(sltv);
            //db.NHOM_THUC_HIEN_KHOAN.Add(nhomthk);
            //db.SaveChanges();

            //// thêm dữ liệu vào bảng nhật ký
            //DichVu QlySpa = new DichVu();
            //QlySpa.NgayThucHienKhoan = a.NgayThucHienKhoan;
            //QlySpa.GioBatDau = a.GioBatDau;
            //QlySpa.GioKetThuc = a.GioKetThuc;
            //QlySpa.NhomThucHienKhoan = nhomthk.MaNhom;
            //QlySpa.CongViec = daumuccv.MaDMCV;
            //db.DichVu.Add(QlySpa);
            //db.SaveChanges();

            //Thêm dữ liệu vào bảng công nhân khoán
            DichVu cnk = new DichVu();
            cnk.idKhachHang = null;
            cnk.idLoaiDV = Convert.ToInt32(a.idLoaiDV);
            cnk.idVoucher = Convert.ToInt32(a.idVoucher);
            cnk.idNhanVien = Convert.ToInt32(a.idNhanVien);
            cnk.Gia = Convert.ToDouble(a.Gia);
            db.DichVus.Add(cnk);
            db.SaveChanges();
            // them san pham vao db
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(cnk);
            }
        }
        //[Authorize(Roles = "ADMIN")]
        public ActionResult Edit(int id)
        {
            List<DichVu> ls = new List<DichVu>();
            ServiceDAO dao = new ServiceDAO();
            DichVu nk = dao.FindDVByID(id);
            return View(nk);
        }

        [HttpPost]
        //[Authorize(Roles = "ADMIN")]
        public ActionResult Edit(DichVu nk, int id)
        {
            ServiceDAO dao = new ServiceDAO();
            DichVu QlySpa = dao.FindDVByID(id);
            QlySpa.idLoaiDV = nk.idLoaiDV;
            QlySpa.idVoucher = nk.idVoucher;
            QlySpa.idNhanVien = nk.idNhanVien;
            QlySpa.Gia = nk.Gia;
            //QlySpa.CongViec = nk.CongViec;
            if (ModelState.IsValid)
            {
                ServiceDAO d = new ServiceDAO();
                d.Edit(QlySpa);
                return RedirectToAction("Index");
            }
            else
            {
                return View(QlySpa);
            }
        }
        public ActionResult Details(int id)
        {
            ViewBag.id = id;
            ServiceDAO dao = new ServiceDAO();
            DichVu sp = dao.FindDVByID(id);
            return View(sp);
        }
        //public ActionResult cnk(int id)
        //{
        //    CNKDAO dao = new CNKDAO();
        //    CNKDTO cn = dao.Congnhankhoan(id);
        //    return View(cn);
        //}
        //public ActionResult daumuc(int id)
        //{
        //    DauMucDAO dao = new DauMucDAO();
        //    DauMucDTO dm = dao.daumuc(id);
        //    return View(dm);
        //}
        // delete

        [AcceptVerbs(HttpVerbs.Post | HttpVerbs.Get)]
        //[Authorize(Roles = "ADMIN")]
        public ActionResult Delete(DichVu cv, int id)
        {
            ServiceDAO dao = new ServiceDAO();
            dao.Delete(id);
            return RedirectToAction("Index");
        }
    }
}