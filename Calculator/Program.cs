using Calculator.Interfaces;
using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new Logger();
            ISummation calculator = new Calculator(logger);
            calculator.Sum();
        }

        public class Logger : ILogger
        {
            void ILogger.Error(string message)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                Console.ResetColor();
            }

            void ILogger.Event(string message)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(message);
                Console.ResetColor();
            }
        }
        public class Calculator : ISummation
        {
            ILogger Logger { get; set; }

            public Calculator(ILogger logger)
            {
                Logger = logger;
            }
            void ISummation.Sum()
            {
                while (true)
                {
                    try
                    {
                        Logger.Event("Введите первое число: ");
                        var firstNum = Convert.ToInt32(Console.ReadLine());
                        Logger.Event("Введите второе число: ");
                        var secondNum = Convert.ToInt32(Console.ReadLine());
                        Logger.Event($"Результат суммирования равен {firstNum + secondNum}");
                        break;
                    }
                    catch (FormatException)
                    {
                        Logger.Error("Ошибка! Введено некорректное значение. Повторите ввод значений");
                    }
                }
            }
        }
    }
}
