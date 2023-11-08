using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] GameObject platform;
    [SerializeField] GameObject startingPlatform;
    [SerializeField] private Vector3 initialPosition;
    [SerializeField] private int numberOfPlatforms;
    [SerializeField] private int platformHorizontalOffset;

    // Start is called before the first frame update
    void Start()
    {
        GameObject start = Instantiate(startingPlatform, initialPosition, Quaternion.identity);
        Destroy(start, 3); // destroy start platform after 3 seconds
        Vector3 newPosition = initialPosition;
        Instantiate(platform, newPosition, Quaternion.identity);
        HashSet<Vector2Int> locations = new HashSet<Vector2Int> { new Vector2Int((int)newPosition.x, (int)newPosition.z) };
        StartCoroutine(AddPlatforms(locations));
    }

    private IEnumerator AddPlatforms(HashSet<Vector2Int> locations)
    {
        for (int index = 0; index < numberOfPlatforms; index++)
        {
            yield return new WaitForSeconds(1);
            List<Vector2Int> newLocations = NextLocations(locations);
            int ind = Random.Range(0, newLocations.Count);
            var newPosition = new Vector3(newLocations[ind].x, initialPosition.y, newLocations[ind].y);
            locations.Add(newLocations[ind]);
            Instantiate(platform, newPosition, Quaternion.identity);
        }
    }

    // return list of possible locations to spawn
    private List<Vector2Int> NextLocations(HashSet<Vector2Int> occupied)
    {
        int offset = platformHorizontalOffset;
        List<Vector2Int> list = new List<Vector2Int>();
        foreach (var loc in occupied)
        {
            Vector2Int newLoc = new Vector2Int(loc.x + offset, loc.y);
            if (AddNewLocation(occupied, newLoc))
            {
                list.Add(newLoc);
            }
            newLoc = new Vector2Int(loc.x - offset, loc.y);
            if (AddNewLocation(occupied, newLoc))
            {
                list.Add(newLoc);
            }
            newLoc = new Vector2Int(loc.x, loc.y + offset);
            if (AddNewLocation(occupied, newLoc))
            {
                list.Add(newLoc);
            }
            newLoc = new Vector2Int(loc.x, loc.y - offset);
            if (AddNewLocation(occupied, newLoc))
            {
                list.Add(newLoc);
            }
        }
        return list;
    }

    private static bool AddNewLocation(HashSet<Vector2Int> occupied, Vector2Int newLoc)
    {
        return !occupied.Contains(newLoc);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
