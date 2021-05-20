using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage2UI : MonoBehaviour
{
    public Slider player2bar;
    public Slider bossbar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player2bar.value = Player2.HeroHp2;
        bossbar.value = Player2.EnemyHp2;
    }
}
