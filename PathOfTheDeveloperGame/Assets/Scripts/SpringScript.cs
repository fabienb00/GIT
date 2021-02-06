using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringScript : MonoBehaviour
{
    [SerializeField] private float springForce;
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Angelo")
        { 
            collision.gameObject.GetComponent<Rigidbody>().AddForce(gameObject.transform.up * springForce);
        }
    }
}
