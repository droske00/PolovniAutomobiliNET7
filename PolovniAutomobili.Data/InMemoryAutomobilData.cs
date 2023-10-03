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
               new Automobil() {Id = 1, Description = "Audi A3", Gorivo = Enums.GorivoVrsta.Benzin},
               new Automobil() {Id = 2, Description = "Audi A4", Gorivo =  Enums.GorivoVrsta.Dizel},
               new Automobil() {Id = 3, Description = "Audi Q5", Gorivo =  Enums.GorivoVrsta.Benzin},
               new Automobil() {Id = 4, Description = "Audi Q6", Gorivo =  Enums.GorivoVrsta.Hibrid}
           };
          
        }

        public Automobil Add(Automobil newCar)
        {
            newCar.Id = _cars.Max(c => c.Id) + 1;
            _cars.Add(newCar);
            return newCar;
        }

        public Automobil GetById(int id)
        {
            Automobil car = _cars.FirstOrDefault(c => c.Id == id);
            return car;
        }

        public IEnumerable<Automobil> GetCarsByDescription(string description)
        {
            var cars = from c in _cars
                       where String.IsNullOrEmpty(description) || c.Description.ToLower().Contains(description.ToLower())
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