using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoController : MonoBehaviour
{
    public float timeCounter;
    public float timeEnd;
    
    IEnumerator Timecount()
    {
        yield return new WaitForSeconds(timeEnd);
        this.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        StartCoroutine(Timecount());
    }
}
