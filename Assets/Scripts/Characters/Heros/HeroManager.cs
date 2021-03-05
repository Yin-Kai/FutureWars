using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FutureWars.Base;


namespace FutureWars.Character
{
    /// <summary>
    ///  管理所有的英雄角色
    /// </summary>
    public class HeroManager
    {
        //单例
        static HeroManager instance = new HeroManager();
        public static HeroManager Instance { get => instance; }

        //将构造方法隐藏起来
        private HeroManager() { }


        //建立游戏对象实体和脚本的联系
        Dictionary<int, Hero> m_HeroDic = new Dictionary<int, Hero>();
        public Dictionary<int,Hero> HeroDic { get => m_HeroDic; }

        //标记为死亡的英雄
        List<int> m_DeadHero = new List<int>();



        public void Start()
        {
            
        }

        /// <summary>
        /// 轮询所有英雄更新
        /// </summary>
        public void Update()
        {
            foreach(Hero hero in m_HeroDic.Values)
            {
                hero.Update();
            }

            foreach(int key in m_DeadHero)
            {
                m_HeroDic.Remove(key);
            }

            m_DeadHero.Clear();
        }

        /// <summary>
        /// 游戏结束处理
        /// </summary>
        public void End()
        {
            foreach (int key in m_DeadHero)
            {
                m_HeroDic.Remove(key);
            }

            m_DeadHero.Clear();
        }


        /// <summary>
        /// 添加游戏对象到管理队列
        /// </summary>
        /// <param name="gameObject"></param>
        public void AddHero(int id, Hero hero)
        {
            m_HeroDic.Add(id, hero);
        }



        /// <summary>
        /// 将游戏对象标记为可删除
        /// </summary>
        /// <param name="key"></param>
        public void DeleteHero(int key)
        {
            m_DeadHero.Add(key);
        }

        /// <summary>
        /// 获取Hero实例
        /// </summary>
        /// <param name="id">Unity中的InstanceId</param>
        /// <returns></returns>
        public Hero FindHero(int id)
        {
            if (m_HeroDic.TryGetValue(id, out Hero temp))
            {
                return temp;
            }
            return null;
        }


    }
}
