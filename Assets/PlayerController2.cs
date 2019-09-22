using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerMotor2))]
public class PlayerController2 : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lookSensitivity = 3f;
    [SerializeField]
    private float thruster = 1000f;
    private PlayerMotor2 motor;

    // Use this for initialization
    void Start()
    {
        print("Started Controller");
        motor = GetComponent<PlayerMotor2>();
    }

    // Update is called once per frame
    void Update()
    {
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");
        //  print(_xMov);
        // print(_zMov);
        Vector3 _movHorizontal = transform.right * _xMov;
        Vector3 _movVertical = transform.forward * _zMov;

        Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;
        //Move
        motor.Move(_velocity);
        //turn camera horizontally
        float _yRot = Input.GetAxisRaw("Mouse X");
        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;
        motor.Rotate(_rotation);
        //turn camera vertically
        float _xRot = Input.GetAxisRaw("Mouse Y");
        Vector3 _cameraRotation = new Vector3(_xRot, 0f, 0f) * lookSensitivity;
        motor.RotateCamera(_cameraRotation);

        //jump

        Vector3 _thrusterforce = Vector3.zero;
        if (Input.GetButton("Jump"))
        {
            _thrusterforce = Vector3.up * thruster;
        }
        motor.ApplyThruster(_thrusterforce);
    }
}
