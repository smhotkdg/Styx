using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part2SteelDoorSelect : MonoBehaviour
{
    public delegate void OnSelect(bool flag);
    public event OnSelect OnSelectHandler;
    int selectIndex = -1;
    private void OnEnable()
    {
        selectIndex = -1;
    }
    public void Select(int index)
    {
        selectIndex = index;
        GetComponent<Animator>().Play("part2SelectBack");
        if(index ==1)
        {
            OnSelectHandler?.Invoke(false);
        }
        else
        {
            OnSelectHandler?.Invoke(true);
        }
        
    }
    private void OnDisable()
    {
        if(selectIndex ==1)
        {

        }
        else if(selectIndex ==2)
        {

        }
    }
}
