using System;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    [SerializeField] bool destroyOnEnter;
    [SerializeField] string tagFilter;
    [SerializeField] string soundEffect;
    [SerializeField] string soundToStop;

    void OnTriggerEnter(Collider other)
    {
        if (!String.IsNullOrEmpty(tagFilter) && !other.gameObject.CompareTag(tagFilter)) return;
        
        FindObjectOfType<AudioManager>().Play(soundEffect);
        FindObjectOfType<AudioManager>().Stop(soundToStop);
        if (destroyOnEnter){
            Destroy(gameObject);
        }
    }
}
