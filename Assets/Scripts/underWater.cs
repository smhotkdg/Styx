using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
public class underWater : MonoBehaviour
{
    public BuoyancyEffector2D buoyancyEffector;

    private void Start()
    {
        StartCoroutine(MoveChangeRoutine());
    }

    IEnumerator MoveChangeRoutine()
    {
        while(true)
        {            
            yield return new WaitForSeconds(0.7f);
            ChangeEffect();
        }
    }
    public void ChangeEffect()
    {
        //0.8~1.2
        float randDensity = Random.Range(0.6f, 1.4f);
        buoyancyEffector.density = randDensity;
        float randMagitude = Random.Range(-4f, 4f);
        //-3~3
        buoyancyEffector.flowMagnitude = randMagitude;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
