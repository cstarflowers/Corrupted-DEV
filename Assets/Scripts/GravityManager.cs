using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour {
    public float gravity = -9.81f;

void FixedUpdate() {
    // Establishes a constant gravity of -9.81 for all attached objects
    GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f,gravity);
}
}
