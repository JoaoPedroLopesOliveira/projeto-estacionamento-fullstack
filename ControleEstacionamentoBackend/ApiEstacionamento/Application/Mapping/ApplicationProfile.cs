using AutoMapper;
using ApiEstacionamento.DTOs;
using ApiEstacionamento.Entities;
public class ApplicationProfile : Profile
{
    public ApplicationProfile()
    {
        CreateMap<VeiculoCreateDTO, Veiculo>();
        CreateMap<Veiculo, VeiculoResponseDTO>();

        CreateMap<AdministradorCreateDTO, Administrador>();
        CreateMap<Administrador, AdministradorResponseDTO>();

        CreateMap<ClienteCreateDTO, Cliente>();
        CreateMap<Cliente, ClienteResponseDTO>();

        CreateMap<PlanoCreateDTO, Plano>();
        CreateMap<Plano, PlanoResponseDTO>();

        CreateMap<EstacionamentoConfigCreateDTO, EstacionamentoConfig>();
        CreateMap<EstacionamentoConfig, EstacionamentoConfigResponseDTO>();
    }
}
