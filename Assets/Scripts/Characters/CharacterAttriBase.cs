using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FutureWars.Character
{

    /// <summary>
    /// 角色属性基类
    /// </summary>
    public abstract class CharacterAttriBase
    {
        //初始生命值
        protected int hp;

        //初始攻击力
        protected int damageValue;

        //初始移动速度
        protected float moveSpeed;

        //射击间隔时间
        protected float shootInterval;


        public int Hp { get => hp; set => hp = value; }
        public int DamageValue { get => damageValue; set => damageValue = value; }
        public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
        public float ShootInterval { get => shootInterval; set => shootInterval = value; }

        /// <summary>
        /// 初始化
        /// </summary>
        public abstract void Init();

    }

}