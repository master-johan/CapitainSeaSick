﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public abstract class Node
{
    protected NodeState _nodeState;

    public NodeState nodeState { get { return _nodeState; } }

    public abstract NodeState Evaluate();

}

public enum NodeState { Running, Success, Failiure}
