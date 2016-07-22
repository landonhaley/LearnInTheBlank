using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class LoadQuizzes : MonoBehaviour {

	public GameObject itemPrefab;
	public GameObject content;
	public GameObject scrollbar;
	public bool selectOne;

	public int columnCount = 1, itemCount;

	void Start () {
		List<Quiz> temp = ControlCenter.Instance.quizzes;
		itemCount = temp.Count;
		RectTransform rowRectTransform = itemPrefab.GetComponent<RectTransform>();
		RectTransform containerRectTransform = content.GetComponent<RectTransform>();

		//calculate the width and height of each child item.
		float width = containerRectTransform.rect.width / columnCount;
		float ratio = width / rowRectTransform.rect.width;
		float height = rowRectTransform.rect.height * ratio;
		int rowCount = itemCount / columnCount;
		if (itemCount % rowCount > 0)
			rowCount++;

		//adjust the height of the container so that it will just barely fit all its children
		float scrollHeight = height * rowCount;
		containerRectTransform.offsetMin = new Vector2(containerRectTransform.offsetMin.x, -scrollHeight);
		//containerRectTransform.offsetMax = new Vector2(containerRectTransform.offsetMax.x, scrollHeight/2);
		int j = 0, i = 0;
		foreach (Quiz quizzy in temp)
		{
			//this is used instead of a double for loop because itemCount may not fit perfectly into the rows/columns
			if (i % columnCount == 0)
				j++;

			//create a new item, name it, and set the parent
			GameObject newItem = Instantiate(itemPrefab) as GameObject;
			newItem.name = "Quiz " + i;
			if (selectOne) {
				newItem.GetComponent<Toggle> ().group = content.GetComponent<ToggleGroup> ();
			}
			Text quizLabel = newItem.GetComponentInChildren<Text> ();
			quizLabel.text = quizzy.title;
			newItem.transform.SetParent(content.transform, false);

			content.GetComponent<ToggleGroup> ().RegisterToggle (newItem.GetComponent<Toggle>());

			//move and size the new item
			RectTransform rectTransform = newItem.GetComponent<RectTransform>();

			float x = -containerRectTransform.rect.width / 2 + width * (i % columnCount);
			float y = containerRectTransform.rect.height / 2 - 50 * j;
			rectTransform.offsetMin = new Vector2(x, y);

			x = rectTransform.offsetMin.x + width;
			y = rectTransform.offsetMin.y + 40;
			rectTransform.offsetMax = new Vector2(x, y);
			i++;

		}


	}
}

