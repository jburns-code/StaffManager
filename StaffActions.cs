using System;
using System.Collections.Generic;
using System.Net;

namespace StaffManager
{
    class StaffActions
    {
        public static void EditStaff(List<Staff> staffList)
        {
            Staff StaffToEdit = null;

            if (staffList.Count == 0)
            {
                Console.WriteLine("No staff to edit.");
                return;
            }

            Console.WriteLine("\nStaff list:"); // generate list of staff members
            foreach (Staff s in staffList)
            {
                Console.WriteLine($"StaffID {s.Id} | {s.Name} ({s.Role})");
            }

            Console.WriteLine("\nEnter staff ID you wish to edit: "); // request staff ID to edit
            string EditChoice = Console.ReadLine();

            foreach (Staff i in staffList)
            {
                if (i.Id.ToString() == EditChoice)
                {
                    StaffToEdit = i;
                }
            }

            Console.Write("Name: ");
            string name = Console.ReadLine();
            
            Console.Write("Role: ");
            string role = Console.ReadLine();

            StaffToEdit.Name = name;
            StaffToEdit.Role = role;
            return;

        }
        public static void RemoveStaff(List<Staff> staffList)
        {
            if (staffList.Count == 0)
            {
                Console.WriteLine("No staff to remove.");
                return;
            }

            Console.WriteLine("\nStaff list:");
            foreach (Staff s in staffList)
            {
                Console.WriteLine($"StaffID {s.Id} | {s.Name} ({s.Role})");
            }

            Console.Write("\nEnter staff ID to delete: ");
            string input = Console.ReadLine();

            Staff StaffToRemove = null;

            foreach (Staff s in staffList)
            {
                if (s.Id.ToString() == input)
                {
                    StaffToRemove = s;
                    break;
                }
            }

            if (StaffToRemove == null)
            {
                Console.WriteLine("Staff ID not found.");
                return;
            }

            Console.WriteLine($"\n********\nAre you sure you want to delete {StaffToRemove.Name}?\n********");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            string confirm = Console.ReadLine();

            if (confirm != "1")
            {
                Console.WriteLine("\nDeletion cancelled.");
                return;
            }

            staffList.Remove(StaffToRemove);
            Console.WriteLine("\nStaff member removed.");
        }
    }
}
