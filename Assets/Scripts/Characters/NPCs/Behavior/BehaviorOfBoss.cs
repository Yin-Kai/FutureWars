



namespace FutureWars.Character
{

    /// <summary>
    /// Boss的行为
    /// </summary>
    public class BehaviorOfBoss : NpcBehaviorBase
    {


        public override void Init()
        {
            float m_Timer = CharacterAttriDB.Boss.shootInterval;
        }

    }

}