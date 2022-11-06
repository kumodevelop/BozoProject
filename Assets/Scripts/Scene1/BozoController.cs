using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BozoController : MonoBehaviour
{
    public Vector3 smokePosition;
    public float speedMove;
    private GameManager gInstance;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        gInstance = GameManager.GetInstance();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gInstance.runType==1)
        {
            if (this.transform.position.x > 1.76)
            {
                this.transform.position += Vector3.left * (speedMove * gInstance.globalspeed) * Time.deltaTime;
                anim.SetBool("littleTired", true);
            }
        }
        if(gInstance.runType==2)
        {
            if (this.transform.position.x > -3.39)
            {
                this.transform.position += Vector3.left * (speedMove * gInstance.globalspeed) * Time.deltaTime;
                anim.SetBool("littleTired", false);
                anim.SetBool("soTired", true);
            }
        }
    }
    void CallSmoke()
    {
        if(gInstance.gameState==1)
            SmokePooling.GetInstance().Create(new Vector3(transform.position.x+smokePosition.x, smokePosition.y,smokePosition.z), transform.localRotation);
    }
}
