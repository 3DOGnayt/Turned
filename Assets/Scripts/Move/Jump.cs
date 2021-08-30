using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public bool _isGrounded;

    public void OnColisionEnter()
    {
        _isGrounded = true;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _isGrounded = false;
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 200, 0));
        }


    }
    
}
