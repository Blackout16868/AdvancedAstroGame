using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasHB : MonoBehaviour
{
    public GameObject healthBar;
    // Update is called once per frame
    public void turnOff(){
        healthBar.SetActive(false);
    }
}
