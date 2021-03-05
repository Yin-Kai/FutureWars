using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using FutureWars.Base;
using FutureWars.Fsm.Scene.MainMenu;



namespace FutureWars.Fsm
{


    public class MainMenuSceneState : StateBase
    {

        //UI字段

        //按钮
        GameObject btnStart;
        GameObject btnTrain;
        GameObject btnHero;
        GameObject btnSetup;
        GameObject btnQuit;

        //Panel
        GameObject panelMainMenu;
        GameObject panelBattle;

        GameObject m_Progress;


        PanelController m_PanelController;

        /// <summary>
        /// 显示调用父类的构造函数
        /// </summary>
        /// <param name="controller"></param>
        public MainMenuSceneState(FsmControllerBase controller) : base(controller) { }


        /// <summary>
        /// 初始化UI信息
        /// </summary>
        public override void Start()
        {
            m_PanelController = new PanelController();

            //异步等待场景加载完成之后再初始化
            GameLoop.m_Mono.StartCoroutine(Init());
        }

        /// <summary>
        /// 主界面逻辑处理
        /// </summary>
        public override void Update()
        {
            m_PanelController.Update();
        }

        /// <summary>
        /// 进入战斗界面
        /// </summary>
        public override void End()
        {
            GameLoop.m_Mono.StartCoroutine(LoadScene());
        }


        /// <summary>
        /// “开始”按钮被点击后的触发事件
        /// </summary>
        void OnBtnStartClick()
        {
            m_FsmController.SetState(new BattleSceneState(m_FsmController));
        }

        /// <summary>
        /// “训练”按钮被点击后的触发事件
        /// </summary>
        void OnBtnTrainClick()
        {
            m_FsmController.SetState(new TrainSceneState(m_FsmController));
        }

        /// <summary>
        /// “英雄”按钮被点击后的触发事件
        /// </summary>
        void OnBtnHeroClick()
        {
            m_PanelController.SetState(m_PanelController.HeroState);
        }

        /// <summary>
        /// “设置”按钮被点击后的触发事件
        /// </summary>
        void OnBtnSetupClick()
        {
            m_PanelController.SetState(m_PanelController.SetupState);
        }

        /// <summary>
        /// “退出”按钮被点击后的触发事件
        /// </summary>
        void OnBtnQuitClick()
        {
            Application.Quit();
        }


        /// <summary>
        /// 获取UI
        /// </summary>
        /// <returns></returns>
        IEnumerator Init()
        {
            while (!m_FsmController.IsFinish)
            {
                yield return null;
            }

            //重置
            m_FsmController.IsFinish = false;

            //Progress
            m_Progress = GameObject.Find("Canvas/Battle/ProgressBackground");

            //Panel
            panelMainMenu = GameObject.Find("Canvas/MainMenu");
            panelBattle = GameObject.Find("Canvas/Battle");

            //Button
            btnStart = GameObject.Find("Canvas/MainMenu/btnStart");
            btnTrain = GameObject.Find("Canvas/MainMenu/btnTrain");
            btnHero = GameObject.Find("Canvas/MainMenu/btnHero");
            btnSetup = GameObject.Find("Canvas/MainMenu/btnSetup");
            btnQuit = GameObject.Find("Canvas/MainMenu/btnQuit");

            btnStart.GetComponent<Button>().onClick.AddListener(OnBtnStartClick);
            btnTrain.GetComponent<Button>().onClick.AddListener(OnBtnTrainClick);
            btnHero.GetComponent<Button>().onClick.AddListener(OnBtnHeroClick);
            btnSetup.GetComponent<Button>().onClick.AddListener(OnBtnSetupClick);
            btnQuit.GetComponent<Button>().onClick.AddListener(OnBtnQuitClick);
        }

        /// <summary>
        /// 加载战斗场景
        /// </summary>
        /// <returns></returns>
        IEnumerator LoadScene()
        {
            const float minX = -1250f;

            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("Battle");
            asyncOperation.allowSceneActivation = false;

            while (!asyncOperation.isDone)
            {
                m_Progress.transform.localPosition = new Vector2(minX - minX * asyncOperation.progress, 0);

                if (asyncOperation.progress >= 0.9f)
                {
                    m_Progress.transform.localPosition = Vector2.zero;

                    asyncOperation.allowSceneActivation = true;
                }

                yield return null;
            }

            m_FsmController.IsFinish = true;
        }
    }

}