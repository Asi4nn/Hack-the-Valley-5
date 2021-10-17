using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public Text text;
    public bool inQuestion = false;
    [SerializeField] QuestionManager qManager;
    [SerializeField] float remainingTime;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (remainingTime > 0)
        {
            text.text = ((int)remainingTime).ToString();
            remainingTime -= Time.deltaTime;
        }
        else
        {
            gameObject.SetActive(false);
            if (inQuestion)
            {
                qManager.Answer();
                inQuestion = false;
            }
        }
    }

    public void SetTime(int time)
    {
        remainingTime = time;
        inQuestion = true;
        gameObject.SetActive(true);
    }
}
