using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerCharacter : MonoBehaviour
{
    public float displayTime = 4.0f;
    // 显示对话框的时长。
    public GameObject dialogBox;
    // 存储Canvas（画布）游戏对象。
    float timerDisplay;
    // 显示对话框的剩余时长。

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
            // 更新显示的剩余时间。
            
            if (timerDisplay < 0)
            {
                dialogBox.SetActive(false);
                // 如果剩余时间小于0，那么再次隐藏对话框。
            }
        }
    }

    public void DisplayDialog()
    // 用于被其他游戏对象调用，显示对话框。
    {
        timerDisplay = displayTime;
        dialogBox.SetActive(true);
    }
}
