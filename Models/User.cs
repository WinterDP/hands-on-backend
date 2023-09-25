namespace UserNS.Model;

class User
{
    private String role = "Worker";
    public required String Name { get; set; }
    public required String Role
    {
        get { return role; }
        set
        {
            if (value == "Worker" || value == "Manager" || value == "Owner" || value == "Admin")
            {
                role = value;
            }
            else
            {
                role = "Worker";
            }
        }
    }
    public required String PhotoPath { get; set; }
    public String[]? Project { get; set; }
}