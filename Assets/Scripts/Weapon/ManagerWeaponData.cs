using System;
using Unity.VisualScripting;
using UnityEngine;

public class ManagerWeaponData : MonoBehaviour
{
    private WeaponStatusData weaponData;
    private IWeapon weapon;
    public WeaponStatusData WeaponData
    {
        get => weaponData;
    }
    public IWeapon Weapon { get => weapon; }

    public void setWeaponData(WeaponStatusData data)
    {
        if (weaponData == null)
        {
            weaponData = data;
            checkWeaponType();
        }
    }

    void checkWeaponType()
    {
        if (this.transform.GetComponent<ManagerWeaponShortRangeAction>())
        {
            weaponData.wpRangeType = EWeaponRangeType.ShortRange;
            weapon = this.transform.GetComponent<ManagerWeaponShortRangeAction>();
        }
        if (this.transform.GetComponent<ManagerWeaponLongRangeAction>())
        {
            weaponData.wpRangeType = EWeaponRangeType.LongRange;
            weapon = this.transform.GetComponent<ManagerWeaponLongRangeAction>();
        }
    }
    void Update()
    {
    }
}
