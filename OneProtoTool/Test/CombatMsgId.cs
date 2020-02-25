//命名空间和proto文件一致
namespace  Msg
{    

    /// <summary>
    /// push:推送消息(S2C) req:请求消息(C2S) resp:回复消息(S2C)
    /// </summary>
    class CombatMsgId //proto文件名 + "MsgId"
    {

        //定义据点城池
        public const int  combat_point = 3;

        //定义战斗武将
        public const int  combat_general = 4;

        //定义城墙
        public const int  combat_wall = 5;

        //定义箭塔
        public const int  combat_arrow = 6;

        //定义战斗方
        public const int  combat_member = 7;

        
        public const int  once_buffstep = 8;

        //释放buff
        public const int  once_buff = 9;

        //定义一次攻击
        public const int  once_attack = 10;

        //定义一次反伤、吸血
        public const int  once_back = 11;

        //定义回合数据
        public const int  round_info = 12;

        //定义战斗数据
        public const int  combatInfo = 13;

    }
}
