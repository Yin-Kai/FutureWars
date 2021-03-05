using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace FutureWars.Character
{

    /// <summary>
    /// 小兵
    /// </summary>
    public class BehaviorOfDogFace : NpcBehaviorBase
    {


        public override void Init()
        {
            m_Timer = CharacterAttriDB.Dogface.shootInterval;
        }


    }

}