using System.Collections;
using UnityEngine;
using FutureWars.Audio;
using FutureWars.Animation;



namespace FutureWars.Character
{
    /// <summary>
    /// 延时任务
    /// </summary>
    public delegate void Task();



    /// <summary>
    /// 角色基类
    /// </summary>
    public abstract class Character
    {

        //实体
        protected GameObject m_GameObject;
        public GameObject GameObject { get => m_GameObject; }

        //音频组件
        protected Sound m_Sound;
        public Sound Sound { get => m_Sound; }

        //动画控制
        protected Animator m_Animator;
        public Animator Animator { get => m_Animator; }

        ////动画组件
        //protected AnimationControl m_AnimationControl;
        //public AnimationControl AnimationControl { get => m_AnimationControl; }



        public Character(GameObject gameObject)
        {
            m_GameObject = gameObject;
        }


        public abstract void UnderAttack(Hero hero);

        public abstract void UnderAttack(Npc npc);


        /// <summary>
        /// 延时执行任务
        /// </summary>
        public static IEnumerator Timer(float seconds, Task task)
        {
            yield return new WaitForSeconds(seconds);
            task();
        }


    }

}