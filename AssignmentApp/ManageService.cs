using System;
using System.Collections.Generic;
using System.Text;
using AssignmentApp.Data.Repository;
using AssignmentApp.Data.Model;
using AssignmentApp;


namespace AssignmentApp
{
    public class ManageService : MainScreen
    {
        ServiceRepository serviceRepository;
        public ManageService()
        {
            serviceRepository = new ServiceRepository();
        }

        public void AddService()
        {
            Service s = new Service();
            s.Room = new Room();
            Console.WriteLine("Enter Service Description = ");
            s.SDESC = Console.ReadLine();
            Console.WriteLine("Enter Service Amount = ");
            s.Amount = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter Service Date = ");
            s.ServiceDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter Room Number =");
            s.Room.Id = Convert.ToInt32(Console.ReadLine());

            if (serviceRepository.Insert(s) > 0)
            {
                Console.WriteLine("service Added Successfully!");
            }
            else
            {
                Console.WriteLine("Error! Cannot Add Service!");
            }
        }

        public void UpdateService()
        {
            Service s = new Service();
            s.Room = new Room();
            Console.Write("Enter The Id of The Service You Want to Update= ");
            s.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Service Description = ");
            s.SDESC = Console.ReadLine();
            Console.WriteLine("Enter Service Amount = ");
            s.Amount = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter Service Date = ");
            s.ServiceDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter Room Number =");
            s.Room.Id = Convert.ToInt32(Console.ReadLine());

            if (serviceRepository.Update(s) > 0)
            {
                Console.WriteLine("service Updated Successfully!");
            }
            else
            {
                Console.WriteLine("Error! Cannot Update Service!");
            }

        }

        public void DeleteService()
        {
            Console.Write("Enter The Id of The Service You Want to Delete= ");
            int id = Convert.ToInt32(Console.ReadLine());
            if (serviceRepository.Delete(id) > 0)
            {
                Console.WriteLine("Service Deleted Successfully!");
            }
            else
            {
                Console.WriteLine("Error! Cannot Delete Service!");
            }
        }

        public void PrintAllService()
        {
            var collection = serviceRepository.GetAll();
            foreach (var item in collection)
            {
                Console.WriteLine($"{item.Id} \t {item.SDESC} \t{item.Amount} \t {item.ServiceDate} \t {item.Room.Id}");
            }
        }

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
                        AddService();
                        break;
                    case (int)Operations.Update:
                        UpdateService();
                        break;
                    case (int)Operations.Delete:
                        DeleteService();
                        break;
                    case (int)Operations.GetAll:
                        PrintAllService();
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
