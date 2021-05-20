using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class Node2
{
    public abstract bool Invoke2();
}

public class CompositeNode2 : Node2
{
    public override bool Invoke2()
    {
        throw new System.NotImplementedException();
    }

    public void AddChild2(Node2 node)
    {
        childrens2.Push(node);
    }

    public Stack<Node2> GetChildrens2()
    {
        return childrens2;
    }
    private Stack<Node2> childrens2 = new Stack<Node2>();
}

public class Selector2 : CompositeNode2
{
    public override bool Invoke2()
    {
        foreach (var node in GetChildrens2())
        {
            if (node.Invoke2())
            {
                return true;
            }
        }
        return false;
    }
}

public class Sequence2 : CompositeNode2
{
    public override bool Invoke2()
    {
        bool p = false;
        foreach (var node in GetChildrens2())
        {
            if (node.Invoke2() == false)
            {
                p = true;
            }
        }
        return !p;
    }
}

public class Recovery : Node2
{
    public BossAct Boss
    {
        set { _Boss = value; }
    }
    private BossAct _Boss;
    public override bool Invoke2()
    {
        return _Boss.Recovery();
    }

}

public class SuoerDefend : Node2
{
    public BossAct Boss
    {
        set { _Boss = value; }
    }
    private BossAct _Boss;
    public override bool Invoke2()
    {
        return _Boss.SuoerDefend();
    }


}
public class BasicAttack : Node2
{
    public BossAct Boss
    {
        set { _Boss = value; }
    }
    private BossAct _Boss;
    public override bool Invoke2()
    {
        return _Boss.BasicAttack();
    }
}
public class SkillAttack : Node2
{
    public BossAct Boss
    {
        set { _Boss = value; }
    }
    private BossAct _Boss;
    public override bool Invoke2()
    {
        return _Boss.SkillAttack();
    }
}

public class TheEnd : Node2
{
    public BossAct Boss
    {
        set { _Boss = value; }
    }
    private BossAct _Boss;
    public override bool Invoke2()
    {
        return _Boss.TheEnd();
    }
}



