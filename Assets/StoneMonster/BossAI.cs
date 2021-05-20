using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    private Sequence2 root = new Sequence2();
    private Selector2 selector = new Selector2();
    private Sequence2 seqDefend = new Sequence2();
    private Sequence2 seqDead = new Sequence2();
    //private Sequence2 seq = new Sequence2();

    private Recovery moveForTarget = new Recovery();
    private SuoerDefend moveBackForTarget = new SuoerDefend();
    private BasicAttack m_OnAttack = new BasicAttack();
    private TheEnd m_IsDead = new TheEnd();
    private SkillAttack stopwhile = new SkillAttack();

    private BossAct m_Boss;
    private IEnumerator behaviorProcess2;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start Tree");
        m_Boss = gameObject.GetComponent<BossAct>();
        root.AddChild2(selector);
        selector.AddChild2(seqDead);
        selector.AddChild2(seqDefend);
        //selector.AddChild(seqStop);

        moveForTarget.Boss = m_Boss;
        moveBackForTarget.Boss = m_Boss;
        m_OnAttack.Boss = m_Boss;
        m_IsDead.Boss = m_Boss;
        stopwhile.Boss = m_Boss;

        seqDefend.AddChild2(moveForTarget);
        seqDefend.AddChild2(m_OnAttack);
        seqDefend.AddChild2(moveBackForTarget);
        seqDefend.AddChild2(stopwhile);

        seqDead.AddChild2(m_IsDead);

        //seqStop.AddChild(stopwhile);

        behaviorProcess2 = BehaviorProcess();
        StartCoroutine(behaviorProcess2);
    }

    public IEnumerator BehaviorProcess()
    {
        while (root.Invoke2())
        {
            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject, 0.0f);
        Debug.Log("Behavior process exit");
    }
    // Update is called once per frame
    void Update()
    {

    }
}