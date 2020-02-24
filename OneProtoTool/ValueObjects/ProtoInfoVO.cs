using System.IO;

namespace OneProtoTool.ValueObjects
{
    class ProtoInfoVO
    {
        public FileInfo fi { get; private set; }

        public string name;

        public ProtoInfoVO(FileInfo fi)
        {
            this.fi = fi;
            name = fi.Name;
            Analyse();
        }

        /// <summary>
        /// 分析出数据
        /// </summary>
        public void Analyse()
        {

        }
    }
}
