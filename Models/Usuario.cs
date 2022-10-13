using System;

namespace atividade2CRUD.Models{
    public class Usuario{
            public int Id {get; set;}
            public string Nome {get; set;}
            public string Login {get; set;}
            public string Senha {get; set;}
    }

    public class Pacote{
            public int id_pacotes {get; set;}
            public string Nome {get; set;}
            public string Origem {get; set;}
            public string Destino {get; set;}
            public string Atrativos {get; set;}
            public DateTime Saida {get; set;}
            public DateTime Retorno {get; set;}
            public int Id {get; set;}
    }
}