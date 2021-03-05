using System;
using FutureWars.Fsm;
using UnityEngine;
using UnityEngine.UI;



namespace FutureWars.Fsm.Scene.MainMenu
{

    public class HeroState : StateBase
    {

        //UI

        GameObject panelHero;


        GameObject btnEsc;


        public HeroState(PanelController m_FsmController) : base(m_FsmController)
        {
            this.m_FsmController = m_FsmController;

            panelHero = GameObject.Find("Canvas/Hero");

            btnEsc = GameObject.Find("Canvas/Hero/Esc");
            btnEsc.GetComponent<Button>().onClick.AddListener(OnBtnEscClick);
        }


        public override void Start()
        {
            panelHero.transform.localPosition = Vector3.zero;
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

            panelHero.transform.Translate(Vector3.up * 2000);
        }

    }

}