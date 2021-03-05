using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FutureWars.Character;
using FutureWars.Fsm;



namespace FutureWars.Fsm.Scene.Battle
{

    public class DetailState : StateBase
    {

        new PanelController m_FsmController;


        //Detail面板
        GameObject panelDetail;

        //击杀数
        Text kills;

        //头像框
        //Image head;

        public DetailState(PanelController panelController) : base(panelController)
        {
            m_FsmController = panelController;

            panelDetail = GameObject.Find("Canvas/Detail");

            kills = panelDetail.transform.GetChild(1).GetComponent<Text>();
            //head = panelDetail.transform.GetChild(2).GetComponent<Image>();
        }

        public override void Start()
        {
            panelDetail.transform.localPosition = Vector3.zero;
        }


        public override void Update()
        {
            if (Input.GetKeyUp(KeyCode.Tab))
            {
                panelDetail.transform.Translate(Vector3.up * 2000);

                m_FsmController.SetState(m_FsmController.BattleState);
            }

            //展示积分面板
            kills.text = "击杀数:" + NpcManager.Instance.Kills;

        }


        public override void End()
        {

        }

    }

}