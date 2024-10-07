using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
// Image类型变量需要的命名空间。

public class UIHealthBar : MonoBehaviour
{
    public static UIHealthBar instance { get; private set; }
    // public static UIHealthBar表示静态的公共属性（变量），可以在任何脚本中调用UIHealthBar.instance（instance为变量名），get属性返回instance自己。
    // set属性是私有属性，防止从外部对此脚本进行更改。
    // 这样，就可以在其他脚本直接引用当前游戏对象，而不需要设置一个public变量后在Inspector窗口手动分配。
    // 同时，如果场景中出现了第二个生命值条，那么根据静态成员的特性，第二个生命值条会覆盖第一个生命值条，因此这种设置称为"单例"。

    public Image mask;
    float originalSize;

    void Awake()
    {
        instance = this;
        // this是一个C#关键字，表示"当前运行该函数的对象"。
        // Awake在游戏开始时就会运行，将当前游戏对象赋予给变量instance。
        // 也就是说，在其他脚本调用UIHealthBar.instance时，返回值即为当前游戏对象。
    }
    void Start()
    {
        originalSize = mask.rectTransform.rect.width;
        // rect.width获取屏幕上的大小。
    }

    public void SetValue(float value)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
        // 设置大小和锚点。
    }
}
