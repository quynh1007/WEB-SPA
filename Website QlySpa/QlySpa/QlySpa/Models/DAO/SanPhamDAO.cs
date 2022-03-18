using QlySpa.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using System.Data.Entity;

namespace QlySpa.Models.DAO
{
    public class SanPhamDAO
    {
        SpaDBContext db;
        public SanPhamDAO()
        {
            db = new SpaDBContext();
        }
        public IQueryable<SanPham> Products
        {
            get { return db.SanPhams; }
        }
        public IQueryable<SanPham> ListSanPham()
        {
            var res = (from s in db.SanPhams select s);
            return res;
        }
        public IEnumerable<SanPham> lstjoin(int pageNum, int pageSize)
        {
            var lst = db.Database.SqlQuery<SanPham>("SELECT * from SanPham")
                .ToPagedList<SanPham>(pageNum, pageSize);
            return lst;
        }
        public SanPham FindProductByID(int id)
        {
            return db.SanPhams.Find(id);
        }
        public void Create(SanPham sp)
        {
            db.SanPhams.Add(sp);
            db.SaveChanges();
        }

        public void Edit(SanPham sp)
        {
            SanPham SanPham = FindProductByID(sp.idSanPham);
            if (SanPham != null)
            {
                SanPham.TenSP = sp.TenSP;
                //SanPham.idSanPham = sp.idSanPham;
                SanPham.Gia = sp.Gia;
                SanPham.Anh = sp.Anh;
                SanPham.NSX = sp.NSX;
                SanPham.HSD = sp.HSD;
                db.SaveChanges();
            }


        }
        public void Delete(int id)
        {
            SanPham pro = db.SanPhams.Find(id);
            if (pro != null)
            {
                db.SanPhams.Remove(pro);
                db.SaveChanges();
            }
        }
        public IEnumerable<SanPham> listLoaiDVByNgayTH(string NKT, int pageNum, int pageSize)
        {

            var lst = db.Database.SqlQuery<SanPham>("listDVByNgayTao " + "'" + NKT + "'").ToPagedList<SanPham>(pageNum, pageSize);
            return lst;
        }
        public IEnumerable<SanPham> lstSearchByHSD(int HSD, int pageNum, int pageSize)
        {
            var lst = db.Database.SqlQuery<SanPham>("lstSearchByHSD " + HSD
                ).ToPagedList<SanPham>(pageNum, pageSize);
            return lst;
        }
        public IEnumerable<SanPham> lstSearchByNDK(string NDK, int pageNum, int pageSize)
        {

            var lst = db.Database.SqlQuery<SanPham>("lstSearchByNDK " + "'" + NDK + "'"
                ).ToPagedList<SanPham>(pageNum, pageSize);
            return lst;
        }
    }
}