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

    //Replay ��ư�� ������ �� ����
    public void onReplay()
    {
        //Stage1 ���� ���� �ٽ� ����
        SceneManager.LoadScene("Stage1");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
