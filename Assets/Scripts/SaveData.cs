
/// <summary>
/// A class that holds the data that will be saved and loaded tp and from the playerprefs
/// </summary>
public class SaveData
{
    public int bestScore;
    public int lastScore;
    public int powerupRepair, powerupRewind, powerupPerfect;

/// <summary>
/// Constructor for the SaveData class that takes in the best score and last score
/// </summary>
/// <param name="bestScore"></param>
/// <param name="lastScore"></param>
    public SaveData(int bestScore , int lastScore)
    {
        this.bestScore = bestScore;
        this.lastScore = lastScore;
    }
    /// <summary>
    /// Constructor for the SaveData class that takes in the best score, last score, and powerups
    /// </summary>
    /// <param name="bestScore"></param>
    /// <param name="lastScore"></param>
    /// <param name="powerupRepair"></param>
    /// <param name="powerupRewind"></param>
    /// <param name="powerupPerfect"></param>
    public SaveData (int bestScore, int lastScore, int powerupRepair, int powerupRewind, int powerupPerfect)
    {
        this.bestScore = bestScore;
        this.lastScore = lastScore;
        this.powerupRepair = powerupRepair;
        this.powerupRewind = powerupRewind;
        this.powerupPerfect = powerupPerfect;
    }

/// <summary>
/// Constructor for the SaveData class that initializes the best score, last score, and powerups to default values
/// </summary>
    public SaveData()
    {
        bestScore = 0;
        lastScore = 0;
        powerupRepair = 2;
        powerupRewind = 0;
        powerupPerfect = 2;
    }

    
}