using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    bool isStart = false;
    bool isEnd = false;
    bool isPause = false;
    public GameObject gamingPanel;
    public GameObject gamePausePanel;
    public GameObject gameOverPanel;
    public GameObject player;

    private PlayerAttribute playerAttribute;
    // Start is called before the first frame update
    void Awake()
    {
        playerAttribute = player.GetComponent<PlayerAttribute>();
        playerAttribute.gameLogic = this;

        GameStart();
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart&&!isPause&&!isEnd)
        {
            if (Input.GetKeyDown(KeyCode.P)||Input.GetKeyDown(KeyCode.Escape))
                GamePause();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.P)||Input.GetKeyDown(KeyCode.Escape))
                GameResume();
        }
    }
    public void GameStart()
    {
        isStart = true;
        isPause = isEnd = false;
    }
    public void GameOver()
    {
        gamingPanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }
    public void GamePause()
    {
        isPause = true;
        gamingPanel.SetActive(false);
        gamePausePanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void GameResume()
    {
        isPause = false;
        gamingPanel.SetActive(true);
        gamePausePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
