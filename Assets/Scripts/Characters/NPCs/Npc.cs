using FutureWars.Audio;
using FutureWars.Animation;
using FutureWars.Base;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;



namespace FutureWars.Character
{

    /// <summary>
    /// NPC的类型
    /// </summary>
    public enum EnumNpc : byte
    {
        //小兵
        Dogface,

        //领主
        Lord,

        //大怪
        Boss

    }



    /// <summary>
    /// 与游戏中的NPC实体对应
    /// </summary>
    public class Npc : Character
    {
        NpcAttriBase m_Attri;
        public NpcAttriBase Attri { get => m_Attri; }
        
        //
        NpcBehaviorBase m_NpcBehavior;


        Rigidbody m_Rigibody;

        CapsuleCollider2D m_Collider;
        public CapsuleCollider2D Collider { get => m_Collider; }

        //NavMeshAgent m_NavMeshAgent;
        //public NavMeshAgent NavMeshAgent { get => m_NavMeshAgent; }

        Coroutine adjustDiretion;

        public Npc(GameObject gameObject,
            NpcBehaviorBase npcBehaviorBase,
            NpcAttriBase npcAttriBase,
            Sound sound)
            : base(gameObject)
        {
            m_NpcBehavior = npcBehaviorBase;
            m_NpcBehavior.SetNpc(this);

            m_Attri = npcAttriBase;
            m_Attri.Init();

            m_Sound = sound;

            //m_AnimationControl = animationControl;

            Start();
        }



        /// <summary>
        /// 获取需要的引用
        /// </summary>
        void Start()
        {
            m_Animator = m_GameObject.GetComponent<Animator>();
            m_Rigibody = m_GameObject.GetComponent<Rigidbody>();
            m_Collider = m_GameObject.GetComponent<CapsuleCollider2D>();

            m_Collider.tag = "Character";
            //m_NavMeshAgent = m_GameObject.GetComponent<NavMeshAgent>();

            //m_NavMeshAgent.speed = m_Attri.MoveSpeed;

            m_NpcBehavior.Start();

            adjustDiretion = GameLoop.m_Mono.StartCoroutine(AdjustDiretion());

        }

        /// <summary>
        /// 更新
        /// </summary>
        public void UpDate()
        {
            m_NpcBehavior.UpDate();
            Move(m_NpcBehavior.Target.GameObject);
        }

        /// <summary>
        /// NPC生命周期结束后的处理工作
        /// </summary>
        public void End()
        {
            GameLoop.m_Mono.StopCoroutine(adjustDiretion);

            NpcManager.Instance.DeleteNpc(m_GameObject.GetInstanceID());
            Object.Destroy(m_GameObject);
            m_GameObject = null;

            NpcManager.Instance.End();
        }




        /// <summary>
        /// 被攻击
        /// </summary>
        /// <param name="origin"></param>
        public override void UnderAttack(Hero origin)
        {
            m_Attri.Hp -= origin.Attri.DamageValue;
            if (m_Attri.Hp <= 0)
            {
                End();
            }
        }


        public override void UnderAttack(Npc origin)
        {
            m_Attri.Hp -= origin.Attri.DamageValue;
            if (m_Attri.Hp <= 0)
            {
                End();
            }
        }




        public void Move()
        {
            float rx = 2 * Mathf.Sin(Time.time) * Time.deltaTime;//方向
            m_GameObject.transform.Translate(new Vector3(-rx, m_Attri.MoveSpeed * Time.deltaTime, 0));

        }


        /// <summary>
        /// 朝目标移动
        /// </summary>
        /// <param name="gameObject"></param>
        public void Move(GameObject gameObject)
        {
            if(gameObject == null)
            {
                return;
            }
            //m_NavMeshAgent.SetDestination(gameObject.transform.position);
            Vector3 direction = (gameObject.transform.position - m_GameObject.transform.position).normalized;
            m_GameObject.transform.Translate(direction * Time.deltaTime * m_Attri.MoveSpeed);
        }




        /// <summary>
        /// 调整角色朝向
        /// </summary>
        /// <returns></returns>
        IEnumerator AdjustDiretion()
        {
            if(m_GameObject == null)
            {
                yield break;
            }

            Vector3 direction = m_GameObject.transform.localPosition;

            yield return null;

            direction = m_GameObject.transform.localPosition - direction;

            //右上
            if (direction.x > 0 && direction.y > 0)
            {
                m_Animator.SetBool("Walk",true);
                m_Animator.SetFloat("deltaX", 1);
                m_Animator.SetFloat("deltaY", 1);
            }
            //左上
            else if (direction.x < 0 && direction.y > 0)
            {
                m_Animator.SetBool("Walk", true);
                m_Animator.SetFloat("deltaX", -1);
                m_Animator.SetFloat("deltaY", 1);
            }
            //左下
            else if (direction.x < 0 && direction.y < 0)
            {
                m_Animator.SetBool("Walk", true);
                m_Animator.SetFloat("deltaX", -1);
                m_Animator.SetFloat("deltaY", -1);
            }
            //右下
            else if (direction.x > 0 && direction.y < 0)
            {
                m_Animator.SetBool("Walk", true);
                m_Animator.SetFloat("deltaX", 1);
                m_Animator.SetFloat("deltaY", -1);
            }
        }


    }

}