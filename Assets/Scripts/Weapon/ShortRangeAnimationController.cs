using UnityEngine;

public class ShortRangeAnimationController : MonoBehaviour
{
    [Header("Component")]
    [SerializeField]
    private Animator animator;

    public void CheckCurrentAction(EWeaponActionType currentAction)
    {
        switch (currentAction)
        {
            case EWeaponActionType.IsMovingToEnemy:
                animator.SetBool("isAttacking", true);
                break;
            default:
                animator.SetBool("isAttacking", false);
                break;
        }
    }

    public void TestFunctionTriggerAttackFalse(ref EWeaponActionType currentAction)
    {
        //if (currentAction == EWeaponActionType.IsMovingToEnemy)
        //{
        //    currentAction = EWeaponActionType.IsIdle;
        //}
    }
}
