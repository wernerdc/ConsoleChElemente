using System;

namespace ConsoleChElemente
{
    internal class ConsoleChElemente
    {
        private static Dictionary<int, ChElement> s_elements = new();

        static void Main(string[] args)
        {
            // test data
            s_elements.Add(1, new ChElement(1, "Wasserstoff", "H", 3));
            s_elements.Add(2, new ChElement(2, "Lithium", "Li", 1));
            s_elements.Add(3, new ChElement(3, "Natrium", "Na", 1));
            s_elements.Add(80, new ChElement(80, "Quecksilber", "Hg", 2));
            s_elements.Add(35, new ChElement(35, "Brom", "Br", 2));
            s_elements.Add(202, new ChElement(202, "HmmJa", "HJ", 0));
            s_elements.Add(180, new ChElement(180, "SoilentGreen", "SG", 1));
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
                
                int option = ReadNumber("Aktion auswählen: ", 1, 5);
                Console.WriteLine();

                switch (option)
                {
                    case 1:
                        ShowAll(); 
                        break;
                    case 2:
                        ShowElement(ReadNumber("Ordnungszahl des Elements eingeben: ", 1, 1000)); 
                        break;
                    case 3:
                        AddElement(ReadElement(false));
                        break;
                    case 4:
                        EditElement(ReadElement(true));
                        break;
                    case 5:
                        DelElement(ReadNumber("Ordnungszahl des Elements eingeben: ", 1, 1000));
                        break;
                    default:
                        break;
                }


                Console.Write("\n\nProgramm beenden (e)? ");
                try
                {
                    string exitApp = Console.ReadLine();
                    if (exitApp.ToLower() == "e")
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

        private static ChElement ReadElement(bool needExistingElement)
        {
            int oZahl = 0;
            while (oZahl == 0)
            {
                oZahl = ReadNumber("Ordnungszahl des Elements eingeben: ", 1, 1000);
                if (needExistingElement)
                {
                    if (!s_elements.ContainsKey(oZahl))
                    {
                        ShowErrorMessage($"Fehler: Element mit Ordnungszahl {oZahl} nicht gefunden!");
                        oZahl = 0;
                    }
                    else
                    {
                        ShowElement(oZahl);
                    }
                }
                else
                {
                    if (s_elements.ContainsKey(oZahl))
                    {
                        ShowErrorMessage($"Fehler: Element mit Ordnungszahl {oZahl} existiert bereits!");
                        ShowElement(oZahl);
                        oZahl = 0;
                    }
                }
            }

            string name = ReadString("Name des Elements eingeben:         ");
            string symbol = ReadString("Symbol des Elements eingeben:       ");
            
            string[] zustände = ChZustand.Zustände;
            for (int i = 0; i < zustände.Length; i++)
            {
                Console.WriteLine($"[{i}] {zustände[i]}");
            }
            int zustand = ReadNumber("Zustand des Elements auswählen:     ", 0, 3);

            return new ChElement(oZahl, name, symbol, zustand);
        }

        private static int ReadNumber(string msg, int min, int max)
        {
            int number = -1;
            while (number == -1)
            {
                try
                {
                    Console.Write(msg);
                    number = int.Parse(Console.ReadLine());
                    if ((number < min) || (number > max))
                    {
                        number = -1;
                        ShowErrorMessage($"Ungültige Eingabe! [{min}-{max}]");
                    }
                }
                catch
                {
                    ShowErrorMessage($"Ungültige Eingabe! [{min}-{max}]");
                }
            }
            return number;
        }
        
        private static string ReadString(string msg)
        {
            string str = "";
            while (str == "")
            {
                try
                {
                    Console.Write(msg);
                    str = Console.ReadLine();
                    if ((str == "") || (str == null))
                    {
                        ShowErrorMessage("Ungültige Eingabe! ");
                    }
                }
                catch
                {
                    ShowErrorMessage("Ungültige Eingabe! ");
                }
            }
            return str;
        }

        private static void AddElement(ChElement element)
        {
            if (s_elements.ContainsKey(element.Ordnungszahl))
            {
                ShowErrorMessage("Fehler: Element mit dieser Ordnungszahl ist bereits vorhanden!");
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
                ShowErrorMessage("Fehler: Element mit dieser Ordnungszahl nicht gefunden!");
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
                ShowErrorMessage("Fehler: Element mit dieser Ordnungszahl nicht gefunden!");
            }
        }

        private static void ShowElement(int oZahl)
        {
            if (s_elements.ContainsKey(oZahl))
            {
                WriteToConsole(s_elements[oZahl]);
            }
            else
            {
                ShowErrorMessage("Fehler: Element mit dieser Ordnungszahl nicht gefunden!");
            }
        }
        
        private static void ShowAll()
        {
            foreach (var item in s_elements.OrderBy(e => e.Key))
            {
                WriteToConsole(item.Value);
            }
        }

        private static void ShowErrorMessage(string msg)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"\n{msg}\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void WriteToConsole(ChElement element)
        {
            Console.ForegroundColor = element.Farbe;
            Console.WriteLine(element.ToString());
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
