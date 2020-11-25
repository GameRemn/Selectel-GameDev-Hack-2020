using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDeck : MonoBehaviour
{
    public List<Condition> conditions;
    public List<Card> cards;

    public int chance;
    // Start is called before the first frame update
    void Start()
    {
        if (conditions.Count != 0)
        {
            foreach (var condition in conditions)
            {
                condition.resource.decks.Add(this);
            }
        }
    }

    public void CalculateChance()
    {
        int newChance = 0;
        foreach (var condition in conditions)
        {
            if (condition.resource.value >= condition.fromResourceNumber &&
                condition.resource.value <= condition.toResourceNumber)
            {
                newChance += condition.trueChance;
            }
        }

        chance = newChance;
    }
}

[System.Serializable]
public class Condition
{
    public Resource resource;
    [Range(0, 100)]
    public int fromResourceNumber;
    [Range(0, 100)]
    public int toResourceNumber;
    public int trueChance;
}