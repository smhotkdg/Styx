// Copyright © Pixel Crushers. All rights reserved.

using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.Collections.Generic;
using System;

namespace PixelCrushers.DialogueSystem.I2Support
{

    /// <summary>
    /// Editor window to copy fields between a Dialogue System dialogue database
    /// and/or localized text table and I2 Localization.
    /// </summary>
    public class DSToI2Window : EditorWindow
    {

        #region Menu Item

        [MenuItem("Tools/Pixel Crushers/Dialogue System/Third Party/I2 Localization/DS To I2", false)]
        public static void ShowWindow()
        {
            GetWindow<DSToI2Window>(false, "DS To I2").minSize = new Vector2(340, 160);
        }

        #endregion

        #region Fields & Properties

        private const string DSI2Category = "Dialogue System/";

        private const string DSToI2PrefsKey = "PixelCrushers.DialogueSystem.DSToI2Prefs";

        [SerializeField]
        private DSToI2Prefs m_prefs = new DSToI2Prefs();
        private DSToI2Prefs prefs
        {
            get { return m_prefs; }
            set { m_prefs = value; }
        }

        [SerializeField]
        private Vector2 m_scrollPosition = Vector2.zero;
        private Vector2 scrollPosition
        {
            get { return m_scrollPosition; }
            set { m_scrollPosition = value; }
        }

        private ReorderableList m_databaseList;

        #endregion

        #region Initialization

        private void OnEnable()
        {
            LoadPrefs();
            InitDatabasesReorderableList();
        }

        private void OnDisable()
        {
            SavePrefs();
        }

        private void LoadPrefs()
        {
            if (EditorPrefs.HasKey(DSToI2PrefsKey))
            {
                prefs = JsonUtility.FromJson<DSToI2Prefs>(EditorPrefs.GetString(DSToI2PrefsKey));
                prefs.AssignDatabasesFromInstanceIDs();
            }
        }

        private void SavePrefs()
        {
            EditorPrefs.SetString(DSToI2PrefsKey, JsonUtility.ToJson(prefs));
        }

        #endregion

        #region GUI

