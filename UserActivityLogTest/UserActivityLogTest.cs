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
    public void GetLastActiveString_UserThatWasJustActive_ReturnsStringSayingCurrentlyActive()
    {
        UserActivityLog userActivityLog = new UserActivityLog();
        userActivityLog.AddUsername("am123");
        userActivityLog.UpdateUserActiveTime("am123");
        Assert.AreEqual("am123 is currently active", userActivityLog.GetLastActiveString("am123"));
    }
    
    [TestMethod]
    public void GetLastActiveString_UserThatWasActiveMinutesAgo_ReturnsStringInMinutes()
    {
        UserActivityLog userActivityLog = new UserActivityLog();
        userActivityLog.AddUsername("am123");
        DateTime time = DateTime.Now.AddMinutes(-5);;
        userActivityLog.UpdateUserActiveTime("am123",time);
        Assert.AreEqual("am123 was active 5 minutes ago", userActivityLog.GetLastActiveString("am123"));
    }
    
    [TestMethod]
    public void GetLastActiveString_UserThatWasActiveHoursAgo_ReturnsStringInMinutes()
    {
        UserActivityLog userActivityLog = new UserActivityLog();
        userActivityLog.AddUsername("am123");
        DateTime time = DateTime.Now.AddMinutes(-122);
        userActivityLog.UpdateUserActiveTime("am123",time);
        Assert.AreEqual("am123 was active 2 hours ago", userActivityLog.GetLastActiveString("am123"));
    }
    
    [TestMethod]
    public void GetLastActiveString_UserThatWasActiveDaysAgo_ReturnsStringInMinutes()
    {
        UserActivityLog userActivityLog = new UserActivityLog();
        userActivityLog.AddUsername("am123");
        DateTime time = DateTime.Now.AddHours(-195);;
        userActivityLog.UpdateUserActiveTime("am123",time);
        Assert.AreEqual("am123 was active 8 days ago", userActivityLog.GetLastActiveString("am123"));
    }
    
    [TestMethod]
    public void GetLastActiveString_UserThatWasActiveMonthsAgo_ReturnsStringInMinutes()
    {
        UserActivityLog userActivityLog = new UserActivityLog();
        userActivityLog.AddUsername("am123");
        DateTime time = DateTime.Now.AddDays(-31);
        userActivityLog.UpdateUserActiveTime("am123",time);
        Assert.AreEqual("am123 was active 1 month ago", userActivityLog.GetLastActiveString("am123"));
    }
    
    [TestMethod]
    public void GetLastActiveString_UserThatWasActiveYearsAgo_ReturnsStringInMinutes()
    {
        UserActivityLog userActivityLog = new UserActivityLog();
        userActivityLog.AddUsername("am123");
        DateTime time = DateTime.Now.AddDays(-369);;
        userActivityLog.UpdateUserActiveTime("am123",time);
        Assert.AreEqual("am123 was active 1 year ago", userActivityLog.GetLastActiveString("am123"));
    }
}