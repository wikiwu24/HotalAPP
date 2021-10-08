using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentApp
{
    class MainScreenFactory
    {
        public MainScreen GetObject(int choice)
        {
            switch (choice)
            {
                case (int)Options.Customer:
                    return new ManagementCustomer();
                    
                case (int)Options.Service:
                    return new ManageService();
                case (int)Options.Room:
                    return new ManageRoom();
                         
                case (int)Options.RoomType:
                    return new  ManageRoomType();
                   
            }
            return null;
        }
    }
}
