using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public GameObject oyuncu;
    void Start()
    {
        oyuncu = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = new Vector3(oyuncu.transform.position.x, oyuncu.transform.position.y+10, oyuncu.transform.position.z-10);
    }
}
