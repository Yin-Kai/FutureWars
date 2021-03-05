using System;




namespace FutureWars.Character
{

    /// <summary>
    /// 存放所有角色的属性
    /// </summary>
    public static class CharacterAttriDB
    {
        #region 安娜

        public static class Anna
        {
            //初始生命值
            public static  int hp = 200;

            //初始攻击力
            public static int damageValue = 30;

            //初始移动速度
            public static float moveSpeed = 5f;

            //初始子弹数
            public static int bulletNum = 14;

            //射击间隔时间
            public static float shootInterval = 0.3f;

            //换弹间隔时间
            public static float reloadInterval = 0.9f;

        }

        #endregion



        #region 小兵

        public static class Dogface
        {
            //初始生命值
            public static int hp = 200;

            //初始攻击力
            public static int damageValue = 10;

            //初始移动速度
            public static float moveSpeed = 4f;

            //射击间隔时间
            public static float shootInterval = 0.8f;
        }

        #endregion


        #region 领主

        public static class Lord
        {
            //初始生命值
            public static int hp = 350;

            //初始攻击力
            public static int damageValue = 20;

            //初始移动速度
            public static float moveSpeed = 2.5f;

            //射击间隔时间
            public static float shootInterval = 1.7f;
        }

        #endregion

        #region 老板

        public static class Boss
        {
            //初始生命值
            public static int hp = 500;

            //初始攻击力
            public static int damageValue = 40;

            //初始移动速度
            public static float moveSpeed = 2f;

            //射击间隔时间
            public static float shootInterval = 3f;
        }

        #endregion

    }

}