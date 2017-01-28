//using UnityEngine;
//using System.Collections;
//using UnityEditor;
//using AppAdvisory.Ads;
//
//[CustomEditor(typeof(AdsManager))]
//public class AdsManagerInspector : Editor
//{
//	public override void OnInspectorGUI ()
//	{
//		serializedObject.Update();
//
//		SerializedProperty adids = serializedObject.FindProperty("adIds");
//		EditorGUILayout.PropertyField(adids);
//		serializedObject.ApplyModifiedProperties();
//
//
////		SerializedProperty banner = serializedObject.FindProperty("listBanner");
////		EditorGUILayout.PropertyField(banner);
////		serializedObject.ApplyModifiedProperties();
//	}
//}
