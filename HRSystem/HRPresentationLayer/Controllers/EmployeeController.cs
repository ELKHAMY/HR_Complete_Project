using Domain.Models;
using Infrastructure.IRepsository;
using Microsoft.AspNetCore.Mvc;

namespace HRPresentationLayer.Controllers
{
    public class EmployeeController : Controller
    {

        #region fields 
        IEmployeerep Employeerep;
        IDepartmentrep departmentrep;


        #endregion

        #region constructor 
        public EmployeeController(IEmployeerep employeerep, IDepartmentrep departmentrep)
        {
            this.Employeerep = employeerep;
            this.departmentrep = departmentrep;
        }
        #endregion

        #region actions

        //--- get all
        public IActionResult Index()
        {
           List<EmployeePersonalData> empmodel = Employeerep.getall();
            return View(empmodel);
        }
        //------ add

        public IActionResult Add() 
        {
            ViewData["deptlist"] = departmentrep.getall();
            return View();
        }
        [HttpPost]
        public IActionResult Add(EmployeePersonalData emp) 
        {
            if (ModelState.IsValid)
            {
                Employeerep.insert(emp);
                Employeerep.save();
                return RedirectToAction("Index");
            }
            ViewData["deptlist"] = departmentrep.getall();
            return View(emp);
        }

        //---- edit 
        public IActionResult Edit(int id)
        {
            EmployeePersonalData oldemp = Employeerep.getbyid(id);
            ViewData["DeptList"] = departmentrep.getall();

            return View(oldemp);
        }
        [HttpPost]
        public IActionResult Edit( EmployeePersonalData newemp, int id) 
        {
            Employeerep.update(id, newemp);
            Employeerep.save();

            return RedirectToAction("Index");
        }
        //------delete

        public IActionResult Delete (int id) 
        {

           EmployeePersonalData empmodel = Employeerep.getbyid(id);
            ViewData["DeptList"] = departmentrep.getall();

            return View(empmodel);
        }
        [HttpPost]
        public IActionResult Delete(EmployeePersonalData oldmodel, int id)
        {
            Employeerep.delete(id);
            Employeerep.save();

            return RedirectToAction("Index");

        }

        #endregion
    }
}
