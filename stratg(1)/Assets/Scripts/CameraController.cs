using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotareSpeed = 10.0f, speed = 10.0f, zoomSpeed = 10.0f;
    private float _mult = 1f;
    private void Update()
    {

        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        float rotate = 0f;
        if(Input.GetKey(KeyCode.Q))
        rotate = -1f;
        if(Input.GetKey(KeyCode.E))
        rotate = 1f;
        _mult = Input.GetKey(KeyCode.LeftShift) ? 2f : 1f;
        transform.Rotate(Vector3.up * rotareSpeed * Time.deltaTime * rotate * _mult, Space.World);
        transform.Translate(new Vector3(hor, 0, ver) * Time.deltaTime * _mult * speed, Space.Self);
        transform.position += transform.up * zoomSpeed * Input.GetAxis("Mouse ScrollWheel") * -1;
        transform.position = new Vector3(
            transform.position.x,
            Mathf.Clamp(transform.position.y, -20f, 30f),
            transform.position.z
        );
    }
}