namespace spotivy_app.spotivy
{
    class TimeFormatter
    {
        public static string FormatTime(int time)
        {
            if (time < 0)
            {
                return "00:00";
            }
            int minutes = (time / 60);
            int seconds = time % 60;
            return (minutes > 9 ? minutes : "0"+minutes)+":"+ (seconds > 9 ? seconds : "0" + seconds);
        }
    }
}
