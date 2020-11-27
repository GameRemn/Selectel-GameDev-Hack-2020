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
    public DecksManager decksManager;
    private void Start()
    {
        
    }

    public void OnLeftEvent()
    {
        AnsverEvent(onLeftReaction);
        
    }

    public void OnRightEvent()
    {
        AnsverEvent(onRightReaction);
    }

    
    public void AnsverEvent(ChangeReaction reaction)
    {
        foreach (var resourceChange in reaction.resourceChanges)
        {
            decksManager.GetResource(resourceChange.resourceType).Value += resourceChange.change;
        }

        if (reaction.nextCard)
        {
            decksManager.CreateNextCard(reaction.nextCard);
        }
        else
        {
            decksManager.CreateNextCard();
        }
        Destroy(gameObject);
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
    public Resource.ResourceType resourceType;
    public int change;
}
[System.Serializable]
public class ChangeReaction
{
    public List<ResourceChange> resourceChanges;
    public string textReaction;
    public Card nextCard;
}

