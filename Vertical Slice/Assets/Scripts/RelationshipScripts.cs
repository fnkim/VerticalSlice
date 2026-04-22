using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class RelationshipCheck
{
    public RelationshipVariable _relationship;
    public int _relationshipCondition;
    
}

[Serializable]
public class RelationshipChange
{
    public RelationshipVariable _relationship;
    public OperationType _operation;

    
}