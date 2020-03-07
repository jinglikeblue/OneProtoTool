using OneProtoTool.Commands;
using OneProtoTool.Models;
using System;

namespace OneProtoTool
{
    class Program
    {

        static void Main(string[] args)
        {
            new Program();
#if DEBUG
            Console.ReadKey();
#endif
        }

        public Program()
        {
            new GenerateCommand().Excute();
            Console.WriteLine("已完成");
        }
    }
}
