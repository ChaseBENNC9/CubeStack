public class SaveData
{
    public int bestScore;
    public int lastScore;
    public int powerupRepair, powerupRewind, powerupPerfect;


    public SaveData(int bestScore , int lastScore)
    {
        this.bestScore = bestScore;
        this.lastScore = lastScore;
    }
    public SaveData (int bestScore, int lastScore, int powerupRepair, int powerupRewind, int powerupPerfect)
    {
        this.bestScore = bestScore;
        this.lastScore = lastScore;
        this.powerupRepair = powerupRepair;
        this.powerupRewind = powerupRewind;
        this.powerupPerfect = powerupPerfect;
    }

    public SaveData()
    {
        bestScore = 0;
        lastScore = 0;
        powerupRepair = 2;
        powerupRewind = 0;
        powerupPerfect = 2;
    }

    
}