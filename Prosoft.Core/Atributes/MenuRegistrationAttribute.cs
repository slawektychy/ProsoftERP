

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class MenuRegistrationAttribute : Attribute
{
    public string MenuPath { get; }

    public MenuRegistrationAttribute(string menuPath)
    {
        MenuPath = menuPath;
    }
}