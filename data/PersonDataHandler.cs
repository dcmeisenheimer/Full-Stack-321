using System.Reflection.PortableExecutable;
using System.Data.Common;
using System.Reflection.Metadata.Ecma335;
using System;
using System.Collections.Generic;
using System.Dynamic;
using api.interfaces;
using api.data;
using api.model;

namespace api.data
{
    public class PersonDataHandler :IPersonDataHandler
    {
        private Database db;
        public PersonDataHandler()
        {
            db = new Database();
        }
         public List<Person> Select()
         {
            List<Person> people = new List<Person>();
            string sql = "SELECT * from person";
            db.Open();
            List<ExpandoObject> results = db.Select(sql);
            foreach(dynamic item in results)
            {
                Person temp = new Person()
                {ID = item.id, 
                FirstName = item.first_name, 
                LastName = item.last_name,
                Major = item.major,
                Minor = item.minor,
                PledgeClass = item.pledge_class,
                GraduatingSemester = item.graduating_semester,
                GradSchool = item.grad_school,
                GradSchoolName = item.grad_school_name,
                Employed = item.employed,
                Position = item.position,
                Company = item.company,
                City = item.city,
                Email = item.email};

                people.Add(temp);
            }

            db.Close();

             return people;
         }
         public void Delete(Person person)
         {

         }
         public void Insert(Person person)
         {
            System.Console.WriteLine("Made it to the insert");

            var values  = GetValues(person);



            string sql = "INSERT INTO person (first_name, last_name, major, minor, pledge_class, graduating_semester, grad_school, grad_school_name, employed, position, company, city, email)";
            sql+= "VALUES(@firstName, @lastName, @major, @minor, @pledgeClass, @graduatingSemester, @gradSchool, @gradSchoolName, @employed, @position, @company, @city, @email)";

            db.Open();
            db.Insert(sql, values);
            db.Close();
         }
         public void Update(Person person)
         {

             System.Console.WriteLine("Made it to the update" + person.FirstName);
            var values  = GetValues(person);

            string sql = "UPDATE person SET first_name=@firstName, last_name=@lastName, major=@major, minor=@minor, pledge_class=@pledgeClass "; 
            sql += "graduating_semester=@graduatingSemester, grad_school=@gradSchool, grad_school_name=@gradSchoolName, employed=@employed, position=@position ";
            sql +="company=@company, city=@city, email=@email";

            sql += "WHERE id=@id";

            db.Open();
            db.Update(sql, values);
            db.Close();
         }

         public Dictionary<string,object> GetValues(Person person)
         {
            var values = new Dictionary<string,object>()
            {
                {"@id", person.ID},
                {"@firstName", person.FirstName},
                {"@lastName", person.LastName},
                {"@major", person.Major},
                {"@minor", person.Minor},
                {"@pledgeClass", person.PledgeClass},
                {"@graduatingSemester", person.GraduatingSemester},
                {"@gradSchool", person.GradSchool},
                {"@gradSchoolName", person.GradSchoolName},
                {"@employed", person.Employed},
                {"@position", person.Position},
                {"@company", person.Company},
                {"@city" , person.City},
            {"@email" , person.Email},
            };

            return values;
         }
    }
}
