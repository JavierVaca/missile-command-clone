using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class to implemnet object poooling for better performance
//Simplifies handling the missiles
public class MissileManager : MonoBehaviour
{
    private List<Missile> inactiveMissiles;
    private List<Missile> activeMissiles;
    private Missile[] missilePrefabs;

    public void AddPrefabs(Missile[] prefabs)
    {
        missilePrefabs = prefabs;
    }

    // Start is called before the first frame update
    void Start()
    {
        inactiveMissiles = new List<Missile>();
        activeMissiles = new List<Missile>();
        InstantiateMissiles();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < activeMissiles.Count; i++)
        {
            if(activeMissiles[i].exploded)
            {
                SetInactive(activeMissiles[i]);
            }
        }
        
    }

    void InstantiateMissiles()
    {
        //Iterate all missile prefabs
        for(int i = 0; i < missilePrefabs.Length; i++)
        {
            //Create multiple copies of each prefa, ideally each missile would 
            // proportinally to likeliness of each missile appearing 
            // For example more small missile than big ones
            for(int j = 0; j <= 10; j++)
            {
                Missile missile =  Instantiate(missilePrefabs[i]);
                missile.gameObject.SetActive(false);
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

    public void LaunchMissile(Vector2 direction, Vector2 position)
    {
       Missile missile = inactiveMissiles[0];
       missile.gameObject.SetActive(true);
       missile.LaunchMissile(direction, position);
       inactiveMissiles.Remove(missile);
       activeMissiles.Add(missile);
    }
}
