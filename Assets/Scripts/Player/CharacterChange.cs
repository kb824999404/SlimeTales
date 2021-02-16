using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChange : MonoBehaviour
{
    public int defaultCharacter = 0;
    private List<GameObject> characters;

    private int currentCharacter;
    // Start is called before the first frame update
    void Awake()
    {
        characters=new List<GameObject>();
        currentCharacter = defaultCharacter;
        foreach (Transform child in transform)
        {
            characters.Add(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool changeCharacter = Input.GetKeyDown(KeyCode.C);
        if(changeCharacter)
        {
            currentCharacter++;
            if(currentCharacter >= characters.Count)
            {
                currentCharacter = 0;
            }
            Debug.Log(currentCharacter);

            for(int i=0;i<characters.Capacity;i++)
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
        }
    }
}
