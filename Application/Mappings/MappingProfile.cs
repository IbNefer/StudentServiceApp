using Application.DTOs.Request.Asignatura;
using Application.DTOs.Request.Persona;
using Application.DTOs.Request.Titulacion;

// Asegúrate de importar los namespaces de todos tus DTOs:
using Application.DTOs.Response;
using Application.DTOs.Response.AreaConocimiento;
using Application.DTOs.Response.Asignatura;
using Application.DTOs.Response.AsignaturaEquivalencia;
using Application.DTOs.Response.AsignaturaIncompatibilidad;
using Application.DTOs.Response.Departamento;
using Application.DTOs.Response.Persona;
using Application.DTOs.Response.Titulacion;
using AutoMapper;
using Domain.Entity;
using Domain.Entity.Authentication;
using static Application.DTOs.Response.SimpleResponseDTO.SimpleResponseDTO; // Para ApplicationUser si hace falta

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // =========================================================
            // 1. MAPEOS PARA DTOs "SIMPLES" (Shared / Listas)
            // =========================================================

            CreateMap<Profesor, ProfesorSimpleResponseDTO>()
                .ForMember(dest => dest.NombreCompleto,
                           opt => opt.MapFrom(src => $"{src.Nombre} {src.Apellido}"))
                .ForMember(dest => dest.DniId, opt => opt.MapFrom(src => src.DniId));

            CreateMap<Departamento, DepartamentoSimpleResponseDTO>();
            CreateMap<Titulacion, TitulacionSimpleResponseDTO>();

            CreateMap<AreaConocimiento, AreaConocimientoSimpleResponseDTO>()
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.NombreArea));

            CreateMap<Pensum, PensumSimpleResponseDTO>();

            CreateMap<Asignatura, AsignaturaSimpleResponseDTO>()
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.NombreAsignatura))
                .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.CodigoAsignatura));



            CreateMap<Persona, PersonaResponseDTO>();

            // --- ESTUDIANTE (Response) ---
            CreateMap<Estudiante, EstudianteResponseDTO>()
                .IncludeBase<Persona, PersonaResponseDTO>()
                // Si Estudiante tiene lista de Asignaturas, AutoMapper intentará usar AsignaturaSimpleResponseDTO
                .ForMember(dest => dest.AsignaturasInscritas, opt => opt.MapFrom(src => src.AsignaturasMatriculadas));

            // --- PROFESOR (Response) ---
            CreateMap<Profesor, ProfesorResponseDTO>()
                .IncludeBase<Persona, PersonaResponseDTO>();

            // --- DEPARTAMENTO (Response) ---
            CreateMap<Departamento, DepartamentoResponseDTO>()
                .ForMember(dest => dest.Profesores, opt => opt.MapFrom(src => src.Profesores));

            // --- TITULACION (Response) ---
            CreateMap<Titulacion, TitulacionResponseDTO>()
                .ForMember(dest => dest.Departamento, opt => opt.MapFrom(src => src.Departamento))
                .ForMember(dest => dest.Pensums, opt => opt.MapFrom(src => src.Pensums));

            // --- ASIGNATURA (Response) ---
            CreateMap<Asignatura, AsignaturaResponseDTO>()
                .ForMember(dest => dest.AreaConocimiento, opt => opt.MapFrom(src => src.AreaConocimiento))
                .ForMember(dest => dest.Titulaciones, opt => opt.MapFrom(src => src.Titulaciones))
                .ForMember(dest => dest.HorariosDisponibles, opt => opt.MapFrom(src =>
                    src.Horarios.Select(h => new HorarioConProfesorDTO
                    {
                        Dia = h.DiaSemana,
                        HoraInicio = h.HoraInicio.ToString(),
                        HoraFin = h.HoraFin.ToString(),
                        NombreProfesor = h.Profesor != null ? $"{h.Profesor.Nombre} {h.Profesor.Apellido}" : "Sin Profesor"
                    })));

            // --- AREA CONOCIMIENTO (Response) ---
            CreateMap<AreaConocimiento, AreaConocimientoResponseDTO>()
                 .ForMember(dest => dest.Asignaturas, opt => opt.MapFrom(src => src.Asignaturas));

            // --- EQUIVALENCIAS E INCOMPATIBILIDADES ---
            CreateMap<AsignaturaEquivalencia, AsignaturaEquivalenciaResponseDTO>()
                .ForMember(dest => dest.Asignatura, opt => opt.MapFrom(src => src.Asignatura))
                .ForMember(dest => dest.AsignaturaEquivalente, opt => opt.MapFrom(src => src.AsignaturaEquivalente));

            CreateMap<AsignaturaIncompatibilidad, AsignaturaIncompatibilidadResponseDTO>()
               .ForMember(dest => dest.Asignatura, opt => opt.MapFrom(src => src.Asignatura))
               .ForMember(dest => dest.AsignaturaIncompatible, opt => opt.MapFrom(src => src.AsignaturaIncompatible));



            // --- ESTUDIANTE (Create) ---
            CreateMap<CreateEstudianteRequestDTO, Estudiante>()
 
                .ForSourceMember(src => src.AsignaturaIds, opt => opt.DoNotValidate());

            // --- ASIGNATURA (Create) ---
            CreateMap<CreateAsignaturasRequestDTO, Asignatura>()
                // Mapeo manual si los nombres no coinciden
                .ForMember(dest => dest.NombreAsignatura, opt => opt.MapFrom(src => src.NombreAsignatura))
                .ForMember(dest => dest.CodigoAsignatura, opt => opt.MapFrom(src => src.CodigoAsignatura));

             CreateMap<CreateProfesorRequestDTO, Profesor>();

          CreateMap<CreateTitulacionRequestDTO, Titulacion>();
        }
    }
}