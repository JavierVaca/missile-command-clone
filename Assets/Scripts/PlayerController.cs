using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private MissileManager manager;
    [SerializeField]
    public Missile[] missilePrefabs;

    // Start is called before the first frame update
    void Start()
    {
        manager = gameObject.AddComponent(typeof(MissileManager)) as MissileManager;
        manager.AddPrefabs(missilePrefabs);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
