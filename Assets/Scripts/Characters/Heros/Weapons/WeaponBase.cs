using System.Collections;
using UnityEngine;

namespace FutureWars.Character
{
    /// <summary>
    /// 只包含字段
    /// 记录各种和武器相关的数据
    /// </summary>
    public abstract class WeaponBase
    {

        //获得父级
        protected Hero m_Hero;

        //是否能射击的标志
        bool isShootReady = true;
        public bool IsShootReady { get => isShootReady; set => isShootReady = value; }

        public WeaponBase()
        {

        }

        public void SetHero(Hero hero)
        {
            m_Hero = hero;
        }





        public virtual void Update()
        {
            Shoot();

            Reload();
        }


        /// <summary>
        /// 基本射击方式，射线检测
        /// </summary>
        /// <returns>被击中物体</returns>
        public virtual void Shoot()
        {
            if (Input.GetMouseButton(0) && m_Hero.Attri.BulletNum> 0)
            {
                if (isShootReady)
                {
                    isShootReady = false;

                    m_Hero.Attri.BulletNum--;

                    DoShowShootSound();
                    DoShowShootEffect();

                    Vector3 origin = m_Hero.GunChild.transform.position;
                    Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - origin;

                    RaycastHit2D hit = Physics2D.Raycast(origin, direction, Mathf.Infinity, 1 << 8);

                    if (m_Hero.Attri.BulletNum <= 0)
                    {
                        Reload();
                    }
                    else
                    {
                        DoShowShootAnimation();
                    }

                    if (hit.collider ==null)
                    {
                        return;
                    }

                    if(hit.collider.tag == "Character")
                    {
                        CharacterManager.Instance.FindCharacter(hit.transform.gameObject.GetInstanceID()).UnderAttack(m_Hero);
                    }
                }
            }
        }

        #region 模板方法模式

        /// <summary>
        /// 射击声音
        /// </summary>
        protected abstract void DoShowShootSound();

        /// <summary>
        /// 射击特效
        /// </summary>
        protected abstract void DoShowShootEffect();


        /// <summary>
        /// 射击动画
        /// </summary>
        protected abstract void DoShowShootAnimation();

        #endregion


        /// <summary>
        /// 换弹
        /// </summary>
        protected void Reload()
        {
            if (Input.GetKeyDown(KeyCode.R) || !isShootReady)
            {
                DoShowReloadAnimation();
            }
        }

        /// <summary>
        /// 换弹声音
        /// </summary>
        protected abstract void DoShowReloadSound();


        /// <summary>
        /// 换弹动画
        /// 需要判断弹药数量
        /// </summary>
        protected abstract void DoShowReloadAnimation();



    }
}