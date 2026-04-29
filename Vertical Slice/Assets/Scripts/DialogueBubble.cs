using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class DialogueBubble : MonoBehaviour
{

    private TMP_Text currentText;
    [SerializeField] private TMP_Text _npcText;
    [SerializeField] private TMP_Text _portraitText;
    [SerializeField] float TimeBtwChars = 0.03f;
    [SerializeField] public bool IsTyping = false;
    [SerializeField] public bool fullText;

    //[SerializeField] private AudioClip _dialogueAudioClip;
    //[SerializeField] private AudioSource _dialogueAudioSource;

    [SerializeField] private Image _spriteUI;

    [SerializeField] private Image _portraitUI;

    



    private GameObject currentDialogueObject;
    [SerializeField] private GameObject _npcDialogue;

    [SerializeField] private GameObject _portraitDialogue;
    [SerializeField] private GameObject _playerOptions;

    [SerializeField] private GameObject _name;
    [SerializeField] private TMP_Text _nameText;

    [SerializeField] private TMP_Text _option1;
    [SerializeField] private TMP_Text _option2;
    [SerializeField] private TMP_Text _option3;


    public void ShowDialogue(string dialogue)
    {
        Debug.Log("showing dialogue");
        gameObject.SetActive(true);

        currentText.text = dialogue;

        currentDialogueObject.SetActive(true);
        

        
        _playerOptions.SetActive(false);


        StartCoroutine(IncreaseMaxVisibleChar(dialogue));


    }



    public void HideBox()
    {
        gameObject.SetActive(false);
    }

    public void ShowName(Names _speakerName)
    {
        _name.SetActive(true);

        switch (_speakerName)
        {
        case Names.Null:
            HideName();
            break;
        case Names.Yuna:
            _nameText.text = "Yuna";
            break;
        
        case Names.Miri:

            _nameText.text = "Miri";
            break;
        case Names.Boy:
            _nameText.text = "Boy";
            break;
        case Names.You:
            _nameText.text = "You";
            break;

        default:
            break;
        }
    }



    public void ChangeSprite(Sprite newSprite)
    {
        _spriteUI.sprite = newSprite;
    }
    
    public void AddPortrait(Sprite newPortrait)
    {
        _portraitUI.gameObject.SetActive(true);
        ChangeDialogueToPortrait(true);
        _portraitUI.sprite = newPortrait;
    }

    public void RemovePortrait()
    {
        _portraitUI.gameObject.SetActive(false);
        ChangeDialogueToPortrait(false);
    }

    public void ChangeDialogueToPortrait(bool input)
    {
        if (input)
        {
            currentDialogueObject = _portraitDialogue;
            currentText = _portraitText;
            _npcDialogue.SetActive(false);
        }
        else
        {
            currentDialogueObject = _npcDialogue;
            currentText = _npcText;
            _portraitDialogue.SetActive(false);
        }


    }
    public void HideSprite()
    {
        _spriteUI.gameObject.SetActive(false);
    }


    public void HideName()
    {
        _name.SetActive(false);
    }

    public void FadingIn(bool boolean)
    {
        if (boolean)
        {
            StartCoroutine(FadeIn());
        }
        else
        {
            StartCoroutine(FadeOut());
        }
    }




    public void ShowPlayerOptions(string[] options)
    {

        _playerOptions.SetActive(true);

        _option1.text = options[0];

        if(options.Length >= 2)
        {
            _option2.transform.parent.gameObject.SetActive(true);
            _option2.text = options[1];
        }
        else 
        {
            _option2.transform.parent.gameObject.SetActive(false);
        }

        if(options.Length >= 3)
        {
            _option3.transform.parent.gameObject.SetActive(true);
            _option3.text = options[2];
        }
        else 
        {
            _option3.transform.parent.gameObject.SetActive(false);
        }
    }

    public void HideDialogue()
    {
        _playerOptions.SetActive(false);
        _npcDialogue.SetActive(false);
        gameObject.SetActive(false);

    }



    IEnumerator IncreaseMaxVisibleChar(string dialogue)
    {
        IsTyping = true;
        fullText = false;
        

        currentText.text = dialogue; //Make the text mesh's content the whole message string right at the beginning. So the characters will stay at the correct positions since the beginning
        currentText.maxVisibleCharacters = 0;
        int messageCharLength = dialogue.Length;
        


        while (currentText.maxVisibleCharacters < messageCharLength)
        {
            if (fullText)
            {
                Debug.Log("showing full text");
                //speeds up typewriter effect
                currentText.maxVisibleCharacters = messageCharLength;
                IsTyping = false;
                yield break;      
            }
                currentText.maxVisibleCharacters++;
                yield return new WaitForSeconds(TimeBtwChars);

            //_dialogueAudioSource.Play();

            
        }

        IsTyping = false;
    }



    IEnumerator FadeOut()
    {
        float alphaValue = 1f;
        Color tmp = _spriteUI.color;

        while (_spriteUI.color.a > 0)
        {
            alphaValue -= 0.06f;
            tmp.a = alphaValue;
            _spriteUI.color = tmp;
            yield return new WaitForSeconds(0.001f);
        }
        _spriteUI.gameObject.SetActive(false);
    }

    IEnumerator FadeIn()
    {
        _spriteUI.gameObject.SetActive(true);
        float alphaValue = 0f;
        Color tmp = _spriteUI.color;
        _spriteUI.color = tmp;

        while (_spriteUI.color.a < 1)
        {
            alphaValue += 0.06f;
            tmp.a = alphaValue;
            _spriteUI.color = tmp;
            yield return new WaitForSeconds(0.001f);
        }

    }



}
