using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour
{
    [SerializeField] GameObject center;
    public GameObject bulletPrefab;
    [SerializeField] GameObject playerObject;
    [SerializeField] LayerMask player;
    [SerializeField] float coolDown;
    [SerializeField] float range;
    Transform playerSpot;
    private float timer;

    // Update is called once per frame
 private void Start() {
        timer = coolDown;
        playerSpot = playerObject.GetComponent<Transform>();
    }

    void Update()
    {
        if (timer>0f){
            timer --;
        }

        if (playerNear() ){
            facePlayer();
            if(timer <= 0f && !PauseMenu.GamePaused){
            fire();
            timer = coolDown;
            }
        }
    }

    public bool playerNear(){
        return Physics.CheckSphere(center.transform.position, range, player);
    }

    public void facePlayer(){
        var lookPos = playerObject.transform.position - transform.position;
        if (lookPos.y<-30){
            lookPos.y = -30;
        }
        //lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 2); 
    }

    public void fire(){
        GameObject bulletObject = Instantiate (bulletPrefab);
        bulletObject.transform.position = transform.position+transform.forward;
        bulletObject.transform.forward = transform.forward;
    }
}