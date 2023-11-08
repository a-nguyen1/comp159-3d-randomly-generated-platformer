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

    private Material material;

    private ScoreController score;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
        score = GameObject.FindGameObjectWithTag("GameController").GetComponent<ScoreController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Random.Range(0, 750) < 1)
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
            var previousColor = material.color;
            material.color = Color.yellow;
            yield return new WaitForSeconds(3);
            if (material.color == Color.yellow)
            {
                flipping = true;
                material.color = Color.red;
                for (int degrees = 0; degrees < 360; degrees++)
                {
                    yield return new WaitForSeconds(0.05f);
                    var transform1 = transform;
                    var rotate = transform1.rotation;
                    transform1.rotation = Quaternion.Euler(xAxisFlip ? new Vector3(rotate.x + degrees, rotate.y, rotate.z) : new Vector3(rotate.x, rotate.y, rotate.z + degrees));
                }
                flipping = false;
            }
            material.color = previousColor;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // lower platform when in contact with player
        if (other.CompareTag("Player"))
        {
            if (!flipping)
            {
                if (material.color != Color.green)
                {
                    material.color = Color.green;
                    score.IncrementScore();
                }
            }
            var transform1 = transform;
            var position = transform1.position;
            Vector3 newPosition = new Vector3(position.x, position.y - 0.05f, position.z);
            position = newPosition;
            transform1.position = position;
            
        }
    }
}
