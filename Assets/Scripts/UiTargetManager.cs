using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class UiTargetManager : MonoBehaviour
{
    public GameObject WorldObject;
    public RectTransform CanvasRect;
    public float y_Margin = 0;
    public float x_Margin = 0;
    RectTransform UI_Element;   
    
    

    void Start()
    {
        //this is the ui element
        UI_Element = GetComponent<RectTransform>();     
    }       
    void FIndWorldPos()
    {
        if (WorldObject == null)
            return;
        Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(WorldObject.transform.position);
       
        Vector2 WorldObject_ScreenPosition = new Vector2(
        ((ViewportPosition.x * CanvasRect.sizeDelta.x) - (CanvasRect.sizeDelta.x * 0.5f)) + x_Margin,
        ((ViewportPosition.y * CanvasRect.sizeDelta.y) - (CanvasRect.sizeDelta.y * 0.5f)) + y_Margin);
        //now you can set the position of the ui element
        UI_Element.anchoredPosition = WorldObject_ScreenPosition;    
    }
    private void LateUpdate()
    {
        if (WorldObject == null)
            return;
        FIndWorldPos();
    }
}
