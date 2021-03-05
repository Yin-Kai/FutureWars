using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace FutureWars.Character
{

    /// <summary>
    /// 英雄属性基类
    /// </summary>
    public abstract class HeroAttriBase : CharacterAttriBase
    {

        //初始子弹数
        protected int bulletNum = 14;

        //换弹间隔时间
        protected float reloadInterval = 0.9f;

        public int BulletNum { get => bulletNum; set => bulletNum = value; }
        public float ReloadInterval { get => reloadInterval; set => reloadInterval = value; }

        /// <summary>
        /// 初始化属性
        /// </summary>
        public override void Init() { }

    }

}