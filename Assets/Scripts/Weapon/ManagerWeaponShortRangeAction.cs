using UnityEngine;

public class ManagerWeaponShortRangeAction : MonoBehaviour, IWeapon
{
    public GameObject SlotTarget;
    private GameObject enemyTarget;
    private EWeaponActionType currentAction;
    public EWeaponActionType CurrentAction
    {
        get { return currentAction; }
        set
        {
            currentAction = value;
            shortRangeAnimationController.CheckCurrentAction(value);
            shortRangeAnimationController.TestFunctionTriggerAttackFalse(ref value);
        }
    }

    [Header("Require Binding")]
    [SerializeField]
    private ShortRangeAnimationController shortRangeAnimationController;
    [SerializeField]
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
        currentAction = EWeaponActionType.IsIdle;
    }
    private void Update()
    {
    }
    private void FixedUpdate()
    {
        handleTakeAction(Time.deltaTime);
    }

    void handleTakeAction(float time)
    {
        if (!SlotTarget) return;
        Debug.Log($"currentAction {currentAction}");
        switch (currentAction)
        {
            case EWeaponActionType.IsIdle:
                HandleIdle();
                break;
            case EWeaponActionType.IsMovingToEnemy:
                HandleMoveToEnemy(time);
                break;
            case EWeaponActionType.IsAttacking:
                HandleAttacking();
                break;
            case EWeaponActionType.IsReturning:
                HandleStopAttacking();
                break;
            default:
                throw new System.Exception("Error_handleTakeAction_NoWeaponAction");
        }
    }

    public void HandleIdle()
    {
        transform.position = SlotTarget.transform.position;
        transform.rotation = SlotTarget.transform.rotation;
    }


    public void HandleMoveToEnemy(float time)
    {
        if (enemyTarget)
        {
            Vector3 endPoint = new Vector3(enemyTarget.transform.position.x,
               enemyTarget.gameObject.GetComponent<CapsuleCollider>().height / 2,
               enemyTarget.transform.position.z);
            Debug.Log($"enemyTarget {enemyTarget}");
            float distance = Vector3.Distance(this.transform.position, endPoint);
            float step = weaponData.WeaponData.wpMoveSpeed * time;
            this.transform.LookAt(new Vector3(this.transform.position.x, this.transform.position.y * -1, this.transform.position.z), endPoint);
            this.transform.position = Vector3.MoveTowards(this.transform.position, endPoint, step);
            if(distance <= weaponData.WeaponData.wpRange)
            {
                currentAction = EWeaponActionType.IsAttacking;
            }
        }
    }

    public void HandleAttacking()
    {
        // TODO: 
        // - attack
    }


    public void HandleStopAttacking()
    {
    }

}
