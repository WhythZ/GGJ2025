using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : Manager<WaveManager>
{
    [SerializeField] private float bigWaveInterval = 5f;

    public void Start()
    {
        StartCoroutine(WaveControl());
    }

    public void Update()
    {
        TestSmallWave();
    }

    //ʱ�����ޣ��Ƚ��ؿ�����д���������п����ɽ����ⲿjson�ļ����ɹؿ�

    IEnumerator WaveControl()
    {
        StartCoroutine(GenerateBigWave01());

        yield return new WaitForSeconds(bigWaveInterval);

        //StartCoroutine(GenerateBigWave02());
    }

    IEnumerator GenerateBigWave01()
    {
        GenerateSmallWaveA();

        yield return new WaitForSeconds(8);

        StartCoroutine(GenerateSmallWaveB());

        yield return new WaitForSeconds(6);

        GenerateSmallWaveA();

        yield return new WaitForSeconds(8);

        StartCoroutine(GenerateSmallWaveB());

        yield return new WaitForSeconds(6);

        GenerateSmallWaveA();
        GenerateSmallWaveC();

        yield return new WaitForSeconds(6);

        GenerateSmallWaveD();

        yield return new WaitForSeconds(8);

        GenerateSmallWaveE();

        yield return new WaitForSeconds(8);

        GenerateSmallWaveD();

        yield return new WaitForSeconds(8);

        GenerateSmallWaveE();

        yield return new WaitForSeconds(12);

        GenerateSmallWaveA();

        yield return new WaitForSeconds(8);

        StartCoroutine(GenerateSmallWaveB());

        yield return new WaitForSeconds(6);

        GenerateSmallWaveC();
        GenerateSmallWaveD();
        yield return new WaitForSeconds(8);

        GenerateSmallWaveC();
        GenerateSmallWaveD();
        yield return new WaitForSeconds(2);
        GenerateSmallWaveF();


    }

    //IEnumerator GenerateBigWave02()
    //{
        //GenerateSmallWaveA();

        //yield return new WaitForSeconds(smallWaveInterval);

        //StartCoroutine(GenerateSmallWaveB());

        //yield return new WaitForSeconds(smallWaveInterval);

        //GenerateSmallWaveD();
    //}

    public void TestSmallWave()
    {
        if (Input.GetKeyDown(KeyCode.F1))
            GenerateSmallWaveA();
        if (Input.GetKeyDown(KeyCode.F2))
            StartCoroutine(GenerateSmallWaveB());
        if (Input.GetKeyDown(KeyCode.F3))
            GenerateSmallWaveC();
        if (Input.GetKeyDown(KeyCode.F4))
            GenerateSmallWaveD();
        if (Input.GetKeyDown(KeyCode.F5))
            GenerateSmallWaveE();
        if (Input.GetKeyDown(KeyCode.F6))
            GenerateSmallWaveF();
    }

    //С��������Ԫ
    private void GenerateSmallWaveA()
    {
        EnemyManager.instance.SpawnTunaAtTo(0, 2);
        EnemyManager.instance.SpawnTunaAtTo(3, 5);
        EnemyManager.instance.SpawnTunaAtTo(6, 8);
    }

    IEnumerator GenerateSmallWaveB()
    {
        // ��һ������
        EnemyManager.instance.SpawnTunaAtTo(0, 8);
        EnemyManager.instance.SpawnTunaAtTo(2, 6);

        // �ȴ� 6 ��
        yield return new WaitForSeconds(2f);

        // �ڶ�������
        //EnemyManager.instance.SpawnTunaAtTo(0, 8);
        //EnemyManager.instance.SpawnTunaAtTo(2, 6);
    }

    private void GenerateSmallWaveC()
    {
        EnemyManager.instance.SpawnGfishAt(0);
        EnemyManager.instance.SpawnGfishAt(1);
        EnemyManager.instance.SpawnGfishAt(2);

    }

    private void GenerateSmallWaveD()
    {
        EnemyManager.instance.SpawnTunaAtTo(2, 8);
        EnemyManager.instance.SpawnTunaAtTo(8, 6);
        EnemyManager.instance.SpawnTunaAtTo(6, 2);
        EnemyManager.instance.SpawnTunaAtTo(0, 6);
        EnemyManager.instance.SpawnTunaAtTo(6, 2);
        EnemyManager.instance.SpawnTunaAtTo(2, 0);
    }
    
    private void GenerateSmallWaveE()
    {
        EnemyManager.instance.SpawnTunaAtTo(2, 8);
        EnemyManager.instance.SpawnTunaAtTo(8, 6);
        EnemyManager.instance.SpawnTunaAtTo(0, 8);
        EnemyManager.instance.SpawnTunaAtTo(0, 6);
        EnemyManager.instance.SpawnTunaAtTo(6, 2);
        EnemyManager.instance.SpawnTunaAtTo(2, 0);
    }

    private void GenerateSmallWaveF()
    {
        EnemyManager.instance.SpawnTunaAtTo(0, 6);
        EnemyManager.instance.SpawnTunaAtTo(1, 7);
        EnemyManager.instance.SpawnTunaAtTo(2, 8);
    }
}

