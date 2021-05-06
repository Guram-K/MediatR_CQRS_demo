using DemoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary.DataAccess
{
    public class DemoDataAccess : IDataAccess
    {
        private List<PersonModel> people = new();

        public DemoDataAccess()
        {
            people.Add(new PersonModel { Id = 1, FirstName = "Tim", LastName = "Corey" });
            people.Add(new PersonModel { Id = 2, FirstName = "Me", LastName = "Ka" });
        }

        public List<PersonModel> GetPeople()
        {
            return people;
        }

        public PersonModel GetPerson(int id)
        {
            return people.FirstOrDefault(i => i.Id == id);
        }

        public PersonModel InsertPerson(string firstName, string lastName)
        {
            PersonModel p = new() { FirstName = firstName, LastName = lastName };
            p.Id = people.Max(x => x.Id) + 1;
            people.Add(p);

            return p;
        }
    }
}
