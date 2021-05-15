using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Numerics;
using System.Transactions;
using UnityEditor;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class GunMovement : MonoBehaviour
{
    private Camera cam;

    private Transform inputEnd;
    private Transform outputEnd;
    private Transform currentGunEnd;

    private float angle;

    private void Awake()
    {
        inputEnd = transform.Find("InputEnd");
        outputEnd = transform.Find("outputEnd");
    }

    private void Start()
    {
        cam = Camera.main;
        currentGunEnd = inputEnd;
    }


    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        FollowMouseCursor();
    }

    private void FollowMouseCursor()
    {
        Vector3 mousePositionVector = Input.mousePosition;
        Vector3 screenPoint = cam.WorldToScreenPoint(transform.localPosition);
        Vector2 offset = new Vector2(mousePositionVector.x - screenPoint.x, mousePositionVector.y - screenPoint.y);

        angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        transform.localRotation = Quaternion.Euler(angle, 0f, 0f);
    }

    private void SwitchGunEnd()
    {
        currentGunEnd = currentGunEnd.Equals(inputEnd) ? outputEnd : inputEnd;
    }
}
