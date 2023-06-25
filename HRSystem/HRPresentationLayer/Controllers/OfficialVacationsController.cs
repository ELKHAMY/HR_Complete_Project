using Domain.Models;
using Infrastructure.IRepsository;
using Infrastructure.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HRPresentationLayer.Controllers
{
    public class OfficialVacationsController : Controller
    {
        
            IOfficialVacationsRepository vac;
            public OfficialVacationsController(IOfficialVacationsRepository vac)
            {
                this.vac = vac;
            }



            public IActionResult Create()
            {
                var model = new OfficialVacationsVM
                {
                    offvac = vac.GetAll()
                };
                return View(model);
            }

            [HttpPost]
            public IActionResult Create(OfficialVacationsVM model)
            {
                if (ModelState.IsValid)
                {
                    var vacss = new OfficialVacations
                    {
                        Name = model.Name,
                        Date = model.Date
                    };
                    vac.Create(vacss);
                    vac.Save();
                    return RedirectToAction("Create");
                }
                model.offvac = vac.GetAll();
                return View("Create", model);
            }

            public IActionResult Delete(int id)
            {
                vac.Delete(id);
                vac.Save();
                return RedirectToAction("Create");
            }

            public IActionResult Edit(int id)
            {
                OfficialVacations editvac = vac.GetById(id);
                return View(editvac);
            }

            [HttpPost]

            public IActionResult Edit([Bind("Id,Name,Day,Date")] OfficialVacations evac, int id)
            {

                if (ModelState.IsValid)
                {
                    vac.update(id, evac);
                    vac.Save();
                    return RedirectToAction("Create");

                }


                return View(evac);
            }

            public IActionResult Details(int id)
            {
                OfficialVacations vo = vac.GetById(id);
                return View(vo);
            }


        
    }
}
