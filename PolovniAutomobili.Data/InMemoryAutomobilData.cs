using PolovniAutomobili.Core;
using System.Linq;

namespace PolovniAutomobili.Data
{
    public class InMemoryAutomobilData : IAutomobilData
    {
        List<Automobil> _cars; //Kreiranje promenljive Liste;

        public InMemoryAutomobilData() 
        {
            _cars = new List<Automobil>()
           {
               new Automobil() {Id = 1, Description = "Audi A3", Gorivo = Enums.GorivoVrsta.Benzin, Name = "Audi A3"},
               new Automobil() {Id = 2, Description = "Audi A4", Gorivo =  Enums.GorivoVrsta.Dizel,  Name = "Audi A4"},
               new Automobil() {Id = 3, Description = "Audi Q5", Gorivo =  Enums.GorivoVrsta.Benzin, Name = "Audi Q5"},
               new Automobil() {Id = 4, Description = "Audi Q6", Gorivo =  Enums.GorivoVrsta.Hibrid, Name = "Audi Q6"}
           };
          
        }

        public Automobil Add(Automobil newCar)
        {
            newCar.Id = _cars.Max(c => c.Id) + 1;
            _cars.Add(newCar);
            return newCar;
        }

        public Automobil Delete(int id)
        {
            Automobil car = _cars.FirstOrDefault(c => c.Id == id);
            if(car != null) 
            {
                _cars.Remove(car);
            }
            return car;
        }

        public Automobil GetById(int id)
        {
            Automobil car = _cars.FirstOrDefault(c => c.Id == id);
            return car;
        }

        public IEnumerable<Automobil> GetCarsByName(string name)
        {
            var cars = from c in _cars
                       where String.IsNullOrEmpty(name) || c.Description.ToLower().Contains(name.ToLower())
                       orderby c.Description
                       select c;
            return cars;
        }

        public Automobil Update(Automobil updateCar)
        {
            var car = _cars.FirstOrDefault(c => c.Id == updateCar.Id);
            if(car != null) 
            {
                car.Description = updateCar.Description;
                car.Gorivo = updateCar.Gorivo;
            }
            return car;
        }
    }
}