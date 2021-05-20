using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public Vector3 Goal;
    float speed = 0.2f;
    void Start()
    {
        Goal = new Vector3(gameObject.transform.position.x, 0, gameObject.transform.position.z); //목표 지점은 Player 위치
        Destroy(gameObject, 2.0f); //2초뒤에 삭제
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Goal, speed);    //목표지점을 향해서 이동 
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Hero"))      //총알이 Hero에게 맞으면
        {
            Player2.HeroHp2 -= 10;  //Hero Hp 10 감소
            Destroy(gameObject, 0.0f);  //
        }
    }
}