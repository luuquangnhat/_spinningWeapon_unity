using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class ManagerWeaponObj1 : MonoBehaviour
{
    public GameObject SlotTarget;
    public float speed = 20;
    public ActionWeapon currentAction;

    public enum ActionWeapon
    {
        IsIdle, IsAttacking, IsStopAttacking
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    public void setSlotTarget(GameObject slotTarget)
    {
        SlotTarget = slotTarget;
    }

    private void OnEnable()
    {
        currentAction = ActionWeapon.IsIdle;
    }

    // Update is called once per frame
    void Update()
    {
        handleTakeAction();
    }

    void handleTakeAction()
    {
        if (!SlotTarget) return;
        Debug.Log($"currentAction {currentAction}");
        switch (currentAction)
        {
            case ActionWeapon.IsIdle:
                handleIsIdle();
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
