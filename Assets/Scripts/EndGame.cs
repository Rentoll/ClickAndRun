using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {
    [SerializeField]
    private GameObject winUI;
    [SerializeField]
    private GameObject defeatUI;
    public void Victory() {
        winUI.SetActive(true);
    }

    public void Defeat() {
        defeatUI.SetActive(true);
    }

    public void RestartGame() {
        SceneManager.LoadScene("Game");
    }
}
