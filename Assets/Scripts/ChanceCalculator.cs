using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class ChanceCalculator
{
    public static CardDeck SelectByChance(List<CardDeck> list)
    {
        int chanceSum = 0;
        foreach (var element in list)
        {
            chanceSum += element.chance;
        }

        int elementChance = Random.Range(0, chanceSum);
        foreach (var element in list)
        {
            if (elementChance < element.chance)
            {
                return element;
            }
            else
            {
                elementChance -= element.chance;
            }
        }
        return list[0];
    }
    
    public static Card SelectByChance(List<Card> list)
    {
        int chanceSum = 0;
        foreach (var element in list)
        {
            chanceSum += element.chance;
        }

        int elementChance = Random.Range(0, chanceSum);
        foreach (var element in list)
        {
            if (elementChance < element.chance)
            {
                return element;
            }
            else
            {
                elementChance -= element.chance;
            }
        }
        return list[0];
    }
}
