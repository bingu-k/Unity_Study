using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    public Define.CameraMode _mode = Define.CameraMode.QuarterView;
    [SerializeField]
    public Vector3 _delta = new Vector3(0.0f, 6.0f, -5.0f);
    [SerializeField]
    public GameObject _player = null;

    void Start()
    {
        
    }

    void LateUpdate()
    {
        if (_mode == Define.CameraMode.QuarterView)
        {
            RaycastHit hit;
            if (Physics.Raycast(_player.transform.position, _delta, out hit, _delta.magnitude, LayerMask.GetMask("Wall")))
            {
                float dist = (hit.point - _player.transform.position).magnitude * 0.8f;
                transform.position = _player.transform.position + _delta.normalized * dist;
            }
            else
            {
                // _player를 기준으로 _delta만큼 떨어져서 카메라를 위치(Position)
                transform.position = _player.transform.position + _delta;

                // _player의 기준축을 화면의 가운데에 오게 설정(Rotation)
                transform.LookAt(_player.transform);
            }
        }
    }

    public void SetQuaterView(Vector3 delta)
    {
        _mode = Define.CameraMode.QuarterView;
        _delta = delta;
    }
}
