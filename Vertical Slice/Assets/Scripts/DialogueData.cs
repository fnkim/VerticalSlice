using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Names {Null, Yuna, Miri, You, Boy}

public enum AnimChange {Null, Idle, Sway, Tilt, Anxious}

[Serializable]
public class DialogueData
{
    public bool hideBox = false;

    //public Sprite _sprite;
    //public Sprite _portrait;
    public Names _name;
    public bool showSprite = false;
    public bool hideSprite = false;
    public AnimChange animChange;

    //public bool fadeIn = false;
    //public bool fadeOut = false;


    public Features[] newFeature;
    
    public string _dialogueText;
}