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

	public void saveLists()
	{
		saveGroupList ();
	}
} 
