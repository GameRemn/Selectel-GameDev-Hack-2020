using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardCreator : MonoBehaviour
{
    public Text text;
    public RectTransform baseRt;
    public Card nowCard;
    public void CreateCard(Card card)
    {
        Card newCard = Instantiate(card, baseRt.transform);
        newCard.GetComponent<MoveCard>().baseRt = baseRt.GetComponent<RectTransform>();
        newCard.questionText = text;
        newCard.СhangeText();
    }

    public void Destroy(Card card)
    {
        
    }
}
