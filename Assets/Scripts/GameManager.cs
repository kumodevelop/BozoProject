using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager gm;
    public int runType = 0;
    public float globalspeed = 0;
    public int gameState;

    
    //1 - Play
    //2 - Pause
    //3 - Lose
    //4 - Win
    //5 - Menu

    public static GameManager GetInstance()
    {
        return gm;
    }
    // Start is called before the first frame update
    void Awake()
    {
        if (gm == null)
        {
            gm = this;
            //Estado = "Play";
            //Ntf = GameObject.Find("notify");
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gameState==3)
        {
            globalspeed = 0;
        }
    }

    


}
