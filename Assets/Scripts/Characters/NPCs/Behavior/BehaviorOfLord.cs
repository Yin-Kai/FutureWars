using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FutureWars.Character
{

    /// <summary>
    /// 领主的行为
    /// </summary>
    public class BehaviorOfLord : NpcBehaviorBase
    {

        public override void Init()
        {
            float m_Timer = CharacterAttriDB.Boss.shootInterval;
        }

    }

}