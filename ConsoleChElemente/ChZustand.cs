using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChElemente
{
    internal class ChZustand
    {
        private static string[] s_zustände = [ "Unbekannt", "Feststoff", "Flüssigkeit", "Gas" ];
        private static ConsoleColor[] s_farben = [ ConsoleColor.Gray, ConsoleColor.Black, ConsoleColor.DarkBlue, ConsoleColor.DarkRed ];
        
        public ChZustand(int nZustand)
        {
            Zustand = s_zustände[nZustand];
            Farbe = s_farben[nZustand];
        }
        
        public string Zustand { get; }
        public ConsoleColor Farbe { get; }
        public static string[] Zustände
        {
            get { return s_zustände; }
        }
    }
}
