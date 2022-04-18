using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float dragSpeed;

    private void Awake()
    {
        if (_target == null)
        {
            _target = FindObjectOfType<PlayerMovement>().gameObject.transform;
        }
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _target.position + _offset, dragSpeed * Time.deltaTime);
    }
}
