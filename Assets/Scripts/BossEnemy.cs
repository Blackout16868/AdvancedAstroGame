using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    public GameObject spawn;
    public GameObject self;
    public bool isABoss = false;

    private void Start() {
        spawn.SetActive(false);
    }

    public  void spawnThing(){
            FindObjectOfType<AudioManager>().Play("bossDefeat");
            spawn.SetActive(true);
    }

}
