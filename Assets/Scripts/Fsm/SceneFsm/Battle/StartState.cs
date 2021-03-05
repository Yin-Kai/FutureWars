using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using FutureWars.Base;
using FutureWars.Character;



namespace FutureWars.Fsm.Scene.Battle
{



    public class StartState : StateBase
    {

        new PanelController m_FsmController;


        //UI

        //英雄选择框，从左到右排列 
        GameObject[] btnHero = new GameObject[3];

        //英雄头像框
        Image boxHero;

        //英雄头像资源
        Sprite[] heroHead = new Sprite[3];

        //选择英雄面板
        GameObject panelStart;

        //确认按钮
        GameObject btnAck;

        //加载路径前缀
        string loadPrefix = "UI/Battle/Start/head/";

        //当前选择的英雄
        EnumHero m_EnumHero = EnumHero.Length;


        public StartState(PanelController panelController) : base(panelController)
        {
            m_FsmController = panelController;

            Init();
        }

        public override void Start()
        {
            panelStart.transform.localPosition = Vector3.zero;
        }


        public override void Update()
        {

        }


        public override void End()
        {
            panelStart.transform.Translate(Vector3.up * 2000);
        }

        /// <summary>
        /// 模板方法
        /// </summary>
        /// <param name="i"></param>
        void OnBtnHeroClick(int i)
        {
            if (boxHero.sprite == null || boxHero.sprite != heroHead[i])
            {
                boxHero.sprite = heroHead[i];
                boxHero.color = new Color(255f, 255f, 255f, 255f);
                m_EnumHero = (EnumHero)i;
            }
            else
            {
                boxHero.sprite = null;
                boxHero.color = new Color(128f, 128f, 128f, 128f);
                m_EnumHero = EnumHero.Length;
            }
        }

        void OnBtnHeroClick0()
        {
            OnBtnHeroClick(0);
        }

        void OnBtnHeroClick1()
        {
            OnBtnHeroClick(1);
        }

        void OnBtnHeroClick2()
        {
            OnBtnHeroClick(2);
        }

        void OnBtnAckClick()
        {
            if(m_EnumHero != EnumHero.Length)
            {
                GameObject hero = Factory.Instance.CreatHero(m_EnumHero);

                GameObject.Find("Main Camera").AddComponent<CameraCtrl>().Player = hero;

                m_FsmController.Hero = HeroManager.Instance.FindHero(hero.GetInstanceID());

                CharacterManager.Instance.Start();

                m_FsmController.SetState(m_FsmController.BattleState);
            }
        }


        /// <summary>
        /// 获取UI
        /// </summary>
        /// <returns></returns>
        void Init()
        {
            //重置
            m_FsmController.IsFinish = false;

            //面板
            panelStart = GameObject.Find("Canvas/Start");

            //选框
            for (int i = 0; i < 3; i++)
            {
                btnHero[i] = GameObject.Find("Canvas/Start/Btn" + i.ToString());
                heroHead[i] = Resources.Load<Sprite>(loadPrefix + i.ToString());
            }

            boxHero = GameObject.Find("Canvas/Start/Box0").GetComponent<Image>();

            //确认
            btnAck = GameObject.Find("Canvas/Start/Ack");

            btnHero[0].GetComponent<Button>().onClick.AddListener(OnBtnHeroClick0);
            btnHero[1].GetComponent<Button>().onClick.AddListener(OnBtnHeroClick1);
            btnHero[2].GetComponent<Button>().onClick.AddListener(OnBtnHeroClick2);
            btnAck.GetComponent<Button>().onClick.AddListener(OnBtnAckClick);
        }
    }
}