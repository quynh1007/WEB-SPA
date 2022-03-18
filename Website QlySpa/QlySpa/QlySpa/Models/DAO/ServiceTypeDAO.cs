using QlySpa.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using System.Data.Entity;

namespace QlySpa.Models.DAO
{
    public class ServiceTypeDAO
    {
        SpaDBContext db;
        public ServiceTypeDAO()
        {
            db = new SpaDBContext();
        }
        public IQueryable<LoaiDichVu> Products
        {
            get { return db.LoaiDichVus; }
        }
        public IQueryable<LoaiDichVu> ListServiceType()
        {
            var res = (from s in db.LoaiDichVus select s);
            return res;
        }
        public IEnumerable<LoaiDichVu> lstjoin(int pageNum, int pageSize)
        {
            var lst = db.Database.SqlQuery<LoaiDichVu>("SELECT * from LoaiDichVu")
                .ToPagedList<LoaiDichVu>(pageNum, pageSize);
            return lst;
        }
        public LoaiDichVu FindProductByID(int id)
        {
            return db.LoaiDichVus.Find(id);
        }
        public void Create(LoaiDichVu sp)
        {
            db.LoaiDichVus.Add(sp);
            db.SaveChanges();
        }

        public void Edit(LoaiDichVu sp)
        {
            LoaiDichVu ServiceType = FindProductByID(sp.idLoaiDV);
            if (ServiceType != null)
            {
                ServiceType.tenLoaiDV = sp.tenLoaiDV;
                //ServiceType.idLoaiDV = sp.idLoaiDV;
                ServiceType.Gia = sp.Gia;
                ServiceType.Anh = sp.Anh;
                ServiceType.NgayTao = sp.NgayTao;
                ServiceType.NgayCapNhat = sp.NgayCapNhat;
                db.SaveChanges();
            }


        }
        public void Delete(int id)
        {
            LoaiDichVu pro = db.LoaiDichVus.Find(id);
            if (pro != null)
            {
                db.LoaiDichVus.Remove(pro);
                db.SaveChanges();
            }
        }
        public IEnumerable<LoaiDichVu> listLoaiDVByNgayTH(string NKT, int pageNum, int pageSize)
        {
            
            var lst = db.Database.SqlQuery<LoaiDichVu>("listDVByNgayTao " + "'" + NKT + "'").ToPagedList<LoaiDichVu>(pageNum, pageSize);
            return lst;
        }
        public IEnumerable<LoaiDichVu> lstSearchByHSD(int HSD, int pageNum, int pageSize)
        {
            var lst = db.Database.SqlQuery<LoaiDichVu>("lstSearchByHSD " + HSD
                ).ToPagedList<LoaiDichVu>(pageNum, pageSize);
            return lst;
        }
        public IEnumerable<LoaiDichVu> lstSearchByNDK(string NDK, int pageNum, int pageSize)
        {

            var lst = db.Database.SqlQuery<LoaiDichVu>("lstSearchByNDK " + "'" + NDK + "'"
                ).ToPagedList<LoaiDichVu>(pageNum, pageSize);
            return lst;
        }
    }
}