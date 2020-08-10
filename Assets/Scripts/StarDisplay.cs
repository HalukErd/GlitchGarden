using System;
using UnityEngine.UI;
using UnityEngine;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int starAmount = 100;
    
    Text textComponent;

    void Start()
    {
        textComponent = GetComponent<Text>();
        UpdateStar();
    }

    void Update()
    {
        UpdateStar();
    }

    private void UpdateStar()
    {
        textComponent.text = starAmount.ToString();
    }

    public void AddStars(int starToAdd)
    {
        starAmount += starToAdd;
        UpdateStar();
    }

    public bool SpendStars(int starToSpend)
    {
        if (starAmount >= starToSpend)
        {
            starAmount -= starToSpend;
            UpdateStar();
            return true;
        }

        return false;
    }
}
