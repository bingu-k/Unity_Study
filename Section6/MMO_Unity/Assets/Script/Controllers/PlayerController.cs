using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float _speed = 10.0f;

    bool _moveToDest = false;
    Vector3 _destPos;

    void Start()
    {
        //Managers.Input.KeyAction -= OnKeyboard;
        //Managers.Input.KeyAction += OnKeyboard;
        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;
    }

    public enum PlayerState
    {
        Die,
        Moving,
        Idle
    }
    PlayerState _state = PlayerState.Idle;

    void UpdateDie()
    {
        // 아무것도 없다.
    }
    void UpdateMoving()
    {
        Vector3 dir = _destPos - transform.position;
        if (dir.magnitude < float.Epsilon)
        {
            _state = PlayerState.Idle;
        }
        else
        {
            float moveDist = Mathf.Clamp(_speed * Time.deltaTime, 0, dir.magnitude);
            transform.position += dir.normalized * moveDist;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 20 * Time.deltaTime);
        }

        // Animation
        Animator anim = GetComponent<Animator>();
        // 현재 게임 상태에 대한 정보를 넘겨줌.
        anim.SetFloat("speed", _speed);
    }
    void UpdateIdle()
    {
        // Animation
        Animator anim = GetComponent<Animator>();
        // 현재 게임 상태에 대한 정보를 넘겨줌.
        anim.SetFloat("speed", 0);
    }

    void OnRunEvent()
    {
        Debug.Log("뚜벅 뚜벅 뚜벅쵸~!");
    }
    void Update()
    {
        switch (_state)
        {
            case PlayerState.Die:
                UpdateDie();
                break;
            case PlayerState.Moving:
                UpdateMoving();
                break;
            case PlayerState.Idle:
                UpdateIdle();
                break;
        }

        // 하드코딩.
        // 스파게티 코드 만들기 따악 좋다~
        //if (_moveToDest)
        //    wait_run_ratio = Mathf.Lerp(wait_run_ratio, 1, 10.0f * Time.deltaTime);
        //else
        //    wait_run_ratio = Mathf.Lerp(wait_run_ratio, 0, 10.0f * Time.deltaTime);
        //Animator anim = GetComponent<Animator>();
        //anim.SetFloat("wait_run_ratio", wait_run_ratio);
        //anim.Play("WAIT_RUN");
    }

    //void OnKeyboard()
    //{
    //    if (Input.GetKey(KeyCode.UpArrow))
    //    {
    //        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.2f);
    //        transform.position += Vector3.forward * Time.deltaTime * _speed;
    //    }
    //    if (Input.GetKey(KeyCode.DownArrow))
    //    {
    //        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.2f);
    //        transform.position += Vector3.back * Time.deltaTime * _speed;
    //    }
    //    if (Input.GetKey(KeyCode.LeftArrow))
    //    {
    //        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.2f);
    //        transform.position += Vector3.left * Time.deltaTime * _speed;
    //    }
    //    if (Input.GetKey(KeyCode.RightArrow))
    //    {
    //        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.2f);
    //        transform.position += Vector3.right * Time.deltaTime * _speed;
    //    }
    //}
    void OnMouseClicked(Define.MouseEvent evt)
    {
        if (_state == PlayerState.Die)
            return;
        _state = PlayerState.Moving;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        int mask = LayerMask.GetMask("Wall");
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100.0f, mask))
        {
            Debug.DrawRay(Camera.main.transform.position, ray.direction * hit.distance, Color.red, 1.0f);
            _destPos = hit.point;
            _moveToDest = true;
        }
    }
}
