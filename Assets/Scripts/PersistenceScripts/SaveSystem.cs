using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public static class SaveSystem
{
    public static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/";
    public static void Init()
    {
        if (!Directory.Exists(SAVE_FOLDER))
        {
            Debug.Log("NO HAY DIRECTORIO DUMMY");
            Directory.CreateDirectory(SAVE_FOLDER);
        };
    }
    public static void Save(string stringtosave)
    {
        File.WriteAllText(SAVE_FOLDER + "save.txt", stringtosave);
    }
    public static string Load()
    {
        if (File.Exists(SAVE_FOLDER + "save.txt"))
        {
            string file = File.ReadAllText(SAVE_FOLDER + "save.txt");
            return file;
        }
        else return null;

    }
}
