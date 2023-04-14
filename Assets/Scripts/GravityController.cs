using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    public float Gravity;

    void Start()
    {
     Physics.gravity = new Vector3(0f, Gravity, 0f);
    }
}
