using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    // �������� RigidBody�� �־�� �Ѵ�.  (IsKinematic : OFF)
    // �������� Collider�� �־�� �Ѵ�.   (IsTrigger : OFF)
    // ������� Collider�� �־�� �Ѵ�.   (IsTrigger : OFF)
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"{collision.gameObject.name} Collision!");
    }

    // ����, ��뿡�� Collider�� �־�� �Ѵ�.
    // �� �� �ϳ��� IsTrigger : On
    // �� �� �ϳ��� RigidBody�� �־�� �Ѵ�.
    private void OnTriggerEnter(Collider other)
    {
        
        Debug.Log($"{other.gameObject.name} Trigger!");
    }

    void Start()
    {
        
    }

    void Update()
    {
        // ���� �����ִ� ����
        Vector3 look = transform.TransformDirection(Vector3.forward);
        // �����ִ� �������� 10�� RED Ray�� ��ڴ�.
        Debug.DrawRay(transform.position + Vector3.up, look * 10, Color.red);
        // ����� Ray�� ���� �΋H�� ���͵��� ����
        RaycastHit[] hits = Physics.RaycastAll(transform.position + Vector3.up, look, 10);
        // �ε��� ��ü�� Log �����
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

            // ���� �߰��� Layer�� �����ؼ� ������.
            int mask = LayerMask.GetMask("Monster") | LayerMask.GetMask("Wall");// (1 << 8) | (1 << 9) = 768

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10.0f, mask))
            //if (Physics.Raycast(Camera.main.transform.position, dir, out hit, 10.0f))
            {
                Debug.DrawRay(Camera.main.transform.position, ray.direction * hit.distance, Color.red, 1.0f);
                // Tag�� Layeró�� ����ϰ� �����.
                Debug.Log($"{hit.collider.gameObject.tag} Ray Cast");
            }
        }
    }
}
