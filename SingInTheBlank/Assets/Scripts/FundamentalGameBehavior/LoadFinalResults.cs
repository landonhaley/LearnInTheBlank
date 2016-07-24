using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public class LoadFinalResults : MonoBehaviour {

	public GameObject itemPrefab;
	public GameObject pContent;
	public GameObject gContent;
	public GameObject rContent;
	public GameObject scrollbar;

	public int columnCount = 1, itemCount;

	// Use this for initialization
	void Start () {
		LoadFinal ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadFinal(){
		
		List<Group> temp = ControlCenter.Instance.quiz.selectedGroups;
		itemCount = temp.Count;
		RectTransform rowRectTransform = itemPrefab.GetComponent<RectTransform> ();
		RectTransform containerRectTransformP = pContent.GetComponent<RectTransform> ();
		RectTransform containerRectTransformG = gContent.GetComponent<RectTransform> ();
		RectTransform containerRectTransformR = rContent.GetComponent<RectTransform> ();


		//calculate the width and height of each child item.
		float widthP = containerRectTransformP.rect.width / columnCount;
		float ratioP = widthP / rowRectTransform.rect.width;
		float heightP = rowRectTransform.rect.height * ratioP;
		float widthG = containerRectTransformG.rect.width / columnCount;
		float ratioG = widthG / rowRectTransform.rect.width;
		float heightG = rowRectTransform.rect.height * ratioG;
		float widthR = containerRectTransformR.rect.width / columnCount;
		float ratioR = widthR / rowRectTransform.rect.width;
		float heightR = rowRectTransform.rect.height * ratioR;
		int rowCount = itemCount / columnCount;
		if (itemCount % rowCount > 0)
			rowCount++;

		//adjust the height of the container so that it will just barely fit all its children
		float scrollHeightP = heightP * rowCount;
		float scrollHeightG = heightG * rowCount;
		float scrollHeightR = heightR * rowCount;
		containerRectTransformP.offsetMin = new Vector2 (containerRectTransformP.offsetMin.x, -scrollHeightP);
		containerRectTransformG.offsetMin = new Vector2 (containerRectTransformG.offsetMin.x, -scrollHeightG);
		containerRectTransformR.offsetMin = new Vector2 (containerRectTransformR.offsetMin.x, -scrollHeightR);

		temp.OrderBy (o => o.points).ToList ();

		int j = 0, i = 0;
		foreach (Group groupy in temp) {

			//this is used instead of a double for loop because itemCount may not fit perfectly into the rows/columns
			if (i % columnCount == 0)
				j++;

			//create a new item, name it, and set the parent
			GameObject newItemP = Instantiate (itemPrefab) as GameObject;
			GameObject newItemG = Instantiate (itemPrefab) as GameObject;
			GameObject newItemR = Instantiate (itemPrefab) as GameObject;
			newItemP.name = groupy.groupname + " Points";
			newItemG.name = "Group " + i;
			newItemR.name = groupy.groupname + " Rank";
			Text groupLabelP = newItemP.GetComponent<Text> ();
			Text groupLabelG = newItemG.GetComponent<Text> ();
			Text groupLabelR = newItemR.GetComponent<Text> ();
			groupLabelP.text = groupy.points.ToString();
			groupLabelG.text = groupy.groupname;
			groupLabelR.text = (i+1).ToString();
			newItemP.transform.SetParent (pContent.transform, false);
			newItemG.transform.SetParent (gContent.transform, false);
			newItemR.transform.SetParent (rContent.transform, false);

			//move and size the new item
			RectTransform rectTransformP = newItemP.GetComponent<RectTransform> ();
			RectTransform rectTransformG = newItemG.GetComponent<RectTransform> ();
			RectTransform rectTransformR = newItemR.GetComponent<RectTransform> ();

			float xp = -containerRectTransformP.rect.width / 2 + widthP * (i % columnCount);
			float yp = containerRectTransformP.rect.height / 2 - 50 * j;
			rectTransformP.offsetMin = new Vector2 (xp, yp);

			float xg = -containerRectTransformG.rect.width / 2 + widthG * (i % columnCount);
			float yg = containerRectTransformG.rect.height / 2 - 50 * j;
			rectTransformG.offsetMin = new Vector2 (xg, yg);

			float xr = -containerRectTransformR.rect.width / 2 + widthR * (i % columnCount);
			float yr = containerRectTransformR.rect.height / 2 - 50 * j;
			rectTransformR.offsetMin = new Vector2 (xr, yr);

			xp = rectTransformP.offsetMin.x + widthP;
			yp = rectTransformP.offsetMin.y + 40;
			rectTransformP.offsetMax = new Vector2 (xp, yp);

			xg = rectTransformG.offsetMin.x + widthG;
			yg = rectTransformG.offsetMin.y + 40;
			rectTransformG.offsetMax = new Vector2 (xg, yg);

			xr = rectTransformR.offsetMin.x + widthR;
			yr = rectTransformR.offsetMin.y + 40;
			rectTransformR.offsetMax = new Vector2 (xr, yr);

			i++;

		}
	}
}
