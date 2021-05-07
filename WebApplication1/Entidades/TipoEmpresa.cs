namespace Easy_Stock.Entidades
{
    public class TipoEmpresa
    {
        public int idTipoEmpresa { get; set; } = 0;
        public string tipoEmpresa { get; set; } = string.Empty;

        public TipoEmpresa()
        {
            this.idTipoEmpresa = 0;
            this.tipoEmpresa = string.Empty;
        }
    }
}