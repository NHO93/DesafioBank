using System;
using System.Net.Http;
using System.Threading.Tasks;

public class UsuarioComum
{
    public string NomeCompleto { get; set; }
    public string CPF { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public decimal Saldo { get; set; }

    public async Task TransferirDinheiro(UsuarioComum destinatario, decimal valor)
    {
        if (Saldo < valor)
        {
            Console.WriteLine("Saldo insuficiente.");
            return;
        }

        if (!await AutorizadorExterno())
        {
            Console.WriteLine("Transferência não autorizada.");
            return;
        }

        Saldo -= valor;
        destinatario.Saldo += valor;

        await EnviarNotificacao(destinatario.Email, "Você recebeu uma transferência.");

        Console.WriteLine("Transferência concluída com sucesso.");
    }

    private async Task<bool> AutorizadorExterno()
    {
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync("https://run.mocky.io/v3/5794d450-d2e2-4412-8131-73d0293ac1cc");
            return response.IsSuccessStatusCode;
        }
    }

    private async Task EnviarNotificacao(string email, string mensagem)
    {
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync("https://run.mocky.io/v3/54dc2cf1-3add-45b5-b5a9-6bf7e7f1f4a6");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Falha ao enviar notificação.");
            }
        }
    }
}