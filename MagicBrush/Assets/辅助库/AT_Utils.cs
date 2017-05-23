﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT_Utils {

	static public Vector3 鼠标位置从屏幕转换到世界参考系 (
		Transform RefObjectTF)
	{
		Vector3 鼠标操作位置InWorld;
		Ray mouseRay = Camera.main.ScreenPointToRay (
			Input.mousePosition);
		float 相机到此物体的z距离 = 
			RefObjectTF.position.z - 
			Camera.main.transform.position.z;
		鼠标操作位置InWorld = 
			mouseRay.GetPoint (相机到此物体的z距离);
		return 鼠标操作位置InWorld;
	}


	public static  T CopyComponent<T>(T original, GameObject destination) where T : Component
	{
		System.Type type = original.GetType();
		Component copy = destination.AddComponent(type);
		System.Reflection.FieldInfo[] fields = type.GetFields();
		foreach (System.Reflection.FieldInfo field in fields)
		{
			field.SetValue(copy, field.GetValue(original));
		}
		return copy as T;
	}
}
