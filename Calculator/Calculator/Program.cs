using System;

namespace Calculator
{
    class Program
    {
        public delegate int IntOperation(int a, int b);
        static void Main(string[] args)
        {
            while (true)
            {
                int a = 0;
                int b = 0;
                string op = "";
                string anotherOp = "";

                while (true)
                {
                    Console.Write("Fill in int 1: ");
                    try
                    {
                        a = Int32.Parse(Console.ReadLine());
                        break;
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                while (true)
                {
                    Console.Write("Fill in int 2: ");
                    try
                    {
                        b = Int32.Parse(Console.ReadLine());
                        break;
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                while (true)
                {
                    Console.WriteLine("Possible operations: ADD, SUB, MUL, DIV, POW, MOD, ROO");
                    Console.Write("Fill in operation: ");
                    op = Console.ReadLine();
                    bool breakWhile = true;

                    switch (op)
                    {
                        case "ADD":
                            PrintOperation(Addition, a, b);
                            break;
                        case "SUB":
                            PrintOperation(Subtraction, a, b);
                            break;
                        case "MUL":
                            PrintOperation(Multiplication, a, b);
                            break;
                        case "DIV":
                            PrintOperation(Division, a, b);
                            break;
                        case "POW":
                            PrintOperation(Power, a, b);
                            break;
                        case "MOD":
                            PrintOperation(Modulo, a, b);
                            break;
                        case "ROO":
                            PrintOperation(Root, a, b);
                            break;
                        default:
                            Console.WriteLine("Not a correct operation.");
                            breakWhile = false;
                            break;
                    }

                    if (breakWhile)
                        break;
                }
                Console.WriteLine("");
                Console.WriteLine("Type 'y' for another operation.");
                anotherOp = Console.ReadLine();

                Console.WriteLine("+--------------------------------------------------------------------------------------+");

                if (anotherOp != "y")
                    break;
            }
            Console.WriteLine("Bye!");
            Console.ReadLine();
        }
        static void PrintToConsole(IntOperation io)
        {
            if (io == Addition)
            {
                Console.Write("Add ");
            }
            if (io == Subtraction)
            {
                Console.Write("Sub ");
            }
            if (io == Multiplication)
            {
                Console.Write("Mul ");
            }
            if (io == Division)
            {
                Console.Write("Div ");
            }
            if (io == Power)
            {
                Console.Write("Pow ");
            }
            if (io == Modulo)
            {
                Console.Write("Mod ");
            }
            if (io == Root)
            {
                Console.Write("Roo ");
            }
        }
        static void PrintOperation(IntOperation io, int a, int b)
        {
            PrintToConsole(io);
            if (io == Addition)
            {
                Console.WriteLine(a + " + " + b + ": " + Addition(a, b));
            }
            if (io == Subtraction)
            {
                Console.WriteLine(a + " - " + b + ": " + Subtraction(a, b));
            }
            if (io == Multiplication)
            {
                Console.WriteLine(a + " * " + b + ": " + Multiplication(a, b));
            }
            if (io == Division)
            {
                Console.WriteLine(a + " / " + b + ": " + Division(a, b));
            }
            if (io == Power)
            {
                Console.WriteLine(a + " ^ " + b + ": " + Power(a, b));
            }
            if (io == Modulo)
            {
                Console.WriteLine(a + " % " + b + ": " + Modulo(a, b));
            }
            if (io == Root)
            {
                Console.WriteLine(a + " \u221A " + b + ": " + Root(a, b));
            }
        }
        static int Addition(int a, int b)
        {
            return a + b;
        }
        static int Subtraction(int a, int b)
        {
            return a - b;
        }
        static int Multiplication(int a, int b)
        {
            int c = 0;
            for (int i = 0; i < b; i++)
                c = Addition(c, a);

            return c;
        }
        static int Division(int a, int b)
        {
            int n = 0;
            while (Subtraction(a, b) >= 0)
            {
                if (b == 0)
                {
                    Console.Write("ERROR! division by zero, outputting max int value ");
                    return 2147483647;
                }
                a = Subtraction(a, b);
                n++;
            }
            return n;
        }
        static int Power(int a, int b)
        {
            int c = 1;
            for (int i = 0; i < b; i++)
            {
                c = Multiplication(c, a);
            }
            return c;
        }
        static int Modulo(int a, int b)
        {
            int c = Division(a, b);
            return Subtraction(a, (Multiplication(b, c)));
        }
        static int Root(int a, int b)
        {
            int c = 0;
            while (Power(c, b) != a)
            {
                if (c >= a)
                {
                    Console.Write("ERROR! no root found ");
                    return 0;
                }
                c++;
            }
            return c;
        }

    }
}
