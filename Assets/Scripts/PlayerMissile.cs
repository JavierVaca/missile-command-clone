using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMissile : Missile
{

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

    }

    public override void ManageTrigger()
    {
        exploded = false;
    }

    void OnCollisionEnter2D(Collision2D other) {
        exploded = true;
        var m =other.gameObject.GetComponent<Missile>();
        m.exploded = true;
    }
}
