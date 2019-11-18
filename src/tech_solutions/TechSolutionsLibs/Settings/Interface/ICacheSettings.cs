namespace TechSolutionsLibs.Settings.Interface
{
    public interface ICacheSettings
    {
        int ExpiresInSeconds { get; set; }
        bool Enable { get; set; }
    }
}
