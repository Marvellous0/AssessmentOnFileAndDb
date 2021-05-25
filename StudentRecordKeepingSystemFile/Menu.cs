using System;
using System.Collections.Generic;

namespace StudentRecordKeepingSystem
{
    public class Menu
    {
    
        static StudentRepository studentRepo = new StudentRepository();

        private void ShowMenu()
        {
            Console.WriteLine("0. Back");
            Console.WriteLine("1. Add Student Information");
            Console.WriteLine("2. Find Student by email");
            Console.WriteLine("3. List Student emails");
            Console.WriteLine("4. Update Student Info");
            Console.WriteLine("5. Delete Student Info");
            Console.WriteLine("6. List of Students in Jss1.");
            Console.WriteLine("7. List Students with age > 18.");
        }

        public void AddStudentDetails()
        {
            Console.Write("Enter your First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter your email: ");
            string email = Console.ReadLine();

            Console.Write("Enter your Phone Number: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Enter your Age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter your Class: ");
            string studentClass = Console.ReadLine();

            studentRepo.AddStudentInfo(firstName, lastName, email, phoneNumber, age, studentClass);
        }

        public void UpdateStudentDetails()
        {
            Console.Write("Enter email of Student: ");
            string email = Console.ReadLine();

            Console.Write("Update Student First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Update Student Age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            studentRepo.UpdateStudent(firstName, email, age);
            studentRepo.RefreshFile();
        }

        public void DeleteStudentName()
        {
            Console.Write("Enter last name of Student you want to delete: ");
            string lastName = Console.ReadLine();

            Console.Write("Are you sure you want to delete? ");
            string option = Console.ReadLine();

            if(option == "yes")
            {
                studentRepo.DeleteStudentLastName(lastName);

                Console.WriteLine($"{lastName} deleted successfully! ");
            }

            else
            {
                ShowMenu();
            }
        }
        public void ShowStudentMenu()
        {
            ShowMenu();
            Console.Write("Option: ");
            string option = Console.ReadLine().Trim();

            switch (option)
            {
                case "0":
                    break;
                case "1":
                    AddStudentDetails();
                    ShowStudentMenu();
                    break;
                case "2":
                    studentRepo.FindStudent();
                    ShowStudentMenu();
                    break;

                case "3":
                    studentRepo.ListAllEmails();
                    ShowStudentMenu();
                    break;

                case "4":
                    UpdateStudentDetails();
                    ShowStudentMenu();
                    break;

                case "5":
                    DeleteStudentName();
                    ShowStudentMenu();
                    break;

                    case "6":
                    studentRepo.ListAllStudentInJss1();
                    ShowStudentMenu();
                    break;

                    case "7":
                    studentRepo.ListAllAges();
                    ShowStudentMenu();
                    break;
                default:
                    Console.WriteLine("Invalid Option!");
                    break;
            }
        }
    }
}