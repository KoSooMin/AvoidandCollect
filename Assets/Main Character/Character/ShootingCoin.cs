using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingCoin : MonoBehaviour
{
    public int hit;
    public Vector3 Dir;
    void Start()
    {
        Destroy(gameObject, 4.0f);
        hit = 0;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += Dir * 0.4f;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Destroy(gameObject, 0.0f);
        }

        if (col.gameObject.layer == LayerMask.NameToLayer("Boss"))
        {
            if (BossAct.cnt == 0)
            {
                Player2.EnemyHp2 -= 1;
                hit = 1;
            }
        }
    }

    void OnGUI()
    {
        GUIStyle style;
        Rect rect;
        int w = Screen.width, h = Screen.height;
        rect = new Rect(0, 0, w, h * 4 / 100);
        style = new GUIStyle();
        style.alignment = TextAnchor.UpperRight;
        style.fontSize = h * 6 / 100;
        style.normal.textColor = Color.black;
        string text = " ";
        if (hit == 1)
            text = "Boss HP: -1!!!";
        GUI.Label(rect, text, style);
        hit = 0;
    }
}