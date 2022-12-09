using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ��ġ ����
// ���� ����
struct MyVector
{
    public float x;
    public float y;
    public float z;

    // �Ÿ�
    public float magnitude { get {  return Mathf.Sqrt(x*x + y*y + z*z); } }
    // ����
    public MyVector normalize { get { return new MyVector(x / magnitude, y / magnitude, z / magnitude); } }

    public MyVector(float x, float y, float z) { this.x = x; this.y = y; this.z = z; }

    public static MyVector operator +(MyVector v1, MyVector v2)
    { return new MyVector(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z); }
    public static MyVector operator -(MyVector v1, MyVector v2)
    { return new MyVector(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z); }
    public static MyVector operator *(MyVector v, float d)
    { return new MyVector(v.x * d, v.y * d, v.z / d); }
    public static MyVector operator /(MyVector v, float d)
    { return new MyVector(v.x / d, v.y / d, v.z / d); }
}

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float _speed = 10.0f;

    void Start()
    {
        Managers.Input.KeyAction -= OnKeyboard; // 2�� ����� �� �ִ�.
        Managers.Input.KeyAction += OnKeyboard;
    }

    // Game Object (Player)
        // Transform
        // PlayerController
    float _yAngle = 0.0f;
    void Update()
    {
        _yAngle += Time.deltaTime * _speed;
        // ���� ȸ����
        //transform.eulerAngles = new Vector3(0.0f, _yAngle, 0.0f);

        // +- delta
        //transform.Rotate(new Vector3(0.0f, Time.deltaTime * _speed, 0.0f));

        // Gimbal Lock�� �ذ��ϱ� ���� ���(Euler Angle -> Quaternion)
        //Quaternion quaternion = transform.rotation;
        //transform.rotation = Quaternion.Euler(0, _yAngle, 0);
    }

    void OnKeyboard()
    {
        // Local -> World
        //transform.TransformDirection()
        // World -> Local
        //transform.InverseTransformDirection()

        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
        //transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * _speed);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.back * Time.deltaTime * _speed);
        //transform.position += transform.TransformDirection(Vector3.back * Time.deltaTime * _speed);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * Time.deltaTime * _speed);
        //transform.position += transform.TransformDirection(Vector3.left * Time.deltaTime * _speed);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * Time.deltaTime * _speed);
        //transform.position += transform.TransformDirection(Vector3.right * Time.deltaTime * _speed);

        // Slerp : ���� ������ ������ �����̰� ���ټ� �ִ� �Լ�(0.0f�� ���� ��, 1.0f�� ������ ��)
        // ����Ÿ�� Slerp�� �����ϰ� �Ǿ��� ��, World Coordinate���� �������� ��ƾ��Ѵ�.
        // ����, Local Coordinate�� �������� ������ Slerp�� ���� �̼��ϰ� ȸ���� �������� �����̰� �Ǵϱ� ��¦�� Ʋ���� ���ɼ��� �ִ�.
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.2f);
            transform.position += Vector3.forward * Time.deltaTime * _speed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.back);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.2f);
            transform.position += Vector3.back * Time.deltaTime * _speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.left);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.2f);
            transform.position += Vector3.left * Time.deltaTime * _speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.right);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.2f);
            transform.position += Vector3.right * Time.deltaTime * _speed;
        }
    }
}
