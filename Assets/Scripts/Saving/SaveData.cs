[System.Serializable]
public readonly struct SaveData
{
    public readonly DialogueStrip currentStrip;
    public readonly int currentDialogueLine;
    
    public SaveData(DialogueStrip strip, int line)
    {
        currentStrip = strip;
        currentDialogueLine = line;
    }
}