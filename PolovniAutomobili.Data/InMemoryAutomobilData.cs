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
               new Automobil() {Id = 3, Description = "Audi A5", Gorivo =  Enums.GorivoVrsta.Benzin},
               new Automobil() {Id = 4, Description = "Audi A6", Gorivo =  Enums.GorivoVrsta.Hibrid}
           };
          
        }

        public IEnumerable<Automobil> GetAll()
        {
            var cars = from c in _cars
                       orderby c.Description
                       select c;
            return _cars;
        }
    }
}