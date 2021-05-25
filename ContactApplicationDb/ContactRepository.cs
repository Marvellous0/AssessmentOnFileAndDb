using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace ContactApplicationDb
{
    public class ContactRepository
    {
        MySqlConnection conn;
        public List<ContactEntity> Contacts = new List<ContactEntity>();

        public ContactRepository(MySqlConnection connection)
        {
            conn = connection;

        }
        public bool AddContactt(int id, string name, string phoneNumber, string email, string officeAddress)
        {

            try
            {
                conn.Open();
                string addContactQuery = "Insert into contact_list (id, name, phone_number, email, office_address)values ('" + id + "', '" + name + "', '" + phoneNumber + "', '" + email + "', '" + officeAddress + "')";

                MySqlCommand command = new MySqlCommand(addContactQuery, conn);
                int Count = command.ExecuteNonQuery();
                if (Count > 0)
                {
                    conn.Close();
                    return true;
                }
                Console.WriteLine("Contact Info created successfully! ");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return false;
        }

        public ContactEntity FindContacttById(int id)
        {
            ContactEntity contact = null;
            try
            {
                conn.Open();
                string contactQuery = "Select id, name, phone_number, email, office_address from contact_list where id = '" + id + "'";

                MySqlCommand command = new MySqlCommand(contactQuery, conn);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    {
                    
                        string name = reader.GetString(1);

                        string phoneNumber = reader.GetString(2);

                        string email = reader.GetString(3);

                        string officeAddress = reader.GetString(4);

                        contact = new ContactEntity(id, name, phoneNumber, email, officeAddress);
                    }
                    //Console.WriteLine(reader[0] + " " + reader[1] + reader[2] + " " + reader[3] + " " + reader[4]);
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return contact;
        }

        public void ListAllContacts()
        {
            List<ContactEntity> Contacts = new List<ContactEntity>();
            try
            {
                conn.Open();
                string contactListQuery = "select id, name, phone_number, email, office_address from contact_list";
                MySqlCommand command = new MySqlCommand(contactListQuery, conn);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader[0] + " " + reader[1] + reader[2] + " " + reader[3] + " " + reader[4]);
                }
                reader.Close();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public bool DeleteContact(int id)
        {
            var contact = FindContacttById(id);

            if (contact == null)
            {
                Console.WriteLine($"Contact with {id} does not exist");
            }

            try
            {
                conn.Open();
                string deleteContactQuery = "delete from contact_list where id = '" + id + "'";

                MySqlCommand command = new MySqlCommand(deleteContactQuery, conn);
                int Count = command.ExecuteNonQuery();
                if (Count > 0)
                {
                    conn.Close();
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return false;
        }

        public bool UpdateContact(int id, string name, string phoneNumber, string email, string officeAddress)
        {
            var contact = FindContacttById(id);

            if (contact== null)
            {
                Console.WriteLine($"Contact with {id} does not exist");
            }
            try
            {
                conn.Open();

                string updateContactQuery = "update contact_list set name ='" + name + "', phone_number = '" + phoneNumber + "', email = '" + email + "', office_address = '" + officeAddress + "' where id = '" + id + "' ";

                MySqlCommand command = new MySqlCommand(updateContactQuery, conn);
                int Count = command.ExecuteNonQuery();

                if (Count > 0)
                {
                    Console.WriteLine("Informations updated successfully! ");
                    conn.Close();
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return false;
        }
    }
}
