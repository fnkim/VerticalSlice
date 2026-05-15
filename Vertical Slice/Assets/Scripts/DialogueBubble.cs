using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public enum Features {ClosedEyes, Horns, Scales, VMouth3, VMouth2, VMouth1, Frown, Smile, Mouth3, Mouth2, Mouth1, GoldEyes2, GoldEyes1,RedEyes2, RedEyes1, Eyes2, Eyes, Eyebrows3, Eyebrows2, Eyebrows}
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

    [SerializeField] private GameObject _sprite;

    //[SerializeField] private Image _portraitUI;
    [SerializeField] private Image _background;


    [SerializeField] private GameObject[] _features;

    private GameObject _currentEyes;
    private GameObject _currentMouth;
    private GameObject _currentEyebrows;

    [SerializeField] private Animator _spriteAnimator;
    



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
        gameObject.SetActive(true);

        _npcText.text = dialogue;

        _npcDialogue.SetActive(true);
        

        
        _playerOptions.SetActive(false);


        StartCoroutine(IncreaseMaxVisibleChar(dialogue));


    }


    public void ChangeFeature(Features feature)
    {
        switch (feature)
        {
            case Features.ClosedEyes:
                HideFeatures("eyes", 0);
                break;
            case Features.Horns:
                _features[1].SetActive(true);
                break;
            case Features.Scales:
                _features[2].SetActive(true);
                break;
            case Features.VMouth3:
                HideFeatures("mouth", 3);
                break;
            case Features.VMouth2:
                HideFeatures("mouth", 4);
                break;
            case Features.VMouth1:
                HideFeatures("mouth", 5);
                break;
            case Features.Frown:
                HideFeatures("mouth", 6);
                break;
            case Features.Smile:
                HideFeatures("mouth", 7);
                break;
            case Features.Mouth3:
                HideFeatures("mouth", 8);
                break;
            case Features.Mouth2:
                HideFeatures("mouth", 9);
                break;
            case Features.Mouth1:
                HideFeatures("mouth", 10);
                break;
            case Features.GoldEyes2:
                HideFeatures("eyes", 11);
                break;
            case Features.GoldEyes1:
                HideFeatures("eyes", 12);
                break;
            case Features.RedEyes2:
                HideFeatures("eyes", 13);
                break;
            case Features.RedEyes1:
                HideFeatures("eyes", 14);
                break;
            case Features.Eyes2:
                HideFeatures("eyes", 15);
                break;
            case Features.Eyes:
                HideFeatures("eyes",16);
                break;
            case Features.Eyebrows3:
                HideFeatures("eyebrows", 17);
                break;
            case Features.Eyebrows2:
                HideFeatures("eyebrows", 18);
                break;
            case Features.Eyebrows:
                HideFeatures("eyebrows", 19);
                break;
        }

    }

    private void HideFeatures(string featureType, int featureNumber)
    {
        switch (featureType)
        {
            case "eyes":
                if (_currentEyes != null)
                {
                    _currentEyes.SetActive(false);
                }
                _features[featureNumber].SetActive(true);
                _currentEyes = _features[featureNumber];
                Debug.Log("changing eyes");
                break;

            case "eyebrows":
                if (_currentEyebrows != null)
                {
                    _currentEyebrows.SetActive(false);
                }
                _features[featureNumber].SetActive(true);
                _currentEyebrows = _features[featureNumber];
                break;

            case "mouth":
                if (_currentMouth != null)
                {
                    _currentMouth.SetActive(false);
                }
                _features[featureNumber].SetActive(true);
                _currentMouth = _features[featureNumber];
                break;

        }
    }


    public void HideBox()
    {
        gameObject.SetActive(false);
    }
    public void ChangeBG(Sprite input)
    {
        _background.sprite = input;
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




    public void HideSprite()
    {
        _sprite.SetActive(false);
    }

    public void ShowSprite()
    {
        _sprite.SetActive(true);
    }



    public void HideName()
    {
        _name.SetActive(false);
    }
/*
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
*/



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
    public void ChangeAnim(AnimChange newAnim)
    {
        switch (newAnim)
        {
            case AnimChange.Idle:
                _spriteAnimator.Play("None");
                break;
            case AnimChange.Sway:
                _spriteAnimator.Play("Sway");
                break;
            case AnimChange.Tilt:
                _spriteAnimator.Play("Tilting");
                break;
            case AnimChange.Anxious:
                _spriteAnimator.Play("Anxious");
                break;
        }
    }



    IEnumerator IncreaseMaxVisibleChar(string dialogue)
    {
        IsTyping = true;
        fullText = false;
        

        _npcText.text = dialogue; //Make the text mesh's content the whole message string right at the beginning. So the characters will stay at the correct positions since the beginning
        _npcText.maxVisibleCharacters = 0;
        int messageCharLength = dialogue.Length;
        


        while (_npcText.maxVisibleCharacters < messageCharLength)
        {
            if (fullText)
            {
                Debug.Log("showing full text");
                //speeds up typewriter effect
                _npcText.maxVisibleCharacters = messageCharLength;
                IsTyping = false;
                yield break;      
            }
                _npcText.maxVisibleCharacters++;
                yield return new WaitForSeconds(TimeBtwChars);

            //_dialogueAudioSource.Play();

            
        }

        IsTyping = false;
    }


/*
    IEnumerator FadeOut()
    {
        float alphaValue = 1f;
        Color tmp = _sprite.color;

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


*/
}
