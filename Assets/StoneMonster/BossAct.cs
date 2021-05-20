using System.Collections;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


public class BossAct : MonoBehaviour
{
    public GameObject Prefab_bullet;
    public SkinnedMeshRenderer m_Renderer;
    public Texture MainTexture, SecondTexture;
    //Renderer m_Renderer;

    public static int cnt = 0;

    int nTime = 0;
    Vector3 target;
    int chk = 0;

    DateTime oldtime; // 과거시간
    DateTime nowtime; // 현재시간

    DateTime oldtime2; // 과거시간
    DateTime nowtime2; // 현재시간

    DateTime oldtime3; // 과거시간
    DateTime nowtime3; // 현재시간

    float timer = 0;
    public GameObject Prefab_skill;
    public bool BasicAttack()
    {
        int random = UnityEngine.Random.Range(-21, 20) + 1;

        if (transform.position.x <= 20 && transform.position.x >= -20)
        {
            if (nTime % 30 == 0)
            {
                Instantiate(Prefab_bullet, gameObject.transform.position, gameObject.transform.rotation);
            }
            if (chk == 0)
            {
                target = new Vector3(random, gameObject.transform.position.y, gameObject.transform.position.z);
                chk = 1;
            }
            if (gameObject.transform.position == target)
            {
                chk = 0;
            }
            transform.position = Vector3.MoveTowards(transform.position, target, 0.5f);
            return true;
        }
        return false;
    }

    public bool Recovery()
    {
        TimeSpan time = nowtime - oldtime; // 지나간 시간(현재시간 - 과거시간)
        if (time.TotalSeconds >= 5) // 5초가 지났을때
        {
            oldtime = nowtime; // 현재시간을 과거시간으로 변경
            if (Player2.EnemyHp2 <= 50) // Enemy의 Hp가 50이하이면
            {
                Player2.EnemyHp2 += 5; // Enemy의 Hp를 5회복 시키기
                return true;
            }
        }
        return false;
    }
    public bool SkillAttack()
    {
        TimeSpan time2 = nowtime2 - oldtime2; // 지나간 시간(현재시간 - 과거시간)
        if (time2.TotalSeconds >= 5) // 5초가 지났을때
        {
            if (Player2.EnemyHp2 <= 80)
            {
                Debug.Log("yes");
                oldtime2 = nowtime2; // 현재시간을 과거시간으로 변경
                GameObject skill = GameObject.Instantiate(Prefab_skill)
                as GameObject;
                skill.transform.parent = null;
                skill.gameObject.layer = LayerMask.NameToLayer("Skill");
                skill.transform.position = new Vector3(Player2.HeroPos.x, Player2.HeroPos.y + 20.0f, Player2.HeroPos.z);
            }
        }
        return false;
    }
    public bool SuoerDefend()
    {
        TimeSpan time3 = nowtime3 - oldtime3;
        if (time3.TotalSeconds >= 8)
        {
            if (Player2.EnemyHp2 <= 30)
            {
                timer += Time.deltaTime;
                if (timer > 3)
                {
                    timer = 0;
                    oldtime3 = nowtime3;
                }
                cnt = 1;
                m_Renderer.material.SetTexture("_MainTex", SecondTexture);
                Debug.Log("Defend!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                return true;
            }

        }
        else
        {
            m_Renderer.material.SetTexture("_MainTex", MainTexture);
            cnt = 0;
        }
        return false;
    }

    public bool TheEnd()
    {
        if (Player2.EnemyHp2 <= 0)
        {
            SceneManager.LoadScene("End");
            Debug.Log("IsDead");
            return false;
        }
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        oldtime = System.DateTime.Now; // 게임을 시작하면 oldtime의 시간 지정
        oldtime2 = System.DateTime.Now;
        oldtime3 = System.DateTime.Now;
        nTime = 0;

        m_Renderer.material.SetTexture("_MainTex", MainTexture);
        //Fetch the Renderer from the GameObject
        ///m_Renderer = GetComponent<Renderer>();

        //Make sure to enable the Keywords
        m_Renderer.material.EnableKeyword("_NORMALMAP");
        m_Renderer.material.EnableKeyword("_METALLICGLOSSMAP");
    }

    // Update is called once per frame
    void Update()
    {
        nowtime = System.DateTime.Now; // 현재시간 계속 업데이트
        nowtime2 = System.DateTime.Now;
        nowtime3 = System.DateTime.Now;
        nTime++;
    }
}