using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterAninator : MonoBehaviour {
	public AnimationCurve _RotateCurve;
	public AnimationCurve _TranslateCurveX;
	public AnimationCurve _TranslateCurveY;
	private float _StartTime = 0.0f;

	// Use this for initialization
	void Start () {	
		_StartTime = Time.realtimeSinceStartup;
	}

	// Update is called once per frame
	void Update () {
			float T = Time.realtimeSinceStartup - _StartTime;
			float r = _RotateCurve.Evaluate(T);
			transform.Rotate(0.0f, 0.0f, r);

			Vector3 move = transform.localPosition;
			move.x = _TranslateCurveX.Evaluate(T);
			move.y = _TranslateCurveY.Evaluate(T);
			transform.localPosition = move*0.05f;
		    
	
	}


}


