using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Script", menuName = "Script/Behavior Script")]
public class BehaviorScript : ScriptableObject {
    [SerializeField]
    private TextAsset file;

    private List<ScriptedAction> scriptedActions;

    void OnValidate() {
        scriptedActions = ParseScriptedActions(file.text);
    }

    private List<ScriptedAction> ParseScriptedActions(string script) {
        List<ScriptedAction> scriptedActions = new List<ScriptedAction>();
        string[] lines = script.Split('\n');

        foreach (string line in lines) {
            if (IsValidAction(line)) {
                scriptedActions.Add(ParseAction(line));
            }
        }

        return scriptedActions;
    }

    private bool IsValidAction(string line) {
        string trimmedLine = line.Trim();

        // Check if the line is a comment.
        if (trimmedLine.StartsWith("#") || trimmedLine.StartsWith("//") || trimmedLine.StartsWith("/*") || trimmedLine.StartsWith("*") || trimmedLine.StartsWith("*/")) {
            return false;
        }

        // Check if the line is empty.
        if (trimmedLine.Length < 2) {
            return false;
        }

        return true;
    }

    private ScriptedAction ParseAction(string scriptedAction) {
        string[] segments = scriptedAction.Split(' ');

        string action = segments[0].ToUpper();
        string directionString = segments[1].ToUpper();
        string durationString = segments[segments.Length - 1];
        float duration = float.Parse(durationString);

        int x = 0;
        int y = 0;

        if (directionString.Contains("LEFT")) {
            x = -1;
        } else if (directionString.Contains("RIGHT")) {
            x = 1;
        }

        if (directionString.Contains("UP")) {
            y = 1;
        } else if (directionString.Contains("DOWN")) {
            y = -1;
        }

        // Normalize diagonals.
        if (x == 0 ^ y == 0 && action.Equals(ScriptedAction.MOVE)) {
            duration *= Mathf.Sqrt(2);
        }

        return new ScriptedAction(action, new Vector2(x, y), duration);
    }

    public List<ScriptedAction> GetScriptedActions() {
        return this.scriptedActions;
    }
}
