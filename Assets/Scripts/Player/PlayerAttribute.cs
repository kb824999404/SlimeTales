using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttribute : MonoBehaviour
{
    public Transform HPPanel;
    private int HP = 3;
    private bool isHurting = false;
    private bool isDead = false;

    private Rigidbody myRigidbody;
    private CharacterChange characterChange;
    [HideInInspector]
    public GameLogic gameLogic;


    // Start is called before the first frame update
    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
        characterChange = GetComponent<CharacterChange>();
        HP=5;
        updataHPPanel();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void Hurt()
    {
        if(!isDead&&!isHurting)
        {
            GoBack();
            HP--;
            if(HP<=0)
            {
                HP = 0;
                isDead = true;
            }
            updataHPPanel();
            if(isDead)
            {
                gameLogic.GameOver();
            }
            isHurting = true;
            characterChange.SetHurt(true);
            Invoke("setHurtable",3.0f);
        }
    }
    public void GoBack()
    {
        transform.position +=(transform.up-transform.forward)*1.0f;
    }
    void setHurtable()
    {
        isHurting = false;
        characterChange.SetHurt(false);
    }
    void updataHPPanel()
    {
        for(int i=0;i<HPPanel.childCount;i++)
        {
            if(i+1<=HP)
            {
                HPPanel.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                HPPanel.GetChild(i).gameObject.SetActive(false);
            }
        }

    }
    public void GameOver()
    {

    }
}
