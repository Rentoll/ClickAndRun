using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerWorldInteraction : MonoBehaviour {
    [SerializeField]
    private CoinCounterUI coinCounterUI;
    [SerializeField]
    private EndGame endGame;
    [SerializeField]
    private GoToTouch touchControl;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision != null) {
            switch (collision.tag) {
                case "Coin":
                    coinCounterUI.CollectCoin();
                    if(coinCounterUI.AmountOfCoins == 0) {
                        touchControl.canMove = false;
                        endGame.Victory();
                    }
                    collision.gameObject.SetActive(false);
                    break;
                case "Spike":
                    touchControl.canMove = false;
                    endGame.Defeat();
                    break;
                default:
                    break;
            }
        }

    }
}
