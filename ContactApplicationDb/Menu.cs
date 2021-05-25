using System;
using MySql.Data.MySqlClient;

namespace ContactApplicationDb
{
    public class Menu
    {
        static string connectionString = "server=localhost;user=root;database=contactapplicationdb;port=3306;password=MARVELLOUS";
        static MySqlConnection conn = new MySqlConnection(connectionString);

        static ContactRepository contactRepo = new ContactRepository(conn);

        private void ShowMenu()
        {
            Console.WriteLine("0. Back");
            Console.WriteLine("1. Add Contact Information");
            Console.WriteLine("2. List available Contacts");
            Console.WriteLine("3. Find Contact ");
            Console.WriteLine("4. Update Contacts");
            Console.WriteLine("5. Delete Contact");
            Console.WriteLine("6. Search Contact using name");
        }

        public void AddContactDetails()
        {
            Console.Write("Enter Contact Id: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your Phone Number: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Enter your email: ");
            string email = Console.ReadLine();

            Console.Write("Enter your Office Address: ");
            string officeAddress = Console.ReadLine();

            contactRepo.AddContactt(id, name, phoneNumber, email, officeAddress);
            Console.WriteLine("Contact Info created successfully! ");
        }

        public void UpdateContactDetails()
        {
            Console.Write("Enter Contact Id you want to update: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Update Contact Name: ");
            string name = Console.ReadLine();

            Console.Write("Update Contact Phone Number: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Update Contact email: ");
            string email = Console.ReadLine();

            Console.Write("Update Contact Office Address: ");
            string officeAddress = Console.ReadLine();

            contactRepo.UpdateContact(id, name, phoneNumber, email, officeAddress);
        }

        public void DeleteContact()
        {
            Console.Write("Enter of Id Contact you want to delete: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Are you sure you want to delete? ");
            string option = Console.ReadLine();

            if (option == "yes")
            {
                contactRepo.DeleteContact(id);

                Console.WriteLine($"Contact with {id} deleted successfully! ");
            }

            else
            {
                ShowMenu();
            }
        }

            public void FindContact()
        {
            Console.WriteLine("Enter the id of the Contact you want to find: ");
            int id = int.Parse(Console.ReadLine());

            var contact = contactRepo.FindContacttById(id);

            if (contact == null)
            {
                Console.WriteLine($"Student with Email \t {id} does not exist! ");
            }

            else
            {
                Console.WriteLine($"Id: {contact.Id} Name: {contact.Name}  Phone Number: {contact.PhoneNumber} Email: {contact.Email} Office Address: {contact.OfficeAddress} ");
            }
        }
        public void ShowContactMenu()
        {
            ShowMenu();
            Console.Write("Option: ");
            string option = Console.ReadLine().Trim();

            switch (option)
            {
                case "0":
                    break;
                case "1":
                    AddContactDetails();
                    ShowContactMenu();
                    break;
                case "2":
                    contactRepo.ListAllContacts();
                    ShowContactMenu();
                    break;

                case "3":
                    FindContact();
                    ShowContactMenu();
                    break;

                case "4":
                    UpdateContactDetails();
                    ShowContactMenu();
                    break;

                case "5":
                    DeleteContact();
                    ShowContactMenu();
                    break;

                case "6":

                    ShowContactMenu();
                    break;

                default:
                    Console.WriteLine("Invalid Option!");
                    break;
            }
        }
    }
}
