using Microsoft.AspNetCore.Mvc;
using Proje.DataAccessLayer;
using Proje.Models;
using Proje.Models.DBEntities;

namespace Proje.Controllers
{
    public class SectorController : Controller
    {
        private readonly SectorDbContext _context;
        public SectorController(SectorDbContext context) 
        { 
            this._context = context;
        }


        [HttpGet]
        public IActionResult SectorIndex()
        {
            var sectors= _context.Sectors.ToList();
            List<SectorViewModel> Sectorlist = new List<SectorViewModel>();
            if (sectors != null )
            {
                
                foreach( var sector in sectors )
                {
                    var sectorViewModel = new SectorViewModel()
                    {
                        SectorID = sector.SectorID,
                        SectorName = sector.SectorName,
                        SectorIsActive = sector.SectorIsActive,
                    };
                    Sectorlist.Add(sectorViewModel);

                }
                return View(Sectorlist);
            }
            return View(Sectorlist);
        }

        //add sector
        [HttpGet]
          public ActionResult Add() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(SectorViewModel Proje)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Sectors = new Sector()
                    {
                       
                        SectorID = Proje.SectorID,
                        SectorName = Proje.SectorName,
                        SectorIsActive = Proje.SectorIsActive,
                       

                    };
                    _context.Sectors.Add(Sectors);
                    _context.SaveChanges();
                    TempData["Success Message"] = " Sector addded succesfully";
                    return RedirectToAction("SectorIndex");
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
                var Sector = _context.Sectors.SingleOrDefault(x => x.SectorID == Id);
                if (Sector != null)
                {
                    var SectorView = new SectorViewModel()
                    {
                       
                        SectorID = Sector.SectorID,
                        SectorName = Sector.SectorName,
                        SectorIsActive = Sector.SectorIsActive,
                        


                    };
                    return View(SectorView);
                }
                else
                {
                    TempData["Error Message"] = " Company Details not available";
                    return RedirectToAction("SectorIndex");
                }

            }
            catch (Exception ex)
            {
                TempData["Error Message"] = ex.Message;

                return RedirectToAction("SectorIndex");
            }



        }
        [HttpPost]
        public IActionResult Edit(SectorViewModel Proje)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Sector = new Sector()
                    {
                       
                        SectorID = Proje.SectorID,
                        SectorName = Proje.SectorName,
                        SectorIsActive = Proje.SectorIsActive,

                    };
                    _context.Sectors.Update(Sector);
                    _context.SaveChanges();
                    TempData["Success Message"] = " Company details updated successfully!";
                    return RedirectToAction("SectorIndex");

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
                var Sector = _context.Sectors.SingleOrDefault(x => x.SectorID == Id);
                if (Sector != null)
                {
                    var SectorView = new SectorViewModel()
                    {

                        SectorID = Sector.SectorID,
                        SectorName = Sector.SectorName,
                        SectorIsActive = Sector.SectorIsActive,



                    };
                    return View(SectorView);
                }
                else
                {
                    TempData["Error Message"] = " Sector Details not available";
                    return RedirectToAction("SectorIndex");
                }

            }
            catch (Exception ex)
            {
                TempData["Error Message"] = ex.Message;

                return RedirectToAction("SectorIndex");
            }



        }

        [HttpPost]

        public IActionResult Delete(SectorViewModel model)
        {
            try
            {
                var Sector = _context.Sectors.SingleOrDefault(x => x.SectorID == model.SectorID);
                if (Sector != null)
                {
                    _context.Sectors.Remove(Sector);
                    _context.SaveChanges();
                    TempData["Success Message"] = "Sector deleted successfully";
                    return RedirectToAction("SectorIndex");
                }
                else
                {
                    TempData["Error Message"] = " Sector Details not available";
                    return RedirectToAction("SectorIndex");
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
