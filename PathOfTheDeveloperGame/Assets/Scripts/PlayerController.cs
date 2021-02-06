using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private Vector2 lowerBound;
    [SerializeField] private Vector2 upperBound;

    //Set up keybinds
    [SerializeField] private const string speedUpCam = "left shift";
    [SerializeField] private const KeyCode startGame = KeyCode.Space;

    private int moveSpeed;
    private const int moveSpeedSlow = 5;
    private const int moveSpeedFast = 15;
    
    //This is used in the update to check if the player would reach the bounds.
    private Vector3 boundCheck;

    //Get an array of all moveable objects in the scene.
    private GameObject[] moveableObjects;

    //Store Angelo, the ball and his startPosition;
    private GameObject angelo;
    private Vector3 angeloStartPosition;

    //Save is game is active
    private bool gameIsActive = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        moveSpeed = moveSpeedSlow;
    }

    private void OnEnable()
    { 
        SceneManager.sceneLoaded += onLoadNewScene;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(speedUpCam)) moveSpeed = moveSpeedFast;
        else if (Input.GetKeyUp(speedUpCam)) moveSpeed = moveSpeedSlow;

        boundCheck = ((transform.right * moveSpeed * Input.GetAxis("Sideways")) + transform.up * moveSpeed * Input.GetAxis("Upwards")) * Time.deltaTime;
        //First instantiate boundCheck to the appropriate change in position.

        //Then check if, if that change were to apply, the player would be out of bounds.
        if(transform.position.x + boundCheck.x >lowerBound.x &&
                transform.position.y + boundCheck.y > lowerBound.y &&
                transform.position.x + boundCheck.x < upperBound.x &&
                transform.position.y + boundCheck.y < upperBound.y)
        {
            //Only if true apply it to the position.
            transform.position += boundCheck;
        }
        if (Input.GetKeyDown(startGame))
        {
            changeGameState();
        }
    }

    private void onLoadNewScene(Scene scene, LoadSceneMode mode)
    {
        angelo = GameObject.FindGameObjectWithTag("Angelo");
        angeloStartPosition = angelo.transform.position;
        moveableObjects = GameObject.FindGameObjectsWithTag("MoveableObject");
    }

    private void changeGameState()
    {
        if (!gameIsActive)
        {
            angelo.isStatic = false;
            angelo.GetComponent<Rigidbody>().isKinematic = false;
            foreach (GameObject obj in moveableObjects)
            {
                obj.GetComponent<MoveableObject>().enabled = false;
            }
            gameIsActive = true;
        }
        else
        {
            angelo.isStatic = true;
            angelo.transform.position = angeloStartPosition;
            angelo.GetComponent<Rigidbody>().isKinematic = true;
            foreach (GameObject obj in moveableObjects)
            {
                obj.GetComponent<MoveableObject>().enabled = true;
            }
            gameIsActive = false;
        }
    }
}
