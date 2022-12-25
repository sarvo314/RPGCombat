using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInputHandler : MonoBehaviour
{
    Vector2 moveInputVector = Vector2.zero;
    Vector2 viewInputVector = Vector2.zero;
    bool invertYMouse = false;
    bool isJumpButtonPressed = false;

    //other components
    CharacterMovementHandler characterMovementHandler;


    private void Awake()
    {
        characterMovementHandler = GetComponent<CharacterMovementHandler>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //view input
        viewInputVector.x = Input.GetAxis("Mouse X");
        viewInputVector.y = Input.GetAxis("Mouse Y") * ((invertYMouse)?(-1):1);

        characterMovementHandler.SetViewInputVector(viewInputVector);


        //move input
        moveInputVector.x = Input.GetAxis("Horizontal");
        moveInputVector.y = Input.GetAxis("Vertical");

        isJumpButtonPressed = Input.GetButtonDown("Jump");
    }
    public NetworkInputData GetNetworkInput()
    {
        NetworkInputData networkInputData = new NetworkInputData();

        //View Data
        networkInputData.rotationInput = viewInputVector.x;

        //Move Data
        networkInputData.movementInput = moveInputVector;
        networkInputData.isJumpPressed = isJumpButtonPressed;

        return networkInputData;
    }
    
}
