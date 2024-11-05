using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ballBehavior : MonoBehaviour
{
    [SerializeField]GameObject dropShadow;
    Rigidbody rb;
    bool beingJuggled;
    public UnityEvent ballDropped;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        DropShadowRaycast();
    }

    void DropShadowRaycast()
    {
        Ray raycast = new Ray(rb.transform.position, -Vector3.up);
        if (Physics.Raycast(raycast, out RaycastHit hit))
        {
            dropShadow.transform.position = hit.point + Vector3.up * .001f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!beingJuggled)
        {
            beingJuggled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (beingJuggled)
        {
            ballDropped.Invoke();
            Destroy(gameObject);
        }
    }


}
