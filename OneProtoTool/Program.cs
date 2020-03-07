using OneProtoTool.Commands;
using OneProtoTool.Models;
using System;

namespace OneProtoTool
{
    class Program
    {

        static void Main(string[] args)
        {
            if(args.Length > 0)
            {
               new Program(args[0]);
            }
            else
            {
                new Program();
            }
            
#if DEBUG
            Console.ReadKey();
#endif
        }

        public Program(string outputDir = null)
        {
            Global.outputDir = outputDir;
            new GenerateCommand().Excute();
            Console.WriteLine("已完成");
        }
    }
}