        private void OnGUI()
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            DrawDatabaseList();
            prefs.textTable = EditorGUILayout.ObjectField(new GUIContent("Text Table", "Optional Text Table to localize."), prefs.textTable, typeof(TextTable), false) as TextTable;
            prefs.localizedTextTable = EditorGUILayout.ObjectField(new GUIContent("Localized Text Table", "Optional legacy Localized Text Table to localize."), prefs.localizedTextTable, typeof(LocalizedTextTable), false) as LocalizedTextTable;
            EditorGUILayout.EndHorizontal();

            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);
            try
            {
                // Database foldouts:
                EditorGUI.BeginDisabledGroup(prefs.GetNumDatabases() == 0);
                for (int i = 0; i < DSToI2Prefs.NumDatabaseCategories; i++)
                {
                    DrawFoldout((DSToI2Prefs.Category)i, prefs.categoryFoldouts[i]);
                }
                EditorGUI.EndDisabledGroup();

                // Text table foldouts:
                EditorGUI.BeginDisabledGroup(prefs.textTable == null);
                DrawFoldout(DSToI2Prefs.Category.TextTable, prefs.GetCategoryFoldout(DSToI2Prefs.Category.TextTable));
                EditorGUI.EndDisabledGroup();

                // Localized text table foldouts:
                EditorGUI.BeginDisabledGroup(prefs.localizedTextTable == null);
                DrawFoldout(DSToI2Prefs.Category.LocalizedTextTable, prefs.GetCategoryFoldout(DSToI2Prefs.Category.LocalizedTextTable));
                EditorGUI.EndDisabledGroup();
            }
            finally
            {
                EditorGUILayout.EndScrollView();
            }

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            prefs.assetIdentifier = (DSToI2Prefs.AssetIdentifierType)EditorGUILayout.EnumPopup(new GUIContent("Assets Use", "Name localized fields using asset ID number or Name/Title."), prefs.assetIdentifier);
            prefs.languageIdentifier = (I2LanguageIdentifierType)EditorGUILayout.EnumPopup(new GUIContent("Fields Use", "Name localized fields using language code or language name."), prefs.languageIdentifier);
            prefs.dialogueEntryInfo = (DSToI2Prefs.DialogueEntryInfo)EditorGUILayout.EnumPopup(new GUIContent("Extra Entry Info", "Add this extra info to dialogue entry terms."), prefs.dialogueEntryInfo);
            prefs.dialogueEntryMinDigits = EditorGUILayout.IntField(new GUIContent("Entry Min Digits", "Pad entry IDs with zeroes to at least this many digits. Improves sorting on dialogue entry terms."), prefs.dialogueEntryMinDigits);
            prefs.verbose = (DSToI2Prefs.Verbose)EditorGUILayout.EnumPopup(new GUIContent("Verbose", "Amount of detail to log to Console window."), prefs.verbose);
            prefs.showHelp = EditorGUILayout.Toggle("Show Help", prefs.showHelp);
            if (prefs.showHelp)
            {
                EditorGUILayout.HelpBox("1. Assign dialogue database and/or text table(s).\n" +
                    "2. Expand foldouts. Tick fields you want to localize.\n" +
                    "3. Click To I2.\n" +
                    "4. Translate in I2 (eg, Languages tab, click Translate).\n" +
                    "5. Click From I2.", MessageType.None);
            }
            EditorGUI.BeginDisabledGroup(prefs.GetNumDatabases() == 0 && prefs.localizedTextTable == null);
            GUILayout.BeginHorizontal();
            if (GUILayout.Button(new GUIContent("Refresh", "Refresh list of fields. Click this if you added new fields to your dialogue database.")))
            {
                prefs.PopulateAllDatabaseFields();
                prefs.PopulateTextTableFields();
                prefs.PopulateLocalizedTextTableFields();
            }
            if (GUILayout.Button(new GUIContent("Clear I2", "Remove Dialogue System fields from I2Languages prefab.")))
            {
                if (EditorUtility.DisplayDialog("Clear I2", "Clear all Dialogue System fields from the I2Languages prefab?", "OK", "Cancel"))
                {
                    ClearI2();
                }
            }
            if (GUILayout.Button(new GUIContent("To I2", "Add ticked fields to I2Languages prefab.")))
            {
                CopyToI2();
            }
            if (GUILayout.Button(new GUIContent("Inspect I2", "Add ticked fields to I2Languages prefab.")))
            {
                InspectI2();
            }
            if (GUILayout.Button(new GUIContent("From I2", "Update fields with the values in I2Languages prefab.")))
            {
                RetrieveFromI2();
            }
            //// Will enable when I2 adds support:
            //if (GUILayout.Button(new GUIContent("Translate All", "Add fields to I2Languages, tell I2 to translate using Google Translate, and update fields from I2Languages.")))
            //{
            //    TranslateAll();
            //}
            GUILayout.EndHorizontal();
            EditorGUI.EndDisabledGroup();
            EditorGUILayout.EndVertical();
        }

        private void InitDatabasesReorderableList()
        {
            m_databaseList = new ReorderableList(prefs.databases, typeof(DialogueDatabase), true, true, true, true);
            m_databaseList.drawHeaderCallback += OnDrawDatabasesListHeader;
            m_databaseList.drawElementCallback += OnDrawDatabasesListElement;
            m_databaseList.onAddCallback += OnAddDatabasesList;
        }

        private void DrawDatabaseList()
        {
            EditorGUI.BeginChangeCheck();
            m_databaseList.DoLayoutList();
            if (EditorGUI.EndChangeCheck())
            {
                prefs.PopulateAllDatabaseFields();
            }
        }

        private void OnDrawDatabasesListHeader(Rect rect)
        {
            EditorGUI.LabelField(rect, "Databases");
        }

        private void OnDrawDatabasesListElement(Rect rect, int index, bool isActive, bool isFocused)
        {
            if (!(0 <= index && index < prefs.databases.Count)) return;
            prefs.databases[index] = EditorGUI.ObjectField(new Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight),
                GUIContent.none,  prefs.databases[index], typeof(DialogueDatabase), false) as DialogueDatabase;
        }

        private void OnAddDatabasesList(ReorderableList list)
        {
            prefs.databases.Add(null);
        }

        private void DrawFoldout(DSToI2Prefs.Category category, FoldoutInfo foldoutInfo)
        {
            var label = (category == DSToI2Prefs.Category.Items) ? "Items/Quests" : category.ToString();
            foldoutInfo.foldout = EditorGUILayout.Foldout(foldoutInfo.foldout, label);
            if (foldoutInfo.foldout)
            {
                EditorGUI.indentLevel++;

                // All/None buttons:
                EditorGUILayout.BeginHorizontal();
                GUILayout.Label(string.Empty, GUILayout.Width(12));
                if (GUILayout.Button("All", GUILayout.Width(64)))
                {
                    foldoutInfo.fieldSelections.SetAllSelections(true);
                }
                if (GUILayout.Button("None", GUILayout.Width(64)))
                {
                    foldoutInfo.fieldSelections.SetAllSelections(false);
                }
                EditorGUILayout.EndHorizontal();

                // All fields:
                var titles = foldoutInfo.fieldSelections.titles;
                var includes = foldoutInfo.fieldSelections.includes;
                for (int i = 0; i < titles.Count; i++)
                {
                    includes[i] = EditorGUILayout.ToggleLeft(titles[i], includes[i]);
                }
                EditorGUI.indentLevel--;
            }
        }

        private void InspectI2()
        {
            var languageSource = FindObjectOfType<I2.Loc.LanguageSource>();
            if (languageSource != null)
            {
                Selection.activeObject = languageSource;
            }
            else
            {
                var languageSourceAsset = Resources.Load("I2Languages");
                if (languageSourceAsset != null)
                {
                    Selection.activeObject = languageSourceAsset;
                }
                else
                {
                    Debug.LogWarning("Can't find I2Languages.");
                }
            }
        }

        #endregion

        #region To I2

        private void CopyToI2()
        {
            foreach (var database in prefs.databases)
            {
                CopyDatabaseToI2(database);
            }

            // Text table:
            if (prefs.textTable != null)
            {
                try
                {
                    EditorUtility.DisplayProgressBar("Copying to I2", "Copying text table fields...", 1);
                    AddTextTableFields();
                }
                finally
                {
                    EditorUtility.ClearProgressBar();
                }
            }

            // Localized text table:
            if (prefs.localizedTextTable != null)
            {
                try
                {
                    EditorUtility.DisplayProgressBar("Copying to I2", "Copying localized text table fields...", 1);
                    AddLocalizedTextTableFields();
                }
                finally
                {
                    EditorUtility.ClearProgressBar();
                }
            }

            SaveI2();
            RepaintI2();
        }

        private void CopyDatabaseToI2(DialogueDatabase database)
        {
            // Dialogue database:
            if (database == null) return;
            try
            {
                var total = 4 + database.conversations.Count;
                EditorUtility.DisplayProgressBar("Copying to I2", "Copying actor fields...", (1 / total));
                foreach (var actor in database.actors)
                {
                    AddFields("Actor/" + GetAssetIdentifier(actor.id, actor.Name), actor.fields, prefs.GetFieldSelections(DSToI2Prefs.Category.Actors));
                }
                EditorUtility.DisplayProgressBar("Copying to I2", "Copying item/quest fields...", (2 / total));
                foreach (var item in database.items)
                {
                    AddFields("Item-Quest/" + GetAssetIdentifier(item.id, item.Name), item.fields, prefs.GetFieldSelections(DSToI2Prefs.Category.Items));
                }
                EditorUtility.DisplayProgressBar("Copying to I2", "Copying location fields...", (3 / total));
                foreach (var location in database.locations)
                {
                    AddFields("Location/" + GetAssetIdentifier(location.id, location.Name), location.fields, prefs.GetFieldSelections(DSToI2Prefs.Category.Locations));
                }
                EditorUtility.DisplayProgressBar("Copying to I2", "Copying variable fields...", (4 / total));
                foreach (var variable in database.variables)
                {
                    AddFields("Variable/" + GetAssetIdentifier(variable.id, variable.Name), variable.fields, prefs.GetFieldSelections(DSToI2Prefs.Category.Variables));
                }
                float current = 4;
                foreach (var conversation in database.conversations)
                {
                    current += 1;
                    EditorUtility.DisplayProgressBar("Copying to I2", "Copying conversation '" + conversation.Title + "'.", (current / total));
                    AddFields("Conversation/" + GetAssetIdentifier(conversation.id, conversation.Title), conversation.fields, prefs.GetFieldSelections(DSToI2Prefs.Category.Conversations));
                    var sanitizedConversationTitle = SanitizeSlash(conversation.Title);
                    foreach (var entry in conversation.dialogueEntries)
                    {
                        var extraInfo = string.Empty;
                        switch (prefs.dialogueEntryInfo)
                        {
                            case DSToI2Prefs.DialogueEntryInfo.Actor:
                                var actor = database.GetActor(entry.ActorID);
                                extraInfo = "/" + ((actor != null) ? actor.Name : string.Empty);
                                break;
                            case DSToI2Prefs.DialogueEntryInfo.Text:
                                extraInfo = "/" + entry.DialogueText;
                                break;
                        }
                        AddFields(GetDialogueEntryHeader(sanitizedConversationTitle, conversation.id, entry.id, extraInfo), entry.fields, prefs.GetFieldSelections(DSToI2Prefs.Category.DialogueEntries));
                    }
                }
            }
            finally
            {
                EditorUtility.ClearProgressBar();
            }
        }

        private string GetAssetIdentifier(int assetID, string assetName)
        {
            return (prefs.assetIdentifier == DSToI2Prefs.AssetIdentifierType.ID) ? assetID.ToString() : SanitizeSlash(assetName);
        }

        private string GetDialogueEntryHeader(string sanitizedConversationTitle, int conversationID, int entryID, string extraInfo)
        {
            var conversationPart = (prefs.assetIdentifier == DSToI2Prefs.AssetIdentifierType.ID)
                ? conversationID.ToString("D" + prefs.dialogueEntryMinDigits)
                : sanitizedConversationTitle;
            return "Conversation/" + conversationPart +
                "/Entry/" + entryID.ToString("D" + prefs.dialogueEntryMinDigits) + extraInfo;
        }

        private void AddTextTableFields()
        {
            var fieldSelections = prefs.GetFieldSelections(DSToI2Prefs.Category.TextTable);
            foreach (var kvp in prefs.textTable.fields)
            {
                var fieldID = kvp.Key;
                var field = kvp.Value;
                if (!(fieldSelections.ShouldInclude(field.fieldName))) continue;
                var value = (field.texts.Count > 0 && !string.IsNullOrEmpty(field.texts[0])) ? field.texts[0] : field.fieldName;
                AddField("TextTable", SanitizeSlash(field.fieldName), value, fieldSelections);
            }
        }

        private void AddLocalizedTextTableFields()
        {
            var fieldSelections = prefs.GetFieldSelections(DSToI2Prefs.Category.LocalizedTextTable);
            for (int i = 0; i < prefs.localizedTextTable.fields.Count; i++)
            {
                var field = prefs.localizedTextTable.fields[i];
                if (!(fieldSelections.ShouldInclude(field.name))) continue;
                var value = (field.values.Count > 0 && !string.IsNullOrEmpty(field.values[0])) ? field.values[0] : field.name;
                AddField("LocalizedTextTable", SanitizeSlash(field.name), value, fieldSelections);
            }
        }

        private void AddFields(string header, List<Field> fields, FieldSelectionDictionary fieldSelections)
        {
            for (int i = 0; i < fields.Count; i++)
            {
                var field = fields[i];
                if (field.type == FieldType.Text)
                {
                    if (!(fieldSelections.ShouldInclude(field.title))) continue;
                    AddField(header, SanitizeSlash(field.title), field.value, fieldSelections);
                }
            }
        }

        private void AddField(string header, string title, string value, FieldSelectionDictionary fieldSelections)
        {
            if (string.IsNullOrEmpty(value)) return;
            var term = DSI2Category + header + "/" + title;
            term = I2.Loc.I2Utils.RemoveNonASCII(term, true);
            if (prefs.showDetails) Debug.Log("Dialogue System: Adding term " + term);
            foreach (var source in I2.Loc.LocalizationManager.Sources)
            {
                var termData = source.AddTerm(term, I2.Loc.eTermType.Text, false);
                if (termData.Languages.Length > 0) termData.Languages[0] = value;
            }
        }

        private void ClearI2()
        {
            try
            {
                EditorUtility.DisplayProgressBar("Clearing I2", "Clearing Dialogue System fields from I2Languages.", 0.01f);
                var terms = I2.Loc.LocalizationManager.GetTermsList();
                float numTerms = terms.Count;
                for (int i = 0; i < terms.Count; i++)
                {
                    var term = terms[i];
                    if (term.StartsWith(DSI2Category))
                    {
                        if (EditorUtility.DisplayCancelableProgressBar("Clearing I2", term, (float)i / numTerms)) break;
                        if (prefs.showDetails) Debug.Log("Dialogue System: Removing term " + term);
                        I2.Loc.LocalizationManager.Sources.ForEach(source => source.RemoveTerm(term));
                    }
                }
            }
            finally
            {
                EditorUtility.ClearProgressBar();
            }
            SaveI2();
            RepaintI2();
        }

        private void SaveI2()
        {
            I2.Loc.LocalizationManager.Sources.ForEach(source => EditorUtility.SetDirty(source.ownerObject));
            AssetDatabase.SaveAssets();
        }

        #endregion

        #region RetrieveFromI2

        private void RetrieveFromI2()
        {
            foreach (var database in prefs.databases)
            {
                RetrieveDatabaseFromI2(database);
            }

            // Text table:
            if (prefs.textTable != null)
            {
                try
                {
                    EditorUtility.DisplayProgressBar("Retrieving from I2", "Retrieving text table fields...", 1);
                    RetrieveTextTableFields();
                }
                finally
                {
                    EditorUtility.ClearProgressBar();
                }
            }

            // Localized text table:
            if (prefs.localizedTextTable != null)
            {
                try
                {
                    EditorUtility.DisplayProgressBar("Retrieving from I2", "Retrieving localized text table fields...", 1);
                    RetrieveLocalizedTextTableFields();
                }
                finally
                {
                    EditorUtility.ClearProgressBar();
                }
            }

            RepaintDialogueSystem();
        }

        private void RetrieveDatabaseFromI2(DialogueDatabase database)
        {
            if (database == null) return;
            try
            {
                var total = 4 + database.conversations.Count;
                EditorUtility.DisplayProgressBar("Retrieving from I2", "Retrieving actor fields...", (1 / total));
                foreach (var actor in database.actors)
                {
                    RetrieveFields("Actor/" + GetAssetIdentifier(actor.id, actor.Name), actor.fields, prefs.GetFieldSelections(DSToI2Prefs.Category.Actors));
                }
                EditorUtility.DisplayProgressBar("Retrieving from I2", "Retrieving item/quest fields...", (2 / total));
                foreach (var item in database.items)
                {
                    RetrieveFields("Item-Quest/" + GetAssetIdentifier(item.id, item.Name), item.fields, prefs.GetFieldSelections(DSToI2Prefs.Category.Items));
                }
                EditorUtility.DisplayProgressBar("Retrieving from I2", "Retrieving location fields...", (3 / total));
                foreach (var location in database.locations)
                {
                    RetrieveFields("Location/" + GetAssetIdentifier(location.id, location.Name), location.fields, prefs.GetFieldSelections(DSToI2Prefs.Category.Locations));
                }
                EditorUtility.DisplayProgressBar("Retrieving from I2", "Retrieving variable fields...", (4 / total));
                foreach (var variable in database.variables)
                {
                    RetrieveFields("Variable/" + GetAssetIdentifier(variable.id, variable.Name), variable.fields, prefs.GetFieldSelections(DSToI2Prefs.Category.Variables));
                }
                float current = 4;
                foreach (var conversation in database.conversations)
                {
                    current += 1;
                    EditorUtility.DisplayProgressBar("Retrieving from I2", "Retrieving conversation '" + conversation.Title + "'.", (current / total));
                    RetrieveFields("Conversation/" + GetAssetIdentifier(conversation.id, conversation.Title), conversation.fields, prefs.GetFieldSelections(DSToI2Prefs.Category.Conversations));
                    var sanitizedConversationTitle = SanitizeSlash(conversation.Title);
                    foreach (var entry in conversation.dialogueEntries)
                    {
                        var extraInfo = string.Empty;
                        switch (prefs.dialogueEntryInfo)
                        {
                            case DSToI2Prefs.DialogueEntryInfo.Actor:
                                var actor = database.GetActor(entry.ActorID);
                                extraInfo = "/" + ((actor != null) ? actor.Name : string.Empty);
                                break;
                            case DSToI2Prefs.DialogueEntryInfo.Text:
                                extraInfo = "/" + entry.DialogueText;
                                break;
                        }
                        RetrieveFields(GetDialogueEntryHeader(sanitizedConversationTitle, conversation.id, entry.id, extraInfo), entry.fields, prefs.GetFieldSelections(DSToI2Prefs.Category.DialogueEntries));
                    }
                }
            }
            finally
            {
                EditorUtility.ClearProgressBar();
            }
        }

        private void RetrieveFields(string header, List<Field> fields, FieldSelectionDictionary fieldSelections)
        {
            var languages = I2.Loc.LocalizationManager.GetAllLanguages();
            var languageCodes = I2.Loc.LocalizationManager.GetAllLanguagesCode();
            for (int i = 0; i < fields.Count; i++)
            {
                var field = fields[i];
                if (field.type == FieldType.Text)
                {
                    if (!(fieldSelections.ShouldInclude(field.title))) continue;
                    if (string.IsNullOrEmpty(field.value)) continue;
                    var sanitizedTitle = SanitizeSlash(field.title);
                    var term = DSI2Category + header + "/" + sanitizedTitle;
                    term = I2.Loc.I2Utils.RemoveNonASCII(term, true);
                    var data = I2.Loc.LocalizationManager.GetTermData(term);
                    if (data == null)
                    {
                        if (prefs.showWarnings) Debug.LogWarning("Dialogue System: I2Languages doesn't contain data for " + term);
                        continue;
                    }
                    var count = (prefs.languageIdentifier == I2LanguageIdentifierType.LanguageCode) ? languageCodes.Count : languages.Count;
                    for (int j = 0; j < count; j++)
                    {
                        var languageForLocalizedFieldTitle = (prefs.languageIdentifier == I2LanguageIdentifierType.LanguageCode) ? languageCodes[j] : languages[j];
                        var locTitle = string.Equals(sanitizedTitle, "Dialogue Text") ? languageForLocalizedFieldTitle : (sanitizedTitle + " " + languageForLocalizedFieldTitle);
                        var locField = Field.Lookup(fields, locTitle);
                        if (locField == null)
                        {
                            locField = new Field(locTitle, string.Empty, FieldType.Localization);
                            fields.Add(locField);
                        }
                        locField.value = ReplaceNewlineCodes(data.Languages[j]);
                        if (prefs.showDetails) Debug.Log("Dialogue System: " + header + " " + locTitle + " = " + data.Languages[j]);
                    }
                }
            }
        }

        private void RetrieveTextTableFields()
        {
            var languages = I2.Loc.LocalizationManager.GetAllLanguages();
            var languageCodes = I2.Loc.LocalizationManager.GetAllLanguagesCode();

            // Set up text table's languages:
            prefs.textTable.languages.Clear();
            prefs.textTable.languages.Add("Default", 0);
            var count = (prefs.languageIdentifier == I2LanguageIdentifierType.LanguageCode) ? languageCodes.Count : languages.Count;
            for (int i = 0; i < count; i++)
            {
                //prefs.textTable.languages.Add(languages[i], i + 1);
                var languageForTextTable = (prefs.languageIdentifier == I2LanguageIdentifierType.LanguageCode) ? languageCodes[i] : languages[i];
                prefs.textTable.languages.Add(languageForTextTable, i + 1);
            }

            // Retrieve field values:
            var fieldSelections = prefs.GetFieldSelections(DSToI2Prefs.Category.TextTable);
            foreach (var kvp in prefs.textTable.fields)
            {
                var fieldID = kvp.Key;
                var field = kvp.Value;
                if (!(fieldSelections.ShouldInclude(field.fieldName))) continue;
                if (string.IsNullOrEmpty(field.fieldName)) continue;
                if (field.texts.Count == 0)
                {
                    field.texts.Add(0, field.fieldName); // Default.
                }
                var term = DSI2Category + "TextTable/" + SanitizeSlash(field.fieldName);
                term = I2.Loc.I2Utils.RemoveNonASCII(term, true);
                var data = I2.Loc.LocalizationManager.GetTermData(term);
                if (data == null)
                {
                    if (prefs.showWarnings) Debug.LogWarning("Dialogue System: I2Languages doesn't contain data for " + term);
                    continue;
                }
                for (int j = 0; j < count; j++)
                {
                    var languageforFieldName = (prefs.languageIdentifier == I2LanguageIdentifierType.LanguageCode) ? languageCodes[j] : languages[j];
                    var valueIndex = j + 1;
                    if (valueIndex >= field.texts.Count) field.texts.Add(j + 1, string.Empty);
                    field.texts[valueIndex] = ReplaceNewlineCodes(data.Languages[j]);
                    if (prefs.showDetails) Debug.Log("Dialogue System: " + term + " " + languageforFieldName + " = " + data.Languages[j]);
                }
            }

            if (TextTableEditorWindow.instance != null)
            {
                Selection.activeObject = prefs.textTable;
            }
        }

        private void RetrieveLocalizedTextTableFields()
        {
            var languages = I2.Loc.LocalizationManager.GetAllLanguages(); //.Sources[0].GetLanguages();
            var languageCodes = I2.Loc.LocalizationManager.GetAllLanguagesCode(); //.Sources[0].GetLanguagesCode();

            // Set up localized text table's languages:
            prefs.localizedTextTable.languages.Clear();
            prefs.localizedTextTable.languages.Add("Default");
            var count = (prefs.languageIdentifier == I2LanguageIdentifierType.LanguageCode) ? languageCodes.Count : languages.Count;
            for (int i = 0; i < count; i++)
            {
                prefs.localizedTextTable.languages.Add(languages[i]);
            }

            // Retrieve field values:
            var fieldSelections = prefs.GetFieldSelections(DSToI2Prefs.Category.LocalizedTextTable);
            for (int i = 0; i < prefs.localizedTextTable.fields.Count; i++)
            {
                var field = prefs.localizedTextTable.fields[i];
                if (!(fieldSelections.ShouldInclude(field.name))) continue;
                if (string.IsNullOrEmpty(field.name)) continue;
                if (field.values.Count == 0)
                {
                    field.values.Add(field.name);
                }
                var term = DSI2Category + "LocalizedTextTable/" + SanitizeSlash(field.name);
                term = I2.Loc.I2Utils.RemoveNonASCII(term, true);
                var data = I2.Loc.LocalizationManager.GetTermData(term);
                if (data == null)
                {
                    if (prefs.showWarnings) Debug.LogWarning("Dialogue System: I2Languages doesn't contain data for " + term);
                    continue;
                }
                for (int j = 0; j < count; j++)
                {
                    var languageForLocalizedFieldTitle = (prefs.languageIdentifier == I2LanguageIdentifierType.LanguageCode) ? languageCodes[j] : languages[j];
                    var valueIndex = j + 1;
                    if (valueIndex >= field.values.Count) field.values.Add(string.Empty);
                    field.values[valueIndex] = ReplaceNewlineCodes(data.Languages[j]);
                    if (prefs.showDetails) Debug.Log("Dialogue System: " + term + " " + languageForLocalizedFieldTitle + " = " + data.Languages[j]);
                }
            }
        }

        private string ReplaceNewlineCodes(string s)
        {
            return string.IsNullOrEmpty(s) ? s : s.Replace("\\n", "\n");
        }

        //private string ReplaceForwardSlashes(string s)
        //{
        //    return s.Replace("/", "%2F").Replace("[%2Fi2nt]", "[/i2nt]");
        //}

        private string SanitizeSlash(string s)
        {
            return string.IsNullOrEmpty(s) ? s : s.Replace("/", ".");
        }

        #endregion

        #region Translate All

        //// Will add when supported.
        //private void TranslateAll()
        //{
        //    if (!I2.Loc.GoogleTranslation.CanTranslate())
        //    {
        //        EditorUtility.DisplayDialog("Google Translate Error", "I2's WebService is not set correctly or needs to be reinstalled. Please correct this and then click Translate All again.", "OK");
        //        return;
        //    }
        //    var languages = I2.Loc.LocalizationManager.Sources[0].GetLanguages();
        //    for (int i = 0; i < languages.Count; i++)
        //    {
        //        var language = languages[i];
        //        typeof(I2.Loc.LocalizationEditor).GetMethod("TranslateAllToLanguage",
        //                    System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic).
        //                    Invoke(obj: null, parameters: new object[] { language });
        //    }
        //}

        #endregion

        #region Repaints

        private void RepaintI2()
        {
            typeof(I2.Loc.LocalizationEditor).GetMethod("ParseTerms",
                System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic).
                Invoke(obj: null, parameters: new object[] { true, false, false });
        }

        private void RepaintDialogueSystem()
        {
            RepaintDialogueEditorWindow();
            RepaintEditor<LocalizedTextTableEditor>();
        }

        private void RepaintDialogueEditorWindow()
        {
            var instance = DialogueEditor.DialogueEditorWindow.instance;
            if (instance != null) instance.Repaint();
        }

        private void RepaintEditor<T>() where T : Editor
        {
            var editors = Resources.FindObjectsOfTypeAll<T>();
            for (int i = 0; i < editors.Length; i++)
            {
                editors[i].Repaint();
            }
        }

        #endregion

    }
}
