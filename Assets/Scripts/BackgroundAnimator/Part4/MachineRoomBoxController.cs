using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineRoomBoxController : MonoBehaviour
{
    public List<Sprite> BoxSpriteList;
    public GameObject BoxObject;

    public Transform InitPos;

    List<GameObject> BoxPool= new List<GameObject>();
    int iPoolIndex = 0; 
    void setInit()
    {
        for(int i =0; i <30; i++)
        {
            GameObject temp = Instantiate(BoxObject);
            temp.transform.SetParent(BoxObject.transform.parent);
            temp.transform.localScale = BoxObject.transform.localScale;
            temp.transform.position = InitPos.position;
            temp.SetActive(false);
            int rand = Random.Range(0, BoxSpriteList.Count);
            temp.GetComponent<SpriteRenderer>().sprite = BoxSpriteList[rand];
            BoxPool.Add(temp);
        }
    }
    private void OnEnable()
    {
        bDisable = false;
        if (BoxPool.Count ==0)
        {
            setInit();
        }
        iPoolIndex = 0;
        StartCoroutine(BoxMakeRoutine());
    }
    IEnumerator BoxMakeRoutine()
    {
        if(bDisable ==false)
        {
            yield return new WaitForSeconds(1.5f);
            if (iPoolIndex >= BoxPool.Count)
            {
                iPoolIndex = 0;
            }
            BoxPool[iPoolIndex].transform.position = InitPos.position;
            BoxPool[iPoolIndex].SetActive(true);
            iPoolIndex++;              
            StartCoroutine(BoxMakeRoutine());
        }
        
    }
    bool bDisable = false;
    private void OnDisable()
    {
        bDisable = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
