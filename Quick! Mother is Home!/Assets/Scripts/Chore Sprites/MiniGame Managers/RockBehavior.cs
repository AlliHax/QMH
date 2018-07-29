using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehavior : MonoBehaviour {

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
