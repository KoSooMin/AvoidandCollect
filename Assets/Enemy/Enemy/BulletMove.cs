using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    DateTime oldtime; // ���Žð�
    DateTime nowtime; // ����ð�
    // Start is called before the first frame update
    void Start()
    {
        oldtime = System.DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector3.forward * 0.5f);
        nowtime = System.DateTime.Now; // ����ð� ��� ������Ʈ
        TimeSpan time = nowtime - oldtime; // ������ �ð�(����ð� - ���Žð�)
        if (time.TotalSeconds >= 3) // 3�ʰ� ��������
        {
            Destroy(gameObject, 0.0f);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Player.HeroHp -= 5;
            Destroy(gameObject, 0.0f);
        }
        if (col.gameObject.tag == "Player2")
        {
            Player2.HeroHp2 -= 5;
            Destroy(gameObject, 0.0f);
        }
    }

}
