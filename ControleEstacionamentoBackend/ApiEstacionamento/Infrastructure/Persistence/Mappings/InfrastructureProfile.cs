using ApiEstacionamento.Domain.Entities;

using ApiEstacionamento.Infrastructure.Persistence.Entitites;
using AutoMapper;

namespace ApiEstacionamento.Infrastructure.Mappings
{
    public class InfrastructureProfile : Profile
    {
        public InfrastructureProfile()
        {
            
        CreateMap<Veiculo, VeiculoEntity>();
        CreateMap<VeiculoEntity, Veiculo>();
        CreateMap<EstacionamentoConfig, EstacionamentoEntity>();
        CreateMap<EstacionamentoEntity, EstacionamentoConfig>();
        CreateMap<Cliente, ClienteEntity>();
        CreateMap<ClienteEntity, Cliente>();
        CreateMap<Plano, PlanoEntity>();
        CreateMap<PlanoEntity, Plano>();
        CreateMap<Administrador, AdministradorEntity>();
        CreateMap<AdministradorEntity, Administrador>();
        CreateMap<Ticket, TicketEntity>();
        CreateMap<TicketEntity, Ticket>();
        }
    }
}