using ApiEstacionamento.DTOs;


namespace ApiEstacionamento.Interfaces
{
    public interface IVeiculoService
    {
        Task<VeiculoResponseDTO> CreateVeiculoAsync(VeiculoCreateDTO DTO);
        Task<VeiculoResponseDTO> GetVeiculoByIdAsync(int id);
        Task<List<VeiculoResponseDTO>> GetAllVeiculosAsync();
        Task<VeiculoResponseDTO>UpdateVeiculoAsync(int id, VeiculoUpdateDTO DTO);
        Task<bool> DeleteVeiculoByIdAsync(int id);
    }
}