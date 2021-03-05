using System;
using UnityEngine;
using FutureWars.Base;



namespace FutureWars.Character
{

    public class SkillOfAnna : SkillBase
    {



        public SkillOfAnna()
        {

        }

        public override void E()
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (isEReady)
                {
                    isEReady = false;

                    //do something



                    GameLoop.m_Mono.StartCoroutine(Hero.Timer(10f, ResetE));
                }
            }
        }

        void ResetE()
        {
            isEReady = true;
        }

        public override void Q()
        {
            if (Input.GetKey(KeyCode.Q))
            {
                if (isQReady)
                {
                    isQReady = true;

                    //do something


                    GameLoop.m_Mono.StartCoroutine(Hero.Timer(20f, ResetQ));
                }
            }
        }

        void ResetQ()
        {
            isQReady = true;
        }

        /// <summary>
        /// 移速增加
        /// </summary>
        public override void Shift()
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Hero.Attri.MoveSpeed = CharacterAttriDB.Anna.moveSpeed * 2;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                Hero.Attri.MoveSpeed = CharacterAttriDB.Anna.moveSpeed;
            }
        }

        public override void Update()
        {
            E();

            Q();

            Shift();
        }
    }
}