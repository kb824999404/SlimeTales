using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StartAnimation : MonoBehaviour
{
    public List<string> captions;
    public GameObject captionText;
    public float letterTime = 0.1f;
    public float captionTime = 2.0f;
    void Awake()
    {
        Time.timeScale = 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("showCaptions",1.0f);
    }

    void showCaptions()
    {
        StartCoroutine(showCaption(letterTime,captionTime));
    }

    IEnumerator showCaption(float letterTime,float captionTime)
    {
        foreach(string caption in captions)
        {
            for(int i=1;i<=caption.Length;i++)
            {
                captionText.GetComponent<TextMeshProUGUI>().text=caption.Substring(0,i);
                yield return new WaitForSeconds(letterTime);
            }
            yield return new WaitForSeconds(captionTime);
        }
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("Level1");
    }
}
