using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Player_Movement : MonoBehaviour
{
    private Rigidbody rb;

    [Header("Movement Properties")]
    [SerializeField] private float movementSpeed = 5;
    [SerializeField] private Transform gimbal;

    [Header("Rotation Properties")]
    [SerializeField] private float rotationTime;
    private float smoothDampVector;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Movement force
        if (Input.GetKey(KeyCode.W)) rb.AddForce(gimbal.forward * movementSpeed);
        if (Input.GetKey(KeyCode.S)) rb.AddForce(-gimbal.forward * movementSpeed);
        if (Input.GetKey(KeyCode.A)) rb.AddForce(-gimbal.right * movementSpeed);
        if (Input.GetKey(KeyCode.D)) rb.AddForce(gimbal.right * movementSpeed);

        // 
    }
}
