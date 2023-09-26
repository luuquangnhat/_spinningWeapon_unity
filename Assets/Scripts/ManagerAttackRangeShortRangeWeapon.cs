using System.Collections.Generic;
using UnityEngine;

public class ManagerAttackRangeShortRangeWeapon : MonoBehaviour
{
    private List<GameObject> weapons;

    private void OnEnable()
    {
        weapons = this.transform.parent.gameObject.GetComponent<ManagerCharacterStatus>().WeaponEquips;
    }

    // TODO
    // - check OnTriggerEnter collision
    // - check OnTriggerStay collision
    // - check OnTriggerExit collision
}
