using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartScript : MonoBehaviour
{
    [SerializeField] private AudioClip backgroundMusic;
    // Start is called before the first frame update
    void Start()
    {
        GameObject temp = GameObject.FindGameObjectWithTag("Player");
        temp.transform.position = gameObject.transform.position;
        temp.transform.rotation = gameObject.transform.rotation;
        temp.GetComponentInChildren<AudioSource>().clip = backgroundMusic;
    }
}
