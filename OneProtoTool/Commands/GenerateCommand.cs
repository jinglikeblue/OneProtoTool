using OneProtoTool.Models;
using OneProtoTool.ValueObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace OneProtoTool.Commands
{
    /// <summary>
    /// 生成代码的命令
    /// </summary>
    class GenerateCommand
    {
        const string MSG_ID_FILE_NAME = "MsgId.cs";

        List<ProtoInfoVO> _protos;

        FileInfo _protocFile;

        ConfigModel _configModel;

        public GenerateCommand()
        {
            Console.WriteLine(AppContext.BaseDirectory);
        }

        public void Excute()
        {
            Global.Ins.config.Init();
            var configModel = Global.Ins.config;
            _configModel = configModel;
            _protocFile = configModel.GetProtocFile();
            if (false == _protocFile.Exists)
            {
                throw new Exception($"没找到协议处理工具:{_protocFile.FullName}");
            }

            FindProtos(configModel.GetProtosDir());
            GenerateCSharpFiles();
            GenerateMsgIdFile();
        }

        /// <summary>
        /// 找到所有的协议文件,根据文件名称排序
        /// </summary>
        /// <returns></returns>
        void FindProtos(DirectoryInfo di)
        {
            var fiList = di.GetFiles("*.proto", SearchOption.AllDirectories);
            List<ProtoInfoVO> protoInfos = new List<ProtoInfoVO>();
            foreach (var fi in fiList)
            {
                protoInfos.Add(new ProtoInfoVO(fi));
            }
            //按照名称，进行一次排序
            protoInfos.Sort((ProtoInfoVO a, ProtoInfoVO b) =>
            {
                var aChars = a.name.ToCharArray();
                var bChars = b.name.ToCharArray();
                int count = aChars.Length < bChars.Length ? aChars.Length : bChars.Length;
                for (int i = 0; i < count; i++)
                {
                    if (aChars[i] < bChars[i])
                    {
                        return -1;
                    }
                    else if (aChars[i] > bChars[i])
                    {
                        return 1;
                    }
                    //相同则比较下一个字符
                }
                return 0;
            }
            );
            _protos = protoInfos;
        }

        /// <summary>
        /// 生成C#类
        /// </summary>
        void GenerateCSharpFiles()
        {
            var outputDir = _configModel.GetOutputDir();
            if(false == outputDir.Exists)
            {
                outputDir.Create();
            }
            //protoc.exe --csharp_out=csharp  protos\chat.proto
            string cmdParamsFormat = "--csharp_out={0}  {1}\\{2}";
            foreach (var proto in _protos)
            {
                var cmd = string.Format(cmdParamsFormat, outputDir.Name, _configModel.GetProtosDir().Name, proto.name);
                Console.WriteLine(_protocFile.Name + " " + cmd);
                var psi = new ProcessStartInfo(_protocFile.Name, cmd);
                Process.Start(psi);                
            }            
        }

        /// <summary>
        /// 分析协议，生成消息Id类，以及所有使用的类的命名空间
        /// </summary>
        void GenerateMsgIdFile()
        {
            var outputDir = _configModel.GetOutputDir();
            for (int i = 0; i < _protos.Count; i++)
            {
                var proto = _protos[i];
                string fileName;
                string content;
                proto.Analyse(out fileName, out content);
                fileName = Path.Combine(outputDir.Name, fileName);
                File.WriteAllText(fileName, content);
            }
        }
    }
}
