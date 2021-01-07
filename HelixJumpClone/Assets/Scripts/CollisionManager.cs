﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [SerializeField] GameObject paintPattern;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.transform.position);
        Instantiate(paintPattern, transform.GetChild(0).gameObject.transform.position, Quaternion.identity);
        //Instantiate(paintPattern, collision.transform.position, Quaternion.identity);
    }
}