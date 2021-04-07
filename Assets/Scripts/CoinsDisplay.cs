using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsDisplay : MonoBehaviour
{

    [SerializeField] int coins = 100;
    Text coinsText;

    // Start is called before the first frame update
    void Start()
    {
        coinsText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        coinsText.text = coins.ToString();
    }

    public bool HaveEnoughCoins(int amount)
    {
        //return true if coins >= amount
        return coins >= amount;
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        UpdateDisplay();
    }

    public void SpendCoins(int amount)
    {
        //Make sure player doesn't spend coins they don't have
        if (coins >= amount)
        {
            coins -= amount;
            UpdateDisplay();
        }
    }
}
