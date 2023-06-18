using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public float smallMonsterSpeed = 1.2f;
    public float bossSpeed = 0.5f;
    public int minMonsterSpawnRate = 2;
    public int maxMonsterSpawnRate = 6;
    public int minKnifeRate = 2;
    public int maxKnifeRate = 6;
    public int bossHearts = 3;
    public int playerHearts = 4;

    public static GameManager Instance;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        } else
        {
            Instance = this;
        }
    } 

    private void OnEnable()
    {
        EventManager.BossHitEvent += BossCondition;
        EventManager.PlayerHitEvent += PlayerCondition;
        EventManager.HeartPlayerHitEvent += PlayerCondition2;
    }

    private void OnDisable()
    {
        EventManager.BossHitEvent -= BossCondition;
        EventManager.PlayerHitEvent -= PlayerCondition;
        EventManager.HeartPlayerHitEvent -= PlayerCondition2;
    }

    private void BossCondition()
    {
        bossHearts -= 1;
        if (bossHearts == 0)
        {
            EventManager.EndGame();
            Time.timeScale = 0;
        }
    }

    private void PlayerCondition()
    {
        playerHearts -= 1;
        if (playerHearts == 0)
        {
            EventManager.EndGame();
            Time.timeScale = 0;
        }
    }

    private void PlayerCondition2()
    {
        playerHearts -= 2;
        if (playerHearts == 0)
        {
            EventManager.EndGame();
            Time.timeScale = 0;
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}