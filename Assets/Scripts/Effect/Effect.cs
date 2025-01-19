using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    //���ӵ�ʵ���Animator�ڵ���Ⱦ��Component
    private SpriteRenderer sr;

    [Header("Damaged Material")]
    //��¼��ʼ�Ĳ���
    private Material originMat;
    //��¼�����ܹ�������Ч���ĵĲ���
    [SerializeField] private Material flashHitMat;
    //���ʸ�����ͣ��ʱ��
    [SerializeField] private float changeMatDuration = 0.1f;

    private void Start()
    {
        //���ӵ�ʵ���Animator�ڵ���Ⱦ��Component
        sr = GetComponentInChildren<SpriteRenderer>();

        //��¼ԭʼ����
        originMat = sr.material;
    }

    private IEnumerator CancelColorChange(float _duration)
    {
        yield return new WaitForSeconds(_duration);
        //�˺�������ȡ��MonoBehaviour�е�����InvokeRepeating�������Ǹ���Invoke��RedBlink����
        CancelInvoke();
        //��ȷ��������ɫ�ָ�Ϊ��ɫ
        sr.color = Color.white;
    }

    private IEnumerator FlashHitFX()
    //���������Ҫʹ����StartCoroutine("FlashHitFX");�����ã�������ֱ����FlashHitFX()
    {
        //ʹ���ܻ�����
        sr.material = flashHitMat;
        //�ӳ�һ��ʱ��
        yield return new WaitForSeconds(changeMatDuration);
        //�ع�ԭ���Ĳ���
        sr.material = originMat;
    }
    private void BlueBlink()
    //���÷���ʾ��InvokeRepeating("BlueBlink", 0, 0.1f);��Ϊ�ӳ��������0.1f��Ƶ�ʳ�������
    {
        if(sr.color != Color.white)
            sr.color = Color.white;
        else
            sr.color = Color.blue;
    }
}
