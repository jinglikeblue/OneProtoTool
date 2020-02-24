using OneProtoTool.Models;

namespace OneProtoTool
{
    /// <summary>
    /// 全局数据
    /// </summary>
    class Global
    {
        public static Global Ins { get; } = new Global();

        /// <summary>
        /// 配置文件地址
        /// </summary>
        public const string CONFIG_PATH = "config.json";

        /// <summary>
        /// 协议Id自增序列
        /// </summary>
        public int msgIdIndex = 1;

        /// <summary>
        /// 配置模块
        /// </summary>
        public ConfigModel config = new ConfigModel();
    }
}
