using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    private Vector3 missileDirection;
    private Rigidbody2D rb2d;
    public bool exploded;
    public float speed;

    
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        exploded = false;
    }

    public void LaunchMissile(Vector3 direction)
    {
        missileDirection = direction;
        exploded = false;
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = missileDirection * speed;
    }

    void OnTriggerEnter2D(Collider2D other) {
        exploded = true;
    }
}
