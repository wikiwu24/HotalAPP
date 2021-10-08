using System;
using System.Collections.Generic;
using System.Text;
using AssignmentApp.Data.Model;
using AssignmentApp.Data.Repository;

namespace AssignmentApp
{
    public class ManageRoom:MainScreen
    {
        IRepository<Room> roomRepository;
        public ManageRoom()
        {
            roomRepository = new RoomRepository();
        }

        public void AddRoom()
        {
            Room r = new Room();
            r.RoomType = new RoomType();
            Console.WriteLine("Enter RoomType Code = ");
            r.RoomType.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Room Status = ");
            r.Status = Convert.ToBoolean(Console.ReadLine());
            if(roomRepository.Insert(r) > 0)
            {
                Console.WriteLine("Room Added Successfully!");
            }
            else
            {
                Console.WriteLine("Error! Cannot Add Room!");
            }
        }

        public void UpdateRoom()
        {
            Room r = new Room();
            r.RoomType = new RoomType();
            Console.WriteLine("Enter The Room Id = ");
            r.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter RoomType Code = ");
            r.RoomType.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Room Status = ");
            r.Status = Convert.ToBoolean(Console.ReadLine());
            if (roomRepository.Update(r) > 0)
            {
                Console.WriteLine("Room Updated Successfully!");
            }
            else
            {
                Console.WriteLine("Error! Cannot Update Room!");
            }
        }

        public void DeleteRoom()
        {
            Console.Write("Enter The Id of The Room You Want to Delete= ");
            int id = Convert.ToInt32(Console.ReadLine());
            if (roomRepository.Delete(id) > 0)
            {
                Console.WriteLine("Room Deleted Successfully!");
            }
            else
            {
                Console.WriteLine("Error! Cannot Delete Room!");
            }
        }

        public void PrintAllRoom()
        {
            var collection = roomRepository.GetAll();
            foreach (var item in collection)
            {
                Console.WriteLine($"{item.Id} \t {item.RoomType.Id}\t {item.Status}");
            }
        }
        public override void Run()
        {
            Menu menu = new Menu();
            int choice = 0;
            // We should put manu.PrintManu() inside do loop, so the user can choice the operation again
            do
            {
                Console.Clear();
                choice = menu.PrintMenu(typeof(Operations));
                switch (choice)
                {
                    case (int)Operations.Add:
                        AddRoom();
                        break;
                    case (int)Operations.Update:
                        UpdateRoom();
                        break;
                    case (int)Operations.Delete:
                        DeleteRoom();
                        break;
                    case (int)Operations.GetAll:
                        PrintAllRoom();
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

