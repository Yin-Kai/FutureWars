using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FutureWars.Character
{

    /// <summary>
    /// 领主的属性
    /// </summary>
    public class AttriOfLord : NpcAttriBase
    {
        public override void Init()
        {
            hp = CharacterAttriDB.Lord.hp;
            damageValue = CharacterAttriDB.Lord.damageValue;
            moveSpeed = CharacterAttriDB.Lord.moveSpeed;
        }

    }

}