using Kla.NumberToWord.Core.Data;
using Kla.NumberToWord.Core.Domain;

namespace Kla.NumberToWord.Core.UnitTests;

public class MyWordStoreFixture : IDisposable
{
    public IWordProvider WordProvider { get; private set; }
    public DividerOption DividerOption { get; private set; }
    public MyWordStoreFixture()
    {
        WordProvider = new WordStore();
        DividerOption = new DividerOption();
    }

    public void Dispose()
    {
    }

}

[CollectionDefinition(nameof(MyWordStoreFixture))]
public class WordStoreFixtureCollection : ICollectionFixture<MyWordStoreFixture>
{
    // This class has no code, and is never created. Its purpose is simply
    // to be the place to apply [CollectionDefinition] and all the
    // ICollectionFixture<> interfaces.
}