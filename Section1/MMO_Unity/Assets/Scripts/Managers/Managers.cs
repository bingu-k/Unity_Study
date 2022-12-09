using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    // 유일성 보장
    static Managers s_instance;
    // Property 사용
    public static Managers Instance { get { Initialize(); return s_instance; } }
    //public static Managers GetInstance() { Initialize(); return s_instance; }

    // Start is called before the first frame update
    void Start()
    {
        // 초기화
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static void Initialize()
    {
        // 존재여부 확인
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            // 존재여부 확인 후 생성
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
