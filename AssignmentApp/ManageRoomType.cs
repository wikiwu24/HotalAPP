using AssignmentApp.Data.Model;
using AssignmentApp.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentApp
{
    public class ManageRoomType : MainScreen
    {
        RoomTypeRepository roomTypeRepository;
        public ManageRoomType()
        {
            roomTypeRepository = new RoomTypeRepository();
        }
        public void AddRoomType()
        {
            RoomType r = new RoomType();
            Console.WriteLine("Enter RoomType Description = ");
            r.RTDESC = Console.ReadLine();
            Console.WriteLine("Enter RoomType Rent = ");
            r.Rent = Convert.ToDecimal(Console.ReadLine());

            if (roomTypeRepository.Insert(r) > 0)
            {
                Console.WriteLine("RoomType Added Successfully!");
            }
            else
            {
                Console.WriteLine("Error! Cannot Add RoomType!");
            }
        }
        public void UpdateRoomType()
        {
            RoomType r = new RoomType();
            Console.WriteLine("Enter The RoomType Id = ");
            r.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter RoomType Description = ");
            r.RTDESC = Console.ReadLine();
            Console.WriteLine("Enter RoomType Rent = ");
            r.Rent = Convert.ToDecimal(Console.ReadLine());
            if (roomTypeRepository.Update(r) > 0)
            {
                Console.WriteLine("Room Updated Successfully!");
            }
            else
            {
                Console.WriteLine("Error! Cannot Update Room!");
            }
        }

        public void DeleteRoomType()
        {
            Console.Write("Enter The Id of The Room You Want to Delete= ");
            int id = Convert.ToInt32(Console.ReadLine());
            if (roomTypeRepository.Delete(id) > 0)
            {
                Console.WriteLine("RoomType Deleted Successfully!");
            }
            else
            {
                Console.WriteLine("Error! Cannot Delete RoomType!");
            }
        }

        public void PrintAllRoomType()
        {
            var collection = roomTypeRepository.GetAll();
            foreach (var item in collection)
            {
                Console.WriteLine($"{item.Id} \t {item.RTDESC} \t{item.Rent}");
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
                        AddRoomType();
                        break;
                    case (int)Operations.Update:
                        UpdateRoomType();
                        break;
                    case (int)Operations.Delete:
                        DeleteRoomType();
                        break;
                    case (int)Operations.GetAll:
                        PrintAllRoomType();
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
