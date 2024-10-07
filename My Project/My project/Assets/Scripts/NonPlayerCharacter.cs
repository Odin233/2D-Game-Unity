using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerCharacter : MonoBehaviour
{
    public float displayTime = 4.0f;
    // ��ʾ�Ի����ʱ����
    public GameObject dialogBox;
    // �洢Canvas����������Ϸ����
    float timerDisplay;
    // ��ʾ�Ի����ʣ��ʱ����

    void Start()
    {
        dialogBox.SetActive(false);
        timerDisplay = -1.0f;
    }

    void Update()
    {
        if (timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;
            // ������ʾ��ʣ��ʱ�䡣
            
            if (timerDisplay < 0)
            {
                dialogBox.SetActive(false);
                // ���ʣ��ʱ��С��0����ô�ٴ����ضԻ���
            }
        }
    }

    public void DisplayDialog()
    // ���ڱ�������Ϸ������ã���ʾ�Ի���
    {
        timerDisplay = displayTime;
        dialogBox.SetActive(true);
    }
}
