using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformController : MonoBehaviour
{
    private int platformType;

    private bool flipping;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Random.Range(0, 10000) < 1)
        {
            Action();
        }
    }

    public void Action()
    {
        StartCoroutine(Random.Range(0, 2) == 0 ? Flip(true) : Flip(false));
    }

    private IEnumerator Flip(bool xAxisFlip)
    {
        if (!flipping)
        {
            flipping = true;
            for (int degrees = 0; degrees < 360; degrees++)
            {
                yield return new WaitForSeconds(0.1f);
                var transform1 = transform;
                var rotate = transform1.rotation;
                transform1.rotation = Quaternion.Euler(xAxisFlip ? new Vector3(rotate.x + degrees, rotate.y, rotate.z) : new Vector3(rotate.x, rotate.y, rotate.z + degrees));
            }
            flipping = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var transform1 = transform;
            var position = transform1.position;
            Vector3 newPosition = new Vector3(position.x, position.y - 0.05f, position.z);
            position = newPosition;
            transform1.position = position;
        }
    }
}
