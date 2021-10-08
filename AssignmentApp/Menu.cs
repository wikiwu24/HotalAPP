using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentApp
{
    public class Menu
    {
        public int PrintMenu(Type t)
        {
            string[] names = Enum.GetNames(t);
            int[] values = (int[])Enum.GetValues(t);
            int length = names.Length;
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine($"Press {values[i]} for {names[i]}");
            }
            return Convert.ToInt32(Console.ReadLine());

        }
    }
}
