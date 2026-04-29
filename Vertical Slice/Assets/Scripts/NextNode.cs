using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum OperationType{Null, Add, Subtract}

[Serializable]
public class NextNode
{
    public bool autoAdvance = false;


    [Header("Friendship Condition")]
    [Header("Leave blank if not applicable.")]
    public RelationshipCheck relationshipCheck;


    [Header("Friendship Level Change")]
    [Header("Leave blank if not applicable.")]
    public RelationshipChange relationshipChange;

    [Header("Extra Lines at the end")]
    [Header("Leave blank if not applicable.")]
    public DialogueData[] extraLines;

    [Header("Choose the next dialogue node.")]
    
    public DialogueNode _nextDialogueNode;

    public TimeOfDay timeOfDay;

}
