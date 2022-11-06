using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    public GameObject actualGround;
    public GameObject nextGround;
    public Vector3 groundStart;
    public Vector3 groundEnd;
    public Vector3 newStartGround;
    public Vector3 newEndGround;
    public float speed;
    private GameManager gInstance;// = GameManager.GetInstance();
    // Start is called before the first frame update
    void Start()
    {
        // actualGround = CityGroundPooling.GetInstance().Create(groundStart, transform.localRotation);
        gInstance = GameManager.GetInstance();
    }
    public void changeGround()
    {
       
        GameManager.GetInstance().runType = 1;
    }

    // Update is called once per frame
    void Update()
    {
        actualGround.transform.position += Vector3.left * (speed*GameManager.GetInstance().globalspeed) * Time.deltaTime;
        if (actualGround.transform.position.x <= groundEnd.x)
        {
            actualGround.transform.position = groundStart;
        }
        //if (GameManager.GetInstance().runType == 1)
           // speed = GameManager.GetInstance().globalspeed;

        if(gInstance.runType==1)
        {
            groundStart = newStartGround;
            groundEnd = newEndGround;
        }

    }
}
