namespace Entity.DTO.Response
{
    public class GetListPersonalResponseDto
    {
        public int IdPersonal { get; set; }
        public string TipoDoc { get; set; }
        public string NumeroDoc { get; set; }
        public string NombreCompleto { get; set; }
        public string FechaNac { get; set; }
        public string FechaIngreso { get; set; }
    }
}
