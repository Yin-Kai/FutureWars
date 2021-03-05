using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace FutureWars.Animation
{

    /// <summary>
    /// 管理动画文件
    /// </summary>
    public class AnimationClipCtrl
    {
        //动画文件
        AnimationClip[] m_AnimationClips;
        public AnimationClip[] AnimationClip { get => m_AnimationClips; }

        public AnimationClipCtrl(string characterName)
        {
            LoadClips(characterName);
        }



        void LoadClips(string characterName)
        {
            string path = AnimationConfig.GetPath(characterName);
            string[] names = AnimationConfig.GetClipsName(characterName);

            m_AnimationClips = new AnimationClip[names.Length];

            Debug.Log(path);
            Debug.Log(names);

            for (int i = 0; i < names.Length; i++)
            {
                m_AnimationClips[i] = Resources.Load<AnimationClip>(path + names[i]);
            }
        }


        /// <summary>
        /// 查找AnimationClip
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public AnimationClip FindClip(string name)
        {
            for (int i = 0; i < m_AnimationClips.Length; i++)
            {
                if (m_AnimationClips[i].name.Equals(name))
                {
                    return m_AnimationClips[i];
                }
            }
            return null;
        }
    }

}