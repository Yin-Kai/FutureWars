using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace FutureWars.Character
{

    /// <summary>
    /// 安娜的属性
    /// </summary>
    public class AttriOfAnna : HeroAttriBase
    {

        /// <summary>
        /// 初始换属性
        /// </summary>
        public override void Init()
        {
            hp = CharacterAttriDB.Anna.hp;
            damageValue = CharacterAttriDB.Anna.damageValue;
            moveSpeed = CharacterAttriDB.Anna.moveSpeed;
            bulletNum = CharacterAttriDB.Anna.bulletNum;
        }
    }

}