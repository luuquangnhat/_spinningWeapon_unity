using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageWeapon : MonoBehaviour
{
    public GameObject mainTarget;
    public float speed = 20;
    public bool isSpin;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpin)
        {
            transform.RotateAround(mainTarget.transform.localPosition + Vector3.down, Vector3.down, speed * Time.deltaTime);
        }
    }

    public void setPosition(GameObject target, float distance)
    {
        mainTarget = target;
        //transform.position = 
    }
}
