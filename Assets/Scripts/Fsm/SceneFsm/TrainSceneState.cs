using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FutureWars.Base;
using UnityEngine.SceneManagement;

namespace FutureWars.Fsm
{

    public class TrainSceneState : StateBase
    {

        //UI字段


        /// <summary>
        /// 显示调用父类的构造函数
        /// </summary>
        /// <param name="controller"></param>
        public TrainSceneState(FsmControllerBase controller) : base(controller) { }


        /// <summary>
        /// 对游戏进行初始化
        /// </summary>
        public override void Start()
        {
            //TODO
            //加载游戏数据


            //TODO
            //获取UI信息
            
        }


        /// <summary>
        /// 主界面逻辑处理
        /// </summary>
        public override void Update()
        {

        }


        /// <summary>
        /// 退回主菜单界面
        /// </summary>
        public override void End()
        {
            GameLoop.m_Mono.StartCoroutine(LoadScene());
        }





        /// <summary>
        /// 切换到主菜单场景
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