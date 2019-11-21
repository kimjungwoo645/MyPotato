using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Potato potato;
    [SerializeField] GameObject stones;

    int score;

    enum State
    {
        GAMEREADY, GAMEPLAY, GAMEOVER
    }
    State state;

    private void Start()
    {
        stones.SetActive(false);
        state = State.GAMEREADY;
        potato.SetKinematic(true);
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
    }
    public void GameOver()
    {
        state = State.GAMEOVER;

        ScrollObject[] scrollObjects = GameObject.FindObjectsOfType<ScrollObject>();

        foreach(ScrollObject scrollObject in scrollObjects)
        {
            scrollObject.enabled = false;
        }
    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
