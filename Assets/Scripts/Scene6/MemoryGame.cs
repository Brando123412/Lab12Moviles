using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryGame : MonoBehaviour
{
    public GameObject[] buttons;
    private List<int> sequence = new List<int>();
    private int playerIndex = 0;

    void Start()
    {
        StartCoroutine(GenerateSequence());
    }

    IEnumerator GenerateSequence()
    {
        for (int i = 0; i < 3; i++)
        {
            int index = Random.Range(0, buttons.Length);
            sequence.Add(index);
            HighlightButton(index);
            yield return new WaitForSeconds(1f);
        }
    }

    void HighlightButton(int index)
    {
        buttons[index].GetComponent<SpriteRenderer>().color = Color.yellow;
        Invoke("ResetButtonColor", 0.5f);
    }

    void ResetButtonColor()
    {
        foreach (var button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    void OnMouseDown()
    {
        int index = System.Array.IndexOf(buttons, gameObject);
        if (index == sequence[playerIndex])
        {
            playerIndex++;
            if (playerIndex >= sequence.Count)
            {
                Debug.Log("You win!");
                playerIndex = 0;
                sequence.Clear();
                StartCoroutine(GenerateSequence());
            }
        }
        else
        {
            Debug.Log("Wrong!");
        }
    }
}
