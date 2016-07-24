﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class RunQuiz : MonoBehaviour 
{

	Group chosenGroup;
	Word chosenWord;
	string hiddenSentence;
	public Text CurrentGroupName;
	public Text CurrentQuestion;
	public InputField userInput;
	public GameObject NextAns;
	public GameObject SubmitAns;
	public Text QNum;

	public GameObject itemPrefab;
	public GameObject pContent;
	public GameObject gContent;
	public GameObject scrollbar;

	public int columnCount = 1, itemCount;


	void Start(){
		loadPointsAndGroups();
	}



	public bool isEqual(string str1, string str2)
	{
		str1 = str1.Trim( new char[] { ',', '.' } );
		str2 = str2.Trim( new char[] { ',', '.' } );

		return ((str1.Length == str2.Length) && (str1 == str2));
	}

	public void checkSubmission()
	{
		int idxGroup = ControlCenter.Instance.gnum;
		Text texty = userInput.GetComponentInChildren<Text>();
		string userAnswer = texty.text;
		bool verdict = isEqual(ControlCenter.Instance.chosenWord.word.ToLower (), userAnswer.ToLower ());

//		print (userAnswer + " (goes with) " + ControlCenter.Instance.chosenWord.word);
//		print ("verdict: " + verdict);

		if (verdict) {
			//Get group and add point
			ControlCenter.Instance.quiz.selectedGroups [idxGroup].points += 1;
			texty.color = Color.green;
			loadPointsAndGroups ();
		} else {

			texty.color = Color.red;
		}
			
		texty.text = ControlCenter.Instance.chosenWord.word;
		SubmitAns.GetComponent<Button>().interactable = false;
		SubmitAns.SetActive (false);
		NextAns.GetComponent<Button>().interactable = true;
		NextAns.SetActive (true);

		//inc question and group
		ControlCenter.Instance.gnum = (ControlCenter.Instance.gnum + 1) % ControlCenter.Instance.quiz.selectedGroups.Count;
		ControlCenter.Instance.qnum += 1;

	}


	public void loadPointsAndGroups(){

		foreach(Text child in pContent.GetComponentsInChildren<Text>()) {
			Destroy(child);
		}

		foreach(Text child in gContent.GetComponentsInChildren<Text>()) {
			Destroy(child);
		}

		List<Group> temp = ControlCenter.Instance.quiz.selectedGroups;
		itemCount = temp.Count;
		RectTransform rowRectTransform = itemPrefab.GetComponent<RectTransform> ();
		RectTransform containerRectTransformP = pContent.GetComponent<RectTransform> ();
		RectTransform containerRectTransformG = gContent.GetComponent<RectTransform> ();

		//calculate the width and height of each child item.
		float widthP = containerRectTransformP.rect.width / columnCount;
		float ratioP = widthP / rowRectTransform.rect.width;
		float heightP = rowRectTransform.rect.height * ratioP;
		float widthG = containerRectTransformG.rect.width / columnCount;
		float ratioG = widthG / rowRectTransform.rect.width;
		float heightG = rowRectTransform.rect.height * ratioG;
		int rowCount = itemCount / columnCount;
		if (itemCount % rowCount > 0)
			rowCount++;

		//adjust the height of the container so that it will just barely fit all its children
		float scrollHeightP = heightP * rowCount;
		float scrollHeightG = heightG * rowCount;
		containerRectTransformP.offsetMin = new Vector2 (containerRectTransformP.offsetMin.x, -scrollHeightP);
		containerRectTransformG.offsetMin = new Vector2 (containerRectTransformG.offsetMin.x, -scrollHeightG);

		int j = 0, i = 0;
		foreach (Group groupy in temp) {
			//this is used instead of a double for loop because itemCount may not fit perfectly into the rows/columns
			if (i % columnCount == 0)
				j++;

			//create a new item, name it, and set the parent
			GameObject newItemP = Instantiate (itemPrefab) as GameObject;
			GameObject newItemG = Instantiate (itemPrefab) as GameObject;
			newItemP.name = groupy.groupname + " Points";
			newItemG.name = "Group " + i;
			Text groupLabelP = newItemP.GetComponent<Text> ();
			Text groupLabelG = newItemG.GetComponent<Text> ();
			groupLabelP.text = groupy.points.ToString();
			groupLabelG.text = groupy.groupname;
			newItemP.transform.SetParent (pContent.transform, false);
			newItemG.transform.SetParent (gContent.transform, false);

			//move and size the new item
			RectTransform rectTransformP = newItemP.GetComponent<RectTransform> ();
			RectTransform rectTransformG = newItemG.GetComponent<RectTransform> ();

			float xp = -containerRectTransformP.rect.width / 2 + widthP * (i % columnCount);
			float yp = containerRectTransformP.rect.height / 2 - 50 * j;
			rectTransformP.offsetMin = new Vector2 (xp, yp);

			float xg = -containerRectTransformG.rect.width / 2 + widthG * (i % columnCount);
			float yg = containerRectTransformG.rect.height / 2 - 50 * j;
			rectTransformG.offsetMin = new Vector2 (xg, yg);

			xp = rectTransformP.offsetMin.x + widthP;
			yp = rectTransformP.offsetMin.y + 40;
			rectTransformP.offsetMax = new Vector2 (xp, yp);

			xg = rectTransformG.offsetMin.x + widthG;
			yg = rectTransformG.offsetMin.y + 40;
			rectTransformG.offsetMax = new Vector2 (xg, yg);
			i++;

		}
		
	}


}