using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewQuestion", menuName = "Quiz/Question")]
public class QuestionData : ScriptableObject
{
    [TextArea] public string questionText;
    public string[] answers = new string[3]; // Opsi A, B, C
    public int answerIndex; // Index 0, 1, atau 2
    public int shapeIndex;
}
