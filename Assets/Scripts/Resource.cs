using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resource : MonoBehaviour
{
    public ResourceType type;
    public List<CardDeck> decks;
    public float colorChangeSpeed;
    
    [SerializeField]
    [Range(0, 100)]
    private int value;

    private Image _image;

    public int Value
    {
        get
        {
            // _text.text = value.ToString();
            ChangeColorByResourceValue(value);
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

    private IEnumerator ChangeToColor(Color color, float localColorChangeSpeed)
    {
        while (_image.color != color)
        {
            _image.color = Color.Lerp(_image.color, color, localColorChangeSpeed);
            yield return null;
        }
    }

    private void ChangeColorByResourceValue(int value)
    {
        if (value >= 0 && value <= 50)
        {
            StartCoroutine(ChangeToColor(Color.Lerp(Color.red, Color.yellow, (float)value/50), colorChangeSpeed));
        }
        else if (value > 50 && value <= 100)
        {
            StartCoroutine(ChangeToColor(Color.Lerp(Color.yellow, Color.green, (float)(value-50)/50), colorChangeSpeed));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _image = GetComponent<Image>();
        ChangeColorByResourceValue(Value);
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

    public enum ResourceType
    {
        Рабы,
        Граждане,
        Армия,
        Деньги
    }
}
