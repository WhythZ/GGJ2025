using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    //链接到实体的Animator内的渲染器Component
    private SpriteRenderer sr;

    [Header("Damaged Material")]
    //记录初始的材质
    private Material originMat;
    //记录用于受攻击动画效果的的材质
    [SerializeField] private Material flashHitMat;
    //材质更替后的停留时间
    [SerializeField] private float changeMatDuration = 0.1f;

    private void Start()
    {
        //链接到实体的Animator内的渲染器Component
        sr = GetComponentInChildren<SpriteRenderer>();

        //记录原始材质
        originMat = sr.material;
    }

    private IEnumerator CancelColorChange(float _duration)
    {
        yield return new WaitForSeconds(_duration);
        //此函数用于取消MonoBehaviour中的所有InvokeRepeating，包括那个被Invoke的RedBlink函数
        CancelInvoke();
        //并确保人物颜色恢复为白色
        sr.color = Color.white;
    }

    private IEnumerator FlashHitFX()
    //这个函数需要使用如StartCoroutine("FlashHitFX");来调用，而不是直接用FlashHitFX()
    {
        //使用受击材质
        sr.material = flashHitMat;
        //延迟一段时间
        yield return new WaitForSeconds(changeMatDuration);
        //回归原来的材质
        sr.material = originMat;
    }
    private void BlueBlink()
    //调用方法示例InvokeRepeating("BlueBlink", 0, 0.1f);此为延迟零秒后以0.1f的频率持续调用
    {
        if(sr.color != Color.white)
            sr.color = Color.white;
        else
            sr.color = Color.blue;
    }
}
