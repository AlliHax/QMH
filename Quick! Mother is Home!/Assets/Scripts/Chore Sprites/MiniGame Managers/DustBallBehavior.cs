using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustBallBehavior : MonoBehaviour {
    public Sprite dustBall1;
    public Sprite dustBall2;
    public Sprite dustBall3;
    public Sprite dustBall4;
    private SpriteRenderer spriteRenderer;
    public GameObject manager;
    public ManagerController managerControllerScript;

    public DustingChore dustingChoreScript;
    public GameObject dustingChoreManager;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "duster")
        {
            if (dustingChoreScript.participatedInChore == false)
            {
                managerControllerScript.participatedInChores = managerControllerScript.participatedInChores + 1;
                dustingChoreScript.participatedInChore = true;
            }
            if (this.gameObject.tag == "dustBall1")
            {
                spriteRenderer.sprite = dustBall2;
                gameObject.tag = "dustBall2";
            }
            else if (gameObject.tag == "dustBall2")
            {
                spriteRenderer.sprite = dustBall3;
                gameObject.tag = "dustBall3";
            }
            else if (gameObject.tag == "dustBall3")
            {
                spriteRenderer.sprite = dustBall4;
                gameObject.tag = "dustBall4";
            }
            else if (gameObject.tag == "dustBall4")
            {
                dustingChoreScript.dustBallRemovedCount = dustingChoreScript.dustBallRemovedCount +1;
                Debug.Log(dustingChoreScript.dustBallRemovedCount);
                Destroy(gameObject);
            }
        }
    }
}
