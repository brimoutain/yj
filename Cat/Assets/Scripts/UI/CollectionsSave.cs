using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionsSave : MonoBehaviour
{
    public static CollectionsSave instance;
    public bool[] gotcollections;
    // Start is called before the first frame update
    void Awake()
    {
        // �����ظ�ʵ��
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // �����´������ظ�����
            return;
        }
        gotcollections = new bool[8];
        instance = this;
        DontDestroyOnLoad(gameObject); // ����������Ϸ����

        // ��ʼ�������������
        Screen.SetResolution(1600, 1000, false);
    }

    public void AddCollections(int num)
    {
        gotcollections[num] = true;
    }


}
