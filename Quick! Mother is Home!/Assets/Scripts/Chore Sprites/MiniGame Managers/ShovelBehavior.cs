using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelBehavior : MonoBehaviour {
    public Sprite emptyShovel;
    public Sprite fullShovel;
    private SpriteRenderer spriteRenderer;
    public bool shovelFull;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (shovelFull == false)
        {
            if (other.gameObject.tag == "poo")
            {
                Destroy(other.gameObject);
                spriteRenderer.sprite = fullShovel;
                shovelFull = true;
            }
        }

        if (shovelFull == true)
        {
            if (other.gameObject.tag == "bag")
            {
                spriteRenderer.sprite = emptyShovel;
                shovelFull = false;
            }
        }
    }
}
