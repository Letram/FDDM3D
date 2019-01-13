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
    private int shots;
    private bool stopped;
	// Use this for initialization
	void Start () {
        wallHealth = 2;
        shots = player.GetComponent<PlayerController>().getRemainingShots();
        shotsCounter.text = "Lives: " + shots;
        stopped = false;
    }

    public int getWallHealth()
    {
        return wallHealth;
    }

    private void Update()
    {
        if(stopped && Input.GetKeyUp(KeyCode.R))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
    private void OnEnable()
    {
        EventManager.onShotFinished += updatePlayerShots;
    }

    private void OnDisable()
    {
        EventManager.onShotFinished -= updatePlayerShots;
    }

    private void updatePlayerShots()
    {
        shots = player.GetComponent<PlayerController>().getRemainingShots();
        shotsCounter.text = "Lives: " + shots;
        if (shots <= 0)
        {
            playerLosePanel.SetActive(true);
            stopped = true;
        }
    }
}
