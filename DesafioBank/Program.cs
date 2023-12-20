using DesafioBank;

class Program
{
    static async Task Main()
    {
        UsuarioComum usuario1 = new UsuarioComum() { NomeCompleto = "Usuario 1", CPF = "12345678901", Email = "usuario1@email.com", Senha = "senha123", Saldo = 5000 };
        UsuarioComum usuario2 = new UsuarioComum() { NomeCompleto = "Usuario 2", CPF = "98765432101", Email = "usuario2@email.com", Senha = "senha456", Saldo = 9000 };
        Lojista lojista1 = new Lojista { NomeCompleto = "Lojista 1", CPF = "12345678901234", Email = "lojista1@email.com", Senha = "senha789", Saldo = 0 };
        Lojista lojista2 = new Lojista() {NomeCompleto = "Lojista 2", CPF = "14725836912", Email = "lojista2@email.com", Senha = "senha987", Saldo = 0};

        Console.WriteLine("Saldo inicial do usuário 1: " + usuario1.Saldo);
        Console.WriteLine("Saldo inicial do usuário 2: " + usuario2.Saldo);
        Console.WriteLine("Saldo inicial do lojista 1: " + lojista1.Saldo);
        Console.WriteLine("Saldo inicial do lojista 2: " + lojista2.Saldo);

        // Transferência entre usuários
        await usuario1.TransferirDinheiro(usuario2, 400);
        Console.WriteLine("Novo saldo do usuário 1: " + usuario1.Saldo);
        Console.WriteLine("Novo saldo do usuário 2: " + usuario2.Saldo);

        // Transferência para lojista
        await usuario1.TransferirDinheiro(lojista1, 500);
        Console.WriteLine("Novo saldo do usuário 1: " + usuario1.Saldo);
        Console.WriteLine("Novo saldo do lojista 1: " + lojista1.Saldo);

        // Transferência para lojista
        await usuario2.TransferirDinheiro(lojista1, 500);
        Console.WriteLine("Novo saldo do usuário 2: " + usuario1.Saldo);
        Console.WriteLine("Novo saldo do lojista 1: " + lojista1.Saldo);

        // Transferência para lojista
        await usuario1.TransferirDinheiro(lojista2, 500);
        Console.WriteLine("Novo saldo do usuário 1: " + usuario1.Saldo);
        Console.WriteLine("Novo saldo do lojista 2: " + lojista1.Saldo);

        // Transferência para lojista
        await usuario2.TransferirDinheiro(lojista2, 500);
        Console.WriteLine("Novo saldo do usuário 2: " + usuario1.Saldo);
        Console.WriteLine("Novo saldo do lojista 2: " + lojista1.Saldo);

        // Transferência com saldo insuficiente
        await usuario2.TransferirDinheiro(usuario1, 400);

        // Transferência para lojista sem saldo
        await usuario2.TransferirDinheiro(lojista1, 200);

        // Transferência com autorização externa falha
        lojista1.Saldo = 1000; // Recarregando saldo para testar novamente
        await usuario1.TransferirDinheiro(lojista1, 300);

        // Tentativa de transferência com autorização externa falha
        lojista2.Saldo = 5000; // Recarregando saldo para testar novamente
        await usuario1.TransferirDinheiro(lojista1, 500);

        // Tentativa de transferência com autorização externa falha
        lojista1.Saldo = 2000; // Recarregando saldo para testar novamente
        await usuario2.TransferirDinheiro(lojista1, 700);

        // Tentativa de transferência com autorização externa falha
        lojista2.Saldo = 3000; // Recarregando saldo para testar novamente
        await usuario2.TransferirDinheiro(lojista1, 900);
    }
}