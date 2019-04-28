using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    bool m_Started;
    public LayerMask m_LayerMask;
    Collider myCollider;
    float radius = 10f;

    [SerializeField] int collisionBuffer = 10;


    void Start()
    {
        m_Started = true;
        myCollider = GetComponent<Collider>();
       // radius = transform.localScale.y;
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
        Debug.Log(count);

        for (int i = 0; i < count; ++i)
        {
            Collider collider = outHitColliders[i];

            if (collider == myCollider)
                continue;

            if (collider.gameObject.CompareTag("Branch") /*&& collider.gameObject.transform.position.y >= transform.position.y*/)
            {
                Debug.Log("Hitting branch");
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

                if (overlapped) Debug.Log("HIT");
            }
        }

    }
}

