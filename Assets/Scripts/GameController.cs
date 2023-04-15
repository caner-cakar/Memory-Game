using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public List<Button> btns = new List<Button>();
    [SerializeField] private Sprite bgImage;

    public Sprite[] puzzles;
    public List<Sprite> gamePuzzles = new List<Sprite>();
    int lastValue;

    private bool firstGuess,secondGuess;

    private void Awake() 
    {
        puzzles = Resources.LoadAll<Sprite>("Sprites/Cards");      
    }
    
    void Start()
    {
        GetButton();
        AddGamePuzzle();
    }

    void GetButton()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");

        for (int i = 0; i < objects.Length; i++)
        {
            btns.Add(objects[i].GetComponent<Button>());
            btns[i].image.sprite = bgImage;
        }   
    }

    private void AddGamePuzzle()
    {
        int index = 0;
        for (int i = 0; i < btns.Count; i++)
        {
            if(index == btns.Count /2 )
            {
                index =0;
            }
            gamePuzzles.Add(puzzles[index]);
            index++;
        }
        shufle(gamePuzzles);
    }

    private void shufle(List<Sprite> newGamePuzzle)
    {
        for (int i = 0; i < newGamePuzzle.Count; i++)
        {
            Sprite temp = newGamePuzzle[i];
            int rand = Random.Range(0,newGamePuzzle.Count);
            newGamePuzzle[i]= newGamePuzzle[rand];   
            newGamePuzzle[rand] = temp;
        }
    }


    private void AddListeners()
    {
        foreach (Button buttons in btns)
        {
            buttons.onClick.AddListener(() => PickaPuzzle());
        }
    }
    private void PickaPuzzle()
    {

    }
}
