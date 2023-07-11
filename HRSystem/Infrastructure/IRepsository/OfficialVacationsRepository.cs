using Domain.Models;
using Infrastructure.Data;
using Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Infrastructure.IRepsository.OfficialVacationsRepository;

namespace Infrastructure.IRepsository
{
    public class OfficialVacationsRepository : IOfficialVacationsRepository
    {
        HRAppDbContext db;


        public OfficialVacationsRepository(HRAppDbContext _db)
        {

            this.db = _db;

        }
        public OfficialVacationsViewModel add(OfficialVacationsViewModel model)
            {
                {
                    try
                    {
                        OfficialVacations obj = new OfficialVacations();
                        obj.Id = model.id;
                        obj.Day = model.day;
                        obj.Date = model.date;

                        var result = db.OfficialVacations.Add(obj);
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
                        OfficialVacations obj = db.OfficialVacations.FirstOrDefault(x => x.Id == id);
                        if (obj != null)
                        {
                            db.OfficialVacations.Remove(obj);
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

            public IEnumerable<OfficialVacationsViewModel> GetALL()
            {

                try
                {
                    List<OfficialVacationsViewModel> officials = new List<OfficialVacationsViewModel>();
                    foreach (var item in db.OfficialVacations)
                    {
                        OfficialVacationsViewModel obj = new OfficialVacationsViewModel();
                        obj.id = item.Id;
                        obj.day = item.Day;
                        obj.date = item.Date;


                        officials.Add(obj);
                    }
                    return officials;
                }
                catch
                {
                    throw;
                }
            }

            public OfficialVacationsViewModel GetByID(int id)
            {
                try
                {


                    OfficialVacations official = db.OfficialVacations.FirstOrDefault(x => x.Id == id);
                    OfficialVacationsViewModel obj = new OfficialVacationsViewModel();
                    obj.id = official.Id;
                    obj.day = official.Day;
                    obj.date = official.Date;

                    return obj;

                }
                catch
                {
                    throw;
                }
            }

            public bool update(OfficialVacationsViewModel model)
            {
                try
                {
                    OfficialVacations obj = db.OfficialVacations.FirstOrDefault(x => x.Id == model.id);
                    if (obj != null)
                    {
                        obj.Id = model.id;
                        obj.Day = model.day;
                        obj.Date = model.date;

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
