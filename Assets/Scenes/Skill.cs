using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public Vector3 Goal;
    float speed = 0.2f;
    void Start()
    {
        Goal = new Vector3(gameObject.transform.position.x, 0, gameObject.transform.position.z); //��ǥ ������ Player ��ġ
        Destroy(gameObject, 2.0f); //2�ʵڿ� ����
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Goal, speed);    //��ǥ������ ���ؼ� �̵� 
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Hero"))      //�Ѿ��� Hero���� ������
        {
            Player2.HeroHp2 -= 10;  //Hero Hp 10 ����
            Destroy(gameObject, 0.0f);  //
        }
    }
}