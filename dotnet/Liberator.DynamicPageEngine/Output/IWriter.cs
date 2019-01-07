namespace Liberator.DynamicPageEngine.Output
{
    internal interface IWriter
    {
        void WriteFile(string name, string outputPath);
    }
}