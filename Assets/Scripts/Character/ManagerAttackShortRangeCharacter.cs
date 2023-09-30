using System.Collections.Generic;
using UnityEngine;
using static ManagerCharacterStatus;

public class ManagerAttackShortRangeCharacter : MonoBehaviour
{
    private List<GameObject> weapons;
    public int radius = 7;

    private void OnEnable()
    {
        weapons = this.transform.parent.gameObject.GetComponent<ManagerCharacterStatus>().WeaponShortRangeEquips;
        this.gameObject.GetComponent<SphereCollider>().radius = radius;
    }

    private void OnTriggerEnter(Collider other)
    {
        ManagerCharacterStatus colliderTarget = other.gameObject.GetComponent<ManagerCharacterStatus>();

        if (colliderTarget
            && colliderTarget.Type != this.transform.parent.gameObject.GetComponent<ManagerCharacterStatus>().Type)
        {
            switch (this.transform.parent.gameObject.GetComponent<ManagerCharacterStatus>().Type)
            {
                case (CharacterType.Main):
                    handleMainAttack(colliderTarget);
                    break;
                case (CharacterType.NPC):
                    handleNPCAttack(colliderTarget);
                    break;
                case (CharacterType.Enemy):
                    handleEnemyAttack(colliderTarget);
                    break;
                default:
                    throw new System.Exception("Error_InvalidColliderTargetType");
            }
        }
    }

    void handleEnemyAttack(ManagerCharacterStatus colliderTarget)
    {


    }
    void handleMainAttack(ManagerCharacterStatus colliderTarget)
    {
        if (colliderTarget.Type == CharacterType.Enemy)
        {
            for (int i = 0; i < weapons.Count; i++)
            {
                if (weapons[i].gameObject.GetComponent<ManagerWeaponShortRangeAction>().EnemyTarget == null
                    && colliderTarget.Type == CharacterType.Enemy
                    && weapons[i].gameObject.GetComponent<ManagerWeaponData>().WeaponData.wpDamage <= colliderTarget.Health)
                {
                    weapons[i].gameObject.GetComponent<ManagerWeaponShortRangeAction>().SetEnemyTarget(colliderTarget.gameObject);
                    weapons[i].gameObject.GetComponent<ManagerWeaponShortRangeAction>().CurrentAction = EWeaponActionType.IsMovingToEnemy;
                }
            }
        }
    }
    void handleNPCAttack(ManagerCharacterStatus colliderTarget)
    {

    }

    private void OnTriggerStay(Collider other)
    {
    }

    private void OnTriggerExit(Collider other)
    {
    }

}
