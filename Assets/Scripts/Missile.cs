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

    public void LaunchMissile(Vector2 direction, Vector2 position)
    {
        gameObject.transform.position = position;
        missileDirection = direction;
        exploded = false;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        rb2d.velocity = missileDirection * speed;
    }

    public virtual void OnTriggerEnter2D(Collider2D other) {
        ManageTrigger();
    }

    //Implemented this way because inheritance doesnt always work on monobehaviours methods
    public virtual void ManageTrigger()
    {
        exploded = true;
    }
}
