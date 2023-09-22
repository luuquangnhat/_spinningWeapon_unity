using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerWeaponSlot1 : MonoBehaviour
{
    public GameObject MainTarget;
    public float speed = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void updatePosition(GameObject mainTarget)
    {
        MainTarget = mainTarget;
        if (mainTarget)
        {
            transform.position = new Vector3(
                mainTarget.transform.position.x,
                mainTarget.transform.position.y + 1,
                mainTarget.transform.position.z + 1
            );
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (MainTarget)
        {
            transform.RotateAround(MainTarget.transform.localPosition + Vector3.down, Vector3.down, speed * Time.deltaTime);
        }
    }
}
