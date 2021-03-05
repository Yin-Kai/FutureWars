



namespace FutureWars.Fsm
{
    /// <summary>
    /// 状态持有者
    /// </summary>
    public abstract class FsmControllerBase
    {
        protected StateBase m_State = null;

        bool isFinish = false;
        public bool IsFinish { get => isFinish; set => isFinish = value; }


        /// <summary>
        /// 切换状态
        /// </summary>
        /// <param name="state"></param>
        public virtual void SetState(StateBase state)
        {
            //通知前一个状态做结束处理
            if (m_State != null)
            {
                m_State.End();
            }

            m_State = state;

            //新状态开始的准备工作
            m_State.Start();
        }

        /// <summary>
        /// 状态的更新
        /// </summary>
        public virtual void Update()
        {
            m_State.Update();
        }

    }

}