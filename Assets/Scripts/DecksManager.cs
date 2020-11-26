using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<CardDeck> decks;
    public Queue<Card> cardQueue;
    public CardDeck nowDeck;
    public CardDeck startDeck;
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
        
    }
}
