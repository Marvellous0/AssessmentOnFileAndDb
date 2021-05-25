using System;

namespace ContactApplicationDb
{
    public class ContactEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
        public string OfficeAddress { get; set; }

        public ContactEntity(int id, string name, string phoneNumber, string email, string officeAddress)
        {
            Id = id;

            Name = name;

            PhoneNumber = phoneNumber;

            Email = email;

            OfficeAddress = officeAddress;
        }
    }
}
