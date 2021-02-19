using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChange : MonoBehaviour
{
    public int defaultCharacter = 0;
    public List<GameObject> Outlines;
    private List<GameObject> characters;
    public List<Material> originMaterials;
    public List<Material> hurtMaterials;
    public List<float> Gravities;
    public List<float> MoveSpeeds;

    private PlayerCharacter playerCharacter;
    private int currentCharacter;
    private int CharacterCount = 1;
    private bool isHurting = false;
    // Start is called before the first frame update
    void Awake()
    {
        playerCharacter = GetComponent<PlayerCharacter>();
        characters=new List<GameObject>();
        currentCharacter = defaultCharacter;
        foreach (Transform child in transform)
        {
            characters.Add(child.gameObject);
        }
        change();
    }

    // Update is called once per frame
    void Update()
    {
        bool changeCharacter = Input.GetKeyDown(KeyCode.C);
        if(changeCharacter)
        {
            currentCharacter++;
            if(currentCharacter >= CharacterCount)
            {
                currentCharacter = 0;
            }
            change();
            updateMaterial();
        }

    }

    void change()
    {
        for(int i=0;i<characters.Count;i++)
        {
            if(i==currentCharacter)
            {
                characters[i].SetActive(true);
            }
            else
            {
                characters[i].SetActive(false);
            }
        }
        for(int i=0;i<Outlines.Count;i++)
        {
            if(i==currentCharacter)
            {
                Outlines[i].SetActive(true);
            }
            else
            {
                Outlines[i].SetActive(false);
            }
            if(i+1>CharacterCount)
            {
                Outlines[i].transform.parent.gameObject.SetActive(false);
            }
            else
            {
                Outlines[i].transform.parent.gameObject.SetActive(true);
            }
        }
        playerCharacter.m_GravityMultiplier = Gravities[currentCharacter];
        playerCharacter.m_MoveSpeedMultiplier = MoveSpeeds[currentCharacter];
    }
    void updateMaterial()
    {
        if(!isHurting)
        {
            characters[currentCharacter].GetComponent<Renderer>().material
                =originMaterials[currentCharacter];
        }
        else
        {
            characters[currentCharacter].GetComponent<Renderer>().material
                =hurtMaterials[currentCharacter];         
        }
    }

    public int getCurrentCharacter()
    {
        return currentCharacter;       
    }
    public void SetHurt(bool value)
    {
        isHurting = value;
        updateMaterial();
    }
    public void GetSlime()
    {
        CharacterCount++;
        change();
    }
}
