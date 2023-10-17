using PolovniAutomobili.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolovniAutomobili.Data
{
    public class SqlCarData : IAutomobilData
    {
        public Automobil Add(Automobil newCar)
        {
            _db.Car.Add(newCar);
            _db.SaveChanges();
            return newCar;
        }

        public Automobil Delete(int id)
        {
            //   Automobil car = _db.Car.FirstOrDefault(c => c.Id == id);
            Automobil car = GetById(id);
            if (car != null) 
            {
                _db.Car.Remove(car);
                _db.SaveChanges();   
            }
            return car;
        }

        public Automobil GetById(int id)
        {
            return _db.Car.Find(id);
        }

        public IEnumerable<Automobil> GetCarsByName(string name)
        {
            var query = from c in _db.Car
                        where string.IsNullOrEmpty(name) || c.Name.Contains(name)
                        orderby c.Name
                        select c;
            return query;
        }

        public Automobil Update(Automobil updateCar)
        {
            var entity = _db.Car.Attach(updateCar);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
            return updateCar;
        }

        public int GetCountOfCars()
        {
            return _db.Car.Count();   
        }

        private readonly PolovniAutomobiliDbContext _db;

        public SqlCarData(PolovniAutomobiliDbContext polovniAutomobiliDbContext)
        {
            _db = polovniAutomobiliDbContext;
        }

    }
}
