using Microsoft.AspNetCore.Mvc;
using Proje.DataAccessLayer;
using Proje.Models;
using Proje.Models.DBEntities;

namespace Proje.Controllers
{
    public class CompanyController : Controller
    {
        private readonly CompanyDbContext _context;
        public CompanyController(CompanyDbContext context) 
        { 
            this._context = context;
        }

        [HttpGet]
        public IActionResult Index()

        {
            var companies = _context.Companies.ToList();
            List<CompanyViewModel> companylist = new List<CompanyViewModel>();
            if (companies != null)
            {
                
                foreach(var company in companies)
                {
                    var ComapanyViewModel = new CompanyViewModel()
                    {
                        Id = company.Id,
                        CompanyName = company.CompanyName,
                        CompanyStatus = company.CompanyStatus,
                        SectorID = company.SectorID,
                        EntegrationID = company.EntegrationID,
                        Contract_Start = company.Contract_Start,
                        Contract_End = company.Contract_End,
                       Authorized = company.Authorized,

                    };
                    companylist.Add(ComapanyViewModel);

                }
                return View(companylist);
            }
            return View(companylist);
        }
        [HttpGet]
        public IActionResult Add() 
        {

            return View();
        }

        [HttpPost]
        public IActionResult Add(CompanyViewModel Proje)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var company = new Company()
                    {
                        CompanyName = Proje.CompanyName,
                        CompanyStatus = Proje.CompanyStatus,
                        SectorID = Proje.SectorID,
                        EntegrationID = Proje.EntegrationID,
                        Contract_Start = Proje.Contract_Start,
                        Contract_End = Proje.Contract_End,
                        Authorized = Proje.Authorized,

                    };
                    _context.Companies.Add(company);
                    _context.SaveChanges();
                    TempData["Success Message"] = " Company addded succesfully";
                    return RedirectToAction("Index");
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

        public IActionResult Edit(int Id) {

            try
            {
                var company = _context.Companies.SingleOrDefault(x => x.Id == Id);
                if (company != null)
                {
                    var companyView = new CompanyViewModel()
                    {
                        Id = company.Id,
                        CompanyName = company.CompanyName,
                        CompanyStatus = company.CompanyStatus,
                        SectorID = company.SectorID,
                        EntegrationID = company.EntegrationID,
                        Contract_Start = company.Contract_Start,
                        Contract_End = company.Contract_End,
                        Authorized = company.Authorized,


                    };
                    return View(companyView);
                }
                else
                {
                    TempData["Error Message"] = " Company Details not available";
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                TempData["Error Message"] = ex.Message;

                return RedirectToAction("Index");
            }
            
        }

        [HttpPost]
        public IActionResult Edit(CompanyViewModel Proje)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var company = new Company()
                    {
                        Id = Proje.Id,
                        CompanyName = Proje.CompanyName,
                        CompanyStatus = Proje.CompanyStatus,
                        SectorID = Proje.SectorID,
                        EntegrationID = Proje.EntegrationID,
                        Contract_Start = Proje.Contract_Start,
                        Contract_End = Proje.Contract_End,
                        Authorized = Proje.Authorized,
                    };
                    _context.Companies.Update(company);
                    _context.SaveChanges();
                    TempData["Success Message"] = " Company details updated successfully!";
                    return RedirectToAction("Index");

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
                var company = _context.Companies.SingleOrDefault(x => x.Id == Id);
                if (company != null)
                {
                    var companyView = new CompanyViewModel()
                    {
                        Id = company.Id,
                        CompanyName = company.CompanyName,
                        CompanyStatus = company.CompanyStatus,
                        SectorID = company.SectorID,
                        EntegrationID = company.EntegrationID,
                        Contract_Start = company.Contract_Start,
                        Contract_End = company.Contract_End,
                        Authorized = company.Authorized,


                    };
                    return View(companyView);
                }
                else
                {
                    TempData["Error Message"] = " Company Details not available";
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                TempData["Error Message"] = ex.Message;

                return RedirectToAction("Index");
            }

        }

        [HttpPost]

        public  IActionResult Delete(CompanyViewModel model)
        {
            try
            {
                var company = _context.Companies.SingleOrDefault(x => x.Id == model.Id);
                if (company != null)
                {
                    _context.Companies.Remove(company);
                    _context.SaveChanges();
                    TempData["Success Message"] = "Company deleted successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Error Message"] = " Company Details not available";
                    return RedirectToAction("Index");
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
