using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] GameObject platform;
    [SerializeField] GameObject startingPlatform;
    [SerializeField] private Vector3 initialPosition;
    [SerializeField] private int numberOfPlatforms;
    [SerializeField] private float platformHorizontalOffset;
    // Start is called before the first frame update
    void Start()
    {
        GameObject start = Instantiate(startingPlatform, initialPosition, Quaternion.identity);
        Destroy(start, 3); // destroy start platform after 3 seconds
        List<GameObject> platforms = new List<GameObject>();
        Vector3 newPosition = initialPosition;
        GameObject floor = Instantiate(platform, newPosition, Quaternion.identity);
        platforms.Add(floor);
        for (int index = 0; index < numberOfPlatforms; index++)
        {
            floor = Instantiate(platform, newPosition, Quaternion.identity);
            newPosition.x += initialPosition.x + Random.Range(-platformHorizontalOffset, platformHorizontalOffset);
            newPosition.y = initialPosition.y;
            newPosition.z += initialPosition.z + Random.Range(-platformHorizontalOffset, platformHorizontalOffset);
            platforms.Add(floor);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
