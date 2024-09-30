using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Player_Movement : MonoBehaviour
{
    private Rigidbody rb;

    [Header("Movement Properties")]
    [SerializeField] private float movementSpeed = 5;

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
        if (Input.GetKey(KeyCode.W)) rb.AddForce(transform.forward * movementSpeed);
    }
}
