using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class OutlineColider : MonoBehaviour
{     
    Material EffectMat;
    SpriteRenderer spriteRenderer;

    private Material MyMat;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        EffectMat = GetComponent<Renderer>().material;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="player")
        {
            //spriteRenderer.material = EffectMat;            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag =="player")
        {            
        }
        
    }
    float effectColor = 0;
    private void Update()
    {

        effectColor += Time.deltaTime;
        float shininess = Mathf.PingPong(Time.time, 4.0f);        
        if(effectColor >=4)
        {
            effectColor = 0;
        }
        EffectMat.SetFloat("_ShadowLIght_Intensity_1", effectColor);
    }
}
