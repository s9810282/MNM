using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PuzzleManager : MonoBehaviour
{
    [SerializeField] Puzzle _puzzle;

    [SerializeField] Image[] puzzleComponent;

    [SerializeField] GameObject option;

    Fade_InOut fade_InOut;

    // Start is called before the first frame update
    void Start()
    {
        fade_InOut = new Fade_InOut();
        OnPuzzle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPuzzle(string str = null)
    {
        StoryManager.Instance.IsPuzzle = true;

        foreach (var item in puzzleComponent)
        {
            item.gameObject.SetActive(true);
            fade_InOut.FadeIn(this, item);
        }

        _puzzle.gameObject.SetActive(true);
    }


    public void Replay()
    {

    }

    public void OnOption()
    {
        option.gameObject.SetActive(true);
    }
}
