using NaughtyAttributes;
using SimpleJSON;
using UnityEngine;




namespace PossumScream.CoolComponents.Savedata
{
	[CreateAssetMenu(menuName = "PossumScream/Components/Savedata/Boolean Savedata File", fileName = "New BooleanSavedata")]
	public class SOBooleanSavedata : ASavedataScriptableObject
	{
		[Header("Value")]
		/* 0 */ [SerializeField] private bool _initial = default;
		/* 9 */ [SerializeField] private bool _value = default;




		#region Controls


			public override void importData(JSONObject dataObject)
			{
				{
					this.value = dataObject["value"];
				}
				base.invokeValueLoadEvent();
			}


			public override void exportData(out JSONObject dataObject)
			{
				dataObject = new JSONObject();
				{
					dataObject.Add("value", this._value);
				}
				base.invokeValueSaveEvent();
			}




			[Button("Reset Value", EButtonEnableMode.Always)]
			public override void resetValue()
			{
				{
					this.value = this._initial;
				}
				base.invokeValueResetEvent();
			}




			public override bool equalsInitial()
			{
				return (this._initial == this._value);
			}




			[Button("Negate Value", EButtonEnableMode.Always)]
			public void negateValue()
			{
				this.value = !this._value;
			}


		#endregion




		#region Getters and Setters


			public bool initial
			{
				get => this._initial;
			}


			public bool value
			{
				get => this._value;
				set
				{
					{
						this._value = value;
					}
					base.invokeValueChangeEvent();
				}
			}


		#endregion
	}
}




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