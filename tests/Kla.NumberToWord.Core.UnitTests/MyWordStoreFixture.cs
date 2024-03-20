using Kla.NumberToWord.Core.Data;

namespace Kla.NumberToWord.Core.UnitTests;

public class MyWordStoreFixture : IDisposable
{
    public WordStore WordStore { get; private set; }
    public MyWordStoreFixture()
    {
        WordStore = new WordStore();
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