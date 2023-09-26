using UnityEngine;

public class ManagerAttackRangeShortRange : MonoBehaviour, IWeapon
{
    private GameObject enemyTarget;
    private ManagerWeaponObj1 weaponData;
    private void Awake()
    {
        weaponData = GetComponent<ManagerWeaponObj1>();
    }
    private void OnTriggerEnter(Collider other)
    {
    }

    private void OnTriggerStay(Collider other)
    {
    }

    private void OnTriggerExit(Collider other)
    {
    }

    private void FixedUpdate()
    {
        moveWeaponToEnemy(Time.deltaTime);
    }

    private void moveWeaponToEnemy(float time)
    {
        if (enemyTarget)
        {
            float distance = Vector3.Distance(enemyTarget.transform.position, weaponData.transform.position);

            if (distance <= weaponData.WeaponData.wpRange)
            {
                // TODO: 
                // - attack
            }
            else
            {
                float step = weaponData.WeaponData.wpMoveSpeed * time;
                transform.position = Vector3.MoveTowards(this.transform.position, enemyTarget.transform.position, step);
            }
        }
    }

    public void handleIdle()
    {
        // TODO: 
        // - animation idle
    }

    public void handleAttacking(GameObject enemyTarget)
    {
        // TODO: 
        // - select enemyTarget
        // - 
    }

    public void handleStopAttacking()
    {
    }
}
