namespace StageLabApi.Data.SeedData;

public class OperaData
{
    public OperaItem[] Operas { get; set; } = [];
}

public class OperaItem
{
    public string Title { get; set; } = string.Empty;
    public string Composer { get; set; } = string.Empty;
}
