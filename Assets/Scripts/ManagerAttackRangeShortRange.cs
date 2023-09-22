using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerAttackRangeShortRange : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.GetComponent<ManagerCharacterStatus>().Type == ManagerCharacterStatus.CharacterType.Enemy)
        {
                
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //if (other.GetComponent<ManagerCharacterMovingPosition>().IsMain == false)
        //{
        //    Debug.Log($"name {other.name}");
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        //if (other.GetComponent<ManagerCharacterMovingPosition>().IsMain == false)
        //{
        //    Debug.Log($"name {other.name}");
        //}
    }
}
