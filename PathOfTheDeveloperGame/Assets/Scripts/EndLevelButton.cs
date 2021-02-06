using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelButton : MonoBehaviour
{
    [SerializeField] private ChangeVisibilityScript winScreen;
    [SerializeField] private ChangeVisibilityScript loadScreen;

    private void Start()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Angelo")
        {
            winScreen.makeSelfVisible();
            loadScreen.makeSelfVisible();
        }
    }
}
