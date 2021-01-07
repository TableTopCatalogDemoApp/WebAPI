namespace TableTopCatalogDemoApp.Data.Design.DataSeed
{
    interface IDataSeedPack
    {
        string GetUniqueId();
        void Apply(TableTopDataContext context);
    }
}
