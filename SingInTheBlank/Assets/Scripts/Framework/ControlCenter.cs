using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ControlCenter : Singleton<ControlCenter> {

	public List<Quiz> quizzes;
	public List<Group> groups;
	public Quiz quiz;

	public void Quit() 
	{
		Application.Quit();
	}

	public void Awake() 
	{

	}

	public void LoadMainWindow()
	{
		SceneManager.LoadScene(9);
		GameObject.DontDestroyOnLoad(gameObject);

	}

	/*called from Quizzes scene*/
	public void LoadMainWindow(List<Quiz> _quizzes)
	{
		quizzes = _quizzes;
		SceneManager.LoadScene(9);
		GameObject.DontDestroyOnLoad(gameObject);
	}

	/*called from Groups scene*/
	public void LoadMainWindow(List<Group> _groups)
	{
		groups = _groups;
		SceneManager.LoadScene(9);
		GameObject.DontDestroyOnLoad(gameObject);
	}

		
	public void LoadQuizSelect()
	{
		SceneManager.LoadScene(7);
		GameObject.DontDestroyOnLoad(gameObject);
	}


	/* quiz selection calls group selection*/
	public void LoadGroupSelect(Quiz _quiz)
	{
		quiz = _quiz;
		SceneManager.LoadScene(6);
		GameObject.DontDestroyOnLoad(gameObject);
	}
		

	/*group selection calls quizzing*/
	public void LoadQuizzing(List<Group> _groups)
	{
		quiz.selectedGroups = _groups;
		SceneManager.LoadScene(5);
		GameObject.DontDestroyOnLoad(gameObject);
	}


	public void LoadGroups()
	{
		SceneManager.LoadScene(1);
		GameObject.DontDestroyOnLoad(gameObject);
	}


	public void LoadQuizzes()
	{
		SceneManager.LoadScene(4);
		GameObject.DontDestroyOnLoad(gameObject);
	}


	public void LoadQuizOverview()
	{
		SceneManager.LoadScene(2);
		GameObject.DontDestroyOnLoad(gameObject);
	}

	public void LoadUpload()
	{
		SceneManager.LoadScene(8);
		GameObject.DontDestroyOnLoad(gameObject);
	}

	/*public void LoadScore()
	{
		_playerData = PlayerControl.Instance.GetAllPlayerData ();
		Application.LoadLevel("Score");
		GameObject.DontDestroyOnLoad(gameObject);
	}*/

	public override void Destroyed(){}

}
