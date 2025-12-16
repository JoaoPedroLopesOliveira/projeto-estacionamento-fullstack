using AutoMapper;
using ApiEstacionamento.Models;
using ApiEstacionamento.DTOs;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<VeiculoCreateDTO, Veiculo>();
        CreateMap<Veiculo, VeiculoResponseDTO>();
        CreateMap<AdministradorCreateDTO, Administrador>();
        CreateMap<Administrador, AdministradorResponseDTO>();
        CreateMap<ClienteCreateDTO, Cliente>();
        CreateMap<Cliente, ClienteResponseDTO>();
        CreateMap<Plano, PlanoResponseDTO>();
        CreateMap<PlanoCreateDTO, Plano>();
    }
}
