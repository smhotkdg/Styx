using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm_Wall : MonoBehaviour
{
    public List<GameObject> FireList;
    BoxCollider2D boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.data.Accesscard == 1)
        {
            boxCollider.enabled = true;
            for(int i=0; i< FireList.Count; i++)
            {
                FireList[i].SetActive(true);
            }
        }
        else
        {
            boxCollider.enabled = false;
            for (int i = 0; i < FireList.Count; i++)
            {
                FireList[i].SetActive(false);
            }
        }

    }
}
