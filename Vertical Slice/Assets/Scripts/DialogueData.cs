using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Names {Null, Boy, You}
[Serializable]
public class DialogueData
{
    public bool hideBox = false;
    public Sprite _sprite;
    public Names _name;
    public bool hideSprite = false;
    public bool fadeIn = false;
    public bool fadeOut = false;
    
    public string _dialogueText;
}