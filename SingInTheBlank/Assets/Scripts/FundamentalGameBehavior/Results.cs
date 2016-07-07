using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Results : MonoBehaviour {

	public List<Group> groupsParticipated = null;

	/*sorts the groups list based on points*/
	/*must be called before DisplayResults() */
	void SortQuizResults (List<Group> _groupsParticipated) 
	{
		
		groupsParticipated = _groupsParticipated;
		// proceed with sorting groupsParticipated
	}
	

	void DisplayResults () 
	{
		
		// display groupsParticipated on GUI
	}
}
