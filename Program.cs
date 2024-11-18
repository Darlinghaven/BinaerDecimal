namespace BinærDecimal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                Console.WriteLine("Velkommen til den 32-bit binære kodeomformer! \n" +
                "1. Konverter binær til decimal \n" +
                "2. Konverter decimal til binær \n" +
                "Vælg en mulighed (1/2):\n");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.WriteLine("");
                    Console.Write("Indtast en 32-bit binær talgruppe (fx 10111011.01001011.10101010.01010101): ");
                    string binaryInput = Console.ReadLine();
                    string decimalResult = Binary32ToDecimal(binaryInput);
                    Console.WriteLine($"Det binære tal {binaryInput} er {decimalResult} i decimal.");
                    Console.WriteLine(" \n" +
                        "=============== Press enter to start again =============== \n" +
                        "");
                }
                else if (choice == "2")
                {
                    Console.WriteLine("");
                    Console.Write("Indtast en 32-bit decimal talgruppe (fx 187.75.170.85): ");
                    string decimalInput = Console.ReadLine();
                    string binaryResult = Decimal32ToBinary(decimalInput);
                    Console.WriteLine($"Decimal tallet {decimalInput} er {binaryResult} i binær.");
                    Console.WriteLine(" \n" +
                        "=============== Press enter to start again =============== \n" +
                        "");
                }
                else
                {
                    Console.WriteLine("Ugyldigt valg.");
                    Console.WriteLine(" \n" +
                        "=============== Press enter to start again =============== \n" +
                        "");
                }
                Console.ReadKey();
            }
        }
        static string Binary32ToDecimal(string binary)
        {
            string[] binaryGroups = binary.Split('.'); 
            string decimalResult = "";

            foreach (string group in binaryGroups)
            {
                int decimalValue = BinaryToDecimal(group); 
                decimalResult += decimalValue + ".";
            }

            return decimalResult.TrimEnd('.'); 
        }

        static string Decimal32ToBinary(string decimalInput)
        {
            string[] decimalGroups = decimalInput.Split('.'); 
            string binaryResult = "";

            foreach (string group in decimalGroups)
            {
                int decimalValue = int.Parse(group); 
                string binaryValue = DecimalToBinary(decimalValue); 
                binaryResult += binaryValue + ".";
            }

            return binaryResult.TrimEnd('.'); 
        }

        static int BinaryToDecimal(string binary)
        {
            int decimalValue = 0;
            int position = 0;

            for (int i = binary.Length - 1; i >= 0; i--)
            {
                if (binary[i] == '1')
                {
                    decimalValue += (int)Math.Pow(2, position);
                }
                position++;
            }
            return decimalValue;
        }

        static string DecimalToBinary(int decimalNumber)
        {
            string binaryValue = "";

            while (decimalNumber > 0)
            {
                binaryValue = (decimalNumber % 2) + binaryValue;
                decimalNumber /= 2;
            }

            return binaryValue.PadLeft(8, '0');
        }
    }
}
