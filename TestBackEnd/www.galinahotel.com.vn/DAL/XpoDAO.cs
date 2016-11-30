using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;
using System.Configuration;
using System.Reflection;

public class XpoDAO
{
    public XpoDAO()
    {
        this.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        this.ModuleAssembly = typeof(CMSModule.Module.CMSModuleModule).Assembly;
    }

    public XpoDAO(string connectionString)
    {
        this.ConnectionString = connectionString;
    }

    public XpoDAO(string connectionString, Assembly moduleAssembly)
    {
        this.ConnectionString = connectionString;
        this.ModuleAssembly = moduleAssembly;
    }

    protected Assembly ModuleAssembly;
    private string ConnectionString;
    private static IDataLayer ThreadSafeDataLayer;

    private void EnsureDataLayer()
    {
        if (ThreadSafeDataLayer == null)
        {
            DevExpress.Persistent.BaseImpl.BaseObject.OidInitializationMode = DevExpress.Persistent.BaseImpl.OidInitializationMode.AfterConstruction;

            XpoDefault.Session = null;
            XPDictionary dict = new ReflectionDictionary();
            dict.GetDataStoreSchema(ModuleAssembly);

            IDataStore store = XpoDefault.GetConnectionProvider(ConnectionString, AutoCreateOption.None);
            ThreadSafeDataLayer = new ThreadSafeDataLayer(dict, store);
        }
    }

    public UnitOfWork ProvideUnitOfWork()
    {
        EnsureDataLayer();
        return new UnitOfWork(ThreadSafeDataLayer);
    }

    public Session ProvideSession()
    {
        EnsureDataLayer();
        return new Session(ThreadSafeDataLayer);
    }
}

