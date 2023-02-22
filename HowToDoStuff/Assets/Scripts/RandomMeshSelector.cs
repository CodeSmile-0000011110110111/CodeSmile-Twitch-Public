using System.Collections.Generic;
using UnityEngine;

namespace CodeSmile.FixingStuff
{
	[RequireComponent(typeof(MeshFilter))]
	public class RandomMeshSelector : MonoBehaviour
	{
		[Header("Selected Mesh")]
		[SerializeField] private Mesh m_SelectedMesh;
		[SerializeField] private int m_SelectedMeshIndex;

		[Header("Settings")]
		[SerializeField] private int m_RandomSeed;
		[SerializeField] private List<Mesh> m_MeshesToChooseFrom = new();
		public int SelectedMeshIndex => m_SelectedMeshIndex;

		private void OnEnable()
		{
			SelectMesh();
		}

		public int GenerateNewRandomSeed() => Random.Range(int.MinValue, int.MaxValue);

		public void SelectMesh()
		{
			m_SelectedMesh = m_MeshesToChooseFrom[SelectedMeshIndex];
			GetComponent<MeshFilter>().sharedMesh = m_SelectedMesh;
			Debug.Log($"selected {m_SelectedMesh} 'randomly' using seed {m_RandomSeed}");
		}

		public void SetRandomMeshIndex()
		{
			// ... no idea what the seed is for so I'm just playing along ...
			Random.InitState(m_RandomSeed);
			m_SelectedMeshIndex = Random.Range(0, m_MeshesToChooseFrom.Count);
		}
		
		public string[] GetMeshNames()
		{
			var names = new List<string>();
			foreach (var mesh in m_MeshesToChooseFrom)
				names.Add(mesh.name);
			
			return names.ToArray();
		}
	}
}