using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FutureWars.Fsm;


namespace FutureWars.Base
{


    public class GameLoop : MonoBehaviour
    {

        SceneFsmController m_SceneController = new SceneFsmController();

        public static MonoBehaviour m_Mono;
        

        void Awake()
        {
            //保证主循环一直能执行
            DontDestroyOnLoad(gameObject);

            m_Mono = this;
        }

        // Start is called before the first frame update
        void Start()
        {
            m_SceneController.SetState(new LoginSceneState(m_SceneController));
        }

        // Update is called once per frame
        void Update()
        {
            m_SceneController.Update();
        }
    }

}