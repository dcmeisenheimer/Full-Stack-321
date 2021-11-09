using System;
using api.interfaces;
using api.data;

namespace api.model
{
    public class Person
    {
        public int ID{get; set;}
        public string FirstName{get;set;}
        public string LastName{get; set;}
        public string Major{get; set;}
        public string Minor{get; set;}
        public string PledgeClass{get; set;}
        public string GraduatingSemester{get;set;}
        public string GradSchool{get;set;}
        public string GradSchoolName{get;set;}
        public string Employed{get;set;}
        public string Position{get;set;}
        public string Company{get;set;}
        public string City{get;set;}
        public string Email{get;set;}

        public IPersonDataHandler dataHandler{get; set;}

        public Person()
        {
            dataHandler =  new PersonDataHandler();
        }
    }
}
