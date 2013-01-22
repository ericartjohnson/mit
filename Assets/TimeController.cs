using UnityEngine;
using System.Collections;

public enum TIME_ERA{
	PAST,
	FUTURE
};

public static class TimeController{
	public static TIME_ERA currentEra = TIME_ERA.PAST;	
}
