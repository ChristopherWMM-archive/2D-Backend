using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterScriptExecutor))]
[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour {
    [SerializeField]
    private string characterName;

    //[SerializeField]
    //private CharacterStats characterStats;

    //[SerializeField]
    //private CharacterInventory characterInventory;

    [SerializeField]
    private Sprite characterPortrait;

    private Animator animator;
    private CharacterScriptExecutor executor;
    private Rigidbody2D rigidbody;

    void Start() {
        animator = gameObject.GetComponent<Animator>();
        executor = gameObject.GetComponent<CharacterScriptExecutor>();
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    public void Face(Vector2 vector) {
        Move(vector);
        Move(0, 0);
    }

    public void Face(Transform transform) {
        Vector2 currentPosition = this.gameObject.transform.position;
        Vector2 targetPosition = transform.position;

        float x = targetPosition.x - currentPosition.x;
        float y = targetPosition.y - currentPosition.y;

        x = (float.IsNaN(x / Mathf.Abs(x))) ? 0 : x / Mathf.Abs(x);
        y = (float.IsNaN(y / Mathf.Abs(y))) ? 0 : y / Mathf.Abs(y);

        Face(x, y);
    }

    public void Face(float x, float y) {
        AnimateFace(x, y);
    }

    public void Move(Vector2 vector) {
        Move(vector.x, vector.y);
    }

    public void Move(float x, float y) {
        AnimateMovement(x, y);
        rigidbody.velocity = GenerateVelocityVector(x, y);
    }

    public void Stop()
    {
        Move(Vector2.zero);
    }

    public void MoveTo(Vector2 location) {
        // TODO
    }

    //public void say(string dialog) {
    //    // TODO
    //    // GetComponentInChildren<TextMesh>().text = dialog;
    //}

    //public void say(string dialog, Character character) {
    //    // TODO
    //}

    //public void say(Dialog dialog, Character character) {
    //    // TODO
    //}

    public void ExecuteScript(BehaviorScript script) {
        ExecutingScript(script, false);
    }

    public void ExecutingScript(BehaviorScript script, bool loop) {
        executor.ExecuteScript(script, loop);
    }

    public bool IsExecutingScript() {
        return executor.isExecuting;
    }

    public void PauseScript() {
        if (IsExecutingScript()) {
            executor.PauseScript();
        }
    }

    public void ResumeScript() {
        if (IsExecutingScript()) {
            executor.ResumeScript();
        }
    }

    public void RestartCurrentScript() {
        executor.RestartCurrentScript();
    }

    // TODO

    private void AnimateMovement(float x, float y) {
        Vector3 scale = gameObject.transform.localScale;

        animator.SetFloat("currentX", x);
        animator.SetFloat("currentY", y);

        // Change horizontal direction only if the opposite key is pressed.
        if (x > 0) {
            gameObject.transform.localScale = new Vector3(Mathf.Abs(scale.x), scale.y, scale.z);
        } else if (x < 0) {
            gameObject.transform.localScale = new Vector3(-Mathf.Abs(scale.x), scale.y, scale.z);
        }

        // Animate vertical only movement.
        if (x == 0 && y != 0) {
            animator.SetFloat("currentX", 1);
        }

        // Change vertical direction only if the opposite key is pressed.
        if (y > 0) {
            animator.SetFloat("previousY", -Mathf.Abs(y));
        } else if (y < 0) {
            animator.SetFloat("previousY", Mathf.Abs(y));
        }
    }

    private void AnimateFace(float x, float y)
    {
        Vector3 scale = gameObject.transform.localScale;

        animator.SetFloat("currentX", x);
        animator.SetFloat("currentY", y);

        if (x > 0) {
            gameObject.transform.localScale = new Vector3(Mathf.Abs(scale.x), scale.y, scale.z);
        } else if (x < 0) {
            gameObject.transform.localScale = new Vector3(-Mathf.Abs(scale.x), scale.y, scale.z);
        }

        if (y > 0) {
            animator.SetFloat("previousY", -Mathf.Abs(y));
        } else if (y < 0) {
            animator.SetFloat("previousY", Mathf.Abs(y));
        }

        animator.SetFloat("currentX", 0);
        animator.SetFloat("currentY", 0);
    }

    private Vector2 GenerateVelocityVector(float x, float y) {
        Vector2 velocity = new Vector2(x, y);

        velocity.Normalize();
        return velocity * 3; // TODO: Speed from character stats.
    }
}
