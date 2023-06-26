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
                var existingVacation = vac.GetAll().FirstOrDefault(v => v.Date == model.Date);

                if (existingVacation != null)
                {
                    // Vacation with the same date already exists, return an error message
                    ModelState.AddModelError("Date", "الإجازة بهذا التاريخ موجودة بالفعل.");
                }
                else
                {
                    // Create a new vacation
                    var newVacation = new OfficialVacations
                    {
                        Name = model.Name,
                        Date = model.Date
                    };
                    vac.Create(newVacation);
                    vac.Save();

                    // Redirect to the create page to show the success message
                    return RedirectToAction("Create");
                }
            }

            // If there was an error or the model state was invalid, return the view with the updated model
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
                var existingVacation = vac.GetAll().FirstOrDefault(v => v.Date == evac.Date);

                if (existingVacation != null)
                {
                    // Vacation with the same date already exists, return an error message
                    ModelState.AddModelError("Date", "الإجازة بهذا التاريخ موجودة بالفعل.");
                }
                else
                {
                    vac.update(id, evac);
                    vac.Save();
                    return RedirectToAction("Create");

                }
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
