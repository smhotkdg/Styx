// Copyright © Pixel Crushers. All rights reserved.

using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;

namespace PixelCrushers.DialogueSystem.I2Support
{

    [Serializable]
    public class FoldoutInfo
    {
        public bool foldout;
        public FieldSelectionDictionary fieldSelections = new FieldSelectionDictionary();
    }

    /// <summary>
    /// Holds the DS To I2 window's current prefs, which are saved into EditorPrefs
    /// between editor sessions.
    /// </summary>
    [Serializable]
    public class DSToI2Prefs : ISerializationCallbackReceiver
    {
        public enum Category { Actors, Items, Locations, Variables, Conversations, DialogueEntries, LocalizedTextTable, TextTable }

        public const int NumDatabaseCategories = 6;

        public const int NumTotalCategories = 8;

        public List<int> databaseInstanceIDs = new List<int>();

        public int textTableInstanceID = 0;

        public int localizedTextTableInstanceID = 0;

        public int dialogueEntryMinDigits = 1;

        public FoldoutInfo[] categoryFoldouts = new FoldoutInfo[NumTotalCategories];

        public enum DialogueEntryInfo { None, Actor, Text }

        public DialogueEntryInfo dialogueEntryInfo = DialogueEntryInfo.None;

        public I2LanguageIdentifierType languageIdentifier = I2LanguageIdentifierType.LanguageCode;

        public enum AssetIdentifierType { ID, Name }

        public AssetIdentifierType assetIdentifier = AssetIdentifierType.ID;

        public enum Verbose { None, Warnings, Detailed }

        public Verbose verbose = Verbose.None;

        public bool showHelp = false;

        public bool showWarnings { get { return verbose == Verbose.Warnings || verbose == Verbose.Detailed; } }

        public bool showDetails { get { return verbose == Verbose.Detailed; } }

        public DSToI2Prefs()
        {
            for (int i = 0; i < NumTotalCategories; i++)
            {
                categoryFoldouts[i] = new FoldoutInfo();
            }
        }

        private List<DialogueDatabase> m_databases = new List<DialogueDatabase>();
        public List<DialogueDatabase> databases { get { return m_databases; } }

        private TextTable m_textTable = null;

        private LocalizedTextTable m_localizedTextTable = null;

        public int GetNumDatabases()
        {
            int count = 0;
            for (int i = 0; i < m_databases.Count; i++)
            {
                if (m_databases[i] != null) count++;
            }
            return count;
        }

        //public DialogueDatabase database
        //{
        //    get
        //    {
        //        if (m_database == null && databaseInstanceID != 0)
        //        {
        //            m_database = EditorUtility.InstanceIDToObject(databaseInstanceID) as DialogueDatabase;
        //            if (m_database != null) PopulateAllDatabaseFields();
        //        }
        //        return m_database;
        //    }
        //    set
        //    {
        //        databaseInstanceID = (value != null) ? value.GetInstanceID() : 0;
        //        if (value != m_database)
        //        {
        //            m_database = value;
        //            if (m_database != null) PopulateAllDatabaseFields();
        //        }
        //    }
        //}

        public TextTable textTable
        {
            get
            {
                if (m_textTable == null && textTableInstanceID != 0)
                {
                    m_textTable = EditorUtility.InstanceIDToObject(textTableInstanceID) as TextTable;
                    if (m_textTable != null) PopulateTextTableFields();
                }
                return m_textTable;
            }
            set
            {
                textTableInstanceID = (value != null) ? value.GetInstanceID() : 0;
                if (value != m_textTable)
                {
                    m_textTable = value;
                    if (m_textTable != null) PopulateTextTableFields();
                }
            }
        }

        public LocalizedTextTable localizedTextTable
        {
            get
            {
                if (m_localizedTextTable == null && localizedTextTableInstanceID != 0)
                {
                    m_localizedTextTable = EditorUtility.InstanceIDToObject(localizedTextTableInstanceID) as LocalizedTextTable;
                    if (m_localizedTextTable != null) PopulateLocalizedTextTableFields();
                }
                return m_localizedTextTable;
            }
            set
            {
                localizedTextTableInstanceID = (value != null) ? value.GetInstanceID() : 0;
                if (value != m_localizedTextTable)
                {
                    m_localizedTextTable = value;
                    if (m_localizedTextTable != null) PopulateLocalizedTextTableFields();
                }
            }
        }

        public void PopulateAllDatabaseFields()
        {
            foreach (var database in m_databases)
            {
                if (database == null) return;
                for (int i = 0; i < NumDatabaseCategories; i++)
                {
                    if (categoryFoldouts[i] == null) categoryFoldouts[i] = new FoldoutInfo();
                    var fieldSelections = categoryFoldouts[i].fieldSelections;
                    switch ((Category)i)
                    {
                        case Category.Actors:
                            fieldSelections.PopulateDictionary<Actor>(database.actors);
                            break;
                        case Category.Items:
                            fieldSelections.PopulateDictionary<Item>(database.items);
                            break;
                        case Category.Locations:
                            fieldSelections.PopulateDictionary<Location>(database.locations);
                            break;
                        case Category.Variables:
                            fieldSelections.PopulateDictionary<Variable>(database.variables);
                            break;
                        case Category.Conversations:
                            fieldSelections.PopulateDictionary<Conversation>(database.conversations);
                            break;
                        case Category.DialogueEntries:
                            fieldSelections.PopulateDictionaryWithDialogueEntries(database.conversations);
                            break;
                    }
                }
            }
        }

        public void PopulateTextTableFields()
        {
            if (textTable == null) return;
            var i = (int)Category.TextTable;
            if (categoryFoldouts[i] == null) categoryFoldouts[i] = new FoldoutInfo();
            categoryFoldouts[i].fieldSelections.PopulateDictionaryWithTextTable(textTable);
        }

        public void PopulateLocalizedTextTableFields()
        {
            if (localizedTextTable == null) return;
            var i = (int)Category.LocalizedTextTable;
            if (categoryFoldouts[i] == null) categoryFoldouts[i] = new FoldoutInfo();
            categoryFoldouts[i].fieldSelections.PopulateDictionaryWithLocalizedTextTable(localizedTextTable);
        }

        public FoldoutInfo GetCategoryFoldout(Category category)
        {
            var index = (int)category;
            if (index >= categoryFoldouts.Length)
            {
                var list = new List<FoldoutInfo>(categoryFoldouts);
                for (int i = categoryFoldouts.Length; i <= index; i++)
                {
                    list.Add(new FoldoutInfo());
                }
                categoryFoldouts = list.ToArray();
            }
            return categoryFoldouts[index];
        }

        public FieldSelectionDictionary GetFieldSelections(Category category)
        {
            return GetCategoryFoldout(category).fieldSelections;
        }

        public void OnBeforeSerialize()
        {
            databaseInstanceIDs.Clear();
            for (int i = 0; i < m_databases.Count; i++)
            {
                var database = m_databases[i];
                databaseInstanceIDs.Add((database == null) ? 0 : database.GetInstanceID());
            }
        }

        public void OnAfterDeserialize() { }

        public void AssignDatabasesFromInstanceIDs()
        {
            m_databases.Clear();
            for (int i = 0; i < databaseInstanceIDs.Count; i++)
            {
                m_databases.Add(EditorUtility.InstanceIDToObject(databaseInstanceIDs[i]) as DialogueDatabase);
            }
        }
    }

}
