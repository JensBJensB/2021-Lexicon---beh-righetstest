/*
  Under den här tiden passade jag på att samtidigt läsa en bok från 2015 jag har om C#
    Så koden förfinas lite ju längre ned man kommer hoppas jag. Tror jag lyckats radera alla svenska
    variablnamn etc. med. Fick ett svagt minne av naming policy och input validation desto längre
    jag kom i boken men detta får vara det jag lämnar in för den här gången. Ser fram emot
    att få lära mig mer
   Trevlig helg!
  M.v.h. Jens Blomsterwall

 */

using System;
using System.Collections.Generic;
using System.IO;

namespace StringManipulation
{
    class Program

    {
        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }
        private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\nMeny");
            Console.WriteLine("====" + Environment.NewLine);
            Console.WriteLine("[1] Skrivl ut \"Hello world\" på skärmen");
            Console.WriteLine("[2] Namn & ålder");
            Console.WriteLine("[3] Byt färg på menytexten");
            Console.WriteLine("[4] Skriv ut dagens datum");
            Console.WriteLine("[5] Vilket tal är störst");
            Console.WriteLine("[6] Gissa talet");
            Console.WriteLine("[7] Spara input till fil");
            Console.WriteLine("[8] Läs input från fil");
            Console.WriteLine("[9] Decimaltal");
            Console.WriteLine("[10] Multiplikationstabell");
            Console.WriteLine("[11] Sortera array");
            Console.WriteLine("[12] Palindrom eller ej");
            Console.WriteLine("[13] Fyll i siffror");
            Console.WriteLine("[14] Sortera array i jämna/udda tal");
            Console.WriteLine("[15] Addera talen i array");
            Console.WriteLine("[16] Rollspel");
            Console.WriteLine("\n[0] Avsluta");
            Console.Write("\r\nAnge ett val: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Hello World");
//                  Console.ReadKey();
                    return true;
                case "2":
                    PersonalInfo();
                    Console.ReadKey();
                    return true;
                case "3":
                    TextColors();
                    Console.ReadKey();
                    return true;
                case "4":
                    Datum();
                    Console.ReadKey();
                    return true;
                case "5":
                    LargestNumber();
                    Console.ReadKey();
                    return true;
                case "6":
                    GuessNumber();
                    Console.ReadKey();
                    return true;
                case "7":
                    CreateTextFile();
                    Console.ReadKey();
                    return true;
                case "8":
                    ReadTextFile();
                    Console.ReadKey();
                    return true;
                case "9":
                    DecimalNumber();
                    Console.ReadKey();
                    return true;
                case "10":
                    MultiplicationTablel();
                    Console.ReadKey();
                    return true;
                case "11":
                    RandomArraySort();
                    Console.ReadKey();
                    return true;
                case "12":
                    Palindrome();
                    Console.ReadKey();
                    return true;
                case "13":
                    FillNumbers();
                    Console.ReadKey();
                    return true;
                case "14":
                    EvenOddNumbers();
                    Console.ReadKey();
                    return true;
                case "15":
                    ArraySum();
                    Console.ReadKey();
                    return true;
                case "16":
                    RolePlay();
                    Console.ReadKey();
                    return true;
                case "0":
                    Console.ReadKey();
                    return false;
                default:
                    return true;
            }
        }
        private static void PersonalInfo()
        {
            Console.Clear();
            string name;
            int age;
            Console.Write("För och efternamn: ");
            name = Console.ReadLine();
            Console.Write("Ålder: ");
            age = int.Parse(Console.ReadLine());
            Console.WriteLine("Du heter {0} och är {1} år gammal", name, age);
        }
        // Fixa input check i mån av tid
        private static void TextColors()
        {
            Console.Clear();
            Console.WriteLine("Välj textfärg på menyn");
            Console.WriteLine("[1] Röd");
            Console.WriteLine("[2] Blå");
            Console.WriteLine("[3] Default");
            string input = Console.ReadLine();
            int val = int.Parse(input);
            {
                if (val != 1)
                {
                    if (val == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else if (val == 3)
                    {
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
            }
        }
        private static void Datum()
        {
            string date = DateTime.Now.ToString("d");
            Console.WriteLine(date);
        }
        private static void LargestNumber()
        {
            // Lägg till en regex i mån av tid.
            Console.Clear();
            Console.Write("Skriv in två tal (mellanslag emellan): ");
            string[] tal = Console.ReadLine().Split();
            double a = double.Parse(tal[0]);
            double b = double.Parse(tal[1]);
            if (a == b)
            {
                Console.WriteLine("talen är lika stora");
            }
            else if (a > b)
            {
                Console.WriteLine(a + " är störst");
            }
            else
            {
                Console.WriteLine(b + " är störst");
            }
        }
        private static void GuessNumber()
        {
            int rand = new Random().Next(1, 101);
            int guessCount = 0;

            {
                Console.Clear();
                Console.WriteLine("Gissa ett heltal (1-100)");

                while (true)
                {
                    Console.Write("\r\nGissa: ");
                    string input = Console.ReadLine();

                    // säkerställ att input är ett heltal
                    if (int.TryParse(input, out int guessedNumber))
                    {
                        guessCount++;

                        if (guessedNumber == rand)
                        {
                            Console.WriteLine("Rätt gissat !! Du behövde {0} gissningar.", guessCount);
                            break;
                        }
                        else if (guessedNumber >= 1 && guessedNumber <= 100) // Om talet är inom 1-100 utför if-satsen 
                        {
                            if (guessedNumber < rand)
                            {
                                Console.Write("Talet är högre än {0}, du har gjort {1} gissningar", guessedNumber, guessCount);
                            }
                            else
                            {
                                Console.Write("Talet är lägre än {0}, du har gjort {1} gissningar", guessedNumber, guessCount);
                            }
                        }

                    }
                }
            }
        }
        private static void CreateTextFile()
        {
            Console.Clear();
            Console.WriteLine("Skriv en rad som sparas i en fil på ditt skrivbord");
            string input = Console.ReadLine();
            try
            {
                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\textfil.txt";
                using (var textStream = new StreamWriter(filePath))
                {
                    textStream.WriteLine(input);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
        private static void ReadTextFile()
        {
            try
            {
                using (var textStream = new StreamReader("D:\\textfil.txt"))
                {
                    Console.WriteLine(textStream.ReadToEnd());
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Problem att läsa filen:");
                Console.WriteLine(e.Message);
            }
        }
        private static void DecimalNumber()
        {
            Console.Clear();
            while (true)
            {
                Console.Write("Skriv ett decimaltal: ");
                string input = Console.ReadLine();
                if (System.Text.RegularExpressions.Regex.IsMatch(input, @"[0-9]+\,+[0-9]+") && (float.TryParse(input, out float number))) // input check: tal med decimaltecken + går att konvertera till decimal
                {
                    Console.WriteLine("Rotern ur " + number + " är " + Math.Sqrt(number));
                    Console.WriteLine(number + " upphöjt i 2 är " + Math.Pow(number, 2));
                    Console.WriteLine(number + " upphöjt i 10 är " + Math.Pow(number, 10));
                    break;
                }

            }
        }
        private static void MultiplicationTablel()
        {
            int a, b;

            Console.Clear();
            Console.Write("Välj multiplikationstabell (1-10): ");
            b = Convert.ToInt32(Console.ReadLine());
            for (a = 1; a <= 10; a++)
            {
                Console.Write("{0}*{1}={2}\t", b, a, b * a);
            }
        }
        private static void EvenOddNumbers() 
        {
            Console.Clear();
            Console.Write("Skriv några heltal separerade med kommatecken: ");
            string input = Console.ReadLine();
            string[] s = input.Split(',');
            int[] intArray = new int[s.Length];
            List<int> oddNumbers = new List<int>();
            List<int> evenNumbers = new List<int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (int.TryParse(s[i], out int number))
                {
                    intArray[i] = number;
                }
            }
            for (int i = 0; i < intArray.Length; i++)
            {
                if (intArray[i] % 2 == 0) // plocka ut de jämna talen
                {
                    evenNumbers.Add(intArray[i]);
                }
                else
                {
                    oddNumbers.Add(intArray[i]);
                }
            }

            oddNumbers.Sort();
            evenNumbers.Sort();

            Console.WriteLine();
            Console.WriteLine("Udda tal:");
            foreach (int oddNumber in oddNumbers)
            {
                Console.WriteLine(oddNumber);
            }
            Console.WriteLine("Jämna tal:");
            foreach (int evenNumber in evenNumbers)
            {
                Console.WriteLine(evenNumber);
            }

        }

        private static void Palindrome()
        {
            string inputString = Console.ReadLine();
            string reversString = "";

            // reverse the string
            for (int i = inputString.Length - 1; i >= 0; i--)
            {
                reversString += inputString[i].ToString();
            }
            if (inputString == reversString)
            {
                Console.WriteLine(inputString + " är ett Palindrom");
            }
            else
            {
                Console.WriteLine(inputString + " är INTE ett Palindrom");
            }
        }
        private static void RandomArraySort()
        {
            Console.Clear();
            int[] randomNumber = new int[9];
            Random RandomNumber = new Random();


            for (int i = 0; i < 9; i++)
            {
                randomNumber[i] = RandomNumber.Next(11, 100);
            }



            foreach (int a in randomNumber)
            {
                Console.WriteLine("Osoterat {0}", a);
            }
            Console.WriteLine();
            Array.Sort(randomNumber);
            foreach (int a in randomNumber)
            {
                Console.WriteLine("Sorterat {0}", a);
            }
        }
        private static void FillNumbers()
        {

            Console.Clear();
            Console.Write("Skriv in två tal (mellanslag emellan): ");
            string[] number = Console.ReadLine().Split();
            int a = int.Parse(number[0]);
            int b = int.Parse(number[1]);

            if (a > b)
            {
                int i = b;
                while (i < a + 1)
                {
                    Console.WriteLine(i);
                    i++;
                }
            }
            if (b >= a)
            {
                int i = a;
                while (i < b + 1)
                {
                    Console.WriteLine(i);
                    i++;
                }

            }
        }
        private static void ArraySum()
        {
            Console.Clear();
            Console.Write("Skriv några heltal separerade med kommatecken: ");
            string input = Console.ReadLine();
            string[] s = input.Split(',');
            int sum = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (int.TryParse(s[i], out int number))
                {
                    sum += number;
                }
            }
            Console.Write("Sum {0}\n", sum.ToString());
        }

        private static void RolePlay()
        {
            Console.Clear();
            Console.Write("Ange ditt namn: ");

            Player you = new Player(Console.ReadLine());

            Console.Write("Ange din motståndares namn: ");

            Player opponent = new Player(Console.ReadLine());

            Console.WriteLine("\nDu: {0}, Hälsa: {1} Styrka: {2} Tur: {3}", you.name, you.health, you.strength, you.luck);
            Console.WriteLine("Motståndare: {0}, Hälsa: {1} Styrka: {2} Tur: {3}", opponent.name, opponent.health, opponent.strength, opponent.luck);
        }

        public class Player
        {
            public string name;
            public int health;
            public int strength;
            public int luck;

            public Player(string name)
            {
                this.name = name;
                this.health = new Random().Next(1, 100);
                this.strength = new Random().Next(1, 100);
                this.luck = new Random().Next(1, 100);
            }            
        }
    }
}




