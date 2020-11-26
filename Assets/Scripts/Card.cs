using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;

public class Card : MonoBehaviour
{
    [TextArea]
    public String question;
    public ChangeReaction onRightReaction;
    public ChangeReaction onLeftReaction;
    [Space(20)] public Text questionText;

    private void Start()
    {
        changeText();
    }

    public void OnLeftEvent()
    {
        Debug.Log("Right");
    }

    public void OnRightEvent()
    {
        Debug.Log("Left");
    }

    
    public void AnsverEvent(ChangeReaction reaction)
    {
        foreach (var resourceChange in reaction.resourceChanges)
        {
            resourceChange.resource.value += resourceChange.change;
        }
    }
    
    
    public void changeTextRight()
    {
        questionText.text = question;
    }

    public void changeTextLeft()
    {
        questionText.text = onLeftReaction.textReaction;
    }

    public void changeText()
    {
        questionText.text = onRightReaction.textReaction;
    }
}

[System.Serializable]
public class ResourceChange
{
    public Resource resource;
    public int change;
}
[System.Serializable]
public class ChangeReaction
{
    public List<ResourceChange> resourceChanges;
    public string textReaction;
    public Card nextCard;
}

