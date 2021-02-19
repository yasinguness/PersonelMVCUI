using PersonelMVCUI.Models.EntityFramework;
using PersonelMVCUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
namespace PersonelMVCUI.Controllers
{
    public class PersonelController : Controller
    {
        PersonelDbEntities db = new PersonelDbEntities();
        // GET: Personel
        public ActionResult Index()
        {
            var model = db.Personel.ToList();
            return View(model);
        }

        public ActionResult Yeni()
        {
            var model = new PersonelFormViewModels()
            {
                Departmans=db.Departman.ToList(),
                Personels=new Personel()
            };
            return View("PersonelForm",model);
        }

        [ValidateAntiForgeryToken]
        public ActionResult Kaydet(Personel personel)
        {
            if (!ModelState.IsValid)
            {
                var model = new PersonelFormViewModels()
                {
                    Departmans = db.Departman.ToList(),
                    Personels = personel
                };
                return View("PersonelForm", model);

            }
            if (personel.Id==0)//ekleme işlemi
            {
                db.Personel.Add(personel);

            }
            else //güncelleme
            {
                db.Entry(personel).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Güncelle(int id)
        {
            var model = new PersonelFormViewModels() { Departmans = db.Departman.ToList(), Personels = db.Personel.Find(id) };
            return View("PersonelForm", model);
        }

        public ActionResult Sil(int id)
        {
            var SilinecekPersonel = db.Personel.Find(id);
            if (SilinecekPersonel==null)
            {
                return HttpNotFound();
            }
            db.Personel.Remove(SilinecekPersonel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}