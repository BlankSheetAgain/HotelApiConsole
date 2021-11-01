using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_API
{
    class Menu
    {
        private int _selected;
        private string[] _sections;
        private string _title;
        public Menu (string [] sections_in, string title_in)
        {
            _selected = 0;
            _sections = sections_in;
            _title = title_in;
        }
        private void DisplayItems ()
        {
            Console.WriteLine(_title);

            for(int i=0; i<_sections.Length; i++)
            {
                if (_selected == i)
                {
                    
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write(">");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"{_sections[i]}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($" {_sections[i]}");
                }
            }
        }
        public int Enter()
        {
            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                DisplayItems();
                key = Console.ReadKey(true);
                if (key.Key==ConsoleKey.UpArrow)
                {
                    _selected--;
                    if (_selected <0)
                    {
                        _selected = _sections.Length - 1;
                    }
                }
                else if (key.Key==ConsoleKey.DownArrow)
                {
                    _selected++;
                    if (_selected>_sections.Length-1)
                    {
                        _selected = 0;
                    }
                }

            } while (key.Key != ConsoleKey.Enter);
            return _selected;
        }
    }
}
