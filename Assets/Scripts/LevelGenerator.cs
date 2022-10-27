using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {
    [Header("Number of Coins and Spikes")]
    [SerializeField]
    private int coinNumber;
    [SerializeField]
    private int spikesNumber;
    [Header("Prefabs")]
    [SerializeField]
    private GameObject coin;
    [SerializeField]
    private GameObject spikes;
    [SerializeField]
    GameObject background;
    [SerializeField]
    private Scaler scaler;
    [SerializeField]
    private CoinCounterUI coinCounter;

    private float widthOfBackground;
    private float heightOfBackground;

    private void Start() {
        scaler.ResizeToFitScreen();
        widthOfBackground = background.transform.localScale.x;
        heightOfBackground = background.transform.localScale.y;
        GenerateLevel();
    }

    private void GenerateLevel() {
        FillBackgroundWithObjects(coin, coinNumber);
        FillBackgroundWithObjects(spikes, spikesNumber);
        coinCounter.gameObject.SetActive(true);
    }

    private void FillBackgroundWithObjects(GameObject objectToInit, int numberOfObjects) {
        Vector3 objectBounds = scaler.GetObjectBounds(objectToInit) / 2;
        Vector3 spawnPlace = Vector3.zero;
        for (int i = 0; i < numberOfObjects; i++) {
            int maximumAttempts = 50;
            for(int currentAttempts = 0; currentAttempts < maximumAttempts; currentAttempts++) {
                spawnPlace = new Vector3(Random.Range(-widthOfBackground + objectBounds.x, widthOfBackground - objectBounds.x),
                                                            Random.Range(-heightOfBackground + objectBounds.y, heightOfBackground - objectBounds.y), 0);
                if(Physics2D.OverlapCircle(spawnPlace, 1f) == null) {
                    break;
                }
            }
            GameObject buf = Instantiate(objectToInit, spawnPlace, Quaternion.identity);
        }
    }

  
}
