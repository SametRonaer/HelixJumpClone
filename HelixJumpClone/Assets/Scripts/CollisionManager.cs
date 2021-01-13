using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [SerializeField] GameObject paintPattern;
    Rigidbody rb;
    [SerializeField] float jumpForce = 10f;
    GameObject paintSplash;
    Animator anim;
    bool kill;
    [SerializeField] GameObject rotationControl;
    GameObject killParticles;
    [SerializeField]GameObject restart;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        killParticles = transform.GetChild(1).gameObject;
        killParticles.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Kill")
        {
        Kill();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
       paintSplash = Instantiate(paintPattern, transform.GetChild(0).gameObject.transform.position, transform.GetChild(0).gameObject.transform.rotation);
       //paintSplash.transform.localScale = transform.GetChild(0).localScale;
       paintSplash.transform.parent = collision.gameObject.transform;
      
       
        if (!kill)
        {
        rb.AddForce(new Vector3(0,jumpForce,0));
        anim.SetTrigger("bounce");
        }
        if(collision.gameObject.tag == "LastDisc")
        {
            print("Finish");
        }
        //print(collision.transform.position);
    }

    private void Kill()
    {
        kill = true;
        anim.SetTrigger("kill");
        killParticles.SetActive(true);
        Time.timeScale = 1.3f;
        rotationControl.GetComponent<Control>().enabled = false;
        Invoke("Restart", 0.5f);
    }

    void Restart()
    {
        restart.SetActive(true);
    }
}
