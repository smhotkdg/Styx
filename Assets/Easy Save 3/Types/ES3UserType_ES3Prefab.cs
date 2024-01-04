using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute()]
	public class ES3UserType_ES3Prefab : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_ES3Prefab() : base(typeof(ES3Internal.ES3Prefab)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (ES3Internal.ES3Prefab)obj;
			
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (ES3Internal.ES3Prefab)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_ES3PrefabArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_ES3PrefabArray() : base(typeof(ES3Internal.ES3Prefab[]), ES3UserType_ES3Prefab.Instance)
		{
			Instance = this;
		}
	}
}