using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassBehavior : MonoBehaviour {
    public Sprite uncutGrass;
    public Sprite cutGrass;
    private SpriteRenderer spriteRenderer;


    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "mower")
        {

            spriteRenderer.sprite = cutGrass;
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
