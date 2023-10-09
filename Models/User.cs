namespace UserNS.Model;

public enum Roles
{
    WORKER,
    MANAGER,
    OWNER,
    ADMIN
}

public class User
{
    public User(string name, string role, string photoPath)
    {
        this.Name = name;
        if (Enum.IsDefined(typeof(Roles), role.ToUpper()))
        {
            this.Role = role;
        }
        else
        {
            // todo: return error on creating a new instance
        }

        this.Role = role;
        this.PhotoPath = photoPath;
    }

    public required String Name { get; set; }
    public required String Role { get; set; }
    public required String PhotoPath { get; set; }
    public String[]? Project { get; set; }
}