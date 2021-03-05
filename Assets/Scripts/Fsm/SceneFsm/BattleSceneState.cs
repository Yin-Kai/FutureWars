using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using FutureWars.Base;
using FutureWars.Character;
using FutureWars.Fsm.Scene.Battle;



namespace FutureWars.Fsm
{

    public delegate void CharacterManagerDelegate();

    /// <summary>
    /// 战斗场景
    /// </summary>
    public class BattleSceneState : StateBase
    {

        PanelController m_PanelController;

        CharacterManagerDelegate CharacterManagerDelegate;

        /// <summary>
        /// 显示调用父类的构造函数
        /// </summary>
        /// <param name="controller"></param>
        public BattleSceneState(FsmControllerBase controller) : base(controller) { }


        public override void Start()
        {
            m_PanelController = new PanelController();
            m_PanelController.SetStateDelegate = m_FsmController.SetState;
            m_PanelController.sceneControllerDelegate = m_FsmController;

            CharacterManagerDelegate = CharacterManager.Instance.Update;
            CharacterManager.Instance.GameOver = GameOver;

            GameLoop.m_Mono.StartCoroutine(Init());
        }

        public override void Update()
        {

            m_PanelController.Update();

            CharacterManagerDelegate();
        }

        public override void End()
        {
            GameLoop.m_Mono.StartCoroutine(LoadScene());
        }


        void GameOver()
        {
            m_PanelController.SetState(m_PanelController.GameOverState);

            CharacterManagerDelegate = Null;
        }

        void Null()
        {

        }


        /// <summary>
        /// 等待场景加载完成后再初始化
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

            m_PanelController.SetState(m_PanelController.StartState);
        }


        /// <summary>
        /// 切换到主菜单
        /// </summary>
        /// <returns></returns>
        IEnumerator LoadScene()
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("MainMenu");
            asyncOperation.allowSceneActivation = true;

            while (!asyncOperation.isDone)
            {
                yield return null;
            }

            m_FsmController.IsFinish = true;
        }

    }
}