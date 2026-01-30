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


                if (choice == "1") // create a new staff member and add to list
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
                else if (choice == "2") // display the saved staff members and information
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
                            Console.WriteLine($"StaffID {s.Id} | {s.Name} ({s.Role})");
                        }
                    }
                }
                
                else if (choice == "3") // edit staff information
                {
                    Console.WriteLine("\nStaff list:"); // generate list of staff members
                    foreach (Staff s in staffList)
                    {
                        Console.WriteLine($"StaffID {s.Id} | {s.Name} ({s.Role})");
                    }

                    Console.WriteLine("\nEnter staff ID to edit: ");
                    string editChoice = Console.ReadLine();
                    Staff staffToRemove = null;

                    foreach (Staff i in staffList)
                    {
                        if (editChoice == i.Id.ToString()) 
                        {

                            Console.WriteLine("\nDo you wish to:\n1. edit\n2. delete");
                            string editSecondChoice = Console.ReadLine();

                            if (editSecondChoice == "1")
                            {                     
                                Console.Write("Name: ");
                                string name = Console.ReadLine();
        
                                Console.Write("Role: ");
                                string role = Console.ReadLine();
                            
                                i.Name = name;
                                i.Role = role;

                                Console.WriteLine("Staff member has been updated.");
                            }

                            else if (editSecondChoice == "2")
                            {
                                Console.WriteLine("\n*****Are you sure you wish to delete this staff member?*****");
                                Console.WriteLine("1. Yes\n2. No");
                                string editThirdChoice = Console.ReadLine();

                                if (editThirdChoice == "1")
                                {
                                    foreach (Staff d in staffList)
                                    {
                                        if (d.Id.ToString() == editChoice)
                                        {
                                            staffToRemove = d;
                                            break;
                                        }
                                    }
                                }
                                else if (editThirdChoice == "2")
                                {
                                    Console.WriteLine("Staff member was not removed.");
                                    break;
                                }

                            }
                            
                        }

                    }
                if (staffToRemove != null) // remove staff member 
                {
                    staffList.Remove(staffToRemove);
                    Console.WriteLine("Staff member removed.");
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