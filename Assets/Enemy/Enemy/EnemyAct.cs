using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class EnemyAct : MonoBehaviour
{
    public GameObject player;
    public GameObject Prefab_bullet;
    int nTime = 0;

    RaycastHit hit;
    float MaxDistance = 1.0f;
    public LayerMask LayerMaskWall;

    float DirR = 180.0f;
    Vector3 Dir;
    float speed = 0.1f;
    //int nTime = 0;
    public Vector3 Goal;
    public bool arrive = false;
    float distance; //목표지점과 현재위치사이 거리 측정

    //MoveFree에서 사용
    float x = 0;
    float z = 0;
    Vector3 go;
    Vector3 pastpos;

    //StopWhile에서 사용
    public bool check = true;
    bool EnemyMove = true;
    float timer = 0;

    public bool Attack()
    {
        float distance = Vector3.Distance(player.transform.position, gameObject.transform.position);
        if (distance <= 10.0f)
        {
            //Debug.Log(distance);
            if (Player.HeroHp > 0)
            {
                if (nTime % 100 == 0)
                {
                    Instantiate(Prefab_bullet, gameObject.transform.position, gameObject.transform.rotation);
                }
                return true;
            }
        }
        return false;
    }
    public bool FollowTarget()
    {
        Vector3 Ray = new Vector3(transform.position.x, 1, transform.position.z);

        if (EnemyMove)  //Enemy가 총알에 맞은게 아니면
        {
            int AInum = 0;

            if (gameObject.transform.position.x > 0 && gameObject.transform.position.z > 0) // AI (1)
            {
                if ((Player.HeroPos.x > 0 && Player.HeroPos.z > 0))    //범위내에 hero 있으면
                {
                    AInum = 1;
                    Goal = Player.HeroPos;

                    if (Physics.Raycast(Ray, transform.forward, out hit, MaxDistance, LayerMaskWall) || Physics.Raycast(Ray, -transform.forward, out hit, MaxDistance, LayerMaskWall))
                        go = Vector3.MoveTowards(gameObject.transform.position, Goal, -speed * 50.0f);  //벽에 부딪히면 뒤로 물러남
                    else
                        go = Vector3.MoveTowards(gameObject.transform.position, Goal, speed);   //앞에 벽없으면 목적지향해 이동

                    if (go.x > 49)
                        go.x = 49;
                    if (go.x < 1)
                        go.x = 1;
                    if (go.z > 49)
                        go.z = 49;
                    if (go.z < 1)
                        go.z = 1;   //범위내인지 검사

                    gameObject.transform.position = go;
                }
            }

            else if (gameObject.transform.position.x > 0 && gameObject.transform.position.z < 0) // AI (2)
            {
                if ((Player.HeroPos.x > 0 && Player.HeroPos.z < 0))
                {
                    AInum = 2;
                    Goal = Player.HeroPos;
                    if (Physics.Raycast(Ray, transform.forward, out hit, MaxDistance, LayerMaskWall) || Physics.Raycast(Ray, -transform.forward, out hit, MaxDistance, LayerMaskWall))
                        go = Vector3.MoveTowards(gameObject.transform.position, Goal, -speed * 50.0f);//벽에 부딪히면 뒤로 물러남
                    else
                        go = Vector3.MoveTowards(gameObject.transform.position, Goal, speed); //앞에 벽없으면 목적지향해 이동

                    if (go.x > 49)
                        go.x = 49;
                    if (go.x < -1)
                        go.x = -1;
                    if (go.z > -1)
                        go.z = -1;
                    if (go.z < -49)
                        go.z = -49; //범위내인지 검사

                    gameObject.transform.position = go;
                }
            }
            else if (gameObject.transform.position.x < 0 && gameObject.transform.position.z < 0) // AI (3)
            {
                if ((Player.HeroPos.x < 0 && Player.HeroPos.z < 0))
                {
                    AInum = 3;
                    Goal = Player.HeroPos;
                    if (Physics.Raycast(Ray, transform.forward, out hit, MaxDistance, LayerMaskWall) || Physics.Raycast(Ray, -transform.forward, out hit, MaxDistance, LayerMaskWall))
                        go = Vector3.MoveTowards(gameObject.transform.position, Goal, -speed * 50.0f);//벽에 부딪히면 뒤로 물러남
                    else
                        go = Vector3.MoveTowards(gameObject.transform.position, Goal, speed); //앞에 벽없으면 목적지향해 이동

                    if (go.x < -49)
                        go.x = -49;
                    if (go.x > -1)
                        go.x = -1;
                    if (go.z > -1)
                        go.z = -1;
                    if (go.z < -49)
                        go.z = -49; //범위내인지 검사
                    gameObject.transform.position = go;
                }
            }
            else if (gameObject.transform.position.x < 0 && gameObject.transform.position.z > 0) // AI (4)
            {
                if ((Player.HeroPos.x < 0 && Player.HeroPos.z > 0))
                {
                    AInum = 4;
                    Goal = Player.HeroPos;
                    if (Physics.Raycast(Ray, transform.forward, out hit, MaxDistance, LayerMaskWall) || Physics.Raycast(Ray, -transform.forward, out hit, MaxDistance, LayerMaskWall))
                        go = Vector3.MoveTowards(gameObject.transform.position, Goal, -speed * 50.0f); //벽에 부딪히면 뒤로 물러남
                    else
                        go = Vector3.MoveTowards(gameObject.transform.position, Goal, speed); //앞에 벽없으면 목적지향해 이동

                    if (go.x < -49)
                        go.x = -49;
                    if (go.x > -1)
                        go.x = -1;
                    if (go.z < 1)
                        go.z = 1;
                    if (go.z > 49)
                        go.z = 49; //범위내인지 검사

                    gameObject.transform.position = go;
                }
            }

            if (AInum != 0)
            {   
                Dir = Goal - gameObject.transform.position;
                Dir.Normalize();
                Quaternion Rot = Quaternion.LookRotation(Dir, new Vector3(0, 1, 0));
                DirR = Rot.eulerAngles.y;
                gameObject.transform.localRotation = Rot;   //플레이어 방향 회전

                Debug.Log("FollowTarget true" + AInum);
                return true;
            }

            else
                return false;

        }
        else
        {
            Debug.Log("FollowTarget false");
            return false;
        }

    }

    public bool MoveFree()
    {
        Vector3 Ray = new Vector3(transform.position.x, 1, transform.position.z);
        if (EnemyMove)
        {
            int AInum = 0;
            if (gameObject.transform.position.x > 0 && gameObject.transform.position.z > 0) // AI (1)
            {
                if (!(Player.HeroPos.x > 0 && Player.HeroPos.z > 0))    //범위내에 hero 없으면
                {
                    AInum = 1;
                    if (Physics.Raycast(Ray, transform.forward, out hit, MaxDistance, LayerMaskWall) || Physics.Raycast(Ray, -transform.forward, out hit, MaxDistance, LayerMaskWall))
                    {
                        x = UnityEngine.Random.Range(1, 49);
                        z = UnityEngine.Random.Range(1, 49);
                        Goal = new Vector3(x, 2.0f, z);
                        go = Vector3.MoveTowards(gameObject.transform.position, Goal, speed);   //벽에 닿으면  목적지 재설정
                    }
                    else
                        go = Vector3.MoveTowards(gameObject.transform.position, Goal, speed);   

                    distance = Mathf.Sqrt(Mathf.Pow((go.x - Goal.x), 2) + Mathf.Pow((go.z - Goal.z), 2));

                    while (distance < 2)  //목표지점에 도착하면 목적지 재설정
                    {
                        x = UnityEngine.Random.Range(1, 49);
                        z = UnityEngine.Random.Range(1, 49);
                        Goal = new Vector3(x, 2.0f, z);
                        distance = Mathf.Sqrt(Mathf.Pow((go.x - Goal.x), 2) + Mathf.Pow((go.z - Goal.z), 2));
                        go = Vector3.MoveTowards(gameObject.transform.position, Goal, speed);
                    }

                    if (go.x > 49)
                        go.x = 49;
                    if (go.x < 1)
                        go.x = 1;
                    if (go.z > 49)
                        go.z = 49;
                    if (go.z < 1)
                        go.z = 1;
                
                    gameObject.transform.position = go;
                }
            }

            else if (gameObject.transform.position.x > 0 && gameObject.transform.position.z < 0) // AI (2)
            {
                if (!(Player.HeroPos.x > 0 && Player.HeroPos.z < 0))
                {
                    AInum = 2;
                    if (Physics.Raycast(Ray, transform.forward, out hit, MaxDistance, LayerMaskWall) || Physics.Raycast(Ray, -transform.forward, out hit, MaxDistance, LayerMaskWall))
                    {
                        x = UnityEngine.Random.Range(1, 49);
                        z = UnityEngine.Random.Range(-49, -1);
                        Goal = new Vector3(x, 2.0f, z);
                        go = Vector3.MoveTowards(gameObject.transform.position, Goal, speed); //벽에 닿으면  목적지 재설정
                    }
                    else
                        go = Vector3.MoveTowards(gameObject.transform.position, Goal, speed); 

                    distance = Mathf.Sqrt(Mathf.Pow((go.x - Goal.x), 2) + Mathf.Pow((go.z - Goal.z), 2));

                    while (distance < 2)  //목표지점에 도착하면 목적지 재설정
                    {
                        x = UnityEngine.Random.Range(1, 49);
                        z = UnityEngine.Random.Range(-49, -1);
                        Goal = new Vector3(x, 2.0f, z);
                        distance = Mathf.Sqrt(Mathf.Pow((go.x - Goal.x), 2) + Mathf.Pow((go.z - Goal.z), 2));
                        go = Vector3.MoveTowards(gameObject.transform.position, Goal, speed);
                    }
                    if (go.x > 49)
                        go.x = 49;
                    if (go.x < -1)
                        go.x = -1;
                    if (go.z > -1)
                        go.z = -1;
                    if (go.z < -49)
                        go.z = -49;

                    gameObject.transform.position = go;
                }
            }
            else if (gameObject.transform.position.x < 0 && gameObject.transform.position.z < 0) // AI (3)
            {
                if (!(Player.HeroPos.x < 0 && Player.HeroPos.z < 0))
                {
                    AInum = 3;
                    if (Physics.Raycast(Ray, transform.forward, out hit, MaxDistance, LayerMaskWall) || Physics.Raycast(Ray, -transform.forward, out hit, MaxDistance, LayerMaskWall))
                    {
                        x = UnityEngine.Random.Range(-49, -1);
                        z = UnityEngine.Random.Range(-49, -1);
                        Goal = new Vector3(x, 2.0f, z);
                        go = Vector3.MoveTowards(gameObject.transform.position, Goal, speed); //벽에 닿으면  목적지 재설정
                    }
                    else
                        go = Vector3.MoveTowards(gameObject.transform.position, Goal, speed);

                    distance = Mathf.Sqrt(Mathf.Pow((go.x - Goal.x), 2) + Mathf.Pow((go.z - Goal.z), 2));

                    while (distance < 2)  //목표지점에 도착하면 목적지 재설정
                    {
                        x = UnityEngine.Random.Range(-49, -1);
                        z = UnityEngine.Random.Range(-49, -1);
                        Goal = new Vector3(x, 2.0f, z);
                        distance = Mathf.Sqrt(Mathf.Pow((go.x - Goal.x), 2) + Mathf.Pow((go.z - Goal.z), 2));
                        go = Vector3.MoveTowards(gameObject.transform.position, Goal, speed);
                    }

                    if (go.x < -49)
                        go.x = -49;
                    if (go.x > -1)
                        go.x = -1;
                    if (go.z > -1)
                        go.z = -1;
                    if (go.z < -49)
                        go.z = -49;

                    gameObject.transform.position = go;
                }
            }

            else if (gameObject.transform.position.x < 0 && gameObject.transform.position.z > 0) // AI (4)
            {

                if (!(Player.HeroPos.x < 0 && Player.HeroPos.z > 0))
                {
                    AInum = 4;
                    if (Physics.Raycast(Ray, transform.forward, out hit, MaxDistance, LayerMaskWall) || Physics.Raycast(Ray, -transform.forward, out hit, MaxDistance, LayerMaskWall))
                    {
                        x = UnityEngine.Random.Range(-49, -1);
                        z = UnityEngine.Random.Range(1, 49);
                        Goal = new Vector3(x, 2.0f, z);
                        go = Vector3.MoveTowards(gameObject.transform.position, Goal, speed); //벽에 닿으면  목적지 재설정
                    }
                    else
                        go = Vector3.MoveTowards(gameObject.transform.position, Goal, speed);

                    distance = Mathf.Sqrt(Mathf.Pow((go.x - Goal.x), 2) + Mathf.Pow((go.z - Goal.z), 2));

                    while (distance < 2)  //목표지점에 도착하면 목적지 재설정
                    {
                        x = UnityEngine.Random.Range(-49, -1);
                        z = UnityEngine.Random.Range(1, 49);
                        Goal = new Vector3(x, 2.0f, z);
                        distance = Mathf.Sqrt(Mathf.Pow((go.x - Goal.x), 2) + Mathf.Pow((go.z - Goal.z), 2));
                        go = Vector3.MoveTowards(gameObject.transform.position, Goal, speed);
                    }

                    if (go.x < -49)
                        go.x = -49;
                    if (go.x > -1)
                        go.x = -1;
                    if (go.z < 1)
                        go.z = 1;
                    if (go.z > 49)
                        go.z = 49;

                    gameObject.transform.position = go;
                }
            }

            if (AInum != 0)
            {
                Dir = Goal - gameObject.transform.position;
                Dir.Normalize();
                Quaternion Rot = Quaternion.LookRotation(Dir, new Vector3(0, 1, 0));
                DirR = Rot.eulerAngles.y;
                gameObject.transform.localRotation = Rot;

                Debug.Log("MoveFree true" + AInum);
                return true;
            }
            else
                return false;
        }
        else
        {
            Debug.Log("MoveFree false");
            return false;
        }
    }


    public bool StopWhile()
    {
        if (EnemyMove == false)      //shootingCoin - 총알맞으면 
        {

            timer += Time.deltaTime;
            if (timer > 3)
            {
                timer = 0;
                EnemyMove = true;
            }   //3초동안 멈춰있음
            return true;
        }
        return false;

    }

    public bool IsDead()
    {
        if (Trigger.coinCnt == 20)
        {
            SceneManager.LoadScene("Stage2");
            Debug.Log("IsDead");
            return false;
        }
        return true;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Coin")
            && gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            //Debug.Log("동전맞음");
            EnemyMove = false;       //Enemy 이동 멈춤
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        nTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        nTime++;
    }
}
