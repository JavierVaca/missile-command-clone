using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private MissileManager manager;
    private Turret[] turrets;
    [SerializeField]
    public Missile[] missilePrefabs;
    

    // Start is called before the first frame update
    void Start()
    {
        manager = gameObject.AddComponent(typeof(MissileManager)) as MissileManager;
        manager.AddPrefabs(missilePrefabs);
        turrets = FindObjectsOfType<Turret>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LaunchMissileToSelectedPoint(Input.mousePosition);
        }
        else if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            LaunchMissileToSelectedPoint(touch.position);
        }
    }

    void LaunchMissileToSelectedPoint(Vector2 selectedPoint)
    {
        Vector2 endPoint = Camera.main.ScreenToWorldPoint(selectedPoint);
        Vector2 startPosition = turrets[0].gameObject.transform.position;
        Vector2 direction = endPoint - startPosition;
        manager.LaunchMissile(direction.normalized, startPosition);
    }
}
