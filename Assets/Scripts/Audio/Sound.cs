using System.Collections.Generic;
using UnityEngine;



namespace FutureWars.Audio
{

    /// <summary>
    /// 声音模块
    /// </summary>
    public class Sound
    {

        SoundSource m_SoundSource;

        SoundClip m_SoundClip;



        public Sound(GameObject gameObject,string CharacterName)
        {
            m_SoundSource = new SoundSource(gameObject);
            m_SoundClip = new SoundClip(CharacterName);
        }


        /// <summary>
        /// 播放指定的声音
        /// </summary>
        /// <param name="clipName"></param>
        public void Play(string clipName)
        {
            AudioSource tempSource = m_SoundSource.GetFreeAudio();
            tempSource.clip = m_SoundClip.FindClipByName(clipName);
            tempSource.Play();
        }


        /// <summary>
        /// 停止播放指定的声音
        /// </summary>
        /// <param name="clipName"></param>
        public void Stop(string clipName)
        {
            List<AudioSource> tempSources = m_SoundSource.AllSources;
            for (int i = 0; i < tempSources.Count; i++)
            {
                if (tempSources[i].isPlaying
                    && tempSources[i].clip.name.Equals(clipName))
                    tempSources[i].Stop();
            }
        }



    }


}