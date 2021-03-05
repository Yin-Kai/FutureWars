using UnityEngine;
using System.IO;
using System.Text;



namespace FutureWars.Audio
{

    /// <summary>
    /// 管理AudioClip
    /// </summary>
    public class SoundClip
    {
        /// <summary>
        /// 从配置文件中读取clips
        /// txt文件开头为数量
        /// 后面每一行为clipName fileName
        /// </summary>
        string[] clipsName;
        string path;
        AudioClip[] allClip;

        public SoundClip(string characterName)
        {
            ReadConfig(characterName);
            LoadClips();
        }


        void ReadConfig(string characterName)
        {
            path = SoundConfig.GetPath(characterName);

            clipsName = SoundConfig.GetClipsName(characterName);
        }



        void LoadClips()
        {
            allClip = new AudioClip[clipsName.Length];

            for (int i = 0; i < clipsName.Length; i++)
            {
                allClip[i] = Resources.Load<AudioClip>(path + clipsName[i]);
            }

        }

        public AudioClip FindClipByName(string clipName)
        {
            for (int i = 0; i < clipsName.Length; i++)
            {
                if (clipsName[i].Equals(clipName))
                {
                    return allClip[i];
                }
            }

            return null;
        }

    }

}