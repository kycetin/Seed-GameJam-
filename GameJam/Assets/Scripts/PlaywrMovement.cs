﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaywrMovement : MonoBehaviour
{

    public CharacterController controller;

    public float gravity = -9.81f;
    public float speed = 12f;
    public float jumpHeight = 3f;
    Vector3 velocitiy;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    bool isGrounded;

    public ShootController theBaloon;
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocitiy.y < 0)
        {
            velocitiy.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocitiy.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocitiy.y += gravity * Time.deltaTime;

        controller.Move(velocitiy * Time.deltaTime);

        if (Input.GetButtonDown("Fire1"))
        {
            theBaloon.isFiring = true;
        }
        else
        {
            theBaloon.isFiring = false;
        }
    }
}