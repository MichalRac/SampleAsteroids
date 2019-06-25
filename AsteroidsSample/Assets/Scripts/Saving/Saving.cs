using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class Saving
{
    public static void SaveHighScore(int highScore)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/highscore.file";
        FileStream stream = new FileStream(path, FileMode.Create);

        HighScore data = new HighScore(highScore);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static HighScore LoadHighScore()
    {
        string path = Application.persistentDataPath + "/highscore.file";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            HighScore highscore = formatter.Deserialize(stream) as HighScore;

            return highscore;
        }
        else
        {
            Debug.LogError($"Save not found, path: {path}");
            return null;
        }
    }
}
