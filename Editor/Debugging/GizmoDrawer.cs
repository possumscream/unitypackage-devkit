#if UNITY_EDITOR


using PossumScream.Editor.Editors;
using PossumScream.Mathematics;
using UnityEditor;
using UnityEngine;




namespace PossumScream.Editor.Debugging
{
	[CustomEditor(typeof(GizmoDrawer))]
	public class GizmoDrawInspector : ScriptlessEditor { }




	[RequireComponent(typeof(Transform))]
	public class GizmoDrawer : MonoBehaviour
	{
		/* + */ [SerializeField] private Vector3Int _positiveAxeFactors = Vector3Int.one;
		/* - */ [SerializeField] private Vector3Int _negativeAxeFactors = Vector3Int.zero;
		[SerializeField] [Min(0f)] private float _gizmoSize = 1f;
		[SerializeField] [Range(0f, 1f)] private float _arrowHeadPercentage = 0.15f;
		[SerializeField] private Color _xAxeColor = Color.red;
		[SerializeField] private Color _yAxeColor = Color.green;
		[SerializeField] private Color _zAxeColor = Color.blue;




		#region Events


			private void OnDrawGizmos()
			{
				TransformPoint transformPoint = new TransformPoint(base.transform);

				Vector3 xNegativeGizmoEnd = transformPoint.position - (transformPoint.right * this._gizmoSize);
				Vector3 xPositiveGizmoEnd = transformPoint.position + (transformPoint.right * this._gizmoSize);
				Vector3 yNegativeGizmoEnd = transformPoint.position - (transformPoint.up * this._gizmoSize);
				Vector3 yPositiveGizmoEnd = transformPoint.position + (transformPoint.up * this._gizmoSize);
				Vector3 zNegativeGizmoEnd = transformPoint.position - (transformPoint.forward * this._gizmoSize);
				Vector3 zPositiveGizmoEnd = transformPoint.position + (transformPoint.forward * this._gizmoSize);


				// +X
				if (this._positiveAxeFactors.x != 0) {
					Vector3 xPositiveVectorEnd;


					// Body
					Debug.DrawLine(transformPoint.position,
						(xPositiveVectorEnd = Vector3.LerpUnclamped(transformPoint.position, xPositiveGizmoEnd, this._positiveAxeFactors.x)),
						this._xAxeColor);

					// Head
					/*Debug.DrawLine(xPositiveVectorEnd,
						Vector3.LerpUnclamped(xPositiveVectorEnd, yPositiveGizmoEnd, this._arrowHeadPercentage),
						this._xAxeColor);
					Debug.DrawLine(xPositiveVectorEnd,
						Vector3.LerpUnclamped(xPositiveVectorEnd, yNegativeGizmoEnd, this._arrowHeadPercentage),
						this._xAxeColor);*/
					Debug.DrawLine(xPositiveVectorEnd,
						Vector3.LerpUnclamped(xPositiveVectorEnd, zPositiveGizmoEnd, this._arrowHeadPercentage),
						this._xAxeColor);
					Debug.DrawLine(xPositiveVectorEnd,
						Vector3.LerpUnclamped(xPositiveVectorEnd, zNegativeGizmoEnd, this._arrowHeadPercentage),
						this._xAxeColor);
				}


				// -X
				if (this._negativeAxeFactors.x != 0) {
					Vector3 xNegativeVectorEnd;


					// Body
					Debug.DrawLine(transformPoint.position,
						(xNegativeVectorEnd = Vector3.LerpUnclamped(transformPoint.position, xNegativeGizmoEnd, this._negativeAxeFactors.x)),
						this._xAxeColor);

					// Head
					/*Debug.DrawLine(xNegativeVectorEnd,
						Vector3.LerpUnclamped(xNegativeVectorEnd, yPositiveGizmoEnd, this._arrowHeadPercentage),
						this._xAxeColor);
					Debug.DrawLine(xNegativeVectorEnd,
						Vector3.LerpUnclamped(xNegativeVectorEnd, yNegativeGizmoEnd, this._arrowHeadPercentage),
						this._xAxeColor);*/
					Debug.DrawLine(xNegativeVectorEnd,
						Vector3.LerpUnclamped(xNegativeVectorEnd, zPositiveGizmoEnd, this._arrowHeadPercentage),
						this._xAxeColor);
					Debug.DrawLine(xNegativeVectorEnd,
						Vector3.LerpUnclamped(xNegativeVectorEnd, zNegativeGizmoEnd, this._arrowHeadPercentage),
						this._xAxeColor);
				}


				// +Y
				if (this._positiveAxeFactors.y != 0) {
					Vector3 yPositiveVectorEnd;


					// Body
					Debug.DrawLine(transformPoint.position,
						(yPositiveVectorEnd = Vector3.LerpUnclamped(transformPoint.position, yPositiveGizmoEnd, this._positiveAxeFactors.y)),
						this._yAxeColor);

					// Head
					Debug.DrawLine(yPositiveVectorEnd,
						Vector3.LerpUnclamped(yPositiveVectorEnd, xPositiveGizmoEnd, this._arrowHeadPercentage),
						this._yAxeColor);
					Debug.DrawLine(yPositiveVectorEnd,
						Vector3.LerpUnclamped(yPositiveVectorEnd, xNegativeGizmoEnd, this._arrowHeadPercentage),
						this._yAxeColor);
					/*Debug.DrawLine(yPositiveVectorEnd,
						Vector3.LerpUnclamped(yPositiveVectorEnd, zPositiveGizmoEnd, this._arrowHeadPercentage),
						this._yAxeColor);
					Debug.DrawLine(yPositiveVectorEnd,
						Vector3.LerpUnclamped(yPositiveVectorEnd, zNegativeGizmoEnd, this._arrowHeadPercentage),
						this._yAxeColor);*/
				}


				// -Y
				if (this._negativeAxeFactors.y != 0) {
					Vector3 yNegativeVectorEnd;


					// Body
					Debug.DrawLine(transformPoint.position,
						(yNegativeVectorEnd = Vector3.LerpUnclamped(transformPoint.position, yNegativeGizmoEnd, this._negativeAxeFactors.y)),
						this._yAxeColor);

					// Head
					Debug.DrawLine(yNegativeVectorEnd,
						Vector3.LerpUnclamped(yNegativeVectorEnd, xPositiveGizmoEnd, this._arrowHeadPercentage),
						this._yAxeColor);
					Debug.DrawLine(yNegativeVectorEnd,
						Vector3.LerpUnclamped(yNegativeVectorEnd, xNegativeGizmoEnd, this._arrowHeadPercentage),
						this._yAxeColor);
					/*Debug.DrawLine(yNegativeVectorEnd,
						Vector3.LerpUnclamped(yNegativeVectorEnd, zPositiveGizmoEnd, this._arrowHeadPercentage),
						this._yAxeColor);
					Debug.DrawLine(yNegativeVectorEnd,
						Vector3.LerpUnclamped(yNegativeVectorEnd, zNegativeGizmoEnd, this._arrowHeadPercentage),
						this._yAxeColor);*/
				}


				// +Z
				if (this._positiveAxeFactors.z != 0) {
					Vector3 zPositiveVectorEnd;


					// Body
					Debug.DrawLine(transformPoint.position,
						(zPositiveVectorEnd = Vector3.LerpUnclamped(transformPoint.position, zPositiveGizmoEnd, this._positiveAxeFactors.z)),
						this._zAxeColor);

					// Head
					/*Debug.DrawLine(zPositiveVectorEnd,
						Vector3.LerpUnclamped(zPositiveVectorEnd, xPositiveGizmoEnd, this._arrowHeadPercentage),
						this._zAxeColor);
					Debug.DrawLine(zPositiveVectorEnd,
						Vector3.LerpUnclamped(zPositiveVectorEnd, xNegativeGizmoEnd, this._arrowHeadPercentage),
						this._zAxeColor);*/
					Debug.DrawLine(zPositiveVectorEnd,
						Vector3.LerpUnclamped(zPositiveVectorEnd, yPositiveGizmoEnd, this._arrowHeadPercentage),
						this._zAxeColor);
					Debug.DrawLine(zPositiveVectorEnd,
						Vector3.LerpUnclamped(zPositiveVectorEnd, yNegativeGizmoEnd, this._arrowHeadPercentage),
						this._zAxeColor);
				}


				// -Z
				if (this._negativeAxeFactors.z != 0) {
					Vector3 zNegativeVectorEnd;


					// Body
					Debug.DrawLine(transformPoint.position,
						(zNegativeVectorEnd = Vector3.LerpUnclamped(transformPoint.position, zNegativeGizmoEnd, this._negativeAxeFactors.z)),
						this._zAxeColor);

					// Head
					/*Debug.DrawLine(zNegativeVectorEnd,
						Vector3.LerpUnclamped(zNegativeVectorEnd, xPositiveGizmoEnd, this._arrowHeadPercentage),
						this._zAxeColor);
					Debug.DrawLine(zNegativeVectorEnd,
						Vector3.LerpUnclamped(zNegativeVectorEnd, xNegativeGizmoEnd, this._arrowHeadPercentage),
						this._zAxeColor);*/
					Debug.DrawLine(zNegativeVectorEnd,
						Vector3.LerpUnclamped(zNegativeVectorEnd, yPositiveGizmoEnd, this._arrowHeadPercentage),
						this._zAxeColor);
					Debug.DrawLine(zNegativeVectorEnd,
						Vector3.LerpUnclamped(zNegativeVectorEnd, yNegativeGizmoEnd, this._arrowHeadPercentage),
						this._zAxeColor);
				}
			}


		#endregion
	}
}


#endif




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