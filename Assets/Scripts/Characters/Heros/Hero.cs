using System.Collections;
using UnityEngine;
using FutureWars.Audio;
using FutureWars.Animation;
using FutureWars.Base;



namespace FutureWars.Character
{

    public enum EnumHero : byte
    {
        Anna,
        Angle,
        Monk,

        Saul,
        Dva,
        Pig,

        Soldier,
        Widow,
        Death,

        Length
    }



    /// <summary>
    /// 和游戏中的英雄实体对应
    /// </summary>
    public class Hero : Character
    {
        HeroAttriBase m_Attri;
        public HeroAttriBase Attri { get => m_Attri; }

        WeaponBase m_Weapon;

        SkillBase m_Skill;

        #region 基本位移旋转逻辑所需引用

        GameObject m_GunChild;
        public GameObject GunChild { get => m_GunChild; }

        CapsuleCollider2D m_Collider;
        public CapsuleCollider2D Collider { get => m_Collider; }


        #endregion




        public Hero(GameObject gameObject,
            WeaponBase weaponBase,
            SkillBase skillBase,
            HeroAttriBase heroAttriBase,
            Sound sound)
            : base(gameObject)
        {
            m_Weapon = weaponBase;
            m_Weapon.SetHero(this);

            m_Skill = skillBase;
            m_Skill.SetHero(this);

            m_Sound = sound;

            //m_AnimationControl = animationControl;

            m_Attri = heroAttriBase;
            m_Attri.Init();

            Start();
        }





        /// <summary>
        /// 获得需要的引用
        /// </summary>
        void Start()
        {
            m_Animator = m_GameObject.GetComponent<Animator>();
            m_Collider = m_GameObject.GetComponent<CapsuleCollider2D>();

            m_Collider.tag = "Character";

            m_GunChild = m_GameObject.transform.GetChild(0).gameObject;

            //m_GunChild.transform.localPosition = new Vector3(-1.06f, 9.82f, 0);
        }


        /// <summary>
        /// 轮询子部分的更新
        /// </summary>
        public void Update()
        {
            m_Weapon.Update();
            m_Skill.Update();
            Move();

            if (m_Attri.Hp <= 0)
            {
                End();
            }
        }

        /// <summary>
        /// 对象生命周期结束后的处理
        /// </summary>
        public void End()
        {
            //GameLoop.m_Mono.StartCoroutine(Timer(5f));
            //播放死亡动画

            HeroManager.Instance.DeleteHero(m_GameObject.GetInstanceID());
            Object.Destroy(m_GameObject);
            m_GameObject = null;

            GameObject.Find("Main Camera").GetComponent<CameraCtrl>().Player = null;

            CharacterManager.Instance.End();
        }



        public override void UnderAttack(Npc origin)
        {
            m_Attri.Hp -= origin.Attri.DamageValue;
            if (m_Attri.Hp <= 0)
            {
                End();
            }
        }

        public override void UnderAttack(Hero origin)
        {
            m_Attri.Hp -= origin.Attri.DamageValue;
            if (m_Attri.Hp <= 0)
            {
                End();
            }
        }










        void Move()
        {
            #region WASD控制移动

            Vector3 preLocation = m_GameObject.transform.localPosition;

            if (Input.GetKey(KeyCode.W))
            {
                m_GameObject.transform.Translate(Vector3.up * m_Attri.MoveSpeed * Time.deltaTime);
               
                m_Animator.SetFloat("deltaX", 0);
                m_Animator.SetFloat("deltaY", 1);

                //m_AnimationControl.Play("Up");
            }
            if (Input.GetKey(KeyCode.S))
            {
                m_GameObject.transform.Translate(Vector3.down * m_Attri.MoveSpeed * Time.deltaTime);
                m_Animator.SetFloat("deltaX", 0);
                m_Animator.SetFloat("deltaY", -1);

                //m_AnimationControl.Play("Down");
            }
            if (Input.GetKey(KeyCode.A))
            {
                m_GameObject.transform.Translate(Vector3.left * m_Attri.MoveSpeed * Time.deltaTime);
                m_Animator.SetFloat("deltaX", -1);
                m_Animator.SetFloat("deltaY", 0);

                //m_AnimationControl.Play("Left");
            }
            if (Input.GetKey(KeyCode.D))
            {
                m_GameObject.transform.Translate(Vector3.right * m_Attri.MoveSpeed * Time.deltaTime);
                m_Animator.SetFloat("deltaX", 1);
                m_Animator.SetFloat("deltaY", 0);
                //m_AnimationControl.Play("Right");
            }

            if (preLocation == m_GameObject.transform.localPosition)
            {
                //停止位移动画
                //m_AnimationControl.Play("Idle");

            }

            #endregion


            #region 调整角色朝向

            //Vector2 temp = Camera.main.ScreenToWorldPoint(Input.mousePosition) - m_GameObject.transform.localPosition;

            //if (temp.x > temp.y && temp.x > -temp.y && !rightRender.enabled)
            //{
            //    //使角色转向右
            //    tempSpriteRenderer.enabled = false;
            //    tempSpriteRenderer = rightRender;
            //    tempSpriteRenderer.enabled = true;

            //    //移动枪口
            //    m_GunChild.transform.localPosition = new Vector3(8.39f, 4.6f, 0);
            //}
            //else if (temp.y > temp.x && temp.y > -temp.x && !upRender.enabled)
            //{
            //    //使角色转向上
            //    tempSpriteRenderer.enabled = false;
            //    tempSpriteRenderer = upRender;
            //    tempSpriteRenderer.enabled = true;

            //    //移动枪口
            //    m_GunChild.transform.localPosition = new Vector3(-1.06f, 9.82f, 0);
            //}
            //else if (temp.x < temp.y && temp.x < -temp.y && !leftRender.enabled)
            //{
            //    //使角色转向左
            //    tempSpriteRenderer.enabled = false;
            //    tempSpriteRenderer = leftRender;
            //    tempSpriteRenderer.enabled = true;

            //    //移动枪口
            //    m_GunChild.transform.localPosition = new Vector3(-7.07f, 6.02f, 0);
            //}
            //else if (temp.y < temp.x && temp.y < -temp.x && !downRender.enabled)
            //{
            //    //使角色转向下
            //    tempSpriteRenderer.enabled = false;
            //    tempSpriteRenderer = downRender;
            //    tempSpriteRenderer.enabled = true;

            //    //移动枪口
            //    m_GunChild.transform.localPosition = new Vector3(0.1f, -3.4f, 0);
            //}

            #endregion

        }




    }






}