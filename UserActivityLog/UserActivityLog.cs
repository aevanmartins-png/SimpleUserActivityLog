namespace UserActivityLog;

/// <summary>
/// This class keeps track of a list of users and when they were last active in. Gives a readable report of users activity
/// which will scale to minutes, hours, days, etc.. appropriately. For example if user was active
/// Also allows to get answer in mars time units inspired from technical interview question
/// </summary>
public class UserActivityLog
{
    // A dictionary which keeps track of the timestamp when a user was last active
    private Dictionary<string, DateTime> _userActivity = new Dictionary<string, DateTime>();
    
    
    /// <summary>
    /// Represents a single time unit and number of seconds that the unit represents. For example a minute is 60
    /// seconds.
    /// </summary>
    /// <param name="UnitName"> Name of unit to represent</param>
    /// <param name="Seconds"> Number of seconds that unit represents</param>
    private record TimeUnit(string UnitName, double Seconds)
    {
        /// <summary>
        /// Returns proper unit label either non-plural if count is less than 1 or plural if greater than 1
        /// </summary>
        /// <param name="count"> Number of units that have passed</param>
        /// <returns> Plural or non-plural string of that unit depending on count</returns>
        public string GetUnitLabel(int count)
        {
            return count == 1 ? UnitName : UnitName + "s";
        }
    }

    // A list of time units and how many seconds they represent
    // Must be added from the highest unit to lowest, where highest is unit representing most amount of seconds
    private static readonly List<TimeUnit> EarthUnits = new()
    {
        // New units of time can be easily added here
        new("year", 31536000), //Assuming 365 days in a year
        new("month", 2592000), //Assuming 30 days in a year
        new("day", 86400),
        new("hour", 3600),
        new("minute", 60),
    };
    
    // A list of time units and how many seconds they represent
    // Must be added from the highest unit to lowest, where highest is unit representing most amount of seconds
    private static readonly List<TimeUnit> MarsUnits = new()
    {
        // New units of time can be easily added here
        new("martian year", 60988425), //687 days in martian year
        new("martian month", 2485700), //28 sols in a month
        new("sol", 88775),
        new("hour", 3800),
        new("minute", 61.65),
    };
    
    
    
    
    /// <summary>
    /// Adds a user to activity log with an initial timestamp of Current Time
    /// </summary>
    /// <param name="username"></param> username to be added
    /// <exception cref="ArgumentException"></exception> if username already exists
    public void AddUsername(string username)
    {
        if (!_userActivity.TryAdd(username,DateTime.Now))
        {
            throw new ArgumentException("username already exists");
        }
    }

    /// <summary>
    /// Updates the last logged in time to Timestamp passed of the username passed.
    /// </summary>
    /// <param name="username"> Username of timestamp to update</param>
    /// <param name="lastLoginTime"> Timestamp to update users last active time to</param>
    /// <exception cref="ArgumentException"></exception> If username does not exist
    public void UpdateUserActiveTime(string username, DateTime lastLoginTime)
    {
        if (!_userActivity.ContainsKey(username))
        {
            throw new ArgumentException("username does not exist");
        }

        _userActivity[username] = lastLoginTime;

    }

    /// <summary>
    /// Updates users last active time to current time. Updates the timestamp of username passed
    /// </summary>
    /// <param name="username">Username of timestamp to update </param>
    /// <exception cref="ArgumentException"></exception> If user does not exist
    public void UpdateUserActiveTime(string username)
    {
        if (!_userActivity.ContainsKey(username))
        {
            throw new ArgumentException("username does not exist");
        }

        _userActivity[username] = DateTime.Now;
    }

    /// <summary>
    /// Returns a human-readable activity statement of when username was last active. Will report time to the
    /// appropriate unit of time: minutes, hours, days, months, etc... If user does not exist or doesn't have
    /// any timestamp (hasn't been active yet) will return string with error message. If unit count is only
    /// 1 will return statement using non-plural form of that unit
    /// </summary>
    /// <param name="username">name to look up activity statement for</param>
    /// <returns>
    /// A string representing the last activity state. Possible returns:
    /// <list type="number">
    /// <item>
    /// <description> "[Username] does not exist" if no username found </description>
    /// </item>
    /// <item>
    /// <description>  "[Username] is currently active" if user has been active within the last 60 seconds </description>
    /// </item>
    /// <item>
    /// <description> "[Username] was active [x] [unit] ago" </description>
    /// </item>
    /// </list>
    /// </returns>
    public string GetLastActiveString(string username)
    {
        return GetLastActiveString(username, EarthUnits);
    }
    
    /// <summary>
    /// Returns activity statement as described in <see cref="GetLastActiveString"/> but in Martian Units
    /// </summary>
    /// <param name="username">name to look up activity statement for</param>
    /// <returns>Activity Statement based on when username was last active</returns>

    public string GetLastActiveStringMarsTime(string username)
    {
        return GetLastActiveString(username, MarsUnits);
    }
    
    
    /// <summary>
    /// Returns human readable statement based on units given. See <see cref="GetLastActiveString"/> for more details
    /// </summary>
    /// <param name="username">name to look up activity statement for</param>
    /// <param name="units">Time unit to use to construct output statement</param>
    /// <returns>Activity statement based on time unites passed in </returns>
    private string GetLastActiveString(string username, List<TimeUnit> units) 
    {
        if (!_userActivity.ContainsKey(username))
        {
            return $"{username} does not exist";
        }
        
        if (!_userActivity.TryGetValue(username, out DateTime lastActiveTime))
        {
            return $"{username} has no recorded activity";
        }

        double secondsElapsed = (DateTime.Now - lastActiveTime).TotalSeconds;
        
        //Start at highest unit and go down until correct unit is found
        foreach (var unit in units)
        {
            if (secondsElapsed > unit.Seconds)
            {
                int numUnitsPassed = (int)(secondsElapsed / unit.Seconds);
                //Calculate if unit label should be plural
                string label = unit.GetUnitLabel(numUnitsPassed);
                return $"{username} was active {numUnitsPassed} {label} ago";
            }
        }
        return $"{username} is currently active";
    }
}