    using System.ComponentModel;
    using System.Text.Json.Serialization;

    public class ToDoTask
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Status { get; set; }
        public DateTime DataVencimento { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatusTarefa
    {
        /// <summary>0 - Pendente</summary>
        [Description("0 - Pendente")]
        Pendente = 0,

        /// <summary>1 - Em Andamento</summary>
        [Description("1 - Em Andamento")]
        EmAndamento = 1,

        /// <summary>2 - Concluído</summary>
        [Description("2 - Concluído")]
        Concluido = 2
    }