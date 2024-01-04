using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileObject : MonoBehaviour
{
    public float Speed = 5;
    public GameObject Boom;
    public GameObject Boom2;
    public delegate void Hit();
    public event Hit HitEventHandler;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="player")
        {
            if (Boom.activeSelf == true)
                Boom2.SetActive(true);
            Boom.SetActive(true);
            HitEventHandler?.Invoke();
            this.gameObject.SetActive(false);

        }        
    }
    // Update is called once per frame
    void Update()
    {
        transform.localPosition += new Vector3(Speed * +Time.deltaTime, 0);
    }
}
