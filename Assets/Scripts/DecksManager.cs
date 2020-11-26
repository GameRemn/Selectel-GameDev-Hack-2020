using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<CardDeck> decks;
    public Queue<Card> cardQueue;
    public CardDeck nowDeck;
    public Card nowCard;
    public RectTransform baseRt;

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public CardDeck SelectCardDeck()
    {
        return ChanceCalculator.SelectByChance(decks);
    }

    public void CreateCard(Card newCardPrefab) //Перенести спаун в отдельный класс
    {
        var newCard = Instantiate(newCardPrefab, base.transform);
        //newCard.GetComponent<MoveCard>().baseRt = base.transform;
    }
}
