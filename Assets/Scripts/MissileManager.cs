using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class to implemnet object poooling for better performance
//Simplifies handling the missiles
public class MissileManager : MonoBehaviour
{
    private List<Missile> inactiveMissiles;
    private List<Missile> activeMissiles;
    
    [SerializeField]
    public GameObject[] missilePrefabs;

    // Start is called before the first frame update
    void Start()
    {
        inactiveMissiles = new List<Missile>();
        activeMissiles = new List<Missile>();
        InvokeRepeating("LaunchMissile", 2.0f, 0.3f);
        InstantiateMissiles();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Missile m in activeMissiles)
        {
            if(m.exploded)
            {
                SetInactive(m);
            }
        }
        
    }

    void InstantiateMissiles()
    {
        //Iterate all missile prefabs
        for(int i = 0; i <= missilePrefabs.Length; i++)
        {
            //Create multiple copies of each prefa, ideally each missile would 
            // proportinally to likeliness of each missile appearing 
            // For example more small missile than big ones
            for(int j = 0; j <= 10; j++)
            {
                Missile missile =  Instantiate(missilePrefabs[i]);
                missile.SetActive(false);
                inactiveMissiles.Add(missile);
            }
        }
    }

    void SetInactive(Missile m)
    {
        m.gameObject.SetActive(false);
        activeMissiles.Remove(m);
        inactiveMissiles.Add(m);
    }

    void LaunchMissile()
    {
       Missile missile = inactiveMissiles[0];
       missile.LaunchMissile(Vector3.up);
    }
}
