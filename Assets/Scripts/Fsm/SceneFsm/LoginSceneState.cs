using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using FutureWars.Base;
using System;


namespace FutureWars.Fsm
{

    /// <summary>
    /// 登录界面
    /// </summary>
    public class LoginSceneState : StateBase
    {

        //UI字段
        GameObject m_Progress;


        /// <summary>
        /// 显示调用父类的构造函数
        /// </summary>
        /// <param name="controller"></param>
        public LoginSceneState(SceneFsmController controller) : base(controller) { }


        /// <summary>
        /// 对游戏进行初始化
        /// </summary>
        public override void Start()
        {
            //TODO
            //加载游戏数据


            //TODO
            //获取UI信息
            m_Progress = GameObject.Find("Canvas/ProgressBackground/Progress");
        }


        /// <summary>
        /// 登录处理
        /// </summary>
        public override void Update()
        {
            //TODO
            //验证登录信息


            //TODO
            //if (登录成功)
            //{
            //    m_FsmController.SetState(new MainMenuSceneState(m_FsmController));
            //}

            //For test
            m_FsmController.SetState(new MainMenuSceneState(m_FsmController));

        }


        /// <summary>
        /// 登录界面结束后切换到主界面
        /// </summary>
        public override void End()
        {
            GameLoop.m_Mono.StartCoroutine(LoadScene());
        }

        IEnumerator LoadScene()
        {
            const float minX = -1250f;

            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("MainMenu");
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