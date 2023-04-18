#if UNITY_EDITOR


using UnityEditor;
using UnityEngine;




namespace PossumScream.Editor.Tools
{
	public class GuidFinder : EditorWindow
	{
		private Object retrievedObject = null;
		private bool assetFound = false;
		private string inputGuid = "";
		private string retrievedPath = "";




		#region Events


			private void OnGUI()
			{
				EditorGUILayout.LabelField("Prompt", EditorStyles.boldLabel);

				this.inputGuid = EditorGUILayout.TextField("GUID", this.inputGuid);

				if (GUILayout.Button("Search in Asset Database")) {
					this.assetFound = tryFindAsset(this.inputGuid, out this.retrievedPath, out this.retrievedObject);
				}

				if (GUILayout.Button("Clean field")) {
					this.assetFound = false;
					this.inputGuid = "";
					this.retrievedObject = null;
					this.retrievedPath = "";
				}


				EditorGUILayout.LabelField("Results", EditorStyles.boldLabel);

				if (this.assetFound) {
					EditorGUILayout.LabelField("Asset found!");
					EditorGUILayout.TextField("Path", this.retrievedPath);

					if (GUILayout.Button("Highlight asset in Project")) {
						EditorGUIUtility.PingObject(this.retrievedObject);
					}

					if (GUILayout.Button("Select asset in Project")) {
						Selection.objects = new[] { this.retrievedObject };
					}
				}
				else {
					EditorGUILayout.LabelField("Asset not found.");
				}
			}


		#endregion




		#region Controls


			[MenuItem("Window/PossumScream/GUID Finder")]
			public static void CreateWindow()
			{
				GetWindow<GuidFinder>("GUID Finder");
			}


		#endregion




		#region Actions


			private static bool tryFindAsset(string guid, out string path, out Object unityObject)
			{
				path = AssetDatabase.GUIDToAssetPath(guid);
				unityObject = AssetDatabase.LoadAssetAtPath<Object>(path);


				return (path.Length > 0);
			}


		#endregion
	}
}


#endif




/*                                                                                            */
/*                    |>  Original script by tomekkie2 @ Unity Forums.  <|                    */
/*                                                                                            */
/*            ____                                 _____                                      */
/*           / __ \____  ____________  ______ ___ / ___/_____________  ____ _____ ___         */
/*          / /_/ / __ \/ ___/ ___/ / / / __ `__ \\__ \/ ___/ ___/ _ \/ __ `/ __ `__ \        */
/*         / ____/ /_/ (__  |__  ) /_/ / / / / / /__/ / /__/ /  /  __/ /_/ / / / / / /        */
/*        /_/    \____/____/____/\__,_/_/ /_/ /_/____/\___/_/   \___/\__,_/_/ /_/ /_/         */
/*                                                                                            */
/*        Licensed under the Apache License, Version 2.0. See LICENSE.md for more info        */
/*        David Tabernero M. @ PossumScream                      Copyright © 2021-2023        */
/*        https://gitlab.com/possumscream                          All rights reserved        */
/*                                                                                            */
/*                                                                                            */