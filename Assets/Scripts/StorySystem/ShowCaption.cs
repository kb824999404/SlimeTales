using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowCaption : StoryItemBase
{
    [SerializeField] public List<string> captions = new List<string>();
    bool isShowing=false;
    public GameObject captionText;
    protected override void executeEvent()
    {
        if(!isShowing)
        {
            Debug.Log("Show Caption");
            captionText.SetActive(true);
            StartCoroutine(showCaption(2));
            isShowing=true;
        }

    }

    IEnumerator showCaption(float time)
    {
        foreach(var caption in captions)
        {
            captionText.GetComponent<TextMeshPro>().text=caption;
            yield return new WaitForSeconds(time);
        }
        isShowing=false;
        gameObject.SetActive(false);
    }
}
