using System.Collections.Generic;
using System.Linq;
using UnityEngine;


/// <summary>
/// This class will trigger a text message when the player enters the trigger,
/// and optionally start a cutscene.
/// </summary>
public abstract class StoryItemBase : MonoBehaviour, ISerializationCallbackReceiver
{
    public string ID;
    [Multiline]
    public string text = "There is no story to be found here.";     //剧情说明
    public AudioClip audioClip;         //触发时播放的音效

    public bool disableWhenDiscovered = true;      //触发后是否隐藏
    public bool executeByTrigger=true;              //通过碰撞触发事件

    public HashSet<StoryItemBase> requiredStoryItems;       //前置事件

    [System.NonSerialized] public HashSet<StoryItemBase> dependentStoryItems = new HashSet<StoryItemBase>();

    [SerializeField] StoryItemBase[] _requiredStoryItems;

    protected StorySystem storySystem =null;


    void OnEnable()
    {
        if (ID == string.Empty && text != null)
        {
            ID = $"SI:{text.GetHashCode()}";
        }
    }

    void Awake()
    {
        ConnectRelations();
        storySystem=StorySystem.getInstance();
        Debug.Log(storySystem);
    }

    void ConnectRelations()
    {
        foreach (var i in requiredStoryItems)
        {
            i.dependentStoryItems.Add(this);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Player"))  return;

        if(executeByTrigger)    TriggerEvent();
    }

    public void TriggerEvent()      //触发事件
    {
        Debug.Log(requiredStoryItems.Count);
        foreach (var requiredStoryItem in requiredStoryItems)
            if (requiredStoryItem != null)
                if (!storySystem.HasSeenStoryItem(requiredStoryItem.ID))
                    return;

        if (audioClip == null)
            UserInterfaceAudio.OnStoryItem();
        else
            UserInterfaceAudio.PlayClip(audioClip);
        executeEvent();
        if (ID != string.Empty)
            storySystem .RegisterStoryItem(ID);
        if (disableWhenDiscovered) gameObject.SetActive(false);
    }

    protected abstract void executeEvent();       //执行事件


    public void OnBeforeSerialize()
    {
        if(requiredStoryItems != null)
            _requiredStoryItems = requiredStoryItems.ToArray();
    }

    public void OnAfterDeserialize()
    {
        requiredStoryItems = new HashSet<StoryItemBase>();
        if (_requiredStoryItems != null)
            foreach (var i in _requiredStoryItems) requiredStoryItems.Add(i);
    }

}