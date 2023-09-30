using UnityEngine;

public class ManagerWeaponLongRangeAction : MonoBehaviour, IWeapon
{
    public GameObject SlotTarget;
    private GameObject enemyTarget;
    public EWeaponActionType currentAction;
    private ManagerWeaponData weaponData;

    public GameObject EnemyTarget
    {
        get { return enemyTarget; }
    }
    public void SetEnemyTarget(GameObject target)
    {
        enemyTarget = target;
    }
    public void SetWeaponSlot(GameObject slotTarget)
    {
        SlotTarget = slotTarget;
    }

    private void Awake()
    {
        weaponData = GetComponent<ManagerWeaponData>();
        currentAction = EWeaponActionType.IsIdle;
    }

    private void FixedUpdate()
    {
        handleTakeAction(Time.deltaTime);
    }

    void handleTakeAction(float time)
    {
        if (!SlotTarget) return;
        switch (currentAction)
        {
            case EWeaponActionType.IsIdle:
                HandleIdle();
                break;
            case EWeaponActionType.IsMovingToEnemy:
                HandleIdle();
                break;
            case EWeaponActionType.IsAttacking:
                if (!enemyTarget)
                {
                    currentAction = EWeaponActionType.IsIdle;
                };
                HandleAttacking(enemyTarget, time);
                break;
            case EWeaponActionType.IsReturning:
                HandleStopAttacking();
                break;
            default:
                throw new System.Exception("Error_NoWeaponAction");
        }
    }


    public void HandleIdle()
    {
        transform.position = SlotTarget.transform.position;
        transform.rotation = SlotTarget.transform.rotation;
    }

    public void HandleAttacking(GameObject enemyTarget, float time)
    {
        Debug.Log("long - handleAttacking");
    }

    public void HandleStopAttacking()
    {
        Debug.Log("long - handleAttacking");
    }

    public void HandleMoveToEnemy(float time)
    {
        throw new System.NotImplementedException();
    }

    public void HandleAttacking()
    {
        throw new System.NotImplementedException();
    }
}
