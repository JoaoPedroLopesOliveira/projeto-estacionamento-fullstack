using ApiEstacionamento.DTOs;
using ApiEstacionamento.Interfaces;
using ApiEstacionamento.Domain.Interfaces.Repositories;
using AutoMapper;
using ApiEstacionamento.Domain.Entities;

namespace ApiEstacionamento.Services
{
    public class VeiculosService : IVeiculoService
{
    private readonly IVeiculoRepository _veiculoRepository;
    private readonly IMapper _mapper;

    public VeiculosService(IVeiculoRepository veiculoRepository, IMapper mapper)
    {
        _veiculoRepository = veiculoRepository;
        _mapper = mapper;
    }

    public async Task<VeiculoResponseDTO> CreateVeiculoAsync(VeiculoCreateDTO dto)
    {
        var veiculo = _mapper.Map<Veiculo>(dto);
        await _veiculoRepository.CreateAsync(veiculo);
        return _mapper.Map<VeiculoResponseDTO>(veiculo);
    }

    public async Task<bool> DeleteVeiculoByIdAsync(int id)
    {
        var existente = await _veiculoRepository.GetByIdAsync(id);
        if (existente == null)
            return false;

        await _veiculoRepository.DeleteAsync(id);
        return true;
    }

    public async Task<List<VeiculoResponseDTO>> GetAllVeiculosAsync()
    {
        var veiculos = await _veiculoRepository.GetAllAsync();
        return _mapper.Map<List<VeiculoResponseDTO>>(veiculos);
    }

    public async Task<VeiculoResponseDTO?> GetVeiculoByIdAsync(int id)
    {
        var veiculo = await _veiculoRepository.GetByIdAsync(id);
        return veiculo == null ? null : _mapper.Map<VeiculoResponseDTO>(veiculo);
    }

    public async Task<VeiculoResponseDTO?> UpdateVeiculoAsync(int id, VeiculoUpdateDTO dto)
    {
        var veiculo = await _veiculoRepository.GetByIdAsync(id);
        if (veiculo == null)
            return null;

        if (!string.IsNullOrEmpty(dto.Placa))
            veiculo.Placa = dto.Placa;

        if (!string.IsNullOrEmpty(dto.Cor))
            veiculo.Cor = dto.Cor;

        if (!string.IsNullOrEmpty(dto.Modelo))
            veiculo.Modelo = dto.Modelo;

        await _veiculoRepository.UpdateAsync(veiculo);
        return _mapper.Map<VeiculoResponseDTO>(veiculo);
    }
}

}