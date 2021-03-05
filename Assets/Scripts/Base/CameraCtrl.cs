using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraCtrl : MonoBehaviour
{
    //单元格像素大小
    public static float pixelToUnit = 100f;
    //缩放比例
    public static float scale = 1f;
    //默认分辨率
    public static Vector2 nativeResolution = new Vector2(1920, 1080);

    GameObject player;
    public GameObject Player { set => player = value; }

    void Awake()
    {
        var camera = GetComponent<Camera>();

        if (camera.orthographic)
        {
            scale = Screen.height / nativeResolution.y;
            pixelToUnit *= scale;
            camera.orthographicSize = (Screen.height / 2) / pixelToUnit;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            gameObject.transform.position = player.transform.position + new Vector3(0f, 0f, -10f);
        }
    }
}

