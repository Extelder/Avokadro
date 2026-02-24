#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.IO;

public static class CardDatabaseGenerator
{
    private const string RootPath = "Assets/Data/Cards";
    private const string SpritesPath = "Assets/Sprites/Deck";

    [MenuItem("Tools/Generate Cards With Sprites")]
    public static void GenerateAllCards()
    {
        if (!AssetDatabase.IsValidFolder("Assets/Data"))
            AssetDatabase.CreateFolder("Assets", "Data");

        if (!AssetDatabase.IsValidFolder(RootPath))
            AssetDatabase.CreateFolder("Assets/Data", "Cards");

        foreach (Suit suit in System.Enum.GetValues(typeof(Suit)))
        {
            string suitFolderPath = $"{RootPath}/{suit}";
            string suitSpriteFolder = $"{SpritesPath}/{suit}";

            if (!AssetDatabase.IsValidFolder(suitFolderPath))
                AssetDatabase.CreateFolder(RootPath, suit.ToString());

            foreach (Rank rank in System.Enum.GetValues(typeof(Rank)))
            {
                string cardName = $"{rank}_of_{suit}";
                string assetPath = $"{suitFolderPath}/{cardName}.asset";

                if (File.Exists(assetPath))
                    continue;

                CardData card = ScriptableObject.CreateInstance<CardData>();

                SerializedObject so = new SerializedObject(card);

                so.FindProperty("<Suit>k__BackingField").enumValueIndex = (int)suit;
                so.FindProperty("<Rank>k__BackingField").enumValueIndex = (int)rank;

                // ---------- LOAD SPRITE ----------
                string spriteName = GetSpriteName(rank);
                string spritePath = $"{suitSpriteFolder}/{spriteName}.png";

                Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(spritePath);

                if (sprite == null)
                {
                    Debug.LogWarning($"Sprite not found: {spritePath}");
                }
                else
                {
                    so.FindProperty("<Icon>k__BackingField").objectReferenceValue = sprite;
                }

                so.ApplyModifiedProperties();

                AssetDatabase.CreateAsset(card, assetPath);
            }
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log("All cards generated with sprites!");
    }

    private static string GetSpriteName(Rank rank)
    {
        switch (rank)
        {
            case Rank.A: return "ace";
            case Rank.J: return "jack";
            case Rank.Q: return "queen";
            case Rank.K: return "king";
            default: return ((int)rank+2).ToString();
        }
    }
}
#endif