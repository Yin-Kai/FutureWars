using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FutureWars.Fsm;
using FutureWars.Character;



namespace FutureWars.Fsm.Scene.Battle
{

    public delegate void SetStateDelegate(StateBase state);

    public class PanelController : FsmControllerBase
    {

        #region 战斗场景中的几个状态

        StateBase m_StartState = null;
        public StateBase StartState
        {
            get
            {
                if (m_StartState == null)
                {
                    return m_StartState = new StartState(this);
                }
                return m_StartState;
            }
        }


        StateBase m_SetupState;
        public StateBase SetupState
        {
            get
            {
                if (m_SetupState == null)
                {
                    return m_SetupState = new SetupState(this);
                }
                return m_SetupState;
            }
        }


        StateBase m_DetailState;
        public StateBase DetailState
        {
            get
            {
                if (m_DetailState == null)
                {
                    return m_DetailState = new DetailState(this);
                }
                return m_DetailState;
            }
        }


        StateBase m_BattleState;
        public StateBase BattleState
        {
            get
            {
                if(m_BattleState == null)
                {
                    return m_BattleState = new BattleState(this);
                }
                return m_BattleState;
            }
        }

        StateBase m_GameOverState;
        public StateBase GameOverState
        {
            get
            {
                if (m_GameOverState == null)
                {
                    return m_GameOverState = new GameOverState(this);
                }
                return m_GameOverState;
            }
        }

        #endregion

        //主角
        Hero m_Hero;
        public Hero Hero { get => m_Hero; set => m_Hero = value; }

        public SetStateDelegate SetStateDelegate;
        public FsmControllerBase sceneControllerDelegate;

        public override void SetState(StateBase state)
        {
            if (m_State != null)
            {
                m_State.End();
            }
            m_State = state;
            m_State.Start();
        }


        public override void Update()
        {
            if (m_State != null)
            {
                m_State.Update();
            }
        }
    }

}