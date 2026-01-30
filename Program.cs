using System;
using System.Collections.Generic;

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
    
                string choice = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(choice))
                {
                    Console.WriteLine("\n-------\nInvalid input. Please try again.\n-------");
                    continue;
                }


                if (choice == "1") // creating a new staff member and adding to the list
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
                }
                else if (choice == "2")
                {
                    if (staffList.Count == 0)
                    {
                        Console.WriteLine("No staff found.");
                    }
                    else
                    {
                        Console.WriteLine("\nStaff list:");
                        foreach (Staff s in staffList)
                        {
                            Console.WriteLine($"{s.Id}: {s.Name} ({s.Role})");
                        }
                    }
                }
                
                else if (choice == "3")
                {
                    Console.WriteLine("\nStaff list:");
                    foreach (Staff s in staffList)
                    {
                        Console.WriteLine($"{s.Id}: {s.Name} ({s.Role})");
                    }

                    Console.WriteLine("\nEnter staff ID to edit: ");
                    string editChoice = Console.ReadLine();
                    foreach (Staff i in staffList)
                    {
                        if (editChoice == i.Id.ToString())
                        {
                            Console.Write("Name: ");
                            string name = Console.ReadLine();
        
                            Console.Write("Role: ");
                            string role = Console.ReadLine();
                            
                            i.Name = name;
                            i.Role = role;

                            Console.WriteLine("Staff member has been updated.");
                        }
                    }

                }

                else if (choice == "4")
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