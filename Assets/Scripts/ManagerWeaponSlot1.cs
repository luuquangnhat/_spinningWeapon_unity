using UnityEngine;

public class ManagerWeaponSlot1 : MonoBehaviour
{
    private float speed = 1f;
    public float rotation = 10f;
    public bool isEquipped;
    public bool isMove;
    private float weaponDistanceY = 1f;

    public void setPosition(int count, int index)
    {
        float degree = 360 / count * index;
        //degree += 90;
        float radius = 1;
        float rad = Mathf.PI * degree / 180;
        float weaponPosX = this.transform.parent.position.x + radius * Mathf.Cos(rad);
        float weaponPosY = this.transform.parent.position.y + radius * Mathf.Sin(rad);
        reUpdatePosition(new Vector3(
          weaponPosX,
          this.transform.parent.position.y + weaponDistanceY,
          weaponPosY
       ));
    }

    private void reUpdatePosition(Vector3 newPosition)
    {
        this.transform.position = newPosition;
    }
    float calAngle(Vector3 point0, Vector3 pointA, Vector3 pointB)
    {
        Vector3 vector0A = point0 - pointA;
        Vector3 vector0B = point0 - pointB;
        return Vector3.Angle(vector0A, vector0B);
    }

    void FixedUpdate()
    {
        if (this.transform.parent && isMove)
        {
            Vector3 point0 = this.transform.parent.transform.localPosition;
            Vector3 pointA = transform.position;
            transform.RotateAround(this.transform.parent.transform.localPosition + Vector3.down, Vector3.down, rotation * speed * Time.deltaTime);
            Vector3 pointB = transform.position;

            float angle = calAngle(point0, pointA, pointB);
        }
    }
}
