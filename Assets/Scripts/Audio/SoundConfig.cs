using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FutureWars.Audio
{

    /// <summary>
    /// 配置文件
    /// </summary>
    public static class SoundConfig
    {

        static string[] anna = { "室内靶场" };
        static string annaPath = "Audio/Character/Hero/Anna/";

        static string[] dogface = { "室内靶场" };
        static string dogfacePath = "Audio/Character/Npc/Dogface/";

        static string[] lord = { "室内靶场" };
        static string lordPath = "Audio/Character/Npc/Lord/";

        static string[] boss = { "室内靶场" };
        static string bossPath = "Audio/Character/Npc/Boss/";


        public static string[] GetClipsName(string characterName)
        {
            switch (characterName)
            {
                case "Anna":
                    return anna;
                case "Dogface":
                    return dogface;
                case "Lord":
                    return lord;
                case "Boss":
                    return boss;
                default:
                    return null;
            }
        }


        public static string GetPath(string characterName)
        {
            switch (characterName)
            {
                case "Anna":
                    return annaPath;
                case "Dogface":
                    return dogfacePath;
                case "Lord":
                    return lordPath;
                case "Boss":
                    return bossPath;
                default:
                    return null;
            }
        }

    }

}