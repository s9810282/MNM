using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void StateChange(string sourceName);

abstract public class StatementOBJ : MonoBehaviour
{
    public abstract void Change(string sourceName);
    public abstract void SlowlyChange(string sourceName);
    public abstract void Delete(string sorceName = null);
    public abstract void SlowlyFadeOut(string sorceName = null);    
    public abstract void SlowlyFadeIn(string sourceName);

    protected Fade_InOut fade_InOut;
    public StateChange[] stateChangeFunc;

    private void Start()
    {
        
    }

    //서서히 사라졋다가 서서히 올라옴
    public abstract IEnumerator SlowChange(string sourceName);

    public abstract IEnumerator SlowFadeIn(string sourceName);

    public abstract IEnumerator SlowFadeOut();

    public virtual void SetDelegate()
    {
        fade_InOut = new Fade_InOut();
        stateChangeFunc = new StateChange[5];

        stateChangeFunc[0] = new StateChange(Change);
        stateChangeFunc[1] = new StateChange(Delete);
        stateChangeFunc[2] = new StateChange(SlowlyFadeIn);
        stateChangeFunc[3] = new StateChange(SlowlyFadeOut);
        stateChangeFunc[4] = new StateChange(SlowlyChange);
    }
}
