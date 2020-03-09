using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OneProtoTool.ValueObjects
{
    class ProtoInfoModel
    {
        class ProtoDesc
        {
            /// <summary>
            /// 命名空间
            /// </summary>
            public string namespaceName;

            /// <summary>
            /// 类名
            /// </summary>
            public string className;

            /// <summary>
            /// 协议注释
            /// </summary>
            public List<string> protoExplain = new List<string>();

            /// <summary>
            /// 协议
            /// </summary>
            public List<string> protoName = new List<string>();
        }

        static string CLASS_TEMPLATE;
        static string CLASS_FIELD_TEMPLATE;

        public FileInfo fi { get; private set; }

        public string name;

        string _outputFileName;

        ProtoDesc _desc;

        public ProtoInfoModel(FileInfo fi)
        {
            this.fi = fi;
            name = fi.Name;            
        }

        /// <summary>
        /// 分析出数据
        /// </summary>
        public void Analyse(out string fileName, out string content)
        {
            var msgName = Path.GetFileNameWithoutExtension(fi.Name);
            _outputFileName = fileName = msgName.Substring(0, 1).ToUpper() + msgName.Substring(1) + "MsgId.cs";

            AnalyseProtoFile();

            if (_desc.protoName.Count == 0)
            {
                content = null;
            }
            else
            {
                content = GenerateContent();
            }
        }

        void AnalyseProtoFile()
        {
            ProtoDesc desc = new ProtoDesc();
            desc.className = Path.GetFileNameWithoutExtension(_outputFileName);
            string[] lines =File.ReadAllLines(fi.FullName);
            for(int i = 0; i < lines.Length; i++)
            {
                var tempLine = lines[i].Trim();
                if(tempLine.StartsWith("package"))
                {
                    desc.namespaceName = tempLine.Substring(7, tempLine.IndexOf(";") - 7).Trim();
                }
                else
                {
                    string explain;
                    string name;
                    if(TryGetProto(i, lines,  out name))
                    {
                        //是个协议，往上找他的注释
                        explain = FindExplain(i, lines);

                        desc.protoName.Add(name);
                        desc.protoExplain.Add(explain);
                    }
                }
            }
            _desc = desc;
        }

        bool TryGetProto(int idx, string[] lines, out string name)
        {
            var tempLine = lines[idx].Trim();
            var messageIdx = tempLine.IndexOf("message");
            if (messageIdx > -1)
            {
                var openBraceIdx = tempLine.IndexOf("{");                
                if (openBraceIdx > -1)
                {
                    name = tempLine.Substring(7, openBraceIdx - 7);
                    return true;
                }
                else if(lines[idx + 1].Trim().StartsWith("{"))
                {
                    name = tempLine.Substring(7);
                    return true;
                }
            }
            name = null;
            return false;
        }

        string FindExplain(int idx, string[] lines)
        {
            StringBuilder sb = new StringBuilder();            

            while(--idx > -1)
            {
                var temp = lines[idx];
                if (temp.Trim().StartsWith("//"))
                {
                    //是注释
                    sb.Insert(0, lines[idx]);
                }
                else
                {
                    break;
                }
            }

            return sb.ToString(); ;
        }

        string GenerateContent()
        {
            if(null == CLASS_TEMPLATE)
            {
                string[] splits = new string[] { "-split-" };
                var template = File.ReadAllText("template.txt");
                var templates = template.Split(splits, StringSplitOptions.RemoveEmptyEntries);
                CLASS_TEMPLATE = templates[0];
                CLASS_FIELD_TEMPLATE = templates[1];
            }
            var output = CLASS_TEMPLATE.Replace("[namespace_name]", _desc.namespaceName);
            output = output.Replace("[class_name]", _desc.className);
            output = output.Replace("[msg_field]", GenerateMsgFields());
            return output;               
        }

        string GenerateMsgFields()
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < _desc.protoName.Count; i++)
            {
                var name = _desc.protoName[i];
                var explain = _desc.protoExplain[i];
                var field = CLASS_FIELD_TEMPLATE.Replace("[proto_explain]", explain);
                field = field.Replace("[proto_name]", name);
                field = field.Replace("[msg_id]", Global.NewMsgId().ToString());
                sb.Append(field);                
            }
            return sb.ToString();
        }
    }
}
