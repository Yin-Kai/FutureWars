using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FutureWars.Fsm;
using UnityEngine.UI;


namespace FutureWars.Fsm.Scene.Battle
{

    public class SetupState : StateBase
    {

        new PanelController m_FsmController;


        //UI

        //设置面板
        GameObject panelSetup;
        

        public SetupState(PanelController panelController) : base(panelController)
        {
            m_FsmController = panelController;

            panelSetup = GameObject.Find("Canvas/Setup");

            panelSetup.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(OnBtnEscClick);
            panelSetup.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(OnBtnExitClick);
            panelSetup.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(OnBtnContinueClick);

        }

        public override void Start()
        {
            panelSetup.transform.localPosition = Vector3.zero;
        }


        public override void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                m_FsmController.SetState(m_FsmController.BattleState);
            }
        }


        public override void End()
        {
            panelSetup.transform.Translate(Vector3.up * 2000);
        }

        void OnBtnEscClick()
        {
            m_FsmController.SetState(m_FsmController.BattleState);
        }

        void OnBtnContinueClick()
        {
            m_FsmController.SetState(m_FsmController.BattleState);
        }

        void OnBtnExitClick()
        {
            m_FsmController.SetStateDelegate(new MainMenuSceneState(m_FsmController.sceneControllerDelegate));
        }
    }

}