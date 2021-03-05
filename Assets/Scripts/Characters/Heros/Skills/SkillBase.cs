using System;
using System.Collections;
using UnityEngine;


namespace FutureWars.Character
{
    /// <summary>
    /// 实现技能特效音效的播放和技能伤害效果的计算
    /// </summary>
    public abstract class SkillBase
    {
        Hero m_Hero;
        public Hero Hero { get => m_Hero; }


        //技能是否冷却
        protected bool isEReady = true;

        protected bool isQReady = true;

        protected bool isShiftReady = true;


        public void SetHero(Hero hero)
        {
            m_Hero = hero;
        }

        public abstract void E();

        public abstract void Q();

        public abstract void Shift();

        public abstract void Update();



    }


}