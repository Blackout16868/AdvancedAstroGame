using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
     Physics.gravity = new Vector3(0f, -0.62f, 0f);
    }
}
