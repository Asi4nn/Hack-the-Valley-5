using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match : MonoBehaviour
{
    public List<Question> easyQuestionList = new List<Question>();
    public List<Question> hardQuestionList = new List<Question>();

    public void AddEasyQuestion(string prompt, string questionType, List<string> correctAnswers, List<string> answers) {
        Question q = new Question();
        q.prompt = prompt;
        q.questionType = questionType;
        q.correctAnswers = new List<string>(correctAnswers);
        q.answers = new List<string>(answers);
        easyQuestionList.Add(q);
    }

    public void AddHardQuestion(string prompt, string questionType, List<string> correctAnswers, List<string> answers)
    {
        Question q = new Question();
        q.prompt = prompt;
        q.questionType = questionType;
        q.correctAnswers = new List<string>(correctAnswers);
        q.answers = new List<string>(answers);
        hardQuestionList.Add(q);
    }

    public void LoadEasyQuestions() { 
        this.AddEasyQuestion(
            "You are in the empty directory NiceGame. Turn NiceGame into an empty git repository.", 
            "MC", 
            new List<string>{ "git init" },
            new List<string>{ "git add", "git init", "git config", "git start" }
            );

        this.AddEasyQuestion(
            "How do you save all your changes for later without committing them to a repository?",
            "MC",
            new List<string>{ "git stash -u" },
            new List<string>{ "git push --all", "git stash", "git stash -u", "git remote add origin git@repourl.git" }
            );

        this.AddEasyQuestion(
            "To pull changes from the remote branch feature in my current repository into my currently working branch feature2, I would do git pull ___ feature",
            "TypeFill",
            new List<string>{ "origin" },
            new List<string>{ "remote", "master", "origin", "main" }
            );

        this.AddEasyQuestion(
            "How do I switch to another existing branch called master?",
            "MC",
            new List<string> { "git checkout master" },
            new List<string> { "git checkout master", "git checkout main", "git pull master", "git checkout -b master" }
            );

        this.AddEasyQuestion(
            "How do I get information on the current state of the repository?",
            "TypeFill",
            new List<string> { "git status" },
            new List<string> { "" }
            );

        this.AddEasyQuestion(
            "To show the entire chronological commit history for my current repository, I would do",
            "TypeFill",
            new List<string> { "git log" },
            new List<string> { "" }
            );

        this.AddEasyQuestion(
            "To pull changes from the remote branch feature in my current repository into my currently working branch feature2, I would do git pull ___ feature",
            "MC",
            new List<string> { "origin" },
            new List<string> { "remote", "master", "origin", "main" }
            );

        this.AddEasyQuestion(
            "You are in your current working repository. I want to fetch all changes from the remote version of this repository, so I do git ___ origin",
            "MC",
            new List<string> { "pull" },
            new List<string> { "pull", "checkout", "push", "init" }
            );

        this.AddEasyQuestion(
            "To merge the tfclassic branch into tf2, I would do git merge ___ ___",
            "MC",
            new List<string> { "tf2 tfclassic" },
            new List<string> { "tf2 tfclassic", "tfclassic tf2", "origin tf2", "tf2 origin" }
            );
    }

    public void LoadHardQuestions()
    {
        this.AddHardQuestion(
            "Which flag for git config only applies the settings you set to the repository you are currently in?",
            "MC",
            new List<string> { "--local", "No flag needed" },
            new List<string> { "--global", "--system", "--local", "No flag needed" }
            );

        this.AddHardQuestion(
            "I want to add the file urmom.txt to the staging area for Git, so that it can get pushed to the remote repository. Assume you are in the same folder that contains the file.",
            "TypeFill",
            new List<string> { "git add urmom.txt" },
            new List<string> { "" }
            );

        this.AddHardQuestion(
            "I am currently in the local repository amog. How do I push my local commits to the branch menu in the remote repository amog?",
            "MC",
            new List<string> { "git push amog menu" },
            new List<string> { "git pull menu amog", "git push amog menu", "git checkout amog menu", "git commit amog menu" }
            );

        this.AddHardQuestion(
            "Commit your current changes with the message “Add login button” (no quotations).",
            "TypeFill",
            new List<string> { "git commit -m “Add login button" },
            new List<string> { "" }
            );

        this.AddHardQuestion(
            "I want to create and work on a new branch called amogus.",
            "TypeFill",
            new List<string> { "git checkout -b amogus" },
            new List<string> { "" }
            );

        this.AddHardQuestion(
            "You are in your current working repository. I want to create a new branch tf2 based off the current existing branch tfclassic. I type in the terminal git checkout ___ ___ origin/tfclassic",
            "MC",
            new List<string> { "-b tf2" },
            new List<string> { "--new tf2", "-b tf2", "tf2 -b", "-f tf2" }
            );

        this.AddHardQuestion(
            "I am in my current working repository, in the branch tf2. I want to merge any new changes from the feature branch into tf2. I do git ___ ___ feature",
            "MC",
            new List<string> { "pull origin" },
            new List<string> { "pull origin", "commit origin", "push origin", "get origin" }
            );

    }


}