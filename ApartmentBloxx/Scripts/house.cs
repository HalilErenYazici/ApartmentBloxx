using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class house : MonoBehaviour
{
    Rigidbody rb;
    BoxCollider box;
    house home;
    public Hook hook;
    public GameManager gameManager;
    public GameObject mainHook;
    public GameObject gameCamera;
    public bool isHold;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        box = GetComponent<BoxCollider>();
        home = GetComponent<house>();

        mainHook = GameObject.Find("MainHook");
        gameCamera = GameObject.Find("Main Camera");
        hook = (Hook)FindObjectOfType(typeof(Hook));
        gameManager = (GameManager)FindObjectOfType(typeof(GameManager));

        isHold = true;
    }
    void LateUpdate()
    {
        if(isHold)
        {
            transform.position = new Vector3(mainHook.transform.position.x, transform.position.y, transform.position.z);
        }

        if(Input.GetMouseButtonDown(0))
        {
            rb.isKinematic = false;
            box.enabled = true;
            hook.isSpawn = true;
            isHold = false;

            hook.transform.position = new Vector3(0, hook.transform.position.y + 5, 0);
            hook.isEntry = false;

            gameManager.score++;

            home.enabled = false;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        gameCamera.SetActive(false);
        Destroy(mainHook.gameObject);
        hook.isSpawn = false;
    }
}
