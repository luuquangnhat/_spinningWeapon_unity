using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class ManagerWeaponObj1 : MonoBehaviour
{
    public GameObject SlotTarget;
    public ActionWeapon currentAction;
    public int wpDamage = 20;
    public int wpAttackSped = 2;
    public int wpRange = 20;

    public enum ActionWeapon
    {
        IsIdle, IsAttacking, IsStopAttacking
    }

    void Start()
    {

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
