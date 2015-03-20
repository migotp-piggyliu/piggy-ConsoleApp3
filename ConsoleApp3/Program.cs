using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using Nancy.TinyIoc;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            /**** multi-interfaces for single instance sample
            public class MyThing : IFoo, IBar
            {
             }
            ctx.Register<IFoo, MyThing>();
            ctx.Register<IBar>((c, p) => c.Resolve<IFoo>() as IBar);
             ****/

            // multi-classes for single interface
            var ctx = TinyIoCContainer.Current;
            ctx.Register<IPet, Dog>("dog").AsMultiInstance();
            ctx.Register<IPet, Cat>("cat").AsMultiInstance();

            int petNo = 0;
            List<IPet> list = new List<IPet>();
            while (true)
            {
                IPet pet = null;
                Console.WriteLine("主人:我來了!");
                Console.Write("你要找(dog/cat)?: ");
                string petType = Console.ReadLine();
                try
                {
                    pet = ctx.Resolve<IPet>(petType.ToLower());
                }
                catch { };
                if (pet == null) break;

                list.Add(pet);
                petNo++;
                pet.Name = "Pet " + petNo + "號";
                Console.WriteLine(pet.GetType().ToString() + " Name:" + pet.Name);

                bool flag = true;
                while (flag)
                {
                    Console.Write("下指令(eat/play/sleep/bye): ");
                    string cmd = Console.ReadLine();
                    if (string.Compare(cmd, "eat", true) == 0)
                        Console.WriteLine(pet.Eat());
                    else if (string.Compare(cmd, "play", true) == 0)
                        Console.WriteLine(pet.Play());
                    else if (string.Compare(cmd, "sleep", true) == 0)
                        Console.WriteLine(pet.Sleep());
                    else
                    {
                        flag = false;
                        Console.WriteLine("沒事，我走了!");
                    }
                }
            }

        }
    }
}
