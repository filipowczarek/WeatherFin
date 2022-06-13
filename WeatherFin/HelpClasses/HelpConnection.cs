namespace WeatherFin.HelpClasses
{
    public static class HelpConnection // in MVC there is possibility to use IConfiguration interface, here I just created workaround
    {
        public static string connectionStr { get; set; }

    }
}
