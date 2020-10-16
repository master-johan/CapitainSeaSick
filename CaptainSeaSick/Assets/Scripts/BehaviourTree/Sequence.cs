using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Node
{
    protected List<Node> nodeList = new List<Node>();

    public Sequence(List<Node> nodes)
    {
        this.nodeList = nodes;
    }
    public override NodeState Evaluate()
    {
        bool isRunning = false;

        foreach (var node in nodeList)
        {
            switch(node.Evaluate())
            {
                case NodeState.Running:
                    isRunning = true;
                    break;
                case NodeState.Success:
                    break;
                case NodeState.Failiure:
                    _nodeState = NodeState.Failiure;
                    return _nodeState;
                    default:
                    break;

            }
        }
        _nodeState = isRunning ? NodeState.Running : NodeState.Success;
        return _nodeState;
    }
}
