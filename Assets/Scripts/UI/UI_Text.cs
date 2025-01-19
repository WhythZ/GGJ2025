using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Text : MonoBehaviour
{
    //获取UI组件
    private Scene_OceanArena ui;

    //UI中显示的属性的名字的文本，将此脚本使用者下的Name显示者拖入赋值此变量
    [SerializeField] TextMeshProUGUI nameText;
    //UI中显示的属性的值的文本，在Unity内使用此脚本的对象同时也是Value的显示者，需要把自己拖入赋值此变量
    [SerializeField] TextMeshProUGUI valueText;

    public void Start()
    {
        //开始时获取UI组件
        ui = GetComponentInParent<Scene_OceanArena>();
    }

    public void Update()
    {
        UpdateStatValueSlotUI();
    }

    public void UpdateStatValueSlotUI()
    //每次数值产生变化时，都要调用此函数更新一次
    {
        //获取人物统计数据脚本
        int _health = CrabManager.instance.GetCurrentHealth();

        //通过此函数获取选取的内容对应的最终值，再转化为字符串
        valueText.text = _health.ToString();
    }
}
