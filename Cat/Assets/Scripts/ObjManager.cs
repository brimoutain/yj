using UnityEngine;

public class ObjManager : MonoBehaviour
{
    public static ObjManager instance; // 静态单例
    public int brokenNum = 0;

    private void Awake()
    {
        // 防止重复创建单例
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // 销毁重复实例
            return;
        }

        instance = this; // 在 Awake 中初始化
    }
}