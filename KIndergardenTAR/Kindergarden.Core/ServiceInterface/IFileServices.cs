using Kindergarden.Core.Domain;
using Kindergarden.Core.Dto;


namespace Kindergarden.Core.ServiceInterface
{
    public interface IFileServices
    {
        void FilesToApi(KindergardenDto dto, KindergardenDomain domain);
        Task<FileToApi> RemoveImageFromApi(FileToApiDto dto);
        Task<List<FileToApi>> RemoveImagesFromApi(FileToApiDto[] dto);
    }
}
