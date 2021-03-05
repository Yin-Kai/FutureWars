using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace FutureWars.Animation
{

    /// <summary>
    /// 动画模块
    /// </summary>
    public class AnimationControl
    {
        
        AnimationClipCtrl m_AnimationClip;

        //Animation
        UnityEngine.Animation m_Animation;


        public AnimationControl(GameObject gameObject,string characterName)
        {
            m_AnimationClip = new AnimationClipCtrl(characterName);

            m_Animation = gameObject.AddComponent<UnityEngine.Animation>();

            Init();
        }

        void Init()
        {
            for (int i = 0; i < m_AnimationClip.AnimationClip.Length; i++)
            {
                m_Animation.AddClip(m_AnimationClip.AnimationClip[i], m_AnimationClip.AnimationClip[i].name);
            }
        }

        /// <summary>
        /// 淡入淡出播放
        /// </summary>
        /// <param name="animation"></param>
        public void Play(string animation)
        {
            Debug.Log("11");

            m_Animation.CrossFade(animation, 0.2f, PlayMode.StopAll);
        }

        /// <summary>
        /// 停止
        /// </summary>
        /// <param name="animation"></param>
        public void Stop(string animation)
        {
            m_Animation.Stop(animation);
        }



    }

}