using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterKnife : MonoBehaviour
{
    public float speed = 2f;

    private Vector2 direction = Vector2.up;

    void Update()
    {
        transform.Translate(direction * Time.deltaTime * speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            EventManager.PlayerHit();
        }
    }
    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}