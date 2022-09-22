using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

public class Worker : MonoBehaviour
{
    public GameObject worker,willGo,wood;
    public float distance;
    public NavMeshAgent _agent;
    public int[] jobs;//HER SAYI Bİ MESLEK 0 İSE YOK 1 İSE VAR
                      //0.Taşıma 1.oduncu

    void Start()
    {
        worker = this.gameObject;
        jobs = new int[6];
    }
    
    public void closeWood()
    {
        float uzaklik = 0;
        GameObject[] tree = GameObject.FindGameObjectsWithTag("Tree");
        int minI = 0;
        if (tree.Length == 0)
        {
            willGo = null;
        }
        else
        {
            if (tree.Length > 1)
            {
                uzaklik = Vector3.Distance(worker.transform.position, tree[0].transform.position);

                for (int i = 0; (i + 1) < tree.Length; i++)
                {

                    if (uzaklik > Vector3.Distance(worker.transform.position, tree[(i + 1)].transform.position))
                    {
                        uzaklik = Vector3.Distance(worker.transform.position, tree[(i + 1)].transform.position);
                        minI = (i + 1);

                    }

                    if (uzaklik < 2)
                    {
                        minI = i;
                        return;
                    }

                }
            }
            else
            {
                minI = 0;
            }
            //Debug.Log(tree[minI]);
            willGo = tree[minI];
        }
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (jobs[1]==1)//ODUNCULUK
        {
            closeWood();
            if (willGo != null)
            {
                distance = Vector3.Distance(transform.position, willGo.transform.position);
                _agent.SetDestination(willGo.transform.position);
            }

            /*
            if (Vector3.Distance(transform.position, willGo.transform.position) < 2)
            {
                _agent.speed = 0;
            }
            else
            {
                _agent.speed = 4;
            }
            */
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            jobs[1] = 1;
        }
    }
    /*
    private void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.name.ToString());
        if (col.tag == "Tree")
        {

            Instantiate(wood, col.transform.position, Quaternion.identity);

        }
    }
    */
}
