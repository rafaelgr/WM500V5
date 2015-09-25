using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM500V5Lib;

namespace WM500V5Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Introduzca comando:");
            string cmd = Console.ReadLine();
            while (cmd != "exit")
            {
                UsbCom usbCom = new UsbCom();
                Input input = new Input();
                input.command = cmd;
                Console.WriteLine(cmd + " -->");
                Task<object> o = usbCom.Invoke(input);
                Console.WriteLine(o.Result);
                Console.Write("Introduzca comando:");
                cmd = Console.ReadLine();
            }
        }
    }
}
