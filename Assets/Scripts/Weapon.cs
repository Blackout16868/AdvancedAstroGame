using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject playerCamera;
    public GameObject playerWeapon;
    public float coolDown = 0.66f;
    private float timer = 0f;


    // Update is called once per frame
    void Update()
    {
        
        if (timer != 0f)
        {
            timer -= Time.deltaTime;
        }

        
        if (Input.GetMouseButton(0)&&timer<=0f)
        {
        GameObject bulletObject = Instantiate (bulletPrefab);
        bulletObject.transform.position = playerWeapon.transform.position+playerCamera.transform.forward;
        bulletObject.transform.forward = playerCamera.transform.forward;

        timer = coolDown;

      }
    }
  }
