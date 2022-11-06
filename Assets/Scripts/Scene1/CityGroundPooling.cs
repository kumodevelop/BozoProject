using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityGroundPooling : MonoBehaviour
{
    public GameObject[] pooling = null;
    public GameObject prefab = null;
    public int maxObjects = 0;

    private static CityGroundPooling uniqueInstance = null;
    public static CityGroundPooling GetInstance()
    {
        return uniqueInstance;
    }

    public void Create(Vector3 position, Quaternion rotation)
    {
        for (int i = 0; i < maxObjects; i++)
        {
            if (!pooling[i].activeSelf)
            {
                pooling[i].SetActive(true);
                pooling[i].transform.position = position;
                pooling[i].transform.rotation = rotation;
             //   pooling[i].SendMessage("nameCaller", caller);
                break;
            }
        }
    }

    public void ReturnToPool(GameObject poolObject)
    {
        poolObject.SetActive(false);
    }



    private void Awake()
    {
        if (uniqueInstance == null)
        {
            uniqueInstance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        //maxObjects = GameManager.GetInstance().getLimiteInimigos();
        //Debug.Log(GameManager.GetInstance().getLimiteInimigos().ToString());
        pooling = new GameObject[maxObjects];
        for (int i = 0; i < maxObjects; i++)
        {        
            pooling[i] = GameObject.Instantiate<GameObject>(prefab);
            pooling[i].SetActive(false);

        }

    }







}
