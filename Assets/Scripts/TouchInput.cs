using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    public GameObject player;
    private Touch firstFinger;
    private int tapCount;
    private Vector2 targetPos;

    public float moveDistance = 5;

    private Vector2 startPos;
    public Vector2 endPos;

    private Vector2 dir;

    public Animator playerAnimator;
    public SpriteRenderer mySprite;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 2;
        float step = speed * Time.deltaTime;

        float dist = Vector3.Distance(player.transform.position, targetPos);
        playerAnimator.SetFloat("Speed", dist);


        player.transform.position = Vector3.MoveTowards(player.transform.position, targetPos, step);
        dir = (endPos - startPos).normalized;

        if (Input.touchCount > 0)
        {
            firstFinger = Input.GetTouch(0);
            tapCount = firstFinger.tapCount;

            switch (firstFinger.phase)
            {
                case TouchPhase.Began:
                    startPos = Camera.main.ScreenToWorldPoint(firstFinger.position);
                    endPos = startPos;
                    break;

                case TouchPhase.Moved:
                    endPos = Camera.main.ScreenToWorldPoint(firstFinger.position);
                    break;

                case TouchPhase.Ended:

                    if (tapCount == 2)
                    {
                        //DoubleTap();
                    }

                    MoveDirection();

                    CheckSwipe();

                    break;
            }
        }
    }

    void DoubleTap()
    {
        Debug.Log("Double Tap");
        Vector2 newPos = Camera.main.ScreenToWorldPoint(firstFinger.position);
        player.transform.position = newPos;
    }

    void MoveDirection()
    {
        Vector3 playerPoint = Camera.main.WorldToScreenPoint(player.transform.position);
        float dist = Vector3.Distance(firstFinger.position, playerPoint);
        if(dist > 150 && firstFinger.position.x < playerPoint.x)
        {
            Move(-moveDistance);
            mySprite.flipX = true;
        }
        else if(dist > 150 && firstFinger.position.x > playerPoint.x)
        {
            Move(moveDistance);
            mySprite.flipX = false;
        }
    }

    private void Move(float offset)
    {
        targetPos = player.transform.position + new Vector3(offset, 0, 0);
    }

    private void CheckSwipe()
    {
        if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
        {
            if (dir.x > 0)
            {
                Move(moveDistance*2);
            }
            else 
            {
                Move(-moveDistance*2);
            }
        }
        else
        {
            if (dir.y > 0)
            {
                Debug.Log("swipe up");
            }
        }
    }
}
