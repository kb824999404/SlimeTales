using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSlime : StoryItemBase
{
    public CharacterChange characterScript;
    public Animator slimeAnimator;
    protected override void executeEvent()
    {
        Debug.Log(text);
        characterScript.GetSlime();
        slimeAnimator.SetBool("Jump",false);
    }

}
