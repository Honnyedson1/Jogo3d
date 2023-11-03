using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controler : MonoBehaviour
{
    public Text coinText;
    private int coins = 0;

    void Start()
    {
        UpdateCoinText();
    }

    public void AddCoin()
    {
        coins++;
        UpdateCoinText();
    }

    void UpdateCoinText()
    {
        coinText.text = " " + coins;
    }
}
