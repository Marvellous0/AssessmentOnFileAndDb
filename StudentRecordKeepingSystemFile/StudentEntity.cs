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

        public override string ToString()
        {
            return $"{FirstName}\t{LastName}\t{Email}\t{PhoneNumber}\t{Age}\t{Class} ";
        }

        internal static StudentEntity StringToStudentEntity(string studentString)
        {
            var props = studentString.Split("\t");

            string firstName = props[0];

            string lastName = props[1];

            string email = props[2];

            string phoneNumber = props[3];

            int age = int.Parse(props[4]);

            string studentClass = props[5];

            return new StudentEntity(firstName, lastName, email, phoneNumber, age , studentClass);
        }
    }

}