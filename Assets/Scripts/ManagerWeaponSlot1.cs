using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerWeaponSlot1 : MonoBehaviour
{
    public float speed = 40f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void updatePosition()
    {
        if (this.transform.parent)
        {
            transform.position = new Vector3(
                this.transform.parent.transform.position.x,
                this.transform.parent.transform.position.y + 1,
                this.transform.parent.transform.position.z + 1
            );
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (this.transform.parent)
        {
            transform.RotateAround(this.transform.parent.transform.localPosition + Vector3.down, Vector3.down, speed * Time.deltaTime);
        }
    }
}
