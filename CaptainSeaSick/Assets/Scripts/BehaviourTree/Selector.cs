using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Node
{
    protected List<Node> nodeList = new List<Node>();

    public Selector(List<Node> nodes)
    {
        this.nodeList = nodes;
    }
    public override NodeState Evaluate()
    {

        foreach (var node in nodeList)
        {
            switch (node.Evaluate())
            {
                case NodeState.Running:
                    _nodeState = NodeState.Running;
                    return _nodeState;
                    
                case NodeState.Success:
                    _nodeState = NodeState.Success;
                    return _nodeState;

                case NodeState.Failiure:
                    break;
                default:
                    break;

            }
        }
        _nodeState = NodeState.Failiure;
        return _nodeState;
    }
}