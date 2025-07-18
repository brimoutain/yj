using UnityEngine;
using UnityEngine.UI;

public class CollectionManager : MonoBehaviour
{
    public static CollectionManager instance; // 静态单例
    public int brokenNum = 0;
    public AngrySlider slider;
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

    public void CheckNum()
    {
        slider.AddNum();
        if(brokenNum >= 30)
        {
            PageManager.TriggerCollectionEvent(6);
            if(brokenNum >= 60)
                PageManager.TriggerCollectionEvent(7);
            if (brokenNum == 100)
            {
                //破坏王
                PageManager.TriggerCollectionEvent(0);
                PageManager.TriggerCollectionEvent(2);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PageManager.TriggerCollectionEvent(4);
        }
    }
}