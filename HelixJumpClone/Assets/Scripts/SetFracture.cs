using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFracture : MonoBehaviour
{

    [SerializeField]
    float forceAmount = 200f;
    GameObject parentDisc;
    GameObject fractureCells;
    GameObject forcePoint;
    GameObject killArea;
    // Start is called before the first frame update
    void Start()
    {
        //Time.timeScale = 1;
        parentDisc = transform.parent.gameObject;
        fractureCells = parentDisc.transform.GetChild(0).gameObject;
        forcePoint = parentDisc.transform.GetChild(1).gameObject;
        killArea = parentDisc.transform.GetChild(3).gameObject;

        

    }




    private void OnTriggerEnter(Collider other)
    {
        
        fractureCells.SetActive(true);
        transform.parent.gameObject.GetComponent<MeshRenderer>().enabled = false;
        if (killArea)
        {
         Destroy(killArea);
        //Vector3 killAreForceDirection = killArea.transform.position - forcePoint.transform.position;
        //killArea.GetComponent<Rigidbody>().AddForce(killAreForceDirection * forceAmount);
        //killArea.GetComponent<Rigidbody>().useGravity = true;
        }
        foreach(Transform t in fractureCells.transform)
        {
            t.gameObject.AddComponent<Rigidbody>();
            //t.gameObject.GetComponent<Rigidbody>().useGravity = false;
            Vector3 direction = t.position - forcePoint.transform.position;
            t.gameObject.GetComponent<Rigidbody>().AddForce(direction * forceAmount);
        }
       // ChangeMesh();
       // AddForceToFractures();
       Destroy(gameObject);
    }
}
