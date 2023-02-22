using System;
using UnityEditor;
using UnityEngine;

namespace CodeSmile.FixingStuff.Editor
{
	[CustomEditor(typeof(RandomMeshSelector))]
	public class RandomMeshSelectorEditor : UnityEditor.Editor
	{
		public override void OnInspectorGUI()
		{
			//base.OnInspectorGUI();

			DrawDefaultInspector();

			var script = (RandomMeshSelector)target;

			if (GUILayout.Button("Change Random Seed"))
			{
				Debug.Log($"Calling method on {target.GetType().Name}");
				
				serializedObject.FindProperty("m_RandomSeed").intValue = script.GenerateNewRandomSeed();
				serializedObject.ApplyModifiedProperties();
				
				script.SetRandomMeshIndex();
				script.SelectMesh();
			}

			var options = script.GetMeshNames();
			var meshIndex = script.SelectedMeshIndex;
			var newMeshIndex = EditorGUILayout.Popup("Meshes", meshIndex, options);
			if (meshIndex != newMeshIndex)
			{
				serializedObject.FindProperty("m_SelectedMeshIndex").intValue = newMeshIndex;
				serializedObject.ApplyModifiedProperties();
				script.SelectMesh();
			}
			
		}
	}
}