using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject heartObject;
    public Sprite heartDisabled;
    public Sprite heartEnabled;
    public GameObject heartParent;
    public GameObject PlayerheartObject;
    public GameObject PlayerheartParent;
    private GameObject[] hearts;
    private GameObject[] Playerhearts;
    private int iterator;
    private int playerIterator;
    public GameObject endPanel;


    private void OnEnable()
    {
        EventManager.BossHitEvent += DisableHeart;
        EventManager.PlayerHitEvent += PlayerDisableHeart;
        EventManager.HeartPlayerHitEvent += PlayerLost;
        EventManager.EndGameEvent += EndGame;
    }

    private void OnDisable()
    {
        EventManager.BossHitEvent -= DisableHeart;
        EventManager.PlayerHitEvent -= PlayerDisableHeart;
        EventManager.HeartPlayerHitEvent -= PlayerLost;
        EventManager.EndGameEvent -= EndGame;
    }

    void Start()
    {
        
        for(int i = 1; i < GameManager.Instance.bossHearts; i++)
        {
            Instantiate(heartObject, heartParent.transform);
        }
        hearts = GameObject.FindGameObjectsWithTag("Heart");
        iterator = hearts.Length - 1;

        for(int i = 1; i < GameManager.Instance.playerHearts; i++)
        {
            Instantiate(PlayerheartObject, PlayerheartParent.transform);
        }
        Playerhearts = GameObject.FindGameObjectsWithTag("PlayerHeart");
        playerIterator = Playerhearts.Length - 1; 

    }
    
    private void DisableHeart()
    {
       hearts[iterator].GetComponent<Image>().sprite = heartDisabled;
        iterator -= 1;
    }

    private void PlayerDisableHeart()
    {
        Playerhearts[playerIterator].GetComponent<Image>().sprite = heartDisabled;
        playerIterator -= 1;
    }

    private void PlayerLost()
    {   
        Playerhearts = GameObject.FindGameObjectsWithTag("PlayerHeart");
        if (Playerhearts.Length <= 1)
        {
            Playerhearts[playerIterator].GetComponent<Image>().sprite = heartDisabled;
            playerIterator -= 1;
        }
        else 
        {
            Playerhearts[playerIterator].GetComponent<Image>().sprite = heartDisabled;
            Playerhearts[playerIterator - 1].GetComponent<Image>().sprite = heartDisabled;
            playerIterator -= 2;
        }
    }

     private void EndGame()
     {
         endPanel.SetActive(true);
     }
}