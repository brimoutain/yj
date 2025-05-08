using UnityEngine;

public class ObjManager : MonoBehaviour
{
    public static ObjManager instance; // ��̬����
    public int brokenNum = 0;

    private void Awake()
    {
        // ��ֹ�ظ���������
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // �����ظ�ʵ��
            return;
        }

        instance = this; // �� Awake �г�ʼ��
    }

    public void CheckNum(int num)
    {
        brokenNum += num;
        if(brokenNum >= 30)
        {
            PageManager.TriggerCollectionEvent(6);
            if(brokenNum >= 60)
                PageManager.TriggerCollectionEvent(7);
            if (brokenNum == 100)
            {
                //�ƻ���
                PageManager.TriggerCollectionEvent(0);

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