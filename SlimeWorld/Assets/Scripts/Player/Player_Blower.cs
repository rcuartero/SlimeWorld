using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Blower : MonoBehaviour
{
    [Header("Blow Angle Properties")]
    [SerializeField] private float blowerRange = 5;
    [SerializeField] private float maxBlowerAngle;      // Find the angle between object and forward and compare to this float
    [SerializeField] private LayerMask objectsLayer;

    [Header("Blow Strength Properties")]
    [SerializeField] private float blowStrength = 10;

    private bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) ToggleBlower(); 

        if (!isActive) return;

        ActivateBlower();
    }

    private void ToggleBlower()
    {
        isActive = !isActive;
    }

    private void ActivateBlower()
    {
        RaycastHit[] blownObjects = Physics.SphereCastAll(transform.position, blowerRange, transform.forward, blowerRange, objectsLayer);

        foreach (RaycastHit objectToBlow in blownObjects)
        {
            if (Vector3.Angle((objectToBlow.transform.position - transform.position).normalized, transform.forward) <= maxBlowerAngle)
            {
                BlowAway(objectToBlow.collider.gameObject);
            }
        }
    }

    private void BlowAway(GameObject slime)
    {
        Rigidbody slimeRB = slime.GetComponent<Rigidbody>();

        slimeRB.AddForce((slime.transform.position - transform.position).normalized * blowStrength);
    }
}