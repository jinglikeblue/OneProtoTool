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
            Console.ReadKey();            
        }

        public Program()
        {
            new GenerateCommand().Excute();
        }
    }
}
