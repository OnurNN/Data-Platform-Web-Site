using Microsoft.AspNetCore.Mvc;
using Proje.DataAccessLayer;
using Proje.Models;
using Proje.Models.DBEntities;

namespace Proje.Controllers
{
    public class PersonalController : Controller
    {
        private readonly PersonalDbContext _context;
        public PersonalController(PersonalDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult PersonalIndex()

        {
            var personals = _context.Personals.ToList();
            List<PersonalViewModel> PersonalList = new List<PersonalViewModel>();
            if (personals != null)
            {

                foreach (var personal in personals)
                {
                    var PersonalViewModel = new PersonalViewModel()
                    {
                        PersonalId = personal.PersonalId,
                        NameSurname = personal.NameSurname,
                        Gender = personal.Gender,
                        Title = personal.Title,
                        PhoneNumber=personal.PhoneNumber,

                    };
                    PersonalList.Add(PersonalViewModel);

                }
                return View(PersonalList);
            }
            return View(PersonalList);
        }

        //add Personal
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(PersonalViewModel Proje)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var personal = new Personal()
                    {

                        PersonalId = Proje.PersonalId,
                        NameSurname= Proje.NameSurname,
                        Gender= Proje.Gender,
                        Title = Proje.Title,
                        PhoneNumber= Proje.PhoneNumber,

                    };
                    _context.Personals.Add(personal);
                    _context.SaveChanges();
                    TempData["Success Message"] = " Personal addded succesfully";
                    return RedirectToAction("PersonalIndex");
                }
                else
                {
                    TempData["Error Message"] = " Model data is not valid.";
                }
                return View();
            }
            catch (Exception ex)
            {
                TempData["Error Message"] = ex.Message;
                return View();
            }
        }


        [HttpGet]

        public IActionResult Edit(int Id)
        {

            try
            {
                var personal = _context.Personals.SingleOrDefault(x => x.PersonalId == Id);
                if (personal != null)
                {
                    var PersonalView = new PersonalViewModel()
                    {

                        PersonalId = personal.PersonalId,
                        NameSurname = personal.NameSurname,
                        Gender = personal.Gender,
                        Title = personal.Title,
                        PhoneNumber = personal.PhoneNumber,




                    };
                    return View(PersonalView);
                }
                else
                {
                    TempData["Error Message"] = " Personal Details not available";
                    return RedirectToAction("PersonalIndex");
                }

            }
            catch (Exception ex)
            {
                TempData["Error Message"] = ex.Message;

                return RedirectToAction("PersonalIndex");
            }



        }


        [HttpPost]
        public IActionResult Edit(PersonalViewModel Proje)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var personal = new Personal()
                    {

                        PersonalId = Proje.PersonalId,
                        NameSurname = Proje.NameSurname,
                        Gender = Proje.Gender,
                        Title = Proje.Title,
                        PhoneNumber = Proje.PhoneNumber,

                    };
                    _context.Personals.Update(personal);
                    _context.SaveChanges();
                    TempData["Success Message"] = " Personal details updated successfully!";
                    return RedirectToAction("PersonalIndex");

                }
                else
                {
                    TempData["Error Message"] = "Model data is invalid";
                    return View();
                }
            }
            catch (Exception ex)
            {

                TempData["Error Message"] = ex.Message;

                return View();
            }


        }


        [HttpGet]

        public IActionResult Delete(int Id)
        {

            try
            {
                var personal = _context.Personals.SingleOrDefault(x => x.PersonalId == Id);
                if (personal != null)
                {
                    var PersonalView = new PersonalViewModel()
                    {

                        PersonalId = personal.PersonalId,
                        NameSurname = personal.NameSurname,
                        Gender = personal.Gender,
                        Title = personal.Title,
                        PhoneNumber = personal.PhoneNumber,




                    };
                    return View(PersonalView);
                }
                else
                {
                    TempData["Error Message"] = " Personal Details not available";
                    return RedirectToAction("PersonalIndex");
                }

            }
            catch (Exception ex)
            {
                TempData["Error Message"] = ex.Message;

                return RedirectToAction("PersonalIndex");
            }



        }

        public IActionResult Delete(PersonalViewModel model)
        {
            try
            {
                var personal = _context.Personals.SingleOrDefault(x => x.PersonalId == model.PersonalId);
                if (personal != null)
                {
                    _context.Personals.Remove(personal);
                    _context.SaveChanges();
                    TempData["Success Message"] = "Personal deleted successfully";
                    return RedirectToAction("PersonalIndex");
                }
                else
                {
                    TempData["Error Message"] = " Personal Details not available";
                    return RedirectToAction("PersonalIndex");
                }

            }
            catch (Exception ex)
            {
                TempData["Error Message"] = ex.Message;

                return View();

            }

        }

    }
}
