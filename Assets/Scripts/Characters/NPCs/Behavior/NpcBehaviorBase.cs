using System;
using UnityEngine;





namespace FutureWars.Character
{

    /// <summary>
    /// NPC特殊行为基类
    /// 不同的NPC由此派生
    /// </summary>
    public abstract class NpcBehaviorBase
    {

        Npc m_Npc;
        public Npc Npc { get => m_Npc; }

        Hero target;
        public Hero Target { get => target; }

        protected float m_Timer=2;


        public void SetNpc(Npc npc)
        {
            m_Npc = npc;
        }

        public abstract void Init();

        public void Start()
        {
            //顺序拿出一个Hero作为目标
            foreach(Hero hero in HeroManager.Instance.HeroDic.Values)
            {
                target = hero;
                break;
            }
        }


        public void UpDate()
        {
            if (target != null && target.GameObject != null)
            {
                Fire(target);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        protected void Move()
        {

        }

        /// <summary>
        /// 朝指定方向移动
        /// </summary>
        /// <param name="target"></param>
        protected void Move(Vector2 target)
        {

        }

        public virtual void Fire(Hero target)
        {
            ////if  主角的生命值为0 什么也不做就return
            //if (target.Attri.Hp <= 0)
            //{
            //    return;
            //}
            //更新计数器
            m_Timer -= Time.deltaTime;
            if (m_Timer > 0)
                return;
            if (Vector3.Distance(m_Npc.GameObject.transform.position, target.GameObject.transform.position) < 1.5f)
            //与主角距离小于1.5米时，停止寻路
            {
                //m_Npc.NavMeshAgent.ResetPath();
                //    //播放lord攻击动画
                //    /*动画播放完*/
                // 重置   
                m_Timer = 2;
                //    //调用Player的OnDamage,减少20生命
                target.UnderAttack(m_Npc);
            }
            else
            {   //追踪
                //m_Npc.NavMeshAgent.SetDestination(target.GameObject.transform.position);
            }
        }


    }

}