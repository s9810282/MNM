using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void StateChange(string sourceName = null);

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
        fade_InOut = new Fade_InOut();

        stateChangeFunc[0] = Change;
        stateChangeFunc[1] = Delete;
        stateChangeFunc[2] = SlowlyFadeIn;
        stateChangeFunc[3] = SlowlyFadeOut;
        stateChangeFunc[4] = SlowlyChange;
    }

    //서서히 사라졋다가 서서히 올라옴
    public abstract IEnumerator SlowChange(string sourceName);

    public abstract IEnumerator SlowFadeIn(string sourceName);

    public abstract IEnumerator SlowFadeOut();
}
