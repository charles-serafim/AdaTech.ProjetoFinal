using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AdaTech.ProjetoFinal
{
    internal class WordList : Utils
    {

        // Método que guarda uma coleção de palavras e devolve uma palavra da coleção
        // ou uma palavra aleatória gerada através da API "https://api.dicionario-aberto.net/"
        public string[] ChooseWord()
        {
            string[] word = new string[2];

            Dictionary<int, string[]> wordList = new Dictionary<int, string[]>
            {
                { 1, new string[] { "Médico", "Professor", "Engenheiro", "Advogado", "Enfermeiro", "Programador", "Contador", "Jornalista", "Chef de cozinha", "Arquiteto", "Policial", "Bombeiro", "Astrônomo", "Fotógrafo", "Psicólogo", "Fisioterapeuta", "Piloto", "Agricultor", "Eletricista", "Dentista", "Veterinário", "Dançarino", "Motorista de caminhão", "Farmacêutico", "Cineasta", "Músico", "Economista", "Artista plástico", "Consultor financeiro", "Gerente de projeto", "Terapeuta ocupacional", "Tradutor", "Geólogo", "Técnico de laboratório", "Analista de sistemas", "Terapeuta da fala", "Consultor de moda", "Nutricionista", "Técnico em informática", "Corretor de imóveis", "Gerente de vendas", "Técnico em radiologia", "Investigador particular", "Analista de marketing", "Bombeiro florestal", "Desenvolvedor de jogos", "Terapeuta familiar", "Analista de segurança da informação", "Técnico em redes de computadores", "Designer de moda", "Cientista de dados", "Cientista ambiental", "Consultor de recursos humanos", "Corretor de seguros", "Técnico em edificações", "Cartunista", "Técnico em manutenção de aeronaves", "Personal trainer", "Investigador de acidentes", "Analista de suporte técnico", "Coordenador de logística", "Artista circense", "Agente de viagens", "Escritor" } },
                { 2, new string[] { "Elefante", "Girafa", "Gorila", "Canguru", "Pinguim", "Ornitorrinco", "Jacaré", "Tartaruga", "Chimpanzé", "Suricata", "Antílope", "Formiga", "Tucano", "Morcego", "Quati", "Coala", "Avestruz", "Esquilo", "Tubarão", "Leão marinho", "Arara", "Ouriço", "Beija flor", "Peixe boi", "Lince", "Foca", "Caracol", "Guepardo", "Flamingo", "Borboleta", "Gato", "Falcão", "Galinha", "Lêmure", "Hiena", "Raposa", "Vagalume", "Polvo", "Urso panda", "Quokka", "Salamandra", "Veado", "Cachorro", "Cavalo marinho", "Dragão de komodo", "Pardal", "Gorrião", "Lobo guará", "Tamanduá", "Borzoi", "Beagle", "Elefante marinho", "Carpa", "Pangolim", "Porco espinho", "Morcego vampiro", "Pato", "Golfinho", "Rinoceronte", "Quetzal", "Quokka", "Urutu", "Mariposa", "Cervo" } },
                { 3, new string[] { "Lasanha", "Espaguete", "Sushi", "Hambúrguer", "Queijadinha", "Croissant", "Tiramisu", "Cuscuz", "Brigadeiro", "Paella", "Risoto", "Guacamole", "Cachorro quente", "Chocolate", "Parmesão", "Queijo coalho", "Feijoada", "Ceviche", "Coxinha", "Creme brûlée", "Baguete", "Abacaxi", "Yakissoba", "Mousse", "Rabanada", "Batata frita", "Abóbora", "Pão de ló", "Pavê", "Açaí", "Churros", "Quindim", "Paçoca", "Frango xadrez", "Tempurá", "Estrogonofe", "Bacalhau", "Pão de queijo", "Gelatina", "Moqueca", "Calzone", "Peixe grelhado", "Pudim", "Bolinho de arroz", "Salada", "Canjica", "Queijo minas", "Panqueca", "Sorvete", "Bolo de cenoura", "Coxinha", "Tapioca", "Vatapá", "Bife a cavalo", "Pão de chocolate", "Pastel", "Bolo de chocolate", "Guisado", "Nachos", "Omelete", "Arroz de carne", "Macarrão", "Feijão tropeiro", "Bauru" } },
                { 4, new string[] { "Computador", "Telefone", "Cadeira", "Mesa", "Caneta", "Lápis", "Papel", "Livro", "Óculos", "Relógio", "Câmera", "Fone de ouvido", "Carro", "Bicicleta", "Máquina fotográfica", "Microscópio", "Televisão", "Roteador", "Luminária", "Refrigerador", "Faca", "Garfo", "Colher", "Prato", "Copo", "Abajur", "Quadro", "Escova de dentes", "Secador de cabelo", "Chave de fenda", "Chave inglesa", "Martelo", "Serra", "Tesoura", "Pincel", "Vassoura", "Aspirador de pó", "Ventilador", "Estante", "Sofá", "Cobertor", "Travesseiro", "Escova de cabelo", "Máquina de lavar", "Fogão", "Liquidificador", "Computador portátil", "Micro ondas", "Teclado", "Mouse", "Impressora", "Scanner", "Mochila", "Bolsa", "Lanterna", "Cadeado", "Guarda chuva", "Binóculos", "Mapa", "Bússola", "Lança chamas", "Microfone", "Caixa de ferramentas", "Pincel atômico" } },
                { 5, new string[] { "Brasil", "Estados Unidos", "Canadá", "Austrália", "Argentina", "Alemanha", "França", "Espanha", "Itália", "Portugal", "Reino Unido", "Rússia", "China", "Japão", "Índia", "México", "Colômbia", "Chile", "Peru", "Uruguai", "Paraguai", "Venezuela", "Bolívia", "Equador", "Suíça", "Suécia", "Noruega", "Dinamarca", "Finlândia", "Holanda", "Bélgica", "Áustria", "Grécia", "Turquia", "Egito", "Nigéria", "África do Sul", "Marrocos", "Quênia", "Nigéria", "Costa do Marfim", "Gana", "Senegal", "Angola", "Moçambique", "Austrália", "Nova Zelândia", "Indonésia", "Tailândia", "Vietnã", "Coreia do Sul", "Malásia", "Filipinas", "Singapura", "Paquistão", "Bangladesh", "Nepal", "Afeganistão", "Irã", "Iraque", "Síria", "Líbano", "Jordânia", "Kuwait" } },
                { 6, new string[] { "Brasília", "Washington", "Ottawa", "Canberra", "Buenos Aires", " Berlim", " Paris", " Madrid", " Roma", " Lisboa", " Londres", " Moscou", " Pequim", " Tóquio", " Nova Delhi", " Cidade do México", " Bogotá", " Santiago", " Lima", " Montevideo", " Assunção", " Caracas", " La Paz", " Quito", " Berna", " Estocolmo", " Oslo", " Copenhague", " Helsinque", " Amsterdã", " Bruxelas", " Viena", " Atenas", " Ancara", " Cairo", " Abu Dhabi", " Riad", " Pretória", " Rabat", " Argel", " Nairobi", " Abuja", " Acra", " Dacar", " Luanda", " Maputo", " Camberra", " Jacarta", " Bangkok", " Hanói", " Seul", " Kuala Lumpur", " Manila", " Singapura", " Islamabad", " Daca", " Catmandu", " Teerã", " Bagdá", " Damasco", " Beirute", " Amã", " Kuwait", " Mascate" } },
                { 7, new string[] { "Rio Branco", "Maceió", "Macapá", "Manaus", "Salvador", "Fortaleza", "Brasília", "Vitória", "Goiânia", "São Luís", "Cuiabá", "Campo Grande", "Belo Horizonte", "Belém", "João Pessoa", "Curitiba", "Recife", "Teresina", "Rio de Janeiro", "Natal", "Porto Alegre", "Porto Velho", "Boa Vista", "Forianópolis", "São Paulo", "Aracaju", "Palmas" } },
            };

            Dictionary<int, string> categoryList = new Dictionary<int, string>
            {
                { 1, "Profissões" },
                { 2, "Animais" },
                { 3, "Comidas" },
                { 4, "Objetos" },
                { 5, "Países" },
                { 6, "Capitais de Países" },
                { 7, "Capitais Brasileiras" }
            };

            Console.WriteLine("Selecione uma categoria: ");
            Console.WriteLine("1. Profissões");
            Console.WriteLine("2. Animais");
            Console.WriteLine("3. Comidas");
            Console.WriteLine("4. Objetos");
            Console.WriteLine("5. Países");
            Console.WriteLine("6. Capitais de Países");
            Console.WriteLine("7. Capitais Brasileiras");
            Console.WriteLine("8. Palavra surpresa (?)");

            int option = ReadOption(1, 8);

            if (option != 8)
            {
                string category;
                string[] words = wordList[option];
                Random random = new Random();
                int randomIndex = random.Next(0, words.Length);
                word[0] = categoryList[option];
                word[1] = words[randomIndex];
            }
            else
            {
                word[0] = "Palavra aleatória";
                word[1] = RandomWordFromAPI();
            }

            return word;
        }

        // Método que consulta a API "https://api.dicionario-aberto.net/" e devolve uma palvra aleatória
        private static string RandomWordFromAPI()
        {
            string apiUrl = "https://api.dicionario-aberto.net/random";

            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = httpClient.GetAsync(apiUrl).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonString = response.Content.ReadAsStringAsync().Result;
                        JsonObject jsonObject = JsonSerializer.Deserialize<JsonObject>(jsonString);

                        if (jsonObject != null && jsonObject.word != null)
                            return jsonObject.word;
                        else
                            Console.WriteLine("Houve um problema na conexão com a API");
                    }
                    else
                    {
                        Console.WriteLine("Houve um problema na conexão com a API");
                        Console.WriteLine($"Erro na requisição: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Houve um problema na conexão com a API");
                    Console.WriteLine($"Erro na requisição: {ex.Message}");
                }

                return "pneumoultramicroscopicossilicovulcanoconiótico";
            }
        }

        // Classe modelo do objeto retornado pela API
        internal class JsonObject
        {
            public int sense { get; set; }
            public int wid { get; set; }
            public string word { get; set; }
        }
    }
}
