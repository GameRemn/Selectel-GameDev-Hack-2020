using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [TextArea]
    public String question;
    public ChangeReaction onRightReaction;
    public ChangeReaction onLeftReaction;
    [Space(20)] public Text questionText;
    public Text rightText;
    public Text leftText;

    private void Start()
    {
        questionText.text = question;
        rightText.text = onRightReaction.textReaction;
        leftText.text = onLeftReaction.textReaction;
    }

    public void OnLeftEvent()
    {
        
    }

    public void OnRightEvent()
    {
        
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

