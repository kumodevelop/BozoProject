using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    public Vector3 nuvemStart;
    public Vector3 nuvemEnd;
    public float speed;
    public bool iscloud = false;
    public bool isforest = false;
    private GameManager gInstance;// = GameManager.GetInstance();
    // Start is called before the first frame update
    void Start()
    {
        gInstance = GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        //if (GameManager.GetInstance().runType == 1)            
        //    speed = 0;
        this.transform.position += Vector3.left * (speed * gInstance.globalspeed) * Time.deltaTime;
        if (this.transform.position.x < nuvemEnd.x)
        {
            if (gInstance.runType == 0 || iscloud)
                this.transform.position = nuvemStart;
            else if((gInstance.runType != 0 && isforest) || iscloud)
            {
                this.transform.position = nuvemStart;
            }
            else
            this.gameObject.SetActive(false);

        }
        else
        {
            
        }
    }
}

