using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRunController : MonoBehaviour
{
    public float speed;
    private GameManager gInstance;
    
    // Start is called before the first frame update
    void Start()
    {
        gInstance = GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.left * (speed * gInstance.globalspeed) * Time.deltaTime;
        if (this.transform.position.x < -8f)
        {
            Destroy(gameObject);
        }
    }

}
