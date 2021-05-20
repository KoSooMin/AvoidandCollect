using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    DateTime oldtime; // 과거시간
    DateTime nowtime; // 현재시간
    // Start is called before the first frame update
    void Start()
    {
        oldtime = System.DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector3.forward * 0.5f);
        nowtime = System.DateTime.Now; // 현재시간 계속 업데이트
        TimeSpan time = nowtime - oldtime; // 지나간 시간(현재시간 - 과거시간)
        if (time.TotalSeconds >= 3) // 3초가 지났을때
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
