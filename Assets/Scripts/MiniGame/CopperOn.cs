using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopperOn : MonoBehaviour
{
    public GameObject Copper;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {       
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Copper.SetActive(spriteRenderer.enabled);
        Check();
    }
    public void Check()
    {
        if (GameManager.Instance.styxData.strEnableCopperwire == "active" && GameManager.Instance.styxData.CopperWireIndex ==0)
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
