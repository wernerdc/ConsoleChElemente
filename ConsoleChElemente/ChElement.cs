using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChElemente
{
    internal class ChElement : ChZustand
    {
        public ChElement(int ordnungszahl, string name, string symbol, int zustand) : base(zustand)
        {
            Ordnungszahl = ordnungszahl;
            Name = name;
            Symbol = symbol;
        }
        public int Ordnungszahl { get; }
        public string Name { get; }
        public string Symbol { get; }

        public override string ToString()
        {
            return $" {Ordnungszahl,3} {Symbol,-2} {Name,-20} {Zustand}";
        }
    }
}
