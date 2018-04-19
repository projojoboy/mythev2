using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor (typeof (ConeWithNormals))] 
public class ConeNormalEditor : Editor {
        [MenuItem ("GameObject/Create Other/ConeWithNormals")]
        static void Create(){
                GameObject gameObject = new GameObject("ConeWithNormals");
                ConeWithNormals s = gameObject.AddComponent<ConeWithNormals>();
                MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
                meshFilter.mesh = new Mesh();
                s.Rebuild();
        }
        
        public override void OnInspectorGUI ()
        {
                ConeWithNormals obj;

                obj = target as ConeWithNormals;

                if (obj == null)
                {
                        return;
                }
        
                base.DrawDefaultInspector();
                EditorGUILayout.BeginHorizontal ();
                
                // Rebuild mesh when user click the Rebuild button
                if (GUILayout.Button("Reeebuild")){
                        obj.Rebuild();
                }
                EditorGUILayout.EndHorizontal ();
        }
}