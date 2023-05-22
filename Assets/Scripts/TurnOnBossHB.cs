using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnBossHB : MonoBehaviour
{
    public GameObject hb;
    public GameObject self;

    private void OnCollisionEnter(Collision collision){
        hb.SetActive(true);
        self.SetActive(false);
    }
}
