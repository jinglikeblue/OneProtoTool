namespace OneProtoTool.ValueObjects
{
    /// <summary>
    /// 配置类（参看config.json）
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

        /// <summary>
        /// 如果不为空，则生成完成后，代码拷贝到该路径(绝对路径)
        /// </summary>
        public string copyPath = null;
    }
}
