using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktop5lab.Entities
{
    public class PersonEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }

        public List<NoteEntity> Notes { get; set; } = [];



        public PersonEntity(
            string firstName,
            string lastName,
            string middleName,
            string login,
            string password)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            Login = login;
            Password = password;
        }

    }
}
