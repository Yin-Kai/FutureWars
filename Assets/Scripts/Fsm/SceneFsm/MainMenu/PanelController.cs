using System;
using FutureWars.Fsm;



namespace FutureWars.Fsm.Scene.MainMenu
{

    public class PanelController : FsmControllerBase
    {
        StateBase m_HeroState = null;
        public StateBase HeroState
        {
            get
            {
                if (m_HeroState == null)
                {
                    return m_HeroState = new HeroState(this);
                }
                return m_HeroState;
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


        public override void SetState(StateBase state)
        {
            m_State = state;

            if (m_State != null)
            {
                m_State.Start();
            }
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