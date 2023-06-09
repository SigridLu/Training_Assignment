﻿using System;
using ConsoleAppDay5Infrastructure.Services;

namespace ConsoleDay5Presentation
{
	public class Menu
	{
        DepartmentService dept;
        EmployeeService ee;

        public Menu()
		{
            dept = new DepartmentService();
            ee = new EmployeeService();
        }

		public void Run()
		{
            while (true)
            {
                FirstStep:
                var e_choice = EntityChoice();
                if (e_choice == "d")
                {
                    var a_choice = ActionChoice("department");
                    switch (a_choice)
                    {
                        case 1:
                            dept.AddDepartment();
                            break;
                        case 2:
                            dept.DeleteDepartment();
                            break;
                        case 3:
                            dept.GetAllDepartments();
                            break;
                        case 4:
                            dept.UpdateDepartment();
                            break;
                        case 5:
                            dept.GetDepartmentById();
                            break;
                        case 6:
                            return;
                        case 7:
                            goto FirstStep;
                        default:
                            Console.WriteLine("Invalid number! Please try again.");
                            break;
                    }
                }
                else if (e_choice == "e")
                {
                    var a_choice = ActionChoice("employee");
                    switch (a_choice)
                    {
                        case 1:
                            ee.AddEmployee();
                            break;
                        case 2:
                            ee.DeleteEmployee();
                            break;
                        case 3:
                            ee.GetAllEmployees();
                            break;
                        case 4:
                            ee.UpdateEmployee();
                            break;
                        case 5:
                            ee.GetEmployeeById();
                            break;
                        case 6:
                            return;
                        case 7:
                            goto FirstStep;
                        default:
                            Console.WriteLine("Invalid number! Please try again.");
                            break;
                    }
                }
                else if (e_choice == "q")
                    return;
                else
                    Console.WriteLine("Invalid selection! Please try again.");
            }
        }

        // input 'd' to select department
        // input 'e' to select employee
        public string EntityChoice()
		{
            Console.WriteLine("Enter d to interact with department data: ");
            Console.WriteLine("Enter e to interact with employee data: ");
            Console.WriteLine("Enter q to quit the program");
            string choice = "";
            try {
                choice = Console.ReadLine();
            } catch (Exception ex) {
                Console.WriteLine("Exception found in first step: " + ex);
            }
            return choice;
        }

        // input number 1 to 6 for interaction with selected entity
        public int ActionChoice(string entity)
        {
            Console.WriteLine($"Enter 1 to add {entity}: ");
            Console.WriteLine($"Enter 2 to delete {entity}: ");
            Console.WriteLine($"Enter 3 to get all {entity}: ");
            Console.WriteLine($"Enter 4 to update {entity}: ");
            Console.WriteLine($"Enter 5 to get {entity} by id: ");
            Console.WriteLine("Enter 6 to exit program: ");
            Console.WriteLine("Enter 7 to go back to last step" + "/n");
            int choice = 0;
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception found in second step: " + ex + "/n");
            }
            return choice;
        }
	}
}



