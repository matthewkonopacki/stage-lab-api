namespace StageLabApi.Models;

public class ActionRole
{
    public int Id { get; set; }
    public required int ActionId { get; set; }
    public required int RoleId { get; set; }
    
    public Action? Action { get; set; }
    public Role? Role { get; set; }
}