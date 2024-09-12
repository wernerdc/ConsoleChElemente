using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChElemente
{
    internal class ChElement : ChZustand
    {
        public ChElement(int ordnungszahl, string name, string symbol, int zustand = 0) : base(zustand)
        {
            Ordnungszahl = ordnungszahl;
            Name = name;
            Symbol = symbol;
        }
        public int Ordnungszahl { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }

        public override string ToString()
        {
            return $"{Symbol}, {Ordnungszahl}, {Name}, {Zustand}";
        }
    }
}
