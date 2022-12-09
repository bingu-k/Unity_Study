using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    // ���ϼ� ����
    static Managers s_instance;
    // Property ���
    public static Managers Instance { get { Initialize(); return s_instance; } }
    //public static Managers GetInstance() { Initialize(); return s_instance; }

    // Start is called before the first frame update
    void Start()
    {
        // �ʱ�ȭ
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static void Initialize()
    {
        // ���翩�� Ȯ��
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            // ���翩�� Ȯ�� �� ����
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }
            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>();
        }
    }
}
