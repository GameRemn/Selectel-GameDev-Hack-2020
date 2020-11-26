using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<CardDeck> decks;
    public Queue<Card> cardQueue;
    public CardDeck nowDeck;
    public Card nowCard;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public CardDeck SelectCardDeck()
    {
        return ChanceCalculator.SelectByChance(decks);
    }
}
