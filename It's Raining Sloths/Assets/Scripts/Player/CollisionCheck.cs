using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    bool m_Started;
    public LayerMask m_LayerMask;
    Collider myCollider;
    float radius = 10f;
    bool colliding = false;

    [SerializeField] int collisionBuffer = 10;
    [SerializeField]


    void Start()
    {
        m_Started = true;
        myCollider = GetComponent<Collider>();
    }

    void FixedUpdate()
    {
        HandleCollision();
    }


    void HandleCollision()
    {
        if (myCollider == null) return;

        Collider[] outHitColliders = new Collider[collisionBuffer];
        int count = Physics.OverlapBoxNonAlloc(myCollider.bounds.center, myCollider.bounds.size / 2, outHitColliders);

        for (int i = 0; i < count; ++i)
        {
            Collider collider = outHitColliders[i];

            if (collider == myCollider)
                continue;

            if (collider.gameObject.CompareTag("Branch") && collider.transform.position.y  >= myCollider.transform.position.y)
            {
                Vector3 otherPosition = collider.transform.position;
                Quaternion otherRotation = collider.transform.rotation;

                Vector3 direction;
                float distance;

                bool overlapped = Physics.ComputePenetration(
                    myCollider, myCollider.transform.position, myCollider.transform.rotation,
                    collider, otherPosition, otherRotation,
                    out direction, out distance
                );

                if (overlapped)
                {
                    transform.position += direction * distance;
                }
                colliding = overlapped;
            }
        }
    }

    public bool Colliding()
    {
        return colliding;
    }
}

