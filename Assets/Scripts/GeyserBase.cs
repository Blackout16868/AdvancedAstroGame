using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeyserBase : MonoBehaviour
{
    [SerializeField] GameObject water;
    [SerializeField] float maxTimeInFrames = 120f;
    private bool isActive;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        water.SetActive(false);
        isActive = false;
        timer =  maxTimeInFrames;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0f){
            timer--;
        }else {
            if (isActive){
               water.SetActive(false); 
               isActive = false;
               timer = Random.Range(10f,maxTimeInFrames);
            }else {
                water.SetActive(true);
                isActive = true;
                timer = Random.Range(10f,maxTimeInFrames);
            }
        }
    }
}
