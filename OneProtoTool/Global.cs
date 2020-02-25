using OneProtoTool.Models;

namespace OneProtoTool
{
    /// <summary>
    /// 全局数据
    /// </summary>
    class Global
    {
        /// <summary>
        /// 协议Id自增序列
        /// </summary>
        static int _msgIdIndex = 1;

        public static int NewMsgId()
        {            
            return _msgIdIndex++;
        }

        public static Global Ins { get; } = new Global();

        /// <summary>
        /// 配置文件地址
        /// </summary>
        public const string CONFIG_PATH = "config.json";        

        /// <summary>
        /// 配置模块
        /// </summary>
        public readonly ConfigModel config = new ConfigModel();
    }
}
