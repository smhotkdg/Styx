// Copyright © Pixel Crushers. All rights reserved.

using UnityEngine;

namespace PixelCrushers.DialogueSystem.I2Support
{

    /// <summary>
    /// Sets the Dialogue System's language to match I2 Localization's language. 
    /// Add to the Dialogue Manager.
    /// </summary>
    [AddComponentMenu("Pixel Crushers/Dialogue System/Third Party/I2 Localization Support/Dialogue System Use I2 Language")]
    public class DialogueSystemUseI2Language : MonoBehaviour
    {

        [Tooltip("Specifies whether fields in the Dialogue System are named by language code or language name.")]
        public I2LanguageIdentifierType specifyLanguageBy = I2LanguageIdentifierType.LanguageCode;

        [Tooltip("On start, set the Dialogue System's current language to match I2 Localization's current language.")]
        public bool useI2LanguageOnStart = true;

        [Tooltip("")]
        public bool useI2LanguageAtRuntime = false;

        void Start()
        {
            UseCurrentI2Language();
        }

        /// <summary>
        /// Updates the Dialogue System's current language setting to match i2.
        /// </summary>
        public void UseCurrentI2Language()
        {
            var language = (specifyLanguageBy == I2LanguageIdentifierType.LanguageCode) ? I2.Loc.LocalizationManager.CurrentLanguageCode : I2.Loc.LocalizationManager.CurrentLanguage;
            DialogueManager.SetLanguage(language);
        }

        /// <summary>
        /// If useI2LanguageAtRuntime is true, replaces the subtitle's formatted text with
        /// its i2 runtime translation.
        /// </summary>
        protected void OnConversationLine(Subtitle subtitle)
        {
            if (!useI2LanguageAtRuntime || subtitle == null) return;
            var entry = subtitle.dialogueEntry;
            var term = "Dialogue System/Conversation/" + entry.conversationID + "/Entry/" + entry.id;
            if (!string.IsNullOrEmpty(entry.DialogueText))
            {
                term += "/Dialogue Text";
            }
            else if (!string.IsNullOrEmpty(entry.MenuText))
            {
                term += "/Menu Text";
            }
            else
            {
                return;
            }
            term = I2.Loc.I2Utils.RemoveNonASCII(term, true);
            var translation = I2.Loc.LocalizationManager.GetTermTranslation(term, true, 0, true, false, null, I2.Loc.LocalizationManager.CurrentLanguage);
            if (!(string.IsNullOrEmpty(translation) || string.Equals(translation, "Null")))
            {
                subtitle.formattedText = FormattedText.Parse(translation);
            }
        }

        /// <summary>
        /// If useI2LanguageAtRuntime is true, replaces the responses' formatted text with
        /// their i2 runtime translations.
        /// </summary>
        protected void OnConversationResponseMenu(Response[] responses)
        {
            if (!useI2LanguageAtRuntime || responses == null) return;
            for (int i = 0; i < responses.Length; i++)
            {
                var response = responses[i];
                var entry = response.destinationEntry;
                var term = "Dialogue System/Conversation/" + entry.conversationID + "/Entry/" + entry.id;
                if (!string.IsNullOrEmpty(entry.MenuText))
                {
                    term += "/Menu Text";
                }
                else if (!string.IsNullOrEmpty(entry.DialogueText))
                {
                    term += "/Dialogue Text";
                }
                else
                {
                    continue;
                }
                term = I2.Loc.I2Utils.RemoveNonASCII(term, true);
                var translation = I2.Loc.LocalizationManager.GetTermTranslation(term, true, 0, true, false, null, I2.Loc.LocalizationManager.CurrentLanguage);
                if (!(string.IsNullOrEmpty(translation) || string.Equals(translation, "Null")))
                {
                    response.formattedText = FormattedText.Parse(translation);
                }
            }
        }
    }
}