using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class Node
{
    public abstract bool Invoke();
}

public class CompositeNode : Node
{
    public override bool Invoke()
    {
        throw new System.NotImplementedException();
    }

    public void AddChild(Node node)
    {
        childrens.Push(node);
    }

    public Stack<Node> GetChildrens()
    {
        return childrens;
    }
    private Stack<Node> childrens = new Stack<Node>();
}

public class Selector : CompositeNode
{
    public override bool Invoke()
    {
        foreach (var node in GetChildrens())
        {
            if (node.Invoke())
            {
                return true;
            }
        }
        return false;
    }
}

public class Sequence : CompositeNode
{
    public override bool Invoke()
    {
        bool p = false;
        foreach (var node in GetChildrens())
        {
            if (node.Invoke() == false)
            {
                p = true;
            }
        }
        return !p;
    }
}

public class FollowTarget : Node
{
    public EnemyAct Enemy
    {
        set { _Enemy = value; }
    }
    private EnemyAct _Enemy;
    public override bool Invoke()
    {
        return _Enemy.FollowTarget();
    }

}

public class MoveFree : Node
{
    public EnemyAct Enemy
    {
        set { _Enemy = value; }
    }
    private EnemyAct _Enemy;
    public override bool Invoke()
    {
        return _Enemy.MoveFree();
    }


}
public class Attack : Node
{
    public EnemyAct Enemy
    {
        set { _Enemy = value; }
    }
    private EnemyAct _Enemy;
    public override bool Invoke()
    {
        return _Enemy.Attack();
    }
}
public class StopWhile : Node
{
    public EnemyAct Enemy
    {
        set { _Enemy = value; }
    }
    private EnemyAct _Enemy;
    public override bool Invoke()
    {
        return _Enemy.StopWhile();
    }
}

public class IsDead : Node
{
    public EnemyAct Enemy
    {
        set { _Enemy = value; }
    }
    private EnemyAct _Enemy;
    public override bool Invoke()
    {
        return _Enemy.IsDead();
    }
}




