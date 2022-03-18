using QlySpa.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using System.Data.Entity;

namespace QlySpa.Models.DAO
{
    public class ServiceDAO
    {
        SpaDBContext db;
        public ServiceDAO()
        {
            db = new SpaDBContext();
        }
        public IQueryable<DichVu> Products
        {
            get { return db.DichVus; }
        }
        public IQueryable<DichVu> ListService()
        {
            var res = (from s in db.DichVus select s);
            return res;
        }
        public IEnumerable<DichVu> lstjoin(int pageNum, int pageSize)
        {
            var lst = db.Database.SqlQuery<DichVu>("SELECT * from DichVu")
                .ToPagedList<DichVu>(pageNum, pageSize);
            return lst;
        }
        public DichVu FindDVByID(int id)
        {
            return db.DichVus.Find(id);
        }
        public void Create(DichVu sp)
        {
            db.DichVus.Add(sp);
            db.SaveChanges();
        }

        public void Edit(DichVu sp)
        {
            DichVu Service = FindDVByID(sp.MaDV);
            if (Service != null)
            {
                Service.idVoucher = sp.idVoucher;
                Service.idNhanVien = sp.idNhanVien;
                Service.idLoaiDV = sp.idLoaiDV;
                Service.Gia = sp.Gia;
               // Service.Anh = sp.Anh;
                Service.NgayTao = sp.NgayTao;
                Service.NgayKT = sp.NgayKT;
                db.SaveChanges();
            }


        }
        public void Delete(int id)
        {
            DichVu pro = db.DichVus.Find(id);
            if (pro != null)
            {
                db.DichVus.Remove(pro);
                db.SaveChanges();
            }
        }
        public IEnumerable<DichVu> listDVByNgayTao(string NKT, int pageNum, int pageSize)
        {
            var lst = db.Database.SqlQuery<DichVu>("listDVByNgayTao " +
                "N'" + NKT + "'").ToPagedList<DichVu>(pageNum, pageSize);
            return lst;
        }
        public IEnumerable<DichVu> lstSearchByHSD(int HSD, int pageNum, int pageSize)
        {
            var lst = db.Database.SqlQuery<DichVu>("lstSearchByHSD " + HSD
                ).ToPagedList<DichVu>(pageNum, pageSize);
            return lst;
        }
        public IEnumerable<DichVu> lstSearchByNDK(string NDK, int pageNum, int pageSize)
        {

            var lst = db.Database.SqlQuery<DichVu>("lstSearchByNDK " + "'" + NDK + "'"
                ).ToPagedList<DichVu>(pageNum, pageSize);
            return lst;
        }
    }
}