using Enum.Enums;

namespace Manager.ServiceManager.States.GameDay;

public class GameDay
{
    public Day DayState { get; private set; }

    public GameDay()
    {
        DayState = Day.Day;
    }
    
    public bool IsDay => DayState == Day.Day;
    public bool IsNight => DayState == Day.Night;
    public bool IsVoting => DayState == Day.Voting;

    public void MovePhase()
    {
        if (DayState == Day.Night)
            DayState = Day.Day;
        else if (DayState == Day.Voting)
            DayState = Day.Day;
        else
            DayState = Day.Night;
    }
}