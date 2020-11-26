using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public List<CardDeck> decks;

    public int value;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckDecks()
    {
        foreach (var deck in decks)
        {
            deck.CalculateChance();
        }
    }
}
