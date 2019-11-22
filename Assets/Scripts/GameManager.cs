using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text startText;
    [SerializeField] Potato potato;
    [SerializeField] GameObject stones;
    [SerializeField] GameObject logo;
    [SerializeField] GameObject gameOver;

    int score;

    enum State
    {
        GAMEREADY, GAMEPLAY, GAMEOVER
    }
    State state;

    private void Start()
    {
        scoreText.gameObject.SetActive(false);
        stones.SetActive(false);
        state = State.GAMEREADY;
        potato.SetKinematic(true);
        gameOver.SetActive(false);
    }
    private void Update()
    {
        switch (state)
        {
            case State.GAMEREADY:
                if (Input.GetButtonDown("Fire1"))
                {
                    GameStart();
                }
                break;
            case State.GAMEPLAY:
                if(potato.IsDead)
                {
                    GameOver();
                }
                break;
            case State.GAMEOVER:
                if (Input.GetButtonDown("Fire1"))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
                break;
        }
    }
    public void GameStart()
    {
        state = State.GAMEPLAY;

        potato.SetKinematic(false);

        stones.SetActive(true);

        scoreText.gameObject.SetActive(true);
        startText.gameObject.SetActive(false);

        logo.SetActive(false);
    }
    public void GameOver()
    {
        state = State.GAMEOVER;

        ScrollObject[] scrollObjects = GameObject.FindObjectsOfType<ScrollObject>();

        foreach(ScrollObject scrollObject in scrollObjects)
        {
            scrollObject.enabled = false;
            gameOver.SetActive(true);
        }
    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
