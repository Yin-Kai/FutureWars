using System;
using UnityEngine;
using FutureWars.Base;

namespace FutureWars.Character
{



    public class WeaponOfAnna : WeaponBase
    {


        public WeaponOfAnna()
        {

        }

        public override void Update()
        {
            Shoot();           
        }



        protected override void DoShowShootSound()
        {
            m_Hero.Sound.Play("室内靶场");
        }

        protected override void DoShowShootEffect()
        {

        }

        protected override void DoShowShootAnimation()
        {
            GameLoop.m_Mono.StartCoroutine(Character.Timer(CharacterAttriDB.Anna.shootInterval, ResetShoot));
            //播放射击动画


        }

        protected override void DoShowReloadSound()
        {

        }

        protected override void DoShowReloadAnimation()
        {
            GameLoop.m_Mono.StartCoroutine(Character.Timer(CharacterAttriDB.Anna.reloadInterval, ResetShoot));
            //播放换弹动画


            m_Hero.Attri.BulletNum = CharacterAttriDB.Anna.bulletNum;
        }


        void ResetShoot()
        {
            IsShootReady = true;
        }



    }

}