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
    [SerializeField] private Vector2 horizontalLimit;

    private List<GameObject> platforms;
    // Start is called before the first frame update
    void Start()
    {
        GameObject start = Instantiate(startingPlatform, initialPosition, Quaternion.identity);
        Destroy(start, 3); // destroy start platform after 3 seconds
        platforms = new List<GameObject>();
        Vector3 newPosition = initialPosition;
        Instantiate(platform, newPosition, Quaternion.identity);
        for (int index = 0; index < numberOfPlatforms; index++)
        {
            Instantiate(platform, newPosition, Quaternion.identity);
            newPosition.x += initialPosition.x + Random.Range(-platformHorizontalOffset, platformHorizontalOffset);
            newPosition.z += initialPosition.z + Random.Range(-platformHorizontalOffset, platformHorizontalOffset);
            newPosition.x = Mathf.Clamp(newPosition.x, horizontalLimit.x, horizontalLimit.y);
            newPosition.z = Mathf.Clamp(newPosition.z, horizontalLimit.x, horizontalLimit.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
