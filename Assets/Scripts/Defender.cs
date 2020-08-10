using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{ 
    [SerializeField] int starCost;


    public int GetStarCost()
    {
        return starCost;
    }

    public void AddStars(int amount)
    {
        FindObjectOfType<StarDisplay>().AddStars(amount);
    }

    
    
}
