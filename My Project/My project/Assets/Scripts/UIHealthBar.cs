using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
// Image���ͱ�����Ҫ�������ռ䡣

public class UIHealthBar : MonoBehaviour
{
    public static UIHealthBar instance { get; private set; }
    // public static UIHealthBar��ʾ��̬�Ĺ������ԣ����������������κνű��е���UIHealthBar.instance��instanceΪ����������get���Է���instance�Լ���
    // set������˽�����ԣ���ֹ���ⲿ�Դ˽ű����и��ġ�
    // �������Ϳ����������ű�ֱ�����õ�ǰ��Ϸ���󣬶�����Ҫ����һ��public��������Inspector�����ֶ����䡣
    // ͬʱ����������г����˵ڶ�������ֵ������ô���ݾ�̬��Ա�����ԣ��ڶ�������ֵ���Ḳ�ǵ�һ������ֵ��������������ó�Ϊ"����"��

    public Image mask;
    float originalSize;

    void Awake()
    {
        instance = this;
        // this��һ��C#�ؼ��֣���ʾ"��ǰ���иú����Ķ���"��
        // Awake����Ϸ��ʼʱ�ͻ����У�����ǰ��Ϸ�����������instance��
        // Ҳ����˵���������ű�����UIHealthBar.instanceʱ������ֵ��Ϊ��ǰ��Ϸ����
    }
    void Start()
    {
        originalSize = mask.rectTransform.rect.width;
        // rect.width��ȡ��Ļ�ϵĴ�С��
    }

    public void SetValue(float value)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
        // ���ô�С��ê�㡣
    }
}
