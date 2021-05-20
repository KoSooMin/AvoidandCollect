using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2 : MonoBehaviour
{
    public static int HeroHp2;
    public static int EnemyHp2 = 100;
    public static Vector3 HeroPos;
    public GameObject Prefab_coin;
    float DirR;
    // Start is called before the first frame update
    void Start()
    {
        HeroPos = gameObject.transform.position;
        HeroHp2 = 100;
        EnemyHp2 = 100;
        DirR = 180;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Dir = new Vector3(Mathf.Sin(DirR / 180.0f * 3.14f), 0, Mathf.Cos(DirR / 180.0f * 3.14f));
        if (gameObject.transform.position.x <= 17 && gameObject.transform.position.x >= -17)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                gameObject.transform.position += new Vector3(0.5f, 0, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                gameObject.transform.position += new Vector3(-0.5f, 0, 0);
            }
        }
        else if (gameObject.transform.position.x >= 17)
        {
            gameObject.transform.position -= new Vector3(0.5f, 0, 0);
        }
        else
        {
            gameObject.transform.position += new Vector3(0.5f, 0, 0);
        }

        HeroPos = gameObject.transform.position;

        if (Input.GetKeyDown(KeyCode.Space))        //ÄÚÀÎ ½î±â
        {
            GameObject coin = GameObject.Instantiate(Prefab_coin)
                as GameObject;
            coin.GetComponent<ShootingCoin>().Dir = Dir;
            coin.transform.parent = null;
            coin.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 180));
            coin.gameObject.layer = LayerMask.NameToLayer("Coin");
            coin.transform.position = new Vector3(HeroPos.x, HeroPos.y + 5.0f, HeroPos.z);
        }

        if (HeroHp2 <= 0)
        {
            SceneManager.LoadScene("GameOver2");
        }
    }


}