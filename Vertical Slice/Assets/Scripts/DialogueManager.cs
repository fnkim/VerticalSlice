using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;



public class DialogueManager : MonoBehaviour
{

    [SerializeField] private DialogueNode _startingNode;
    public static DialogueManager Instance { get; private set; }
    [SerializeField] private DialogueBubble _dialogue;

    public bool IsDialogueActive => _currentNode != null;
       
    



// VARIABLES THAT KEEP TRACK OF DIALOGUE STUFF
    // Sets the current dialogue node
    private DialogueNode _currentNode;


    // variable that holds the NextNode
    private NextNode _nodeToGoTo;

    // Bool that checks whether the starting dialogue lines are over or not
    private bool _dialogueOver;

    // integer for current line
    private int _currentLine;

    //variable for length of the current array of lines
    private int _lengthOfArray;

    // variable for the current DialogueData
    private DialogueData _currentData;

    // bool for whether it is waiting for the player to click a choice
    private bool _waitingForPlayerResponse;




    private void Awake()
    {
        Instance = this;
        _dialogue.HideDialogue();
    }

    private void Start()
    {
        StartDialogue(_startingNode);
    }

    public void StartDialogue(DialogueNode asset)
    {
        _currentNode = asset;
        
        //sets up the node stuff with the current node's data.
        // read the comments i left on SetupNode()
        SetupNode(_currentNode);
        //advances with current data
        Advance(_currentData);

    }

    private void Update ()
    {

        if (_currentNode == null) return;
        
        
        TypeWriter();

    }


    private void TypeWriter()
    {
  
        // if the typing effect has stopped
        if (!_dialogue.IsTyping)
        {
            // if space or mouse button click has been pressed once
            if(!_waitingForPlayerResponse && Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                if (_dialogueOver)
                {
                    // if the current line int hasn't gone over the array length and if the current node has lines
                    if (_currentLine < _lengthOfArray)
                    {
                        _currentData = _nodeToGoTo.extraLines[_currentLine];
                    }
                    else
                    {
                        _currentData = null;
                    }
                }
                //if the starting lines are still going
                else
                {
                    // if the current line int hasn't gone over the array length and if the current node has lines
                    if (_currentLine < _lengthOfArray)
                    {
                        //sets currentData to the current node's current line (which is element 0)
                        _currentData = _currentNode._lines[_currentLine];
                    }
                    else
                    {
                        _currentData = null;
                    }
                }
                Advance(_currentData);
            }
        }
        // if the typewriter effect is still going
        else
        {
            //if space or mousebutton click is being held
            if(!_waitingForPlayerResponse && Input.GetKey(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                Debug.Log("showing full text");
                //speeds up typewriter effect
                _dialogue.fullText = true;
            }         
        }
    }


    public void Advance(DialogueData _dialogueData)
    {
        // if there's no currentNode, return
        if (_currentNode == null) return;


    // ADVANCES DIALOGUE

        //if there's nothing in the current data, advance after lines
        if (_currentData == null)
        {
            AdvanceAfterLines();
        }
        //if the current line int is less than _lengthOfArray
        else if(_currentLine < _lengthOfArray)
        {
            
            
            DialogueDataManager(_dialogueData);
            _dialogue.ShowDialogue(_dialogueData._dialogueText);
            _dialogue.fullText = false;
            _currentLine++;
        }
        else
        {
            AdvanceAfterLines();
        }

    }

    private void DialogueDataManager(DialogueData input)
    {

        if (input._sprite != null)
        {
            _dialogue.ChangeSprite(input._sprite);
            if (input.fadeIn)
            {
                _dialogue.FadingIn(true);
            }
        }


        if (input._portrait == null)
        {
            _dialogue.RemovePortrait();
        }
        else
        {
            _dialogue.AddPortrait(input._portrait);
        }



        if (input.hideBox)
        {
            _dialogue.HideBox();
        }

        if (input.hideSprite)
        {
            _dialogue.HideSprite();
        }

        if (input.fadeOut)
        {
            _dialogue.FadingIn(false);
        }

        _dialogue.ShowName(input._name);

    }




    private void AdvanceAfterLines()
    {
        //basically, if the dialogue node hasn't progressed onto the extra lines yet
        if(!_dialogueOver)
        {
            //if there are reply options
            if (_currentNode._playerReplyOptions.Length != 0)
            {
                //show player options
                _waitingForPlayerResponse = true;
                _dialogue.ShowPlayerOptions(_currentNode._playerReplyOptions);

            }
            //if there are next nodes
            else if (_currentNode._nextNode.Length != 0)            
            {
                CycleFriendshipCheck(_currentNode._nextNode);
            }
            //if there aren't next nodes
            else
            {
                print("ending dialogue");
                EndDialogue();
            }
        }
        
        //advance to the next node after the extra lines
        else
        {
            // if the node to go to's next node has stuff in it
            if (_nodeToGoTo._nextDialogueNode != null)
            {
                //sets the current node to the next node
                _currentNode = _nodeToGoTo._nextDialogueNode;
                //sets up the next node's array stuff and everything
                SetupNode(_currentNode); 
                //sets the node to go to variable to null to refresh it
                _nodeToGoTo = null;
                //advances with the current data
                Advance(_currentData);
        
            }
            // if there is no next dialogue node
            else
            {
                EndDialogue();
            }

        }


    }


    private void CycleFriendshipCheck(NextNode[] nextNodeArray)
    {
        //cycle through the list of next nodes
        bool _friendshipConditionMet = false;

        for (int i = 0; i < nextNodeArray.Length; i++)
        {
            if (nextNodeArray[i].autoAdvance == true)
            {
                _friendshipConditionMet = true;
            }

            //if the index's friendship check has something in it
            if (nextNodeArray[i].relationshipCheck._relationship != null)
            {
                _friendshipConditionMet = RelationshipChecker(nextNodeArray[i].relationshipCheck);
            }   

            if (_friendshipConditionMet)
            {
                SelectedOption(i);
                break;
            } 

        }
        
        if (_friendshipConditionMet == false)
        {
            EndDialogue();
        }
    }


    private bool RelationshipChecker(RelationshipCheck relationshipCheck)
    {
        bool _hasConditionBeenMet;
        // checks for if current friendship level is >= the  required friendship level
        if (relationshipCheck._relationship.RelationshipLevel >= relationshipCheck._relationshipCondition)
        {
            _hasConditionBeenMet = true;
            Debug.Log(relationshipCheck._relationship.RelationshipLevel);
            Debug.Log(relationshipCheck._relationshipCondition);
            return _hasConditionBeenMet;
        }
        else
        {
            _hasConditionBeenMet = false;
        }
        return _hasConditionBeenMet;
    }
    public void EndDialogue()
    {
        if (_currentNode == null)
        {
            return;
        }
        _currentNode = null;
        _currentLine = 0;
        _waitingForPlayerResponse = false;
        _dialogue.HideDialogue();
    }




    public void SelectedOption(int option)
    {
        // sets variable to say the dialogue is over
        _dialogueOver = true;

        _waitingForPlayerResponse = false;
        
        //Selects which node to go to. "nodeToGoTo" contains the next dialogue node and friendship variable modifiers
        _nodeToGoTo = _currentNode._nextNode[option];

        //friendship variable
        RelationshipVariable relationshipVariable = _nodeToGoTo.relationshipChange._relationship;

        //operation to change the friendship variable
        OperationType operation = _nodeToGoTo.relationshipChange._operation;

        if (relationshipVariable != null)
        {
            switch (operation)
            {
                case OperationType.Null:
                    break;
                case OperationType.Add:
                    relationshipVariable.RelationshipLevel ++;
                    break;
                case OperationType.Subtract:
                    relationshipVariable.RelationshipLevel --;
                    break;
                default:
                    break;
                    
            }
        }

        // set current line int to 0
        _currentLine = 0;
        

        //if the node to go to has extra lines
        if (_nodeToGoTo.extraLines.Length != 0)
        {
            _lengthOfArray = _nodeToGoTo.extraLines.Length;
            // set current dialogue data to the next node to go to's 0th element extra line
            _currentData = _nodeToGoTo.extraLines[_currentLine];            
        }
        //if the node to go to doesn't have extra lines
        else
        {
            //set current node to the next dialogue node of _nodeToGoTo
            _currentNode = _nodeToGoTo._nextDialogueNode;
            SetupNode(_currentNode);
        }
        
        if (_nodeToGoTo.timeOfDay != TimeOfDay.Unchanged)
        {
            EventBus.Trigger(EventNames.NewTimeEvent, _nodeToGoTo.timeOfDay);
        }
        //advance line with the current data
        Advance(_currentData);
    }


    //sets up the next node. This means setting up the length of array and current data
    private void SetupNode(DialogueNode node)
    {
        _dialogueOver = false;
        // if the current node's lines array has more than 0 elements (basically, if it has literally anything in it)
        if (node._lines.Length != 0)
        {
            _currentLine = 0;
            //sets up length of array
            _lengthOfArray = node._lines.Length;
            //sets currentData (which is element 0) of _currentNode
            _currentData = node._lines[_currentLine];
            //turn off dialogue over to start over
        }
        // however, if the current node's lines array has nothing in it
        else
        {
            // there is no current data. this means when the code advances, it immediately moves onto the advance after lines part
            _currentData = null;
        }
    }
}


