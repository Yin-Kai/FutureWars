using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    GameObject[] m_GameObject;
    SpriteRenderer[] m_SpriteRender;

    // Start is called before the first frame update
    void Start()
    {
        m_GameObject = new GameObject[3];
        m_SpriteRender = new SpriteRenderer[3];
        m_GameObject[0] = GameObject.Find("Box/1");
        m_SpriteRender[0] = m_GameObject[0].GetComponent<SpriteRenderer>();
        m_GameObject[1] = GameObject.Find("Box/2");
        m_SpriteRender[1] = m_GameObject[1].GetComponent<SpriteRenderer>();
        m_GameObject[2] = GameObject.Find("Box/3");
        m_SpriteRender[2] = m_GameObject[2].GetComponent<SpriteRenderer>();

        StartCoroutine(Recuvery());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamageCalculation()
    {
        if (m_SpriteRender[2].enabled)
        {
            m_SpriteRender[2].enabled = false;
            return;
        }
        if(m_SpriteRender[1].enabled)
        {
            m_SpriteRender[1].enabled = false;
            return;
        }
        if (m_SpriteRender[0].enabled)
        {
            m_SpriteRender[0].enabled = false;
            return;
        }
    }

    public IEnumerator Recuvery()
    {
        while (true)
        {
            for (int i = 0; i < 3; i++)
            {
                m_SpriteRender[i].enabled = true;
            }

            yield return new WaitForSeconds(3);
        }
    }
}
