using System;

namespace ConsoleChElemente
{
    internal class ConsoleChElemente
    {
        private static List<ChElement> s_elemente = new();

        static void Main(string[] args)
        {
            bool appRunning = true;
            while (appRunning)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Clear();
                Console.WriteLine("ConsolePersonOO \n");

                

                Console.Write("\n\nProgramm beenden (e)? ");
                try
                {
                    string exitApp = Console.ReadLine();
                    if (exitApp.ToUpper() == "E")
                    {
                        appRunning = false;
                    }
                }
                catch
                {
                    // no error message, just keep going and repeat the app
                }
            }
        }

        private static void AddElement(int oZahl, string name, string symbol, int zustand)
        {
            foreach (ChElement element in s_elemente)
            {
                if (element.Ordnungszahl == oZahl)
                {
                    Console.WriteLine("Fehler: Element mit dieser Ordnungszahl ist bereits vorhanden!");
                    return;     // exit method
                }
            }

            ChElement newElement = new ChElement(oZahl, name, symbol, zustand);
            s_elemente.Add(newElement);
        }

        private static void DelElement(int oZahl)
        {
            bool foundElement = false;
            foreach (ChElement element in s_elemente)
            {
                if (element.Ordnungszahl == oZahl)
                {
                    foundElement = true;
                    s_elemente.Remove(element);
                    Console.WriteLine("Element Gelöscht.");
                }
            }
            if (!foundElement)
                Console.WriteLine("Fehler: Element mit dieser Ordnungszahl ist nicht vorhanden!");
        }

        private static void EditElement(int oZahl, ChElement element)
        {
            bool foundElement = false;
            foreach (ChElement e in s_elemente)
            {
                if (e.Ordnungszahl == oZahl)
                {
                    foundElement = true;
                    s_elemente.Remove(e);
                    s_elemente.Add(element);
                    Console.WriteLine("Element Bearbeitet");
                }
            }
            if (!foundElement)
                Console.WriteLine("Fehler: Element mit dieser Ordnungszahl ist nicht vorhanden!");
        }
        private static void ShowElement(int oZahl)
        {
            foreach (ChElement element in s_elemente)
            {
                if (element.Ordnungszahl == oZahl)
                {
                    WriteElementToConsole(element);
                }
            }
        }

        private static void ShowAllElements()
        {
            foreach (ChElement element in s_elemente)
            {
                WriteElementToConsole(element);
            }
        }

        private static void WriteElementToConsole(ChElement element)
        {
            Console.ForegroundColor = element.Farbe;
            Console.WriteLine(element.ToString());
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
