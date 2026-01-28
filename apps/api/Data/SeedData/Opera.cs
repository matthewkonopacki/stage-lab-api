using System.Text.Json;
using Bogus;

namespace StageLabApi.Data.SeedData;

public class Opera : DataSet
{
    private static readonly Lazy<OperaData> _data = new(LoadData);

    private static OperaData LoadData()
    {
        var path = Path.Combine(AppContext.BaseDirectory, "Data", "SeedData", "operas.json");

        if (!File.Exists(path))
        {
            throw new FileNotFoundException(
                $"Opera data file not found at: {path}. "
                    + "Ensure the file exists and is set to 'Copy to Output Directory' in the .csproj."
            );
        }

        var json = File.ReadAllText(path);

        return JsonSerializer.Deserialize<OperaData>(
                json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            ) ?? new OperaData();
    }

    /// <summary>
    /// Returns a random opera object (contains both title and composer)
    /// </summary>
    public OperaItem Full() => Random.ArrayElement(_data.Value.Operas);

    /// <summary>
    /// Returns a random opera title (e.g., "La Traviata", "Carmen")
    /// </summary>
    public string Title() => Random.ArrayElement(_data.Value.Operas).Title;

    /// <summary>
    /// Returns a random composer name (e.g., "Giuseppe Verdi", "Georges Bizet")
    /// </summary>
    public string Composer() => Random.ArrayElement(_data.Value.Operas).Composer;

    /// <summary>
    /// Returns a random opera by a specific composer
    /// </summary>
    public OperaItem ByComposer(string composer)
    {
        var matches = _data.Value.Operas.Where(o => o.Composer == composer).ToArray();
        return matches.Length > 0 ? Random.ArrayElement(matches) : Full();
    }

    /// <summary>
    /// Returns all unique composers
    /// </summary>
    public string[] AllComposers() =>
        _data.Value.Operas.Select(o => o.Composer).Distinct().ToArray();
}
