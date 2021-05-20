using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public static int coinCnt;
    // Start is called before the first frame update
    void Start()
    {
        coinCnt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Coin")
        {
            coinCnt++;
            Debug.Log("Trigger!");
            Destroy(col.gameObject);
        }
    }
}
