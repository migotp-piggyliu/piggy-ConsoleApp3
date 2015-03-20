using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Dog : PetBase, IPet
    {
        public Dog() : base()
        {
        }

        public string Eat()
        {
            return ("骨頭好好吃");
        }

        public string Play()
        {
            return ("到處聞一聞");
        }

        public string Sleep()
        {
            return ("跑去狗窩");
        }

    }
}
