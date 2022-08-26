using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue {
    public string Portrait;
    //This is just for ease of reference
    public string DialogueName;
    [TextArea(5, 10)]
    public string[] Sentences;
}
