using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CardCreator : MonoBehaviour
{
    public float duration;
    public Text text;
    public RectTransform baseRt;
    public DecksManager decksManager;
    public Card nowCard;
    public void CreateCard(Card card)
    {
        Card newCard = Instantiate(card, baseRt.transform);
        newCard.transform.DORotate(new Vector3(0, 0, 0), duration);
        newCard.GetComponent<MoveCard>().baseRt = baseRt.GetComponent<RectTransform>();
        newCard.questionText = text;
        newCard.СhangeText();
        newCard.decksManager = decksManager;
    }

    public void Destroy(Card card)
    {
        
    }
}
