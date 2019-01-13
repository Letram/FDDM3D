using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    private int wallHealth;
    public GameObject player;
    public TextMeshProUGUI shotsCounter;
    public GameObject playerLosePanel;
    public GameObject playerWinPanel;

    private int shots;
    private bool lost;
    private bool win;
	// Use this for initialization
	void Start () {
        wallHealth = 2;
        shots = player.GetComponent<PlayerController>().getRemainingShots();
        shotsCounter.text = "Lives: " + shots;
        lost = false;
        win = false;
    }

    public int getWallHealth()
    {
        return wallHealth;
    }

    private void Update()
    {
        if (lost && Input.GetKeyUp(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (win && Input.GetKeyUp(KeyCode.Return))
            SceneManager.LoadScene(0);
    }
    private void OnEnable()
    {
        EventManager.onShotFinished += updatePlayerShots;
        EventManager.onWallDestroyed += playerWin;
    }

    private void OnDisable()
    {
        EventManager.onShotFinished -= updatePlayerShots;
        EventManager.onWallDestroyed -= playerWin;
    }

    private void updatePlayerShots()
    {
        shots = player.GetComponent<PlayerController>().getRemainingShots();
        shotsCounter.text = "Lives: " + shots;
        if (shots <= 0)
        {
            playerLosePanel.SetActive(true);
            lost = true;
        }
    }

    private void playerWin()
    {
        playerWinPanel.SetActive(true);
        win = true;
    }
}
