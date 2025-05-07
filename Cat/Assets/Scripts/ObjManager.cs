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
}