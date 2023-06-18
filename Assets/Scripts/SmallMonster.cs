using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallMonster : MonoBehaviour
{
    Vector2 dir;
    float distance = 0.5f;
    float speed;
    private float targetTime = 2f;

    public GameObject knife;
    public GameObject strongKnife;
    // Start is called before the first frame update
    void Start()
    {   
        dir = transform.right;
        speed = GameManager.Instance.smallMonsterSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * Time.deltaTime * speed);

        targetTime -= Time.deltaTime;
        if(targetTime <= 0) {
            var randomShot = Random.Range(0,10);
            if (randomShot == 6)
            {
                ThrowSSKnife();
            }
            else {
                ThrowKnife();
            }
       
            targetTime = Random.Range(GameManager.Instance.minKnifeRate, GameManager.Instance.maxKnifeRate);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Wall"))
        {
            transform.position = transform.position + Vector3.down * distance;
            transform.Rotate(0, 180, 0);
        }
    }
    
    void ThrowKnife()
    {

        Instantiate(knife, transform.position, Quaternion.Euler(-180, 0, 0));

    }

    void ThrowSSKnife()
    {

        Instantiate(strongKnife, transform.position, Quaternion.Euler(-180, 0, 0));

    }
}
