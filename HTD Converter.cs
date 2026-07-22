using System;
using System.Text;

public class Program
{
    public static void Main()
    {
        int Mode = Select();
        System.Console.Clear();
        System.Console.WriteLine("initializing mode "+Mode);
        System.Console.Clear();
        string result = translate(Mode);
        System.Console.WriteLine("translate: "+result);
    }

    public static int Select()
    {
        bool valuer = false;
        int Number = 0;
        while(!valuer)
        {
            System.Console.WriteLine(new string('=', 45));
            System.Console.WriteLine("Hexadecimal Converter");
            System.Console.WriteLine(new string('=', 45));
            System.Console.WriteLine("\nSelect The Mode\n"+"1. Hexadecimal to Text\n"+"2. Text To Hexadecimal\n"+"3. Hexadecimal to Decimal\n"+"4. Decimal To Hexadecimal");
            Console.Write(" ");
            string option = Console.ReadLine();

            if(int.TryParse(option,out Number))
            {
                valuer = true;
                System.Threading.Thread.Sleep(1500);
            }
            else
            {
                System.Console.WriteLine("Mode don't Exist, Try again");
                valuer = false;
                System.Threading.Thread.Sleep(1500);
            }
        }
        return Number;
    }

    public static string translate(int option)
    {
        System.Console.Clear();
        string result = " ";

        if(option == 1)
        {
            Console.Write("Enter the Hexadecimal code: ");
            string hexa = Console.ReadLine();
            hexa = hexa.Replace(" ","");
            byte[] text = new byte[hexa.Length / 2];
            for (int i = 0; i < text.Length; i++)
            {
                text[i] = Convert.ToByte(hexa.Substring(i * 2, 2), 16);
            }
            result = Encoding.UTF8.GetString(text);
        }
        else if(option == 2)
        {
            Console.Write("Enter the Text: ");
            string textInput = Console.ReadLine();
            byte[] bytes = Encoding.UTF8.GetBytes(textInput);
            result = BitConverter.ToString(bytes).Replace("-", "");
        }
        else if(option == 3)
        {
            Console.Write("Enter the Hexadecimal code: ");
            string hexa = Console.ReadLine();
            result = Convert.ToInt32(hexa, 16).ToString();
        }
        else if(option == 4)
        {
            Console.Write("Enter the Decimal Code: ");
            string numbers = Console.ReadLine();
            int.TryParse(numbers, out int intext);
            result = intext.ToString("X2");
        }
        return result;
    }
}
