using Calisanlar.Models;
using System.Collections.Generic;

namespace Calisanlar.Data
{
    public interface ICalisanRepo
    {
        IEnumerable<Calisan> GetAllCalisans();
        void CreateCalisan (Calisan cln);
        void UpdateCalisan (Calisan cln);

        bool SaveChanges();
    }
}
