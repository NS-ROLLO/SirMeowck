using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBox : MonoBehaviour
{
    public Vector2 forceDirection;
    public float torque;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(forceDirection);
        rb.AddTorque(torque);
        Invoke("KillIt", 3f);
    }

    private void KillIt()
    {
        Destroy(gameObject);
    }

}
