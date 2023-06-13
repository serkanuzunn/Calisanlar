using Calisanlar.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Calisanlar.Data
{
    public class SqlCalisanRepo : ICalisanRepo
    {

        private readonly CalisanContext _context;

        public SqlCalisanRepo(CalisanContext context)
        {
            _context = context;
        }

        public void CreateCalisan(Calisan cln)
        {
            if (cln==null)
            {
                throw new ArgumentException(nameof(cln));
            }

            _context.Calisanlar.Add(cln);
        }

        public IEnumerable<Calisan> GetAllCalisans()
        {
            return _context.Calisanlar.ToList();
        }


        public void UpdateCalisan(Calisan cln)
        {
            //Nothing
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
