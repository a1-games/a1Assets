using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class VSCOL_Camera_Movement : MonoBehaviour
{
    private Camera _cam;
    [SerializeField] private float _moveSpeed = 3f;
    private void Awake()
    {
        _cam = GetComponent<Camera>();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += _cam.transform.forward * _moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= _cam.transform.forward * _moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += _cam.transform.right * _moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= _cam.transform.right * _moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.position -= Vector3.up * _moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += Vector3.up * _moveSpeed * Time.deltaTime;
        }
        if (Input.GetMouseButton(0))
        {
            transform.Rotate(Vector3.up, Time.deltaTime * -22f);
        }
        if (Input.GetMouseButton(1))
        {
            transform.Rotate(Vector3.up, Time.deltaTime * 22f);
        }
    }
}
