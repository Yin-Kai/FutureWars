using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FutureWars.Animation
{

    /// <summary>
    /// 动画配置文件
    /// </summary>
    public static class AnimationConfig
    {
        //动画的文件名字
        static string[] anna = { "Up", "Down", "Left", "Right" };

        //路径
        static string annaPath = "Animation/Hero/Anna/";

        /// <summary>
        /// 寻找文件名
        /// </summary>
        /// <param name="characterName"></param>
        /// <returns></returns>
        public static string[] GetClipsName(string characterName)
        {
            switch (characterName)
            {
                case "Anna":
                    return anna;
                default:
                    return null;
            }
        }


        /// <summary>
        /// 寻找路径
        /// </summary>
        /// <param name="characterName"></param>
        /// <returns></returns>
        public static string GetPath(string characterName)
        {
            switch (characterName)
            {
                case "Anna":
                    return annaPath;
                default:
                    return null;
            }
        }


    }

}