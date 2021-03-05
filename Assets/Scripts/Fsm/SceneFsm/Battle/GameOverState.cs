using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



namespace FutureWars.Fsm.Scene.Battle
{

    /// <summary>
    /// 游戏结束面板
    /// </summary>
    public class GameOverState : StateBase
    {

        new PanelController m_FsmController;

        //UI

        //设置面板
        GameObject panelGameOver;

        public GameOverState(PanelController panelController) : base(panelController)
        {
            m_FsmController = panelController;

            panelGameOver = GameObject.Find("Canvas/GameOver");

            panelGameOver.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(OnBtnAckClick);
        }

        public override void Start()
        {
            panelGameOver.transform.localPosition = Vector3.zero;
        }


        public override void Update()
        {
            //按回车键后退回到主界面
            if (Input.GetKey(KeyCode.Return))
            {
                m_FsmController.SetStateDelegate(new MainMenuSceneState(m_FsmController.sceneControllerDelegate));
            }
        }


        public override void End()
        {
            panelGameOver.transform.Translate(Vector3.up * 2000);
        }

        void OnBtnAckClick()
        {
            m_FsmController.SetStateDelegate(new MainMenuSceneState(m_FsmController.sceneControllerDelegate));
        }
    }

}