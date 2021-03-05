using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FutureWars.Character;
using FutureWars.Audio;
using FutureWars.Animation;



namespace FutureWars.Base
{

    /// <summary>
    /// 生产在游戏中的实体对象
    /// </summary>
    public class Factory
    {

        //单例
        static Factory instance = new Factory();
        public static Factory Instance { get => instance; }


        const string heroPrefix = "Prefab/Hero/";

        const string npcPrefix = "Prefab/Npc/";

        public GameObject CreatHero(EnumHero enumHero)
        {
            GameObject gameObject = Resources.Load<GameObject>(heroPrefix + enumHero.ToString());
            gameObject = Object.Instantiate(gameObject,Vector3.zero,Quaternion.identity);

            Sound sound = new Sound(gameObject, enumHero.ToString());

            //AnimationControl animationControl = new AnimationControl(gameObject, enumHero.ToString());

            Hero hero;

            switch (enumHero)
            {
                case EnumHero.Anna:
                    hero = new Hero(gameObject, new WeaponOfAnna(), new SkillOfAnna(), new AttriOfAnna(), sound);
                    break;
                default:
                    return null;
            }
            HeroManager.Instance.AddHero(gameObject.GetInstanceID(), hero);

            return gameObject;
        }



        public void CreatNpc(EnumNpc enumNpc)
        {
            GameObject gameObject = Resources.Load<GameObject>(npcPrefix + enumNpc.ToString());
            gameObject = Object.Instantiate(gameObject);

            Sound sound = new Sound(gameObject, enumNpc.ToString());

            //AnimationControl animationControl = new AnimationControl(gameObject, enumNpc.ToString());

            Npc npc;

            switch (enumNpc)
            {
                case EnumNpc.Dogface:
                    npc = new Npc(gameObject, new BehaviorOfDogFace(), new AttriOfDogface(), sound);
                    break;
                case EnumNpc.Lord:
                    npc = new Npc(gameObject, new BehaviorOfLord(), new AttriOfLord(), sound);
                    break;
                case EnumNpc.Boss:
                    npc = new Npc(gameObject, new BehaviorOfBoss(), new AttriOfBoss(), sound);
                    break;
                default:
                    return;
            }
            NpcManager.Instance.AddNpc(gameObject.GetInstanceID(), npc);
        }

    }

}