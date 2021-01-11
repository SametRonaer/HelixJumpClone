using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    [SerializeField] float rotationSensitivity = 0.1f;
    Vector2 touchPosition = new Vector2(0,0);
    float turningDirection;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        TurnCylinder();
      
    }

    private void TurnCylinder()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            //print(touch.position.x);
            if (touch.phase == TouchPhase.Moved)
            {

                turningDirection = touch.position.x - touchPosition.x;
                turningDirection = Mathf.Sign(turningDirection);
                transform.eulerAngles -= new Vector3(0, rotationSensitivity, 0) * turningDirection;
            }
            touchPosition = touch.position;

        }
    }
}
