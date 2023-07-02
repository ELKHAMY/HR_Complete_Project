using Domain.Models;
using Infrastructure.IRepsository;
using Microsoft.AspNetCore.Mvc;

namespace HRPresentationLayer.Controllers
{
    public class DepartmentController : Controller
    {
        #region fields 

        IDepartmentrep departmentrep;
        #endregion

        #region constractor
        public DepartmentController(IDepartmentrep departmentrep)
        {
            this.departmentrep = departmentrep;
        }
        #endregion

        #region actions

        //---- get all
        public IActionResult Index()
        {
            
            return View(departmentrep.getall());
        }

        //--------- add

        public IActionResult Add() 
        {
        return View();
        
        }

        [HttpPost]
        public IActionResult Add(Department dep)
        {
            departmentrep.insert(dep);
            departmentrep.save();
            return RedirectToAction("Index");

        }
        //---------------- edit 

        public IActionResult Edit(int id) 
        {
           Department olddep=  departmentrep.getbyid(id);
            return View(olddep);
        }

        [HttpPost]

        public IActionResult Edit(Department newdep,int id)
        {

            departmentrep.update(id, newdep);
            departmentrep.save();

            return RedirectToAction("Index");
        }
        //-----delete

        public IActionResult Delete(int id)
        {
            Department model = departmentrep.getbyid(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Department oldmodel ,int id)
        {
            departmentrep.delete(id);
            departmentrep.save();

            return RedirectToAction("Index");

        }
        #endregion

    }
}
