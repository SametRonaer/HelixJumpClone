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
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

   

    private void OnCollisionEnter(Collision collision)
    {
       // paintSplash = Instantiate(paintPattern, transform.GetChild(0).gameObject.transform.position, Quaternion.identity);
        //paintSplash.transform.parent = collision.gameObject.transform;
        //Instantiate(paintPattern, collision.transform.position, Quaternion.identity);
        rb.AddForce(new Vector3(0,jumpForce,0));
        anim.SetTrigger("bounce");
        //print(collision.transform.position);
    }
}
