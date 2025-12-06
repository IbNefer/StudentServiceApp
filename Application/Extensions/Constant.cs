

namespace Application.Extensions
{
    public static class Constant
    {
        public const string RegisterRoute = "api/account/identity/create";
        public const string LoginRoute = "api/account/identity/login";
        public const string RefreshTokenRoute = "api/account/identity/refresh-token";
        public const string HttpClientName = "WebUiClient";
        public const string CreateAdminRoute = "setting";
        public const string ChangeUserRoleRoute = "api/account/identity/change-role";
        public const string GetRolesRoute = "api/account/identity/roles/list";
        public const string GetUserWithRolesRoute = "api/account/identity/users-with-roles";

        public const string BrowserStorageKey = "x-key";
        public const string HttpClientHeaderScheme = "Bearer";

        //Titulacion
        public const string TitulacionRoute = "api/titulacion";
        //Estudiante
        public const string EstudianteRoute = "api/estudiante";
        //Profesor
        public const string ProfesorRoute = "api/profesor";
        //Departamento
        public const string DepartamentoRoute = "api/departamento";
        //Pensum
        public const string PensumRoute = "api/pensum";
        //Asignatura
        public const string AsignaturaRoute = "api/asignatura";
        //Horario
        public const string HorarioRoute = "api/horario";
        //AreaConocimiento
        public const string AreaConocimientoRoute = "api/areaconocimiento";
        //AsignaturaEquivalencia
        public const string AsignaturaEquivalenciaRoute = "api/equivalencia";
        //AsignaturaIncompatibilidad
        public const string AsignaturaIncompatibilidadRoute = "api/incompatibilidad";


        public static class Roles{
            public const string Admin = "Admin";
            public const string User = "User";
        }
    }
}
