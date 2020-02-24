using System;
using System.Collections.Generic;
using System.Text;

namespace OneProtoTool.ValueObjects
{
    /// <summary>
    /// 配置类
    /// </summary>
    class ConfigVO
    {
        /// <summary>
        /// 协议目录
        /// </summary>
        public string protoSourceDir = "protos";

        /// <summary>
        /// C#代码输出目录
        /// </summary>
        public string csharpOutputDir = "csharp";

        /// <summary>
        /// protoc.exe文件路径
        /// </summary>
        public string protocFile = "protoc.exe";
        
    }
}
