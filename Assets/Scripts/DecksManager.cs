using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecksManager : MonoBehaviour
{
    public List<CardDeck> decks;
    public Queue<Card> cardQueue;
    public CardDeck nowDeck;
    public CardDeck startDeck;
    public CardCreator cardCreator;
    void Start()
    {
        if (startDeck)
        {
            nowDeck = startDeck;
        }
        else
        {
            nowDeck = ChanceCalculator.SelectByChance(decks);
        }

        cardCreator.CreateCard(ChanceCalculator.SelectByChance(nowDeck.cards));
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
        
    }
}
