using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    public List<Question> questions;
    public Text questionText;
    public Question currentQuestion;
    public GameObject multipleChoiceObject;

    public Button submitButton;

    private List<Question> unansweredQuestions;
    
    // Start is called before the first frame update
    void Start()
    {
        submitButton.onClick.AddListener(Answer);
        unansweredQuestions = questions;

        GetRandomQuestion();
    }

    private void GetRandomQuestion()
    {
        int index = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[index];

        SetAnswers();
        questionText.text = questions[index].prompt;
        unansweredQuestions.RemoveAt(index);
    }

    private void SetAnswers()
    {
        if (currentQuestion.questionType == "MC")
        {
            for (int i = 0; i < multipleChoiceObject.transform.childCount; i++)
            {
                multipleChoiceObject.transform.GetChild(i).transform.GetChild(0).GetComponent<Text>().text = currentQuestion.answers[i];
            }
        }
    }

    public void Answer()
    {
        bool correct = true;

        if (currentQuestion.questionType == "MC")
        {
            for (int i = 0; i < multipleChoiceObject.transform.childCount; i++)
            {
                
                string txt = multipleChoiceObject.transform.GetChild(i).transform.GetChild(0).GetComponent<Text>().text;
                bool selected = multipleChoiceObject.transform.GetChild(i).GetComponent<MCButtonController>().selected;
                if (selected && !currentQuestion.correctAnswers.Contains(txt) || !selected && currentQuestion.correctAnswers.Contains(txt))
                {
                    correct = false;
                    break;
                }
            }
        }

        GetRandomQuestion();
    }
}
