using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public GameObject wood;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.name.ToString());
        if (col.name == "Balta")
        {

            Instantiate(wood, this.gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
