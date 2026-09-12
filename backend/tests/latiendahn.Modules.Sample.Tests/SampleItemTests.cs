using latiendahn.Modules.Sample.Domain;
using Xunit;

namespace latiendahn.Modules.Sample.Tests;

public sealed class SampleItemTests
{
    [Fact]
    public void Create_trims_name_and_assigns_id()
    {
        var now = DateTimeOffset.UtcNow;

        var item = SampleItem.Create("  Widget  ", "una descripcion", now);

        Assert.Equal("Widget", item.Name);
        Assert.NotEqual(Guid.Empty, item.Id);
        Assert.Equal(now, item.CreatedOn);
    }

    [Fact]
    public void Rename_updates_name_and_description()
    {
        var item = SampleItem.Create("Old", null, DateTimeOffset.UtcNow);

        item.Rename("  New  ", "desc");

        Assert.Equal("New", item.Name);
        Assert.Equal("desc", item.Description);
    }
}