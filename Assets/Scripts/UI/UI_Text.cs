using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Text : MonoBehaviour
{
    //��ȡUI���
    private Scene_OceanArena ui;

    //UI����ʾ�����Ե����ֵ��ı������˽ű�ʹ�����µ�Name��ʾ�����븳ֵ�˱���
    [SerializeField] TextMeshProUGUI nameText;
    //UI����ʾ�����Ե�ֵ���ı�����Unity��ʹ�ô˽ű��Ķ���ͬʱҲ��Value����ʾ�ߣ���Ҫ���Լ����븳ֵ�˱���
    [SerializeField] TextMeshProUGUI valueText;

    public void Start()
    {
        //��ʼʱ��ȡUI���
        ui = GetComponentInParent<Scene_OceanArena>();
    }

    public void Update()
    {
        UpdateStatValueSlotUI();
    }

    public void UpdateStatValueSlotUI()
    //ÿ����ֵ�����仯ʱ����Ҫ���ô˺�������һ��
    {
        //��ȡ����ͳ�����ݽű�
        int _health = CrabManager.instance.GetCurrentHealth();

        //ͨ���˺�����ȡѡȡ�����ݶ�Ӧ������ֵ����ת��Ϊ�ַ���
        valueText.text = _health.ToString();
    }
}
