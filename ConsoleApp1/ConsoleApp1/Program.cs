using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        //Task1 é colocada para executar sem prender a thread principal
        //Task2 é colocada para executar e prende a thread principal através do await
        //Para entender bastar observar a ordem dos prints no console
        static async Task Main(string[] args)
        {
            Task<int> task1 = Task.Run (()=>Task1());
            Console.WriteLine("Chamou Task 1:" + DateTime.Now.ToString());
            int retornoTask2 = await Task.Run(() => Task2());
            Console.WriteLine("Chamou Task 2:" + DateTime.Now.ToString());
            Console.WriteLine("Retorno Task 2:" + retornoTask2.ToString());
            task1.Wait();//aguarda a task1 para mostrar seu resultado
            Console.WriteLine("Retorno Task 1:" + task1.Result);
            Console.ReadLine();
        }



        private static int Task1()
        {
            Thread.Sleep(10000);
            Console.WriteLine("Task 1:" + DateTime.Now.ToString());
            return 1;
        }

        private static int Task2()
        {
            Thread.Sleep(5000);
            Console.WriteLine("Task 2:" + DateTime.Now.ToString());
            return 2;
        }


    }
}
