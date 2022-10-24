using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IcicleSpawner : MonoBehaviour
{
    public GameObject Icicle;
    
    void Start()
    {
        StartCoroutine(spawn());
    }

    IEnumerator spawn()
    {
        Instantiate(Icicle, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2f);
        StartCoroutine(spawn());
    }
}
