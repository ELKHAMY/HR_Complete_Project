using Domain.Models;
using Infrastructure.Data;
using Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Infrastructure.IRepsository.HoursRepository;

namespace Infrastructure.IRepsository
{
    public class HoursRepository : IHoursRepository
    {

        HRAppDbContext db;


        public HoursRepository(HRAppDbContext _db)
        {

            this.db = _db;

        }
        public HoursViewModel add(HoursViewModel model)
            {
                {
                    try
                    {
                        Hours obj = new Hours();
                        obj.Id = model.id;
                        obj.AddHours = model.addHours;
                        obj.RemoveHours = model.removeHours;

                        var result = db.Hours.Add(obj);
                        db.SaveChanges();
                        return model;
                    }
                    catch
                    {
                        throw;
                    }
                }
            }

            public bool delete(int id)
            {
                try
                {
                    if (id > 0)
                    {
                        Hours obj = db.Hours.FirstOrDefault(x => x.Id == id);
                        if (obj != null)
                        {
                            db.Hours.Remove(obj);
                            db.SaveChanges();
                            return true;
                        }
                        else
                            return false;
                    }
                    else
                        return false;
                }
                catch (Exception)
                {
                    throw;
                }
            }

            public IEnumerable<HoursViewModel> GetALL()
            {
                try
                {
                    List<HoursViewModel> hours = new List<HoursViewModel>();
                    foreach (var item in db.Hours)
                    {
                        HoursViewModel obj = new HoursViewModel();
                        obj.id = item.Id;
                        obj.addHours = item.AddHours;
                        obj.removeHours = item.RemoveHours;


                        hours.Add(obj);
                    }
                    return hours;
                }
                catch
                {
                    throw;
                }
            }

            public HoursViewModel GetByID(int id)
            {
                try
                {


                    Hours hour = db.Hours.FirstOrDefault(x => x.Id == id);
                    HoursViewModel obj = new HoursViewModel();
                    obj.id = hour.Id;
                    obj.addHours = hour.AddHours;
                    obj.removeHours = hour.RemoveHours;

                    return obj;

                }
                catch
                {
                    throw;
                }
            }

            public bool update(HoursViewModel model)
            {
                try
                {
                    Hours obj = db.Hours.FirstOrDefault(x => x.Id == model.id);
                    if (obj != null)
                    {
                        obj.Id = model.id;
                        obj.AddHours = model.addHours;
                        obj.RemoveHours = model.removeHours;

                        db.SaveChanges();
                        return true;
                    }
                    else
                        return false;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        
    }
}
