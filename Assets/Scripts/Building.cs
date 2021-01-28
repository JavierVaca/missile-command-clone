using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        gameObject.SetActive(false);   
    }
}
