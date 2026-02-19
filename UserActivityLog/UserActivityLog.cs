namespace UserActivityLog;

/// <summary>
/// This class keeps track of a list of users and when they were last active in. Gives a readable report of users activity
/// which will scale to minutes, hours, days, etc.. appropriately. For example if user was active 
/// </summary>
public class UserActivityLog
{
    // A dictionary which keeps track of the timestamp when a user was last active
    private Dictionary<string, DateTime?> _userAcitvity = new Dictionary<string, DateTime?>();

    /// <summary>
    /// Adds a user to activity log with an initial timestamp of null
    /// </summary>
    /// <param name="name"></param> username to be added
    /// <exception cref="ArgumentException"></exception> if user already exists
    public void addUser(string username)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Updates the last logged in time to Timestamp passed of the username passed.
    /// </summary>
    /// <param name="name"> Username of timestamp to update</param>
    /// <param name="lastLoginTime"> Timestamp to update users last active time to</param>
    /// <exception cref="ArgumentException"></exception> If user does not exist
    public void updateUserActiveTime(string username, DateTime lastLoginTime)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Updates users last active time to current time. Updates the timestamp of username passed
    /// </summary>
    /// <param name="name">Username of timestamp to update </param>
    /// <exception cref="ArgumentException"></exception> If user does not exist
    public void updateUserActiveTime(string username)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Returns a human-readable activity statement of when username was last active. Will report time to the
    /// appropriate unit of time: minutes, hours, days, months, etc... If user does not exist or doesn't have
    /// any timestamp (hasn't been active yet) will return string with error message
    /// </summary>
    /// <param name="name"></param>
    /// <returns>
    /// A string representing the last activity state. Possible returns:
    /// <list type="number">
    /// <item>
    /// <description> "Username does not exist" if no username found </description>
    /// </item>
    /// <item>
    /// <description>  "User has no recorded activity" if user hasn't been active </description>
    /// </item>
    /// <item>
    /// <description> ""User was active [x] [unit] ago" </description>
    /// </item>
    /// </list>
    /// </returns>
    public string GetLastActiveString(string name)
    {
        throw new NotImplementedException();
    }
}