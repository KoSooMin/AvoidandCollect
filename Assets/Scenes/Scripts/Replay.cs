using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Replay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Replay 버튼을 눌렀을 때 동작
    public void onReplay()
    {
        //Stage1 부터 게임 다시 시작
        SceneManager.LoadScene("Stage1");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
