using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QlySpa.Models.DAO;
using QlySpa.Models.EF;

namespace QlySpa.Models.DAO
{
    public class LoaiDV
    {
        SpaDBContext db = new SpaDBContext();

        public LoaiDichVu Chitietdichvu(int id)
        {
            LoaiDichVu lst = db.Database.SqlQuery<LoaiDichVu>("loaidichvu " + id).FirstOrDefault();
            return lst;
        }
    }
}