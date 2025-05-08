using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteButton : MonoBehaviour
{
    public GameObject pageGroup;
    public GameObject tabGroup;

    private void Awake()
    {
        //GameObject note = GameObject.Find("NoteBookWindow");
        //pageGroup = note.transform.Find("PageGroup").gameObject;
        //tabGroup = note.transform.Find("TabGroup").gameObject;
    }

    public void OpenAchievements()
    {
        pageGroup.SetActive(true);
        tabGroup.SetActive(true);
    }
}
