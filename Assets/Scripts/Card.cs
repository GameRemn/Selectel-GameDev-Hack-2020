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
        
    }

    public void OnLeftEvent()
    {
        Destroy(gameObject);
        Debug.Log("Right");
    }

    public void OnRightEvent()
    {
        Destroy(gameObject);
        Debug.Log("Left");
    }

    
    public void AnsverEvent(ChangeReaction reaction)
    {
        foreach (var resourceChange in reaction.resourceChanges)
        {
            resourceChange.resource.Value += resourceChange.change;
        }
    }
    
    
    public void СhangeTextRight()
    {
        questionText.text = onRightReaction.textReaction;
    }

    public void СhangeTextLeft()
    {
        questionText.text = onLeftReaction.textReaction;
    }

    public void СhangeText()
    {
        questionText.text = question;
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

