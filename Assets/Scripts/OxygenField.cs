using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OxygenField : MonoBehaviour
{
    [SerializeField] LayerMask player;
    [SerializeField] GameObject playerObject;
    [SerializeField] Transform center;
    [SerializeField] float range = 1000f;
    [SerializeField] float outOfBoundsDamage = 10f;
    [SerializeField] float damageCooldownFrames = 10f;
    [SerializeField] TMP_Text lowOxygen;
    private float timer = 0f;
    // Start is called before the first frame update
        void Start(){
            lowOxygen.text ="";
        }
    // Update is called once per frame
    void Update()
    {   
        if (!Physics.CheckSphere(center.position, range, player)){
            if(timer==damageCooldownFrames){
            playerObject.GetComponent<PlayerLife>().takeDamage(outOfBoundsDamage);
            timer = 0f;
            }
            lowOxygen.text ="WARNING LOW OXYGEN";

        }else {
             lowOxygen.text ="";
             playerObject.GetComponent<PlayerLife>().heal(5f);
        }
        
        if (timer < damageCooldownFrames){
            timer++;
        }
    }
}
