using DenunciaUnaBestia.Application.Core;

namespace DenunciaUnaBestia.Application.Core;

public interface IBaseService<TDto, TCreateDto>
{
    Task<ServiceResult<IEnumerable<TDto>>> GetAllAsync();
    Task<ServiceResult<TDto>> GetByIdAsync(int id);
    Task<ServiceResult> CreateAsync(TCreateDto dto);
    Task<ServiceResult> UpdateAsync(int id, TCreateDto dto);
    Task<ServiceResult> DeleteAsync(int id);
}
