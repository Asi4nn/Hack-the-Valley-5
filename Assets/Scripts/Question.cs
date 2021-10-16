using System.Collections.Generic;

[System.Serializable]
public class Question
{
    public string prompt;
    public string questionType; // change to enum later to MC/TypeFill/Dots/Pool
    public List<string> correctAnswers;
    public List<string> answers;
}
