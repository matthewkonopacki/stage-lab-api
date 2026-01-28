using Bogus;
using Bogus.Premium;

namespace StageLabApi.Data.SeedData;

public static class BogusOperaExtensions
{
    public static Opera Opera(this Faker faker)
    {
        return ContextHelper.GetOrSet(faker, () => new Opera());
    }
}
