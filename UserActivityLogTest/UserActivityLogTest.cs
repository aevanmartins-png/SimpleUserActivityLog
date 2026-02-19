namespace UserActivityLogTest;
using UserActivityLog;
[TestClass]
public sealed class UserActivityLogTest
{
    [TestMethod]
    public void GetLastActiveString_UserDoesNotExist_ReturnsStringWithProperReport()
    {
        UserActivityLog userActivityLog = new UserActivityLog();
        Assert.AreEqual("am123 does not exist", userActivityLog.GetLastActiveString("am123"));
    }
    
    [TestMethod]
    public void GetLastActiveString_UserWithNotActivity_ReturnsStringWithProperReport()
    {
        UserActivityLog userActivityLog = new UserActivityLog();
        userActivityLog.addUser("am123");
        Assert.AreEqual("am123 has no recorded activity", userActivityLog.GetLastActiveString("am123"));
    }
    
    [TestMethod]
    public void GetLastActiveString_UserThatWasJustActive_ReturnsStringSayingCurrentlyActive()
    {
        UserActivityLog userActivityLog = new UserActivityLog();
        userActivityLog.addUser("am123");
        userActivityLog.updateUserActiveTime("am123");
        Assert.AreEqual("am123 is currently active", userActivityLog.GetLastActiveString("am123"));
    }
    
    [TestMethod]
    public void GetLastActiveString_UserThatWasActiveMinutesAgo_ReturnsStringInMinutes()
    {
        UserActivityLog userActivityLog = new UserActivityLog();
        userActivityLog.addUser("am123");
        DateTime time = DateTime.Now;
        time.AddMinutes(-5);
        userActivityLog.updateUserActiveTime("am123");
        Assert.AreEqual("am123 was active 5 minutes ago", userActivityLog.GetLastActiveString("am123"));
    }
    
    [TestMethod]
    public void GetLastActiveString_UserThatWasActiveHoursAgo_ReturnsStringInMinutes()
    {
        UserActivityLog userActivityLog = new UserActivityLog();
        userActivityLog.addUser("am123");
        DateTime time = DateTime.Now;
        time.AddMinutes(-122);
        userActivityLog.updateUserActiveTime("am123");
        Assert.AreEqual("am123 was active 2 hours ago", userActivityLog.GetLastActiveString("am123"));
    }
    
    [TestMethod]
    public void GetLastActiveString_UserThatWasActiveDaysAgo_ReturnsStringInMinutes()
    {
        UserActivityLog userActivityLog = new UserActivityLog();
        userActivityLog.addUser("am123");
        DateTime time = DateTime.Now;
        time.AddHours(-195);
        userActivityLog.updateUserActiveTime("am123");
        Assert.AreEqual("am123 was active 8 days ago", userActivityLog.GetLastActiveString("am123"));
    }
    
    [TestMethod]
    public void GetLastActiveString_UserThatWasActiveMonthsAgo_ReturnsStringInMinutes()
    {
        UserActivityLog userActivityLog = new UserActivityLog();
        userActivityLog.addUser("am123");
        DateTime time = DateTime.Now;
        time.AddDays(-31);
        userActivityLog.updateUserActiveTime("am123");
        Assert.AreEqual("am123 was active 1 month ago", userActivityLog.GetLastActiveString("am123"));
    }
    
    [TestMethod]
    public void GetLastActiveString_UserThatWasActiveYearsAgo_ReturnsStringInMinutes()
    {
        UserActivityLog userActivityLog = new UserActivityLog();
        userActivityLog.addUser("am123");
        DateTime time = DateTime.Now;
        time.AddDays(-369);
        userActivityLog.updateUserActiveTime("am123");
        Assert.AreEqual("am123 was active 1 year ago", userActivityLog.GetLastActiveString("am123"));
    }
}