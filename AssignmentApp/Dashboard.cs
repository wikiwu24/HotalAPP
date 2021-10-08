using System;
using System.Collections.Generic;
using System.Text;


namespace AssignmentApp
{
    class Dashboard
    {
        public void ShowDashboard()
        {
            Menu m = new Menu();
            int choice = m.PrintMenu(typeof(Options));
            MainScreenFactory factory = new MainScreenFactory();
            MainScreen ms = factory.GetObject(choice);
            if (ms != null)
            {
                ms.Run();
            }

        }
    }
}
