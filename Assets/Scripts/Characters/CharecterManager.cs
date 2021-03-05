using System;
using System.Collections.Generic;
using FutureWars.Fsm;



namespace FutureWars.Character
{

    /// <summary>
    /// 管理所有的角色
    /// </summary>
    public class CharacterManager
    {

        //单例
        static CharacterManager instance = new CharacterManager();
        public static CharacterManager Instance { get => instance; }
        
        //隐藏构造方法
        private CharacterManager() { }


        public CharacterManagerDelegate GameOver;


        /// <summary>
        /// 初始化
        /// </summary>
        public void Start()
        {
            HeroManager.Instance.Start();

            NpcManager.Instance.Start();
        }



        /// <summary>
        /// 轮询所有角色更新
        /// </summary>
        public void Update()
        {
            HeroManager.Instance.Update();

            NpcManager.Instance.Update();
        }


        /// <summary>
        /// 游戏结束处理
        /// </summary>
        public void End()
        {
            HeroManager.Instance.End();

            NpcManager.Instance.End();

            NpcManager.Instance.IsGameOver = true;

            if(GameOver != null)
            {
                GameOver();
            }
        }


        /// <summary>
        /// 获取角色实例
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Character FindCharacter(int id)
        {
            Character character = HeroManager.Instance.FindHero(id);

            if (null != character)
            {
                return character;
            }

            return NpcManager.Instance.FindNpc(id);
        }





    }

}