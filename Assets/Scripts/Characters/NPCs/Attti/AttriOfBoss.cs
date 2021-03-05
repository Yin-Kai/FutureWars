


namespace FutureWars.Character
{

    /// <summary>
    /// Boss的属性
    /// </summary>
    public class AttriOfBoss : NpcAttriBase
    {

        public override void Init()
        {
            hp = CharacterAttriDB.Boss.hp;
            damageValue = CharacterAttriDB.Boss.damageValue;
            moveSpeed = CharacterAttriDB.Boss.moveSpeed;
        }
    }

}