namespace MessageSender
{
    public class AppSettings
    {

        public AppSettingsTwillio appSettingsTwillio { get; set; }
    }

    public class AppSettingsTwillio
    {
        public string? accountSid { get; set; }

        public string? authToken { get; set; }
        public string? TwilloNumber { get; set; }
    }
}
