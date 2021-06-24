using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PuzzleInitiator : MonoBehaviour
{
	public DetectPlayer detect;
	private bool isOpened;
    [SerializeField] private SlidingPuzzle puzzle;
	[SerializeField] private ItemContainer inventory;
	[SerializeField] private Item coin1;
	public GameObject blockCoin;

	private void Start()
	{

	}

	void Update()
    {
		//player starts puzzle
		if (detect.inChest() == true && isOpened == false)
        {
			isOpened = true;
			puzzle.TogglePuzzle();

		}
		//player walks away from chest, closing puzzle
		if (detect.inChest() == false && isOpened == true)
		{
			isOpened = false;
			puzzle.TogglePuzzle();
			Debug.Log("Puzzled closed");
		}

	}

	public void OnPuzzleSolved() 
	{
		Debug.Log("Coinsss");
		inventory.AddItem(coin1);
	}
}
