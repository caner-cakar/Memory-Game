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

    private bool firstGuess,secondGuess;
    private int firstGuessIndex, secondGuessIndex,gameGuess,correctGuess;
    private string firstGuessPuzzle,secondGuessPuzzle;

    private void Awake() 
    {
        puzzles = Resources.LoadAll<Sprite>("Sprites/Cards");      
    }
    
    void Start()
    {
        GetButton();
        AddGamePuzzle();
        AddListeners();
        gameGuess = gamePuzzles.Count /2 ;  
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

        if(!firstGuess)
        {
            firstGuess = true;
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            firstGuessPuzzle = gamePuzzles[firstGuessIndex].name;
            btns[firstGuessIndex].image.sprite = gamePuzzles[firstGuessIndex];
        }
        else if(!secondGuess)
        {
            secondGuess = true;
            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            secondGuessPuzzle = gamePuzzles[secondGuessIndex].name;

            btns[secondGuessIndex].image.sprite = gamePuzzles[secondGuessIndex];

            StartCoroutine(ThePuzzlesMatch());
        }
    }
    IEnumerator ThePuzzlesMatch()
    {
        yield return new WaitForSeconds(1f);
        if(firstGuessPuzzle == secondGuessPuzzle)
        {
            yield return new WaitForSeconds(1f);
            btns[firstGuessIndex].interactable = false;
            btns[secondGuessIndex].interactable = false;
            btns[firstGuessIndex].image.color = new Color(0,0,0,0);
            btns[secondGuessIndex].image.color = new Color(0,0,0,0);
            correctGuess++;
            isGameFinished();
        }
        else 
        {
            btns[firstGuessIndex].image.sprite = bgImage;
            btns[secondGuessIndex].image.sprite = bgImage;
        }
        yield return new WaitForSeconds(1f);
        firstGuess = false;
        secondGuess = false;
    }
    void isGameFinished()
    {
        if(correctGuess == gameGuess)
        {

        }
    }
}
