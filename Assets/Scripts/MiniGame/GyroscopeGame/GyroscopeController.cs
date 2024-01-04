using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GyroscopeController : MonoBehaviour
{
    public Transform target;
    public Text InfoText;
    public Text ResultText;

    public Image WarningImage;
    public Text WarningText;
    void Start()
    {
        Input.gyro.enabled = true;
    }

    

    // Update is called once per frame
    void Update()
    {
        ResultText.text = Input.gyro.rotationRate.ToString();
        target.Rotate(Input.gyro.rotationRateUnbiased.x, Input.gyro.rotationRateUnbiased.y, Input.gyro.rotationRateUnbiased.z);
        InfoText.text = "Input.gyro.rotationRateUnbiased.x == " + Input.gyro.rotationRateUnbiased.x + "\n" + "Input.gyro.rotationRateUnbiased.y == " + Input.gyro.rotationRateUnbiased.y + "\n" + "Input.gyro.rotationRateUnbiased.z == "+Input.gyro.rotationRateUnbiased.z;

        float warningIndex = Mathf.Abs(Input.gyro.rotationRate.x) + Mathf.Abs(Input.gyro.rotationRate.y) + Mathf.Abs(Input.gyro.rotationRate.z);
        if(warningIndex <=0.11f)
        {
            WarningText.text = "안정 !";
            WarningImage.color = new Color(0, 1, 0);
        }
        else
        {
            if(warningIndex >1f)
            {
                WarningText.text = "종료 !";
                WarningImage.color = new Color(0, 0, 0);
            }
            else
            {
                WarningText.text = "주의 !";
                WarningImage.color = new Color(1, 0, 0);
            }            
        }        
    }
}
