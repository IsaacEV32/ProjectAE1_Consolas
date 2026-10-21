using UnityEngine;

public class SaveSystemXbox : SaveSystem
{
    public override void Awake()
    {
        //Here I will initialize the path for persistent data in Xbox
        base.Awake();
    }
    public override void Save()
    {
        //Here will go the code for Xbox to save the game

    }
    public override bool HasSaved()
    {
        //Here will go the code for Xbox to check if the player has saved
        return true;
    }
    public override void Load()
    {
        //Here will go the code for Xbox to load the game
    }
}
