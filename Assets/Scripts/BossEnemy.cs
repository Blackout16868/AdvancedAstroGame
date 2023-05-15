using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    public GameObject spawn;
    public GameObject self;

    private void Start() {
        spawn.SetActive(false);
    }

    public  void spawnThing(){
            FindObjectOfType<AudioManager>().Play("Bowder");
            spawn.SetActive(true);
        
    }

    public bool isBoss(){
        return true;
    }

}
