using UnityEngine;

[RequireComponent(typeof(Character))]
public class CharacterScriptExecutor : MonoBehaviour {
    [SerializeField]
    private BehaviorScript script;
    private Character character;

    private ScriptedAction currentAction;
    private int currentBehaviorIndex;
    private float nextBehaviorTime;
    private float pausedTime;

    public bool isExecuting;
    private bool isLooping;
    private bool isPaused;

    void Start() {
        character = GetComponent<Character>();

        // For testing purposes only.
        if (script != null) {
           ExecuteScript(script);
        }
    }

    void FixedUpdate() {
        if (isExecuting) {
            if (Time.fixedTime >= nextBehaviorTime) {
                if (isLooping) {
                    currentBehaviorIndex %= script.GetScriptedActions().Count;
                } else {
                    if (currentBehaviorIndex >= script.GetScriptedActions().Count) {
                        isExecuting = false;
                        character.Stop();
                        return;
                    }
                }

                currentAction = script.GetScriptedActions()[currentBehaviorIndex++];
                nextBehaviorTime = Time.fixedTime + currentAction.duration;
            }

            switch (currentAction.action) {
                case ScriptedAction.MOVE:
                    character.Move(currentAction.direction);
                    break;
                case ScriptedAction.STOP:
                    character.Stop();
                    break;
                case ScriptedAction.FACE:
                    character.Face(currentAction.direction);
                    break;
            }
        }
    }

    public void ExecuteScript(BehaviorScript script) {
        ExecuteScript(script, false);
    }

    public void ExecuteScript(BehaviorScript script, bool loop) {
        isExecuting = true;
        isLooping = loop;

        currentBehaviorIndex = 0;
        nextBehaviorTime = 0;
    }

    public void PauseScript() {
        if (!isPaused && isExecuting && script != null) {
            isExecuting = false;
            isPaused = true;

            pausedTime = Time.fixedTime;

            character.Stop();
        }
    }

    public void ResumeScript() {
        if (isPaused && !isExecuting && script != null) {
            isExecuting = true;
            isPaused = false;

            nextBehaviorTime += Time.fixedTime - pausedTime;
            pausedTime = 0;
        }
    }

    public void RestartCurrentScript() {
        isExecuting = true;

        currentBehaviorIndex = 0;
        nextBehaviorTime = 0;
    }
}
