using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : Manager<WaveManager>
{
    [SerializeField] private float waveInterval = 5f;

    public void Update()
    {
        
    }

    //时间有限，先将关卡配置写死，后续有空做成解析外部json文件生成关卡
    private void GenerateBigWave01()
    {
    }

    private void GenerateBigWave02()
    {
    }

    //小波次生成元
    private void GenerateSmallWaveA()
    {

    }
    private void GenerateSmallWaveB()
    {
    }
    private void GenerateSmallWaveC()
    {
    }
    private void GenerateSmallWaveD()
    {
    }
    private void GenerateSmallWaveE()
    {
    }
    private void GenerateSmallWaveF()
    {
    }
}
