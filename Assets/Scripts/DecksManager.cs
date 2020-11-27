using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecksManager : MonoBehaviour
{
    public List<CardDeck> decks;
    public List<Card> cardQueue;
    public CardDeck nowDeck;
    public CardDeck startDeck;
    public CardCreator cardCreator;
    public List<Resource> resources;
    void Start()
    {
        foreach (var deck in decks)
        {
            deck.decksManager = this;
        }
        if (startDeck)
        {
            startDeck.decksManager = this;
            nowDeck = startDeck;
        }
        else
        {
            nowDeck = ChanceCalculator.SelectByChance(decks);
        }
        nowDeck.SelectCardAndAddToQueue();
        CreateNextCard();
    }

    public void AddToQueue(Card card)
    {
        cardQueue.Add(card);
    }

    public void CreateNextCard(Card card = null)
    {
        if (card)
        {
            Debug.Log("Карта вне очереди");
            cardCreator.CreateCard(card);
        }
        else
        {
            if (cardQueue.Count == 0)
            {
                Debug.Log("Нет карт в очереди");
                nowDeck = ChanceCalculator.SelectByChance(decks);
                nowDeck.SelectCardAndAddToQueue();
                CreateNextCard();
            }
            else
            {
                cardCreator.CreateCard(cardQueue[0]);
                cardQueue.RemoveAt(0);
            }
        }
    }

    public Resource GetResource(Resource.ResourceType type)
    {
        foreach (var resource in resources)
        {
            if (resource.type == type)
                return resource;
        }

        return null;
    }
}
