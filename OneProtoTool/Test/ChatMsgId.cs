namespace Msg //命名空间和proto文件一致
{
    /// <summary>
    /// push:推送消息(S2C) req:请求消息(C2S) resp:回复消息(S2C)
    /// </summary>
    class ChatMsgId //proto文件名 + "MsgId"
    {
        //推送聊天信息  
        public const int push_chat = 0;

        //发送聊天信息
        public const int req_chat = 1;
    }
}
