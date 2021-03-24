using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Reflection;

namespace logger
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            Logger log = new Logger();

            while (exit == false)
            {
                Console.WriteLine("Вид проверки:");
                Console.WriteLine("1. Debug");
                Console.WriteLine("2. Error");
                Console.WriteLine("3. Fatal");
                Console.WriteLine("4. Info");
                Console.WriteLine("5. Warning");
                Console.WriteLine("6. SystemInfo");
                Console.WriteLine("0. Выход");
                int x = Convert.ToInt32(Console.ReadLine());
                switch (x)
                {
                    case 1:
                        Debug(log);
                        break;
                    case 2:
                        Error(log);
                        break;
                    case 3:
                        Fatal(log);
                        break;
                    case 4:
                        Info(log);
                        break;
                    case 5:
                        Warning(log);
                        break;
                    case 6:
                        SystemInfo(log);
                        break;
                    case 0:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Нет такого меню!");
                        break;
                }
                Console.WriteLine("");
            }
        }

        static private void Debug(Logger log)
        {
            Random rand = new Random();
            int a = rand.Next(3);
            try
            {
                switch (a)
                {
                    case 0:
                        log.Debug("Произошел дебаг, ошибок нет");
                        break;
                    case 1:
                        throw new Exception("Debug Exception");
                    case 2:
                        object[] args = { rand.Next(2), rand.Next(2), rand.Next(2), rand.Next(2), rand.Next(2)};
                        log.DebugFormat("Произошел дебаг, ошибок нет, но процессор хочет кое-что сказать: ", args);
                        break;
                }
            }
            catch (Exception e)
            {
                log.Debug("Произошел дебаг, ошибка:", e);
            }
        }

        static private void Error(Logger log)
        {
            try
            {
                Random rand = new Random();
                int a = rand.Next(4);
                switch (a)
                {
                    case 0:
                        log.Error("Произошла ошибка");
                        break;
                    case 1:
                        throw new Exception("Error Exception");
                    case 2:
                        throw new ArgumentNullException();
                    case 3:
                        throw new AbandonedMutexException();
                }
            }
            catch (ArgumentNullException e)
            {
                log.Error(e);
            }
            catch (AbandonedMutexException e)
            {
                log.ErrorUnique("Произошла ошибка:", e);
            }
            catch (Exception e)
            {
                log.Error("Произошла ошибка:", e);
            }
        }
        static private void Fatal(Logger log)
        {
            Random rand = new Random();
            int a = rand.Next(2);
            try
            {
                switch (a)
                {
                    case 0:
                        log.Fatal("Произошла фатальная ошибка");
                        break;
                    case 1:
                        throw new Exception("Fatal Exception");
                }
            }
            catch (Exception e)
            {
                log.Fatal("Произошла фатальная ошибка:", e);
            }
        }
        static private void Info(Logger log)
        {
            Random rand = new Random();
            int a = rand.Next(3);
            try
            {
                switch (a)
                {
                    case 0:
                        log.Debug("Важная информация!");
                        break;
                    case 1:
                        throw new Exception("Info Exception");
                    case 2:
                        object[] args = { rand.Next(2), rand.Next(2), rand.Next(2), rand.Next(2), rand.Next(2) };
                        log.DebugFormat("Информация от процессора: ", args);
                        break;
                }
            }
            catch (Exception e)
            {
                log.Debug("Информация:", e);
            }
        }
        static private void Warning(Logger log)
        {
            Random rand = new Random();
            int a = rand.Next(3);
            try
            {
                switch (a)
                {
                    case 0:
                        log.Warning("Внимание!");
                        break;
                    case 1:
                        throw new Exception("Спасибо за внимание");
                    case 2:
                        log.WarningUnique("Уникальное внимание!");
                        break;
                }
            }
            catch (Exception e)
            {
                log.Warning("Внимание:", e);
            }
        }
        static private void SystemInfo(Logger log)
        {
            Dictionary<object, object> properties = new Dictionary<object, object>();
            properties.Add("CPU", "Good");
            properties.Add("GPU", "Bad");
            log.SystemInfo("Системная информация:", properties);
        }
    }
}
