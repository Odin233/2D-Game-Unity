using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    // Unity内置的触发器函数，碰撞体进入触发器后每一帧都会执行一次，参数即为进入触发器的碰撞体。
    {
        RubyController Ct = other.GetComponent<RubyController>();

        if (Ct != null)
        {
            Ct.ChangeHealth(-1);
        }
    }

}
