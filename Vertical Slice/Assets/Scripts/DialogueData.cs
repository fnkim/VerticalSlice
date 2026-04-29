using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Names {Null, Yuna, Miri, You, Boy}
[Serializable]
public class DialogueData
{
    public bool hideBox = false;
    public Sprite _sprite;
    public Sprite _portrait;
    public Names _name;
    public bool hideSprite = false;
    public bool fadeIn = false;
    public bool fadeOut = false;
    
    public string _dialogueText;
}