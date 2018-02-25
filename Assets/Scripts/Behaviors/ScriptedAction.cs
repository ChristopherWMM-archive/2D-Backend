using UnityEngine;

// TODO: Rewrite
public class ScriptedAction {
    public const string MOVE = "MOVE";
    public const string STOP = "STOP";
    public const string FACE = "FACE";
    // public const string SAY = "SAY";

    public string action;
    public Vector2 direction;
    public string message;
    public float duration;

    //public ScriptedAction(string action, string message, float duration) {
    //    this.action = action;
    //    this.message = message;
    //    this.duration = duration;
    //}

    public ScriptedAction(string action, Vector2 direction, float duration) {
        this.action = action;
        this.direction = direction;
        this.duration = duration;
    }

    public ScriptedAction(string action, float duration) {
        this.action = action;
        this.direction = Vector2.zero;
        this.duration = duration;
    }
}
