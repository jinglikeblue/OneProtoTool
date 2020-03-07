using Newtonsoft.Json;
using OneProtoTool.ValueObjects;
using System;
using System.IO;

namespace OneProtoTool.Models
{
    class ConfigModel
    {
        ConfigVO _vo;

        public ConfigModel()
        {
            Init();
        }

        public void Init()
        {
            try
            {
                //读取配置文件
                string json = File.ReadAllText(Global.CONFIG_PATH);
                if (!string.IsNullOrEmpty(json))
                {
                    _vo = JsonConvert.DeserializeObject<ConfigVO>(json);
                }
            }
            catch
            {
                Console.WriteLine("已自动生成config.json， 使用方法参考「README.md」");                
            }

            if(null == _vo)
            {
                _vo = new ConfigVO();                
                SaveVO();
            }

            if(null != Global.outputDir)
            {
                _vo.copyPath = Global.outputDir;
                SaveVO();
            }
        }

        void SaveVO()
        {
            string json = JsonConvert.SerializeObject(_vo, Formatting.Indented);
            File.WriteAllText(Global.CONFIG_PATH, json);
        }

        /// <summary>
        /// 配置文件所在目录
        /// </summary>
        public DirectoryInfo directory
        {
            get
            {
                var fi = new FileInfo(Global.CONFIG_PATH);
                return fi.Directory;
            }
        }

        /// <summary>
        /// 得到协议文件的目录
        /// </summary>
        public DirectoryInfo GetProtosDir()
        {
            string dir = Path.Combine(directory.FullName, _vo.protoSourceDir);
            return new DirectoryInfo(dir);
        }

        /// <summary>
        /// 得到代码生成目录1
        /// </summary>
        /// <returns></returns>
        public DirectoryInfo GetOutputDir()
        {
            string dir = Path.Combine(directory.FullName, _vo.csharpOutputDir);
            return new DirectoryInfo(dir);
        }

        /// <summary>
        /// 代码生成器文件
        /// </summary>
        /// <returns></returns>
        public FileInfo GetProtocFile()
        {
            string file = Path.Combine(directory.FullName, _vo.protocFile);
            return new FileInfo(file);
        }

        public ConfigVO GetVO()
        {
            return _vo;
        }


    }
}
