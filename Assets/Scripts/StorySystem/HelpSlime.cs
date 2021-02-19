using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpSlime : StoryItemBase
{
    public Animator slimeAnimator;
    protected override void executeEvent()
    {
        Debug.Log(text);
        slimeAnimator.SetBool("Jump",true);
    }

}

