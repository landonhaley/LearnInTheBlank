using UnityEngine;
using System.Collections;
using System.IO;

public class SaveLists : MonoBehaviour {

	public void OnClick()
	{
		ControlCenter.Instance.Quit ();
	}

	public void saveGroupList()
	{
		using (StreamWriter outwriter = new StreamWriter("groups.txt",false))
		{
			foreach (Group _group in ControlCenter.Instance.groups)
			{
				outwriter.WriteLine (_group.groupname);
			}
		}
	}

	public void saveQuizList()
	{
		print ("saving quiz");
	}

	public void saveLists()
	{
		saveGroupList ();
		saveQuizList ();
	}
}

//	//Save to groups.txt
//	void saveGroupList(List<Group> grouplist)
//	{
//		print ("saving groups");
//		using (StreamWriter outwriter = new StreamWriter("group.txt",false))
//		{
//			foreach (Group _group in grouplist)
//			{
//				outwriter.WriteLine (_group.groupname);
//			}
//		}
//	}
//
//	//Save to quizzes folder
//	void saveQuizList(List<Quiz> quizlist)
//	{
//		print ("saving quiz");
//
//	}
//}
