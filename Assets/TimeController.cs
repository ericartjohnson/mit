using UnityEngine;
using System.Collections;

public enum TIME_ERA{
	PAST,
	FUTURE
};

public static class TimeController{
	private static TIME_ERA _currentEra = TIME_ERA.PAST;	
	private static float _timeWeight = -1f;
	
	public static TIME_ERA currentEra{
		get{return _currentEra;}
		set{
			TIME_ERA oldEra = _currentEra;
			_currentEra = value;
			/*switch(_currentEra){
				case TIME_ERA.PAST: _timeWeight = -1f; break;
				case TIME_ERA.FUTURE: _timeWeight = 1f; break;
			}*/
			if( (_currentEra == TIME_ERA.PAST && _timeWeight > 0f ) || (_currentEra == TIME_ERA.FUTURE && _timeWeight <= 0f) ) _timeWeight = -_timeWeight;
			if(oldEra != _currentEra){
				BroadcastCenter.broadcastMessage("eraChanged",null);
			}
		}
	}
	
	public static float timeWeight{
		get{return _timeWeight;}
		set{
			_timeWeight = Mathf.Clamp(value,-1f,1f);
			if(_timeWeight <= 0f && _currentEra != TIME_ERA.PAST) currentEra = TIME_ERA.PAST;
			else if(_timeWeight > 0f && _currentEra != TIME_ERA.FUTURE) currentEra = TIME_ERA.FUTURE;
		}
	}
	
	public static float normalizedWeightForEra(TIME_ERA era){
		float o = 0f;
		switch(era){
			case TIME_ERA.PAST: o = Mathf.Clamp(-_timeWeight,0,1); break;
			case TIME_ERA.FUTURE: o = Mathf.Clamp(_timeWeight,0,1); break;
		}
		return o;
	}
	
	public static float signedTimeWeightForEra(TIME_ERA era){
		float o = 0f;
		switch(era){
			case TIME_ERA.PAST: o = -_timeWeight; break;
			case TIME_ERA.FUTURE: o = timeWeight; break;
		}
		return o;
	}
}