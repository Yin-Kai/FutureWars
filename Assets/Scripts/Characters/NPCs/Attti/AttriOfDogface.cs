using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace FutureWars.Character
{

    /// <summary>
    /// 小兵的属性
    /// </summary>
    public class AttriOfDogface : NpcAttriBase
    {

        public override void Init()
        {
            hp = CharacterAttriDB.Dogface.hp;
            damageValue = CharacterAttriDB.Dogface.damageValue;
            moveSpeed = CharacterAttriDB.Dogface.moveSpeed;
        }
    }

}