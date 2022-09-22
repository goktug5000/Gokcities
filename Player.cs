using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Quaternion = UnityEngine.Quaternion;

public class Player : MonoBehaviour
{
    public GameObject lumberjack;
    public int para;
    public Text paramiz;
    public Collider AllCol;

    void Start()
    {
        para = 20;
        paramiz.text = para.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Rigidbody>().Sleep();
        if (Input.GetKey(KeyCode.W)){
            this.gameObject.transform.Translate(0, 0, 10 * Time.deltaTime);
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            //this.gameObject.transform.Translate(-10*Time.deltaTime, 0, 0);
            this.gameObject.transform.Translate(0, 0, 10 * Time.deltaTime);
            this.gameObject.transform.rotation = Quaternion.Euler(0, 270, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //this.gameObject.transform.Translate(0, 0, -10 * Time.deltaTime);
            this.gameObject.transform.Translate(0, 0, 10 * Time.deltaTime);
            this.gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            //this.gameObject.transform.Translate(10 * Time.deltaTime, 0, 0);
            this.gameObject.transform.Translate(0, 0, 10 * Time.deltaTime);
            this.gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
        }


    }

    private void OnTriggerEnter(Collider col)
    {
        //Debug.Log(col.tag.ToString());
        if (col.tag == "Area")
        {
            AllCol = col;
            
        }
    }
    public void OduncuSpawn()
    {
        if (para>=10)
        {
            para -= 10;
            paramiz.text = para.ToString();
            Instantiate(lumberjack, AllCol.transform.position, Quaternion.identity);
        }
        
    }
}
