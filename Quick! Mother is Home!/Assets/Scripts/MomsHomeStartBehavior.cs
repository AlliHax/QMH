using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MomsHomeStartBehavior : MonoBehaviour {
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        animator.Play("momshome");
    }
}
