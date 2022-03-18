using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QlySpa.Models.DAO;
using QlySpa.Models.EF;

namespace QlySpa.Controllers
{
    public class serviceViewController : Controller
    {
        // GET: serviceView
        public ActionResult Index(int pageNum = 1, int pageSize = 10)
        {
            //ViewBag.Thang = Thang;
            //ViewBag.Tuan = Tuan;
           // ViewBag.CN = CN;
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
    }
}