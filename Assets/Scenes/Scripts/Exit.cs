using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    //Exit 버튼을 눌렀을 때 동작
    public void OnExit()
    {
        //게임 종료
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit(); 
        #endif

    }
    // Update is called once per frame
    void Update()
    {

    }
}
