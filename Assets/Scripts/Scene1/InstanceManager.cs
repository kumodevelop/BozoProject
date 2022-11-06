using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceManager : MonoBehaviour
{

    public Vector3 enemyStartPosition;
    float interval = 2;
    float instantiateTime = 0;
    float intervalVariation = 0.5f;
    public float runningTime;
    private GameManager gInstance;
    int rrandom, switchRange;
    public GameObject arvore, arvore2;
    bool activearvore = false;

    [Header("Prefabs")]
    public GameObject minionPrefab;
    public GameObject gadinhoPrefab;
    public GameObject olavoPrefab;
    public GameObject cadeiraPrefab;
    public GameObject estatuaHavanPrefab;
    public GameObject doggoPrefab;
    public GameObject datatoalhaPrefab;
    public GameObject helioPrefab;
    public GameObject speedUpPrefab;

    bool callOlavo, callCadeira, callEstatua, callDoggo, callData, callHelio;

    // Start is called before the first frame update
    void Start()
    {
        gInstance = GameManager.GetInstance();
        switchRange = 1;

    }

    // Update is called once per frame
    void Update()
    {
        runningTime = Time.time;
        if (gInstance.gameState == 1)
        {
            if (Time.time > instantiateTime)
            {
                if (gInstance.runType != 2)
                {
                    rrandom = Random.Range(1, switchRange);
                    if (rrandom == 1)
                        Instantiate(minionPrefab, enemyStartPosition, Quaternion.identity);
                    if (rrandom == 2)
                        Instantiate(gadinhoPrefab, enemyStartPosition, Quaternion.identity);

                    instantiateTime = Time.time + Random.Range(interval - intervalVariation, interval + intervalVariation);
                }
            }

            if (runningTime > 8.5f)
            {
                if (!callEstatua)
                {
                    Instantiate(estatuaHavanPrefab, new Vector3(6.07f, -1.17f, 1), Quaternion.identity);
                    speedUpPrefab.SetActive(true);
                    callEstatua = true;
                }
            }
            if (runningTime > 17)
            {
                gInstance.globalspeed = 1.05f;
                switchRange = 3;
                if (!callDoggo)
                {
                    Instantiate(doggoPrefab, new Vector3(5.84f, -1.95f, 1), Quaternion.identity);
                    speedUpPrefab.SetActive(true);
                    callDoggo = true;
                }

            }
            if (runningTime > 25.5f)
            {
                gInstance.globalspeed = 1.1f;
                if (!callData)
                {
                    Instantiate(datatoalhaPrefab, new Vector3(6.97f, -1.5f, 1), Quaternion.identity);
                    speedUpPrefab.SetActive(true);
                    callData = true;
                }

            }
            if (runningTime > 34f)
            {
                gInstance.globalspeed = 1.15f;
                gInstance.runType = 1;
                if (!callCadeira)
                {

                    Instantiate(cadeiraPrefab, new Vector3(5.93f, -1.69f, 1), Quaternion.identity);
                    speedUpPrefab.SetActive(true);
                    callCadeira = true;
                }

            }
            if (runningTime > 36f)
            {
                if (!callOlavo)
                {
                    Instantiate(olavoPrefab, new Vector3(6.02f, -1.9f, 1), Quaternion.identity);
                    callOlavo = true;
                }
            }
            if (runningTime > 42.5f)
            {
                gInstance.globalspeed = 1.2f;



            }
            if (runningTime > 51f)
            {
                gInstance.globalspeed = 1.3f;
                if (!callHelio)
                {
                    Instantiate(helioPrefab, new Vector3(6.08f, -1.66f, 1), Quaternion.identity);
                    speedUpPrefab.SetActive(true);
                    callHelio = true;
                }
            }
            if (runningTime > 60f)
            {
                gInstance.runType = 2;
            }
            if (gInstance.runType != 0 && !activearvore)
            {
                arvore.SetActive(true);
                arvore2.SetActive(true);
                activearvore = true;
            }
        }
    }


}
