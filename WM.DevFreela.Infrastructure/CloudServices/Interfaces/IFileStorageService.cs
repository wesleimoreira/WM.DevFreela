namespace WM.DevFreela.Infrastructure.CloudServices.Interfaces
{
    public interface IFileStorageService
    {
        void UpdateFile(byte[] bytes, string fileName);
    }
}
