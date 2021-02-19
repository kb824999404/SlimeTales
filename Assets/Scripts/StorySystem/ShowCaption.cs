using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowCaption : StoryItemBase
{
    public List<string> captions;
    public GameObject captionText;
    public bool showOnce = false;

    bool isShowing=false;
    protected override void executeEvent()
    {
        if(!isShowing)
        {
            Debug.Log("Show Caption");
            captionText.SetActive(true);
            StartCoroutine(showCaption(2.0f));
            isShowing=true;
        }
    }
  
    IEnumerator showCaption(float time)
    {
        foreach(string caption in captions)
        {
            captionText.GetComponent<TextMeshProUGUI>().text=caption;
            yield return new WaitForSeconds(time);
        }
        captionText.GetComponent<TextMeshProUGUI>().text = "";
        isShowing=false;
        if(showOnce)    gameObject.SetActive(false);
    }
}
