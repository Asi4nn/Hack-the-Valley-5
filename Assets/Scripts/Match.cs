using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match : MonoBehaviour
{
    public List<Question> questionList = new List<Question>;

    public void AddQuestion(string prompt, string questionType, string[] correctAnswers, string[] answers) {
        Question q = new Question();
        q.prompt = prompt;
        q.questionType = questionType;
        q.correctAnswers = new List<string>(correctAnswers);
        q.answers = new List<string>(answers);
        questionList.Add(q);
    }

    public void LoadQuestions() { 
        this.AddQuestion(
            "You are in the empty directory NiceGame. Turn NiceGame into an empty git repository.",
            "MC",
            { "git init" },
            { "git add", "git init", "git config", "git start" }
            );

        this.AddQuestion(
            "How do you save all your changes for later without committing them to a repository?",
            "MC",
            { "git stash -u" },
            { "git push --all", "git stash", "git stash -u", "git remote add origin git@repourl.git" }
            );

        this.AddQuestion(
            "To pull changes from the remote branch feature in my current repository into my currently working branch feature2, I would do git pull ___ feature",
            "TypeFill",
            { "origin" },
            { "remote", "master", "origin", "main" }
            );

        this.AddQuestion(
            "Which flag for git config only applies the settings you set to the repository you are currently in?",
            "MC",
            { "--local", "No flag needed" },
            { "--global", "--system", "--local", "No flag needed" }
            )
    }
}