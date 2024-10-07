using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public AudioClip collectedClip;
    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("Object that entered the trigger : " + other);
        RubyController Ct = other.GetComponent<RubyController>();
        if (Ct != null)
        {
            if (Ct.health < Ct.maxHealth)
            {
                Ct.ChangeHealth(2);
                Destroy(gameObject);

                Ct.PlaySound(collectedClip);
            }
        }
    }
}