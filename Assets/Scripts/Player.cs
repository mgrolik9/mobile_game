using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public TouchInput myTouch;
    public GameObject knife;
    public Transform KnifePosition;

    private Collider2D myCollider;

    //private Touch firstFinger;

    void Start()
    {
        myCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (myCollider == Physics2D.OverlapPoint(myTouch.endPos) && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                ThrowAKnife();
            }
        }
    }

     private void ThrowAKnife()
    {
        Instantiate(knife, KnifePosition.position, Quaternion.Euler(0, 0, 0));
    }
}