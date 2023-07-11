using Domain.Models;
using Infrastructure.IRepsository;
using Infrastructure.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HRPresentationLayer.Controllers
{
    public class GenralsettingController : Controller
    {
        IGenral genral;
        public GenralsettingController(IGenral genral) 
        {
        this.genral = genral;   
        }
        public IActionResult Index()
        {

            Hours hmodel = genral.GetHours();
            WeeklyHoliday wmodel = genral.GetWeeklyHoliday();
            HoursweeklyholidaysViewModel model = new HoursweeklyholidaysViewModel();


            model.AddHours = (int)hmodel.AddHours;
            model.RemoveHours = (int)hmodel.RemoveHours;
            model.Day1 = wmodel.Day1;
            model.Day2 = wmodel.Day2;



            return View(model);
        }

        //----- edit 

        public IActionResult Edit() 
        {
            Hours hmodel = genral.GetHours();
            WeeklyHoliday wmodel = genral.GetWeeklyHoliday();
            HoursweeklyholidaysViewModel model = new HoursweeklyholidaysViewModel();


            model.AddHours = (int)hmodel.AddHours;
            model.RemoveHours = (int)hmodel.RemoveHours;
            model.Day1 = wmodel.Day1;
            model.Day2 = wmodel.Day2;

            return View(model); 
        }
        [HttpPost]
        public IActionResult Edit(HoursweeklyholidaysViewModel nemodel)
        {
            Hours oldmo = genral.GetHours();
            oldmo.AddHours=nemodel.AddHours;
            oldmo.RemoveHours=nemodel.RemoveHours;

            WeeklyHoliday oldwe = genral.GetWeeklyHoliday();
            oldwe.Day1 = nemodel.Day1;
            oldwe.Day2=nemodel.Day2;
            genral.save();

            return RedirectToAction("Index");
          
        }
    }
}
