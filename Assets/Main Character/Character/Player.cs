using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public static int HeroHp;
    public static Vector3 HeroPos;
    public GameObject Prefab_coin;
    float DirR;

    RaycastHit hit;
    float MaxDistance = 1.0f;
    public LayerMask LayerMaskWall;

    // Start is called before the first frame update
    void Start()
    {
        HeroPos = gameObject.transform.position;
        HeroHp = 100;
        DirR = 0;

    }

    void Update (){
        Vector3 Dir = new Vector3(Mathf.Sin(DirR / 180.0f * 3.14f), 0, Mathf.Cos(DirR / 180.0f * 3.14f));
        float speed = 0.2f;

        Vector3 LeftDir = new Vector3(Mathf.Sin((DirR - 60.0f) / 180.0f * 3.14f), 0, Mathf.Cos((DirR - 60.0f) / 180.0f * 3.14f));
        Vector3 RightDir = new Vector3(Mathf.Sin((DirR + 60.0f) / 180.0f * 3.14f), 0, Mathf.Cos((DirR + 60.0f) / 180.0f * 3.14f));

        Vector3 Ray = new Vector3(transform.position.x, 1, transform.position.z);
        Debug.DrawRay(Ray, transform.forward * MaxDistance, Color.blue, 0.3f);
        Debug.DrawRay(Ray, -transform.forward * MaxDistance, Color.blue, 0.3f);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (Physics.Raycast(Ray, transform.forward, out hit, MaxDistance, LayerMaskWall) == false)
                gameObject.transform.position += Dir * speed;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (Physics.Raycast(Ray, -transform.forward, out hit, MaxDistance, LayerMaskWall) == false)
                gameObject.transform.position -= Dir * speed;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (Physics.Raycast(Ray, LeftDir, out hit, MaxDistance, LayerMaskWall) == false)
                DirR -= 1.0f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (Physics.Raycast(Ray, RightDir, out hit, MaxDistance, LayerMaskWall) == false)
                DirR += 1.0f;
        }

        gameObject.transform.rotation = Quaternion.Euler(0, DirR, 0);
        HeroPos = gameObject.transform.position;

        if (Input.GetKeyDown(KeyCode.Space))  //동전 발사
        {
            GameObject coin = GameObject.Instantiate(Prefab_coin)
                as GameObject;
            coin.GetComponent<ShootingCoin>().Dir = Dir;
            coin.transform.parent = null;
            coin.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 180));
            coin.gameObject.layer = LayerMask.NameToLayer("Coin");
            coin.transform.position = new Vector3(HeroPos.x, HeroPos.y+1.5f, HeroPos.z);    //Player 위치에서 발사
        }

        if(HeroHp <= 0)
        {
            SceneManager.LoadScene("GameOver1");
        }
    }

    void OnGUI()
    {
        GUIStyle style;
        Rect rect;
        int w = Screen.width, h = Screen.height;
        rect = new Rect(0, 0, w, h * 4 / 100);
        style = new GUIStyle();
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 4 / 100;
        style.normal.textColor = Color.white;

        string text = " Player HP " + "\n" + " Coin : " + Trigger.coinCnt;
        GUI.Label(rect, text, style);
    }
}

