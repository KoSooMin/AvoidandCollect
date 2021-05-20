using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Sequence root = new Sequence();
    private Selector selector = new Selector();
    private Sequence seqMoveAttack = new Sequence();
    private Sequence seqDead = new Sequence();
    //private Sequence seqStop = new Sequence();

    private FollowTarget moveForTarget = new FollowTarget();
    private MoveFree moveBackForTarget = new MoveFree();
    private Attack m_OnAttack = new Attack();
    private IsDead m_IsDead = new IsDead();
    private StopWhile stopwhile = new StopWhile();

    private EnemyAct m_Enemy;
    private IEnumerator behaviorProcess;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start Tree");
        m_Enemy = gameObject.GetComponent<EnemyAct>();
        root.AddChild(selector);
        selector.AddChild(seqDead);
        selector.AddChild(seqMoveAttack);
        //selector.AddChild(seqStop);

        moveForTarget.Enemy = m_Enemy;
        moveBackForTarget.Enemy = m_Enemy;
        m_OnAttack.Enemy = m_Enemy;
        m_IsDead.Enemy = m_Enemy;
        stopwhile.Enemy = m_Enemy;

        seqMoveAttack.AddChild(moveForTarget);
        seqMoveAttack.AddChild(m_OnAttack);
        seqMoveAttack.AddChild(moveBackForTarget);
        seqMoveAttack.AddChild(stopwhile);

        seqDead.AddChild(m_IsDead);

        //seqStop.AddChild(stopwhile);

        behaviorProcess = BehaviorProcess();
        StartCoroutine(behaviorProcess);
    }

    public IEnumerator BehaviorProcess()
    {
        while (root.Invoke())
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