using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float maxWidth;
    private float maxHeight;
    private MissileManager manager;
    private Camera camera;
    [SerializeField]
    public Missile[] missilePrefabs;

    // Start is called before the first frame update
    void Start()
    {
        manager = gameObject.AddComponent(typeof(MissileManager)) as MissileManager;
        manager.AddPrefabs(missilePrefabs);
        maxWidth = Screen.width;
        maxHeight = Screen.height;
        camera = Camera.main;
        InvokeRepeating("LaunchMissile", 2.0f, 2.0f);
    }

    void LaunchMissile()
    {
        //Optimize by caching the corners from screen to worldposition, to avoid screentoworldpoint
        Vector3 screenPointStart = new Vector3(Random.Range(0, maxWidth), maxHeight);
        Vector2 worldPointStart = camera.ScreenToWorldPoint(screenPointStart);
        Vector3 screenPointEnd = new Vector3(Random.Range(0, maxWidth), 0);
        Vector2 worldPointEnd = camera.ScreenToWorldPoint(screenPointEnd);
        Vector2 direction = worldPointEnd - worldPointStart;
        Debug.Log("Points: " + worldPointEnd + worldPointStart + "Directoin: " + direction);
        manager.LaunchMissile(direction.normalized, worldPointStart);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
