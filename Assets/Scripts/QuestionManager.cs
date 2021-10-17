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
    public GameObject typeFillObject;

    public Button submitButton;

    [SerializeField] TimerController timerController;
    [SerializeField] int questionTime = 10;

    private List<Question> unansweredQuestions;
    private int dmgToEnemy = 20;
    private int dmgToPlayer = 20;
    
    // Start is called before the first frame update
    void Start()
    {
        // sample questions
        Question q = new Question();
        q.prompt = "You are in the empty directory NiceGame. Turn NiceGame into an empty git repository.";
        q.questionType = "MC";
        q.correctAnswers = new List<string>{"git init"};
        string[] ans = { "git add", "git init", "git config", "git start" };
        q.answers = new List<string>(ans);
        questions.Add(q);

        q = new Question();
        q.prompt = "How do you save all your changes for later without committing them to a repository?";
        q.questionType = "MC";
        q.correctAnswers = new List<string> { "git stash -u" };
        string[] ans2 = { "git push --all", "git stash", "git stash -u", "git remote add origin git@repourl.git" };
        q.answers = new List<string>(ans2);
        questions.Add(q);

        q = new Question();
        q.prompt = "To pull changes from the remote branch feature in my current repository into my currently working branch feature2, I would do git pull ___ feature";
        q.questionType = "TypeFill";
        q.correctAnswers = new List<string> { "origin" };
        string[] ans3 = { "remote", "master", "origin", "main" };
        q.answers = new List<string>(ans3);
        questions.Add(q);


        multipleChoiceObject.SetActive(false);
        typeFillObject.SetActive(false);

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
        timerController.SetTime(questionTime);
        if (currentQuestion.questionType == "MC")
        {
            multipleChoiceObject.SetActive(true);
            for (int i = 0; i < multipleChoiceObject.transform.childCount; i++)
            {
                multipleChoiceObject.transform.GetChild(i).transform.GetChild(0).GetComponent<Text>().text = currentQuestion.answers[i];
            }
        }
        else if (currentQuestion.questionType == "TypeFill")
        {
            typeFillObject.SetActive(true);
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
            multipleChoiceObject.SetActive(false);
            ResetSelectedButtons();
        }
        else if (currentQuestion.questionType == "TypeFill")
        {
            correct = typeFillObject.transform.GetChild(0).transform.transform.Find("Text").GetComponent<Text>().text.Equals(currentQuestion.correctAnswers[0]);
            typeFillObject.SetActive(false);
        }

        if (correct)
        {
            gameObject.GetComponent<PlayerStats>().DamageEnemy(dmgToEnemy);
        }
        else
        {
            gameObject.GetComponent<PlayerStats>().DamagePlayer(dmgToPlayer);
        }
        
        GetRandomQuestion();
    }

    void ResetSelectedButtons()
    {
        for (int i = 0; i < multipleChoiceObject.transform.childCount; i++)
        {
            multipleChoiceObject.transform.GetChild(i).GetComponent<MCButtonController>().selected = false;
            multipleChoiceObject.transform.GetChild(i).GetComponent<MCButtonController>().UpdateColour();
        }
    }

    public void SetInactive()
    {
        gameObject.SetActive(false);
    }
}
