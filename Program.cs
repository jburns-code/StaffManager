using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace StaffManager
{
    class Program
    {
        static void Main()
        {
            List<Staff> staffList = new List<Staff>();
            bool running = true;
            int nextId = 1;

            while (running)
            {
                Console.WriteLine("\n--- Staff Manager ---");
                Console.WriteLine("1. Add staff");
                Console.WriteLine("2. List staff");
                Console.WriteLine("3. Edit staff member");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");
    
                string Choice = Console.ReadLine();
                string EditChoice = null;

                if (string.IsNullOrWhiteSpace(Choice))
                {
                    Console.WriteLine("\n-------\nInvalid input. Please try again.\n-------");
                    continue;
                }


                if (Choice == "1") // create a new staff member and add to list
                {
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(name))
                    {
                        Console.WriteLine("\n-------\nName cannot be empty.\n-------");
                        continue;
                    }

                    Console.Write("Role: ");
                    string role = Console.ReadLine();

                    Staff staff = new Staff(nextId, name, role);
                    staffList.Add(staff);
                    nextId++;

                    Console.WriteLine("Staff added.");
                    continue;
                }

                else if (Choice == "2") // display the saved staff members and information
                {
                    if (staffList.Count == 0)
                    {
                        Console.WriteLine("No staff found.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nStaff list:");
                        foreach (Staff s in staffList)
                        {
                            Console.WriteLine($"StaffID {s.Id} | {s.Name} ({s.Role})");
                        }
                    }
                }

                else if (Choice == "3") // edit staff information
                {          
                    Console.WriteLine("\nDo you wish to:\n1. edit\n2. delete");
                    string SecondEditChoice = Console.ReadLine();

                    if (SecondEditChoice == "1")
                    {
                        StaffActions.EditStaff(staffList);
                    } 

                    else if (SecondEditChoice == "2") 
                    {
                        StaffActions.RemoveStaff(staffList);
                    }
                }

                else if (Choice == "4")
                {
                    running = false;
                }
                else
                {
                    Console.WriteLine("Invalid option.");
                }
            }
        }
    }
}