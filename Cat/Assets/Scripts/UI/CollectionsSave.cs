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
        // 处理重复实例
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // 销毁新创建的重复对象
            return;
        }
        gotcollections = new bool[8];
        instance = this;
        DontDestroyOnLoad(gameObject); // 保留整个游戏对象

        // 初始化代码放在这里
        Screen.SetResolution(1600, 1000, false);
    }

    public void AddCollections(int num)
    {
        gotcollections[num] = true;
    }


}
