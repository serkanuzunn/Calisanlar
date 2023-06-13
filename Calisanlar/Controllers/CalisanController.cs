using Calisanlar.Data;
using Calisanlar.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Calisanlar.Controllers
{
    [ApiController]
    public class CalisanController:ControllerBase
    {
        private ICalisanRepo _repository;
        private static List<Calisan> calisanlar = new List<Calisan>();

        public CalisanController(ICalisanRepo repository)
        {
            _repository = repository;
        }

        private object GetCalisanAgaci(Calisan calisan)
        {
            var agac = new
            {
                AdSoyad = calisan.AdSoyad,
                SicilNo = calisan.SicilNo,
                Astlar = new List<object>()
            };

            if (calisan.Astlar != null)
            {
                foreach (var ast in calisan.Astlar)
                {
                    var astAgaci = GetCalisanAgaci(ast);
                    ((List<object>)agac.Astlar).Add(astAgaci);
                }
            }

            return agac;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Calisan>> GetAllCommands()
        {
            var rootCalisanlar = calisanlar.Where(c => c.Ust == null).ToList();
            List<object> calisanAgaci = new List<object>();
            foreach (var calisan in rootCalisanlar)
            {
                var agac = GetCalisanAgaci(calisan);
                calisanAgaci.Add(agac);
            }

            return Ok(calisanAgaci);
        }

        [HttpPost]
        public ActionResult<Calisan> CreateCalisan (Calisan calisan)
        {
            if (!ModelState.IsValid)
                return BadRequest("Geçersiz veri");

            if (calisan.SicilNo.Length != 11 || !calisan.SicilNo.All(char.IsLetterOrDigit))
                return BadRequest("Geçersiz sicil numarası");

            calisanlar.Add(calisan);
            return Ok();
        }


        [HttpPut]
        public ActionResult UpdateCalisan(string sicilNo,Calisan calisan) 
        {
            if (!ModelState.IsValid)
                return BadRequest("Geçersiz veri!");

            if (sicilNo != calisan.SicilNo)
                return BadRequest("Sicil numarası güncellenemez!");

            var existingCalisan = calisanlar.FirstOrDefault(c => c.SicilNo == sicilNo);
            if (existingCalisan == null)
                return NotFound();

            existingCalisan.AdSoyad = calisan.AdSoyad;
            existingCalisan.Astlar = calisan.Astlar;
            existingCalisan.Ust = calisan.Ust;

            return Ok();
        }
    }
}
