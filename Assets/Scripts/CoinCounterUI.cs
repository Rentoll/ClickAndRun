using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCounterUI : MonoBehaviour {
    private int amountOfCoins;

    [SerializeField]
    private TextMeshProUGUI text;


    private void Start() {
        amountOfCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
        UpdateCounterText();
    }
    private void UpdateCounterText() {
        text.text = "Remaining coins - " + amountOfCoins;
    }

    public void CollectCoin() {
        amountOfCoins--;
        UpdateCounterText();
    }

    public int AmountOfCoins {
        get { return amountOfCoins; }
    }
}
