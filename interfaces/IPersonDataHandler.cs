using System;
using System.Collections.Generic;
using api.model;
using api.Controllers;
using System.Linq;

namespace api.interfaces
{
    public interface IPersonDataHandler
    {
        public List<Person> Select();
         public void Delete(Person person);
         public void Insert(Person person);
         public void Update(Person person);
    }
}
