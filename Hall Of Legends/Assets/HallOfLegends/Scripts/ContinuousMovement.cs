﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ContinuousMovement : MonoBehaviour
{
    [Tooltip("The speed at which the player moves.")]
    public float speed = 1f;
    public XRNode inputSource;
    public float gravity = -9.81f;
    public LayerMask groundLayer;

    [Tooltip("This adds a little value above the contorller as the players height. Without this the height of the player would be set to the position of the controller, which is the eyes.")]
    public float additionalHeight = 0.2f;

    // how fast the enemy is falling. Increase with time.
    private float fallingSpeed;
    private Vector2 inputAxis;

    private XRRig rig;

    //Charactercontroller script sitting on the player
    private CharacterController character;


    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        rig = GetComponent<XRRig>();
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
    }

    private void FixedUpdate() 
    {
        CapsuleFollowHeadset();
        
        Quaternion headYaw = Quaternion.Euler(0, rig.cameraGameObject.transform.eulerAngles.y, 0);
        Vector3 direction = headYaw * new Vector3(inputAxis.x, 0, inputAxis.y);

        character.Move(direction * Time.fixedDeltaTime * speed);

        //Gravity
        bool isGrounded = CheckIfGrounded();
        if (isGrounded)
        {
            fallingSpeed = 0;
        }else
        {
            fallingSpeed += gravity * Time.fixedDeltaTime;
        }
        
        character.Move(Vector3.up * fallingSpeed * Time.fixedDeltaTime);
    }

    //Check if the player is still on ground or in the air.
    bool CheckIfGrounded()
    {
        Vector3 rayStart = transform.TransformPoint(character.center);
        float rayLength = character.center.y + 0.01f;
        bool hasHit = Physics.SphereCast(rayStart, character.radius, Vector3.down, out RaycastHit hitInfo, rayLength, groundLayer);
        return hasHit;
    }

    void CapsuleFollowHeadset()
    {
        character.height = rig.cameraInRigSpaceHeight + additionalHeight;
        Vector3 capsuleCenter = transform.InverseTransformPoint(rig.cameraGameObject.transform.position);
        character.center = new Vector3(capsuleCenter.x, character.height/2 + character.skinWidth, capsuleCenter.z);
    }
}
