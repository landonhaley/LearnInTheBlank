#pragma strict

function Start () {

}

function Update () {

}

function GoToGroups () {
	SceneManagement.SceneManager.LoadScene(1);
}

function GoToQuizzes () {
	SceneManagement.SceneManager.LoadScene(4);
}

function GoToUpload () {
	SceneManagement.SceneManager.LoadScene(8);
}

function GoToSelectQuiz () {
	SceneManagement.SceneManager.LoadScene(7);
}

function GoToQuizzing () {
	SceneManagement.SceneManager.LoadScene(5);
}

function GoToMainMenu () {
	SceneManagement.SceneManager.LoadScene(0);
}