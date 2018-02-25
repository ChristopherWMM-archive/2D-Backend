using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    [SerializeField]
    private Character character;

    void FixedUpdate() {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        GameObject.Find("xInput").GetComponent<Text>().text = "Player X: " + x;
        GameObject.Find("yInput").GetComponent<Text>().text = "Player Y: " + y;

        // For testing purposes only.
        if (character.IsExecutingScript()) {
            GameObject.Find("Input mode").GetComponent<Text>().text = "Script Input";
            return;
        } else {
            GameObject.Find("Input mode").GetComponent<Text>().text = "Player Input";
        }

        // For testing purposes only.
        if (Input.GetKeyDown(KeyCode.Space)) {
            character.RestartCurrentScript();
        }

        character.Move(x, y);
    }

    public Character GetCharacter() {
        return this.character;
    }

    public void SetCharacter(Character character) {
        this.character = character;
    }
}