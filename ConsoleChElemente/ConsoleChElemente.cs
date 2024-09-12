using System;

namespace ConsoleChElemente
{
    internal class ConsoleChElemente
    {
        private static Dictionary<int, ChElement> s_elements = new();

        static void Main(string[] args)
        {
            // test data
            s_elements.Add(1, new ChElement(1, "Helium", "H", 3));
            s_elements.Add(4, new ChElement(4, "HmmJa", "HJ", 0));
            s_elements.Add(100, new ChElement(100, "SoilentGreen", "SGr", 1));
            s_elements.Add(10, new ChElement(10, "Glibber", "Gl", 2));

            bool appRunning = true;
            while (appRunning)
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.WriteLine("ConsoleChElemente\n");

                Console.WriteLine("[1] Alle Elemente anzeigen");
                Console.WriteLine("[2] Element mit Ordnungsnummer anzeigen");
                Console.WriteLine("[3] Neues Element hinzufügen");
                Console.WriteLine("[4] Element mit Ordnungsnummer bearbeiten");
                Console.WriteLine("[5] Element mit Ordnungsnummer löschen");
                
                Console.Write("Aktion auswählen: ");
                int option = EnterNumber(1, 5);
                Console.WriteLine();

                switch (option)
                {
                    case 1:
                        ShowAll(); 
                        break;
                    case 2:
                        Console.Write("Ordnungszahl des Elements eingeben: ");
                        ShowElement(EnterNumber(1, 1000)); 
                        break;
                    case 3:
                        AddElement(EnterElement());
                        break;
                    case 4:
                        EditElement(EnterElement());
                        break;
                    case 5:
                        Console.Write("Ordnungszahl des Elements eingeben: ");
                        DelElement(EnterNumber(1, 1000));
                        break;
                    default:
                        break;
                }


                Console.Write("\n\nProgramm beenden (E)? ");
                try
                {
                    string exitApp = Console.ReadLine();
                    if (exitApp.ToLower() == "E")
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

        private static ChElement EnterElement()
        {
            Console.Write("Ordnungszahl des Elements eingeben: ");
            int oZahl = EnterNumber(1, 1000);

            Console.Write("Name des Elements eingeben:         ");
            string name = EnterString();
            
            Console.Write("Symbol des Elements eingeben:       ");
            string symbol = EnterString();
            
            string[] zustände = ChZustand.Zustände;
            for (int i = 0; i < zustände.Length; i++)
            {
                Console.WriteLine($"[{i}] {zustände[i]}");
            }
            Console.Write("Zustand des Elements auswählen:     ");
            int zustand = EnterNumber(0, 3);

            return new ChElement(oZahl, name, symbol, zustand);
        }


        private static void ShowErrortMessage(string msg)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"\n{msg}\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static int EnterNumber(int min, int max)
        {
            int number = -1;
            while (number == -1)
            {
                try
                {
                    number = int.Parse(Console.ReadLine());
                    if (number < min || number > max)
                    {
                        number = -1;
                        ShowErrortMessage($"Ungültige Eingabe! [{min}-{max}]");
                    }
                }
                catch
                {
                    ShowErrortMessage($"Ungültige Eingabe! [{min}-{max}]");
                }
            }
            return number;
        }
        
        private static string EnterString()
        {
            string str = "";
            while (str == "")
            {
                try
                {
                    str = Console.ReadLine();
                    if (str == "" || str == null)
                    {
                        ShowErrortMessage("Ungültige Eingabe! ");
                    }
                }
                catch
                {
                    ShowErrortMessage("Ungültige Eingabe! ");
                }
            }
            return str;
        }

        private static void AddElement(ChElement element)
        {
            if (s_elements.ContainsKey(element.Ordnungszahl))
            {
                Console.WriteLine("Fehler: Element mit dieser Ordnungszahl ist bereits vorhanden!");
                return;     // exit method
            }

            s_elements.Add(element.Ordnungszahl, element);
            Console.WriteLine("Element hinzugefügt.");
        }

        private static void DelElement(int oZahl)
        {
            if (s_elements.ContainsKey(oZahl))
            {
                    s_elements.Remove(oZahl);
                    Console.WriteLine("Element gelöscht.");
            }
            else
            {
                Console.WriteLine("Fehler: Element mit dieser Ordnungszahl nicht gefunden!");
            }
        }

        private static void EditElement(ChElement element)
        {
            if (s_elements.ContainsKey(element.Ordnungszahl))
            {
                s_elements[element.Ordnungszahl] = element;
                Console.WriteLine("Element bearbeitet.");
            }
            else
            {
                Console.WriteLine("Fehler: Element mit dieser Ordnungszahl nicht gefunden!");
            }
        }

        private static void ShowElement(int oZahl)
        {
            if (s_elements.ContainsKey(oZahl))
            {
                WriteElementToConsole(s_elements[oZahl]);
            }
            else
            {
                Console.WriteLine("Fehler: Element mit dieser Ordnungszahl nicht gefunden!");
            }
        }
        
        private static void ShowAll()
        {
            foreach (var item in s_elements.OrderBy(e => e.Key))
            {
                WriteElementToConsole(item.Value);
            }
        }

        private static void WriteElementToConsole(ChElement element)
        {
            Console.ForegroundColor = element.Farbe;
            Console.WriteLine(element.ToString());
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
