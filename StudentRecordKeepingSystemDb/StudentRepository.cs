using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace StudentRecordKeepingSystem
{
    public class StudentRepository
    {
        MySqlConnection conn;

        public List<StudentEntity> Students = new List<StudentEntity>();

        public StudentRepository(MySqlConnection connection)
        {
            conn = connection;

        }
        public bool AddStudent(string firstName, string lastName, string email, string phoneNumber, int age, string studentClass)
        {

            try
            {
                conn.Open();
                string addStudentQuery = "Insert into student_records (first_name, last_name, email, phone_number, age, student_class)values ('" + firstName + "', '" + lastName + "', '" + email + "', '" + phoneNumber + "', '" + age + "', '" + studentClass + "')";

                MySqlCommand command = new MySqlCommand(addStudentQuery, conn);
                int Count = command.ExecuteNonQuery();
                if (Count > 0)
                {
                    conn.Close();
                    return true;
                }
                Console.WriteLine("Student Info created successfully! ");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return false;
        }

        public StudentEntity FindStudentByEmail(string email)
        {
            StudentEntity student = null;
            try
            {
                conn.Open();
                string studentQuery = "Select first_name, last_name, email, phone_number, age, student_class from student_records where email = '" + email + "'";

                MySqlCommand command = new MySqlCommand(studentQuery, conn);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    {
                        string first_name = reader.GetString(0);

                        string last_name = reader.GetString(1);

                        string phone_number = reader.GetString(3);

                        int age = reader.GetInt32(4);

                        string student_class = reader.GetString(5);

                        student = new StudentEntity(first_name, last_name, email, phone_number, age, student_class);
                    }
                    Console.WriteLine(reader[0] + " " + reader[1]);
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return student;
        }

        public void ListAllEmails()
        {
            List<StudentEntity> Students = new List<StudentEntity>();
            try
            {
                conn.Open();
                string studentEmailQuery = "select first_name, last_name, email, phone_number, age, student_class from student_records";
                MySqlCommand command = new MySqlCommand(studentEmailQuery, conn);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader[2]);
                }
                reader.Close();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ListAllAges()
        {
            List<StudentEntity> Students = new List<StudentEntity>();
            try
            {
                conn.Open();
                string studentEmailQuery = "select age from student_records where age > 18";
                MySqlCommand command = new MySqlCommand(studentEmailQuery, conn);
                MySqlDataReader reader = command.ExecuteReader();

                int count = 0;
                while (reader.Read())
                {
                    Console.WriteLine($"Age: {reader[0]}");
                    count++;
                }

                Console.WriteLine($"Number of Students with ages greater than 18 is {count}. ");
                reader.Close();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ListAllStudentInJss1()
        {
            List<StudentEntity> Students = new List<StudentEntity>();
            try
            {
                conn.Open();
                string studentEmailQuery = "select * from student_records where student_class = 'Jss1'";
                MySqlCommand command = new MySqlCommand(studentEmailQuery, conn);
                MySqlDataReader reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    Console.WriteLine(reader[0] + " " + reader[1] + " " + reader[2] + " " + reader[3] + " " + reader[4] + " " + reader[5]);
                }
                reader.Close();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public bool UpdateStudent(string firstName, string email, int age)
        {
            var student = FindStudentByEmail(email);
            if (student == null)
            {
                Console.WriteLine($"Student with {email} does not exist");
            }
            try
            {
                conn.Open();

                string updateStudentQuery = "update student_records set first_name ='" + firstName + "', age = '" + age + "' where email = '" + email + "'";

                MySqlCommand command = new MySqlCommand(updateStudentQuery, conn);
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

        public bool DeleteStudentLastName(string lastName)
        {
            if (lastName == null)
            {
                Console.WriteLine($"Student with {lastName} does not exist");
            }
            try
            {
                conn.Open();
                string deleteStudentLastNameQuery = "delete from student_records where last_name = '" + lastName + "'";

                MySqlCommand command = new MySqlCommand(deleteStudentLastNameQuery, conn);
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
    }
}