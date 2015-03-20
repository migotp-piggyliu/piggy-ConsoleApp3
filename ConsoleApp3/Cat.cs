using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Cat : PetBase, IPet
    {
        public Cat() : base()
        {
        }

        public string Eat()
        {
            return ("我要魚罐罐");
        }

        public string Play()
        {
            return ("到處抓一抓");
        }

        public string Sleep()
        {
            return ("躲去紙箱");
        }

    }
}
