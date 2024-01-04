using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutLoudController : MonoBehaviour
{
    public enum NPCType
    {
        Famrmer,
        NON,
        Fire
    }
    public NPCType Type = NPCType.NON;

    private void OnEnable()
    {
        bDisable = false;
        StartCoroutine(OutLoudRoutine());
    }
    IEnumerator OutLoudRoutine()
    {
        if (bDisable == false)
        {
            float rand_f = Random.Range(3, 15);
            if (bDisable == false)
            {
                yield return new WaitForSeconds(rand_f);
                switch (Type)
                {
                    case NPCType.Famrmer:
                        UIManager.Instance.setDialogue(this.gameObject, languageController.Instance.GetOutLoudFammer(), 100, 1.5f);
                        break;
                    case NPCType.Fire:
                        UIManager.Instance.setDialogue(this.gameObject, languageController.Instance.GetFireEventRandom(), 120, 1.5f);
                        break;
                }
                float rand_d = Random.Range(1, 6);
                yield return new WaitForSeconds(rand_d);
            }
           
            if (bDisable == false)
            {
                StartCoroutine(OutLoudRoutine());
            }
        }
        
        
    }
    bool bDisable = false;
    private void OnDisable()
    {
        bDisable = true;
        StopAllCoroutines();
    }
}
