using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor (typeof (Cone))] 
public class ConeEditor : Editor {
        [MenuItem ("GameObject/Create Other/Cone")]
        static void Create(){
                GameObject gameObject = new GameObject("Cone");
                Cone s = gameObject.AddComponent<Cone>();
                MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
                meshFilter.mesh = new Mesh();
                s.Rebuild();
        }
        
        public override void OnInspectorGUI ()
        {
                Cone obj;

                obj = target as Cone;

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