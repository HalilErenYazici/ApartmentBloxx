using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    MeshRenderer meshRenderer;
    public GameObject entry, house;
    public float number1, number2;
    public bool isSpawn;
    public bool isEntry;

    void Start()
    {
        InvokeRepeating("Spawn", number1, number2);
        meshRenderer = GetComponent<MeshRenderer>();
        isEntry = true;
        isSpawn = true;
    }
    void Update()
    {
        if(isSpawn)
        {
            meshRenderer.enabled = true;
        }
        if(!isSpawn)
        {
            meshRenderer.enabled = false;
        }
    }
    void Spawn()
    {
        if(isSpawn)
        {
            if(isEntry)
            {
                Instantiate(entry, transform.position, transform.rotation);
                isSpawn = false;
            }

            if(!isEntry)
            {
                Instantiate(house, transform.position, transform.rotation);

                isSpawn = false;
            }
            
        }
    }
}
