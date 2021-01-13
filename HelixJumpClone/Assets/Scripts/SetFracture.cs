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
  
        }
        foreach(Transform t in fractureCells.transform)
        {
            t.gameObject.AddComponent<Rigidbody>();
            Vector3 direction = t.position - forcePoint.transform.position;
            t.gameObject.GetComponent<Rigidbody>().AddForce(direction * forceAmount);
        }
        foreach (Transform t in parentDisc.transform)
        {
            if (t.gameObject.tag == "Paint")
            {
                Destroy(t.gameObject);
            }
        }
        Destroy(gameObject);
    }
}
