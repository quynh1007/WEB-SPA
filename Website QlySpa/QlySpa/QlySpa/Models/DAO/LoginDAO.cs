using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QlySpa.Models.EF;

namespace QlySpa.Models.DAO
{
    public class LoginDAO
    {
        SpaDBContext db;
        public LoginDAO()
        {
            db = new SpaDBContext();
        }
        public IQueryable<ACCOUNT> ACCOUNTs
        {
            get { return db.ACCOUNTs; }
        }
        public bool Login(string email, string password)
        {
            var res = (from s in db.ACCOUNTs where s.Email == email && s.Password == password select s);
            if (res.Count() > 0)
                return true;
            return false;
        }
        public void Create(ACCOUNT ac)
        {
            db.ACCOUNTs.Add(ac);
            db.SaveChanges();
        }
        public ACCOUNT FindProductByID(string email)
        {
            return db.ACCOUNTs.Find(email);
        }
    }
}