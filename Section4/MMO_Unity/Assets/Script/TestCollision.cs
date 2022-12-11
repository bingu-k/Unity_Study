using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    // 본인한테 RigidBody가 있어야 한다.  (IsKinematic : OFF)
    // 본인한테 Collider가 있어야 한다.   (IsTrigger : OFF)
    // 상대한테 Collider가 있어야 한다.   (IsTrigger : OFF)
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"{collision.gameObject.name} Collision!");
    }

    // 본인, 상대에게 Collider가 있어야 한다.
    // 둘 중 하나는 IsTrigger : On
    // 둘 중 하나는 RigidBody가 있어야 한다.
    private void OnTriggerEnter(Collider other)
    {
        
        Debug.Log($"{other.gameObject.name} Trigger!");
    }

    void Start()
    {
        
    }

    void Update()
    {
        // 현재 보고있는 방향
        Vector3 look = transform.TransformDirection(Vector3.forward);
        // 보고있는 방향으로 10의 RED Ray를 쏘겠다.
        Debug.DrawRay(transform.position + Vector3.up, look * 10, Color.red);
        // 쏘아진 Ray를 통해 부딫힌 모든것들을 저장
        RaycastHit[] hits = Physics.RaycastAll(transform.position + Vector3.up, look, 10);
        // 부딪힌 물체의 Log 남기기
        foreach (RaycastHit hit in hits)
        {
            Debug.Log($"{hit.collider.gameObject.name} Ray Cast!");
        }

        // Loacl <-> World <-> ViewPort <-> Screen
        //Debug.Log(Input.mousePosition); // Screen
        //Debug.Log(Camera.main.ScreenToViewportPoint(Input.mousePosition));  // ViewPort
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
            //Vector3 dir = (mousePos - Camera.main.transform.position).normalized;
            //Debug.DrawRay(Camera.main.transform.position, ray.direction * 10.0f, Color.red, 1.0f);

            // 내가 추가한 Layer를 수정해서 진행함.
            int mask = LayerMask.GetMask("Monster") | LayerMask.GetMask("Wall");// (1 << 8) | (1 << 9) = 768

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10.0f, mask))
            //if (Physics.Raycast(Camera.main.transform.position, dir, out hit, 10.0f))
            {
                Debug.DrawRay(Camera.main.transform.position, ray.direction * hit.distance, Color.red, 1.0f);
                // Tag와 Layer처럼 비슷하게 진행됨.
                Debug.Log($"{hit.collider.gameObject.tag} Ray Cast");
            }
        }
    }
}
