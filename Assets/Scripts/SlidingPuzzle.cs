using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlidingPuzzle : MonoBehaviour, IPointerClickHandler
{
	[Tooltip("Shuffle count, set to 0 for easy testing")][SerializeField] int shuffleCount = 1;
	[Tooltip("Specify how fast tiles should move")][SerializeField] float moveSpeed = 1;
	[Tooltip("Show 9th piece?")][SerializeField] bool show9thPiece = true;

    private List<Image> images;				//internal list of images to swap and check
	private int freePositionIndex;			//stores position of item to swap with
	private int dimensions;					//calculates dimensions based on number of items
	private bool swapAllowed = true;		//should we accept swap requests? False during animations
	private Canvas canvas;					//reference to canvas to hide/show everything

	public UnityEvent OnPuzzleSolved;		//register to this event to get a callback when the puzzle is solved

	void Awake()
    {
		//stop rendering the puzzle
		canvas = GetComponent<Canvas>();
		canvas.enabled = false;

		//gather all images
		images = new List<Image>();
		foreach(Transform child in transform)
		{
			images.Add(child.GetComponent<Image>());
		}

		//disable last image and set last index as free index
		int lastImage = images.Count - 1;
		images[lastImage].enabled = show9thPiece;
		freePositionIndex = lastImage;

		//calculate the dimensions, eg 9 slots -> dimensions is 3 (by 3)
		dimensions = (int)Mathf.Sqrt(images.Count);

		//Brute force shuffle
		Shuffle();
    }

	public void StartPuzzle() 
	{
		if (canvas.enabled) return;

		canvas.enabled = true;
		swapAllowed = true;
	}

	public void TogglePuzzle()
	{
		if (!canvas.enabled) StartPuzzle(); else StopPuzzle();
	}

	public void StopPuzzle()
	{
		canvas.enabled = false;
		swapAllowed = false;
	}

	public void Shuffle()
	{
		//brute force shuffle 
		for (int i = 0; i < shuffleCount; i++)
		{
			swapItemWithFree(Random.Range(0, images.Count));
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (!swapAllowed) return;

		//Get image and image index
		Image clickedImage = eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>();
		int clickedImageIndex = images.IndexOf(clickedImage);
		swapItemWithFree(clickedImageIndex, true);

		bool solved = checkSolve();
		Debug.Log("Are we solved? " + solved);
		if (solved && OnPuzzleSolved != null) OnPuzzleSolved.Invoke();
	}

	private bool checkSolve()
	{
		for (int i = 0; i < images.Count; i++)
		{
			if (transform.GetChild(i) != images[i].transform) return false;
		}

		return true;
	}

	private void swapItemWithFree(int pSwapIndex, bool pAnimate = false)
	{
		//get the grid locations of old and new image
		Vector2Int freePositionGridXY = new Vector2Int(freePositionIndex % dimensions, freePositionIndex / dimensions);
		Vector2Int newPositionGridXY = new Vector2Int(pSwapIndex % dimensions, pSwapIndex / dimensions);

		//check if they are in the same column and one distance apart
		if (Vector2Int.Distance(freePositionGridXY, newPositionGridXY) != 1) return;

		//swap their positions
		Vector2 freePosition = images[freePositionIndex].rectTransform.anchoredPosition;
		Vector2 oldPosition = images[pSwapIndex].rectTransform.anchoredPosition;

		if (!pAnimate) { 
			images[freePositionIndex].rectTransform.anchoredPosition = oldPosition;
			images[pSwapIndex].rectTransform.anchoredPosition = freePosition;
		} else
		{
			StartCoroutine(DoImageAnimation (images[freePositionIndex], oldPosition, images[pSwapIndex], freePosition));
		}

		//swap their indices in the list
		Image tmp = images[freePositionIndex];
		images[freePositionIndex] = images[pSwapIndex];
		images[pSwapIndex] = tmp;
		freePositionIndex = pSwapIndex;
	}

	//Coroutine for animation
	private IEnumerator DoImageAnimation(Image image1, Vector2 oldPosition, Image image2, Vector2 freePosition)
	{
		swapAllowed = false;
		float startTime = Time.realtimeSinceStartup;
		float lerpValue = 0;
		do
		{
			lerpValue = (Time.realtimeSinceStartup - startTime) * moveSpeed;
			image1.rectTransform.anchoredPosition = Vector2.Lerp(freePosition, oldPosition, lerpValue);
			image2.rectTransform.anchoredPosition = Vector2.Lerp(oldPosition, freePosition, lerpValue);
			yield return null;
		} while (lerpValue < 1);

		swapAllowed = true;
	}
}
