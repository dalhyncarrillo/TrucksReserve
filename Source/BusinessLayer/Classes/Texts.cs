// Trucks reserve (https://github.com/raste/TrucksReserve)(http://tr.wiadvice.com/)
// Copyright (c) 2015 Georgi Kolev. 
// Licensed under Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0).

using System.Collections.Generic;
using System.Linq;

using DataLayer;
using BusinessLayer.BObjects;
using BusinessLayer.Instruments;
using ToolsLibrary;

namespace BusinessLayer.Classes
{
    public class Texts
    {
        internal static void GetTexts(TrucksReserveEntities trModel, ref List<BBaseText> texts, ref BText selectedText, int? selectedTextId)
        {
            trModel.ExcIfNull();

            texts = new List<BBaseText>();
            selectedText = null;

            List<Text> bTexts = trModel.Texts.Where(t => t.Deleted == false).ToList();
            if (bTexts.AreThereItems() == true)
            {
                foreach (Text text in bTexts)
                {
                    if (selectedTextId.HasValue == true && text.ID == selectedTextId.Value)
                    {
                        selectedText = new BText(text);
                        texts.Add(selectedText);
                    }
                    else
                    {
                        texts.Add(new BBaseText(text));
                    }
                }
            }
        }

        internal static BText GetText(TrucksReserveEntities trModel, TextType type, bool onlyWithFilledDescription = false, bool excIfNull = true)
        {
            trModel.ExcIfNull();

            Text dbText = trModel.Texts.FirstOrDefault(t => t.Type == (int)type && t.Deleted == false
                && (onlyWithFilledDescription == false || string.IsNullOrEmpty(t.Description) == false));

            BText text = null;
            if (dbText == null)
            {
                if (excIfNull == true) { dbText.ExcIfNull(); }
            }
            else
            {
                text = new BText(dbText);
            }

            return text;
        }

        internal static List<BText> GetTextsForPage(TrucksReserveEntities trModel, LoadedPage page)
        {
            trModel.ExcIfNull();

            List<BText> texts = new List<BText>();

            switch (page)
            {
                case LoadedPage.Promotions:
                    BText promText = GetText(trModel, TextType.Promotions, onlyWithFilledDescription: true, excIfNull: false);
                    if (promText != null)
                    {
                        texts.Add(promText);
                    }
                    break;
                default:
                    BTools.NewBException(string.Format("За страница {0} не се поддържа вземането на текстове за показване.", page));
                    break;
            }

            return texts;
        }

        public static void UpdateText(int textId, string newDescription)
        {
            newDescription = newDescription.GetTrimmed();

            using (TrucksReserveEntities trModel = new TrucksReserveEntities())
            {
                Text text = trModel.Texts.FirstOrDefault(t => t.ID == textId);
                text.ExcIfNull();

                if (text.Description != newDescription)
                {
                    text.Description = newDescription;
                    trModel.SaveChanges();
                }
            }

        }



    }
}
