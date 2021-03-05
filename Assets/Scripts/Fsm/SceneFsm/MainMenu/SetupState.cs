using System;
using FutureWars.Fsm;
using UnityEngine;
using UnityEngine.UI;




namespace FutureWars.Fsm.Scene.MainMenu
{

    public class SetupState : StateBase
    {

        //UI

        GameObject panelSetup;


        GameObject btnEsc;


        new PanelController m_FsmController;

        public SetupState(PanelController m_FsmController) : base(m_FsmController)
        {
            this.m_FsmController = m_FsmController;

            panelSetup = GameObject.Find("Canvas/Setup");

            btnEsc = GameObject.Find("Canvas/Setup/Esc");
            btnEsc.GetComponent<Button>().onClick.AddListener(OnBtnEscClick);
        }


        public override void Start()
        {
            panelSetup.transform.localPosition = Vector3.zero;
        }


        public override void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OnBtnEscClick();
            }
        }


        void OnBtnEscClick()
        {
            m_FsmController.SetState(null);

            panelSetup.transform.Translate(Vector3.up * 2000);
        }


    }

}