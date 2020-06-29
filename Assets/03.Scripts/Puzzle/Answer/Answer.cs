using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answer : MonoBehaviour
{
    [SerializeField] public Text inputText = null;

    [SerializeField] public Button endAnswerBtn = null;

    protected int selectNum = 0;
    public int SelectNum { get { return selectNum; } set { selectNum = value; } }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnAnswerBtn()
    {
        gameObject.SetActive(true);
    }

    public void OffAnswerBtn()
    {
        gameObject.SetActive(false);
    }
}
