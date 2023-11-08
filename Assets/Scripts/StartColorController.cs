using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartColorController : MonoBehaviour
{
    private Material[] material;
    // Start is called before the first frame update
    void Start()
    {
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        material = new Material[renderers.Length];
        for (int x = 0; x < renderers.Length; x++)
        {
            material[x] = renderers[x].material;
        }
        StartCoroutine("StartSequence");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator StartSequence()
    {
        foreach (var mat in material)
        {
            mat.color = Color.red;
        }
        yield return new WaitForSeconds(1);
        foreach (var mat in material)
        {
            mat.color = Color.yellow;
        }
        yield return new WaitForSeconds(1);
        foreach (var mat in material)
        {
            mat.color = Color.green;
        }
    }
}
