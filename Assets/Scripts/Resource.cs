using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resource : MonoBehaviour
{
    public List<CardDeck> decks;
    public Types resourceType;
    
    [SerializeField]
    [Range(0, 100)]
    private int value;
    
    private Text _text;

    public enum Types
    {
        Cityzenry,
        Slaves,
        Army,
        Money
    }
    
    public int Value
    {
        get
        {
            _text.text = resourceType + ": " + value;
            return value;
        }
        set
        {
            if (value > 100 || value < 0)
            {
                Debug.Log("End game");
                // @TODO вызов метода для окончания игры с проигрышем
            } else if (value >= 0 && value <= 100)
            {
                this.value = value;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<Text>();
        _text.text = resourceType + ": " + value;
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
