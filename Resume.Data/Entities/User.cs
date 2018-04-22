using Resume.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resume.Data.Entities
{
    public class User : Entity
    {
        public User(Guid id,
            string firstName,
            string lastName,
            string email,
            string password,
            DateTime dateOfBirth) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            DateOfBirth = dateOfBirth;
        }

        public User() : base(Guid.NewGuid()) { }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public DateTime DateOfBirth { get; private set; }
    }
}
