using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    // Unity���õĴ�������������ײ����봥������ÿһ֡����ִ��һ�Σ�������Ϊ���봥��������ײ�塣
    {
        RubyController Ct = other.GetComponent<RubyController>();

        if (Ct != null)
        {
            Ct.ChangeHealth(-1);
        }
    }

}
