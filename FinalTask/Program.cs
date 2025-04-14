using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathAdd;
using MathDivision;
using MathMinus;
using MathMulty;
using MathPower;
using MainInterface;

namespace FinalProjectFromKutsenko
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainInterface.IMathOperation[] operations = new MainInterface.IMathOperation[] {
                new MathAdd.AddOperation(),
                new MathDivision.DivisionOperation(),
                new MathMinus.MinusOperation(),
                new MathMulty.MultyOperation(),
                new MathPower.PowerOperation(),
            };
            while (true)
            {
                Console.WriteLine($"1. Decide task: ");
                Console.WriteLine($"2. Exit: ");
                Console.Write($"Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice > 0 && choice < 3)
                {
                    if (choice == 1)
                    {
                        Console.WriteLine($"");
                        Console.Write($"Write Task: ");
                        string input = Console.ReadLine();
                        var parts = input.Split(' ');
                        double a = double.Parse(parts[0]);
                        string op = parts[1];
                        double b = double.Parse(parts[2]);

                        IMathOperation selectedOp = null;
                        foreach (var o in operations)
                        {
                            if (o.OperatorSymbol == op)
                            {
                                selectedOp = o;
                                break;
                            }
                        }

                        double result = selectedOp.Calculate(a, b);
                        Console.WriteLine($"");
                        Console.WriteLine($"Answer: {result}");
                        Console.WriteLine($"");
                        continue;

                        Console.ReadLine();
                    }
                    if (choice == 2) 
                    {
                        break;
                    }
                }
                else
                {
                    Console.Write($"TypeError. Enter choice again: ");
                    choice = Convert.ToInt32(Console.ReadLine());
                }
            }
        }
    }
}
