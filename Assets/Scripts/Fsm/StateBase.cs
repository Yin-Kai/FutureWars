



namespace FutureWars.Fsm
{

    /// <summary>
    /// 定义状态接口
    /// </summary>
    public abstract class StateBase
    {
        protected FsmControllerBase m_FsmController = null;

        public StateBase(FsmControllerBase context)
        {
            m_FsmController = context;
        }



        /// <summary>
        /// 状态开始时的处理工作
        /// </summary>
        public virtual void Start() { }

        /// <summary>
        /// 状态的更新
        /// </summary>
        public virtual void Update() { }

        /// <summary>
        /// 状态结束时的处理工作
        /// </summary>
        public virtual void End() { }
    }

}