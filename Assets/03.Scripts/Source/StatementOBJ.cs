using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class StatementOBJ : MonoBehaviour
{
    public abstract void Change(string sourceName);
    public abstract void SlowlyChange(string sourceName);
    public abstract void Delete();
    public abstract void SlowlyFadeOut();
    public abstract void SlowlyFadeIn(string sourceName);

    protected Fade_InOut fade_InOut;

    private void Start()
    {
        fade_InOut = new Fade_InOut();
    }

    //서서히 사라졋다가 서서히 올라옴
    public abstract IEnumerator SlowChange(string sourceName);

    public abstract IEnumerator SlowFadeIn(string sourceName);

    public abstract IEnumerator SlowFadeOut();
}
