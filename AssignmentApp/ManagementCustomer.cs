using System;
using System.Collections.Generic;
using System.Text;
using AssignmentApp.Data.Repository;
using AssignmentApp.Data.Model;

namespace AssignmentApp
{
    public class ManagementCustomer:MainScreen
    {
        IRepository<Customer> customerRepository;
        public ManagementCustomer()
        {
            customerRepository = new CustomerRepository();
        }
        void AddCustomer()
        {
            Customer c = new Customer();
            // there is no need to ask for id, since it is auto-generated
            c.Room = new Room();
            Console.Write("Emter Customer Name = ");
            c.CName = Console.ReadLine();
            Console.Write("Emter Customer Address = ");
            c.Address = Console.ReadLine();
            Console.Write("Emter Customer Phone = ");
            c.Phone = Console.ReadLine();
            Console.Write("Emter Customer Email= ");
            c.Email = Console.ReadLine();
            Console.WriteLine("Enter Check in Date & Time = ");
            c.CheckIn = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Emter Total Persons = ");
            c.TotalPersons = Convert.ToInt32(Console.ReadLine());
            Console.Write("Emter Booking Days = ");
            c.BookingDays = Convert.ToInt32(Console.ReadLine());
            Console.Write("Emter Advance = ");
            c.Advance = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter the Room Number = ");
            c.Room.Id = Convert.ToInt32(Console.ReadLine());

            if (customerRepository.Insert(c) > 0)
            {
                Console.WriteLine("Customer Added Successfully!");
            }
            else
            {
                Console.WriteLine("Error! Cannot Add Customer!");
            }
        }
        void UpdateCustomer()
        {
            Customer c = new Customer();
            c.Room = new Room();
            Console.Write("Emter The Id of The Customer You Want to Update= ");
            c.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Emter Customer Name = ");
            c.CName = Console.ReadLine();
            Console.Write("Emter Customer Address = ");
            c.Address = Console.ReadLine();
            Console.Write("Emter Customer Phone = ");
            c.Phone = Console.ReadLine();
            Console.Write("Emter Customer Email= ");
            c.Email = Console.ReadLine();
            Console.WriteLine("Enter Check in Date & Time = ");
            c.CheckIn = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Emter Total Persons = ");
            c.TotalPersons = Convert.ToInt32(Console.ReadLine());
            Console.Write("Emter Booking Days = ");
            c.BookingDays = Convert.ToInt32(Console.ReadLine());
            Console.Write("Emter Advance = ");
            c.Advance = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter the Room Number = ");
            c.Room.Id = Convert.ToInt32(Console.ReadLine());

            if (customerRepository.Update(c) > 0)
            {
                Console.WriteLine("Customer Updated Successfully!");
            }
            else
            {
                Console.WriteLine("Error! Cannot Update Customer!");
            }
        }

        void DeleteCustomer()
        {
            Console.Write("Emter The Id of The Customer You Want to Delete= ");
            int id = Convert.ToInt32(Console.ReadLine());
            if (customerRepository.Delete(id) > 0)
            {
                Console.WriteLine("Customer Deleted Successfully!");
            }
            else
            {
                Console.WriteLine("Error! Cannot Delete Customer!");
            }
        }

        void PrintAllCustomer()
        {
            var collection = customerRepository.GetAll();
            foreach (var item in collection)
            {
                Console.WriteLine($"{item.Id} \t {item.CName} \t {item.Address} \t {item.Phone} \t{item.Email} \t{item.CheckIn} \t{item.TotalPersons} \t {item.BookingDays} \t{item.Advance}");
            }
        }

        /*public void */

        public override void Run()
        {
            
            int choice = 0;
            // We should put manu.PrintManu() inside do loop, so the user can choice the operation again
            do
            {
                Console.Clear();
                Menu menu = new Menu();
                choice = menu.PrintMenu(typeof(Operations));
                switch (choice)
                {
                    case (int)Operations.Add:
                        AddCustomer();
                        break;
                    case (int)Operations.Update:
                        UpdateCustomer();
                        break;
                    case (int)Operations.Delete:
                        DeleteCustomer();
                        break;
                    case (int)Operations.GetAll:
                        PrintAllCustomer();
                        break;
                    case (int)Operations.Exit:
                        Console.WriteLine("Thanks!");
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
                Console.WriteLine("Press Enter to Continue");
                Console.ReadLine();

            } while (choice != (int)Operations.Exit);


        }
    }

        

    
}
