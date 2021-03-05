using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FutureWars.Fsm;

namespace FutureWars.Fsm.Scene.Battle
{

    /// <summary>
    /// 控制战斗时的UI
    /// </summary>
    public class BattleState : StateBase
    {

        new PanelController m_FsmController;
        

        //UI
        //面板
        GameObject panelBattle;

        //文本控件
        Text hp;
        Text bulletNum;

        const string hpStr = "HP:";
        const string bulletNumStr = "BulletNum:";

        public BattleState(PanelController panelController) : base(panelController)
        {
            m_FsmController = panelController;

            panelBattle = GameObject.Find("Canvas/Battle");

            hp = panelBattle.transform.GetChild(1).GetComponent<Text>();
            bulletNum = panelBattle.transform.GetChild(2).GetComponent<Text>();
        }

        public override void Start()
        {
            panelBattle.transform.localPosition = Vector3.zero;
        }

        public override void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                m_FsmController.SetState(m_FsmController.DetailState);
            }
            else if (Input.GetKey(KeyCode.Escape))
            {
                m_FsmController.SetState(m_FsmController.SetupState);
            }

            hp.text = hpStr + m_FsmController.Hero.Attri.Hp;
            bulletNum.text = bulletNumStr + m_FsmController.Hero.Attri.BulletNum;
        }

        public override void End()
        {
            //panelBattle.transform.Translate(Vector3.up * 2000);
        }
    }

}