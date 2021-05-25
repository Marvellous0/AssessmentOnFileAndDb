using System;
namespace StudentRecordKeepingSystem
{
    public class StudentEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public int Age { get; set; }

        public string Class { get; set; }

        public StudentEntity(string firstName, string lastName, string email, string phoneNumber, int age, string studentClass)
        {
            FirstName = firstName;

            LastName = lastName;

            Email = email;

            PhoneNumber = phoneNumber;

            Age = age;

            Class = studentClass;
        }
    }

}