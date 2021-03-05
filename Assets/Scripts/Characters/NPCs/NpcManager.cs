using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FutureWars.Base;


namespace FutureWars.Character
{

    /// <summary>
    /// 管理所有的NPC角色
    /// </summary>
    public class NpcManager
    {
        //单例
        static NpcManager instance = new NpcManager();
        public static NpcManager Instance { get => instance; }

        //隐藏构造方法
        private NpcManager() { }

        //建立游戏中的实体和代码实例的联系
        Dictionary<int, Npc> m_Npc = new Dictionary<int, Npc>();

        //标记为死亡的NPC
        List<int> m_DeadNpc = new List<int>();

        //游戏结束标志
        bool isGameOver = false;
        public bool IsGameOver { get => isGameOver; set => isGameOver = value; }

        //最大NPC数量
        const int MAX_NUMBER = 20;

        //NPC死亡数
        int kills = 0;
        public int Kills { get => kills; }

        public void Start()
        {
            GameLoop.m_Mono.StartCoroutine(CreatNpc());
        }

        /// <summary>
        /// 轮询NPC
        /// </summary>
        public void Update()
        {
            foreach(Npc npc in m_Npc.Values)
            {
                npc.UpDate();
            }

            foreach(int key in m_DeadNpc)
            {
                m_Npc.Remove(key);
            }

            m_DeadNpc.Clear();
        }


        /// <summary>
        /// 游戏结束的处理
        /// </summary>
        public void End()
        {
            foreach (int key in m_DeadNpc)
            {
                m_Npc.Remove(key);
            }

            m_DeadNpc.Clear();
        }

        public void AddNpc(int id,Npc npc)
        {
            m_Npc.Add(id, npc);
        }


        /// <summary>
        /// 将NPC标记为死亡
        /// </summary>
        /// <param name="id"></param>
        public void DeleteNpc(int id)
        {
            ++kills;
            m_DeadNpc.Add(id);
        }


        /// <summary>
        /// 根据实体id寻找NPC对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Npc FindNpc(int id)
        {
            if(m_Npc.TryGetValue(id,out Npc npc))
            {
                return npc;
            }

            return null;
        }

        /// <summary>
        /// 在游戏中随机生成NPC
        /// </summary>
        IEnumerator CreatNpc()
        {
            int randomN;

            //当现有敌人数量小于最大敌人数量，就产生敌人
            while (m_Npc.Count <= MAX_NUMBER)
            {
                yield return new WaitForSeconds(Random.Range(1, 5));
                randomN = Random.Range(0, 100);
                //控制产生三种敌人
                switch (randomN % 3)
                {
                    case 0:
                        Factory.Instance.CreatNpc(EnumNpc.Dogface);
                        break;
                    case 1:
                        Factory.Instance.CreatNpc(EnumNpc.Boss);
                        break;
                    case 2:
                        Factory.Instance.CreatNpc(EnumNpc.Lord);
                        break;
                }

                if(kills > 20 || isGameOver)
                {
                    yield break;
                }
            }
            GameLoop.m_Mono.StartCoroutine(StopCreating());
        }

        /// <summary>
        /// 等待再次唤醒CreatNpc
        /// </summary>
        /// <returns></returns>
        IEnumerator StopCreating()
        {
            while (m_Npc.Count > MAX_NUMBER / 2)
            {
                yield return new WaitForSeconds(3f);

                if (kills > 20 || isGameOver)
                {
                    yield break;
                }
            }

            GameLoop.m_Mono.StartCoroutine(CreatNpc());
        }

        
    }

}