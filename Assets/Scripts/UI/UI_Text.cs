using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Text : MonoBehaviour
{
    private Scene_OceanArena ui;
    [SerializeField] private TextValueType type;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI valueText;

    public void Start()
    {
        ui = GetComponentInParent<Scene_OceanArena>();
    }

    public void Update()
    {
        if (type == TextValueType.Health)
        {
            int _health = CrabManager.instance.GetCurrentHealth();
            //ͨ���˺�����ȡѡȡ�����ݶ�Ӧ������ֵ����ת��Ϊ�ַ���
            valueText.text = _health.ToString();
        }

        if (type == TextValueType.Score)
        {
            int _score = CrabManager.instance.score;
            valueText.text = _score.ToString();
        }
    }
}

public enum TextValueType
{
    Health,
    Score
}
