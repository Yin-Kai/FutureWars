using System.Collections.Generic;
using UnityEngine;


namespace FutureWars.Audio
{

    /// <summary>
    /// 管理AudioSource
    /// </summary>
    public class SoundSource
    {
        List<AudioSource> allSources;
        public List<AudioSource> AllSources
        {
            get { return allSources; }
        }

        GameObject m_GameObject;

        
        public SoundSource(GameObject gameObject)
        {
            this.m_GameObject = gameObject;

            //初始时添加的AudioSource
            allSources = new List<AudioSource>();
            for (int i = 0; i < 3; i++)
                allSources.Add(m_GameObject.AddComponent<AudioSource>());
        }

        /// <summary>
        /// 获取空闲的AudioSource
        /// </summary>
        /// <returns>空闲的AudioSource</returns>
        public AudioSource GetFreeAudio()
        {
            for (int i = 0; i < allSources.Count; i++)
            {
                if (!allSources[i].isPlaying)
                    return allSources[i];
            }

            AudioSource tempAudio = m_GameObject.AddComponent<AudioSource>();
            allSources.Add(tempAudio);

            return tempAudio;
        }

        /// <summary>
        /// 释放多余的空闲AudioSource
        /// </summary>
        public void ReleaseFreeAudio()
        {
            int count = 0;
            List<AudioSource> tempAudio = new List<AudioSource>();
            for (int i = 0; i < allSources.Count; i++)
                if (!allSources[i].isPlaying)
                {
                    count++;
                    if (count > 3)
                        tempAudio.Add(allSources[i]);
                }

            for (int i = 0; i < tempAudio.Count; i++)
                allSources.Remove(tempAudio[i]);

            tempAudio.Clear();
            tempAudio = null;
        }
    }

}