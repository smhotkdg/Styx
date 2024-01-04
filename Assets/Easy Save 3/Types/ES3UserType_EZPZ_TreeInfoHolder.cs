using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("globalVariableList", "dialogueTreeList")]
	public class ES3UserType_EZPZ_TreeInfoHolder : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_EZPZ_TreeInfoHolder() : base(typeof(EZPZ_TreeInfoHolder)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (EZPZ_TreeInfoHolder)obj;
			
			writer.WriteProperty("globalVariableList", instance.globalVariableList);
			writer.WriteProperty("dialogueTreeList", instance.dialogueTreeList);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (EZPZ_TreeInfoHolder)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "globalVariableList":
						instance.globalVariableList = reader.Read<System.Collections.Generic.List<EZPZ_TreeInfoHolder.VariableData>>();
						break;
					case "dialogueTreeList":
						instance.dialogueTreeList = reader.Read<System.Collections.Generic.List<DialogueTreeScriptableObj>>();
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_EZPZ_TreeInfoHolderArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_EZPZ_TreeInfoHolderArray() : base(typeof(EZPZ_TreeInfoHolder[]), ES3UserType_EZPZ_TreeInfoHolder.Instance)
		{
			Instance = this;
		}
	}
}