using System;
using UnityEngine;

public class ManagerWeaponObj1 : MonoBehaviour
{
    public GameObject SlotTarget;
    public ActionWeapon currentAction;
    private WeaponStatusData weaponData;

    public WeaponStatusData WeaponData
    {
        get => weaponData;
    }

    public enum ActionWeapon
    {
        IsIdle, IsAttacking, IsStopAttacking
    }

    void Start()
    {
        fakeData();
    }

    void fakeData()
    {
        weaponData = new WeaponStatusData();
        weaponData.id = Guid.NewGuid().ToString();
        weaponData.wpName = this.gameObject.name;
        weaponData.wpDamage = 20;
        weaponData.wpRange = 1;
        weaponData.wpAttackSpeed = 2;
    }

    void Update()
    {
        handleTakeAction();
    }

    private void OnEnable()
    {
        currentAction = ActionWeapon.IsIdle;
    }

    public void setSlotTarget(GameObject slotTarget)
    {
        SlotTarget = slotTarget;
    }

    void handleTakeAction()
    {
        if (!SlotTarget) return;
        switch (currentAction)
        {
            case ActionWeapon.IsIdle:
                handleIsIdle();
                break;
            case ActionWeapon.IsAttacking:
                //handleIsAttacking();
                break;
            case ActionWeapon.IsStopAttacking:
                handleIsStopAttacking();
                break;
            default:
                throw new System.Exception("Error");
        }
    }

    void handleIsIdle()
    {
        transform.position = SlotTarget.transform.position;
        transform.rotation = SlotTarget.transform.rotation;
    }

    void handleIsAttacking(GameObject enemyTarget)
    {

    }
    void handleIsStopAttacking()
    {

    }
}
