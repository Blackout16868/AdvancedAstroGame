using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatforms : MonoBehaviour
{
     [SerializeField] GameObject gameController;

    // Update is called once per frame
   private void OnCollisionEnter(Collision collision)
   {
    if (collision.gameObject.name == "Player"){
        collision.gameObject.transform.SetParent(transform);
    }
   }

private void OnCollisionExit(Collision collision)
   {
    if (collision.gameObject.name == "Player"){
        collision.gameObject.transform.SetParent(gameController.transform);
    }
   }
}
