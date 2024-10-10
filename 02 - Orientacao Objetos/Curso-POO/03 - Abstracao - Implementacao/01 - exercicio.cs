// Exercício: Processamento de Transações Bancárias
// Problema 01: A classe Transaction está acoplada a tipos específicos de transações, tornando o código rígido e difícil de expandir.
public class Transaction
{
    public void ProcessBankTransfer()
    {
        Console.WriteLine("Processing bank transfer...");
    }

    public void ProcessCreditCardPayment()
    {
        Console.WriteLine("Processing credit card payment...");
    }
}

//=========================================================================================

// Exercício: Cálculo de Salários de Funcionários (RH)
// Problema 02: A classe SalaryCalculator está acoplada a tipos específicos de funcionários, dificultando a manutenção.

public class SalaryCalculator
{
    public void CalculateManagerSalary()
    {
        Console.WriteLine("Calculating manager salary...");
    }

    public void CalculateInternSalary()
    {
        Console.WriteLine("Calculating intern salary...");
    }
}

//=========================================================================================

// Exercício: Relatórios Financeiros
// Problema : Descubra e resolva o problema

public class FinancialReport
{
    public void GenerateMonthlyReport()
    {
        Console.WriteLine("Generating monthly report...");
    }

    public void GenerateYearlyReport()
    {
        Console.WriteLine("Generating yearly report...");
    }
}

//=========================================================================================
// Exercício: Benefícios de Funcionários
// Problema : Descubra e resolva o problema

public class Benefits
{
    public void ApplyHealthInsurance()
    {
        Console.WriteLine("Applying health insurance...");
    }

    public void ApplyPensionPlan()
    {
        Console.WriteLine("Applying pension plan...");
    }
}

//=========================================================================================
// Exercício: Empréstimos Bancários
// Problema : Descubra e resolva o problema

public class Loan
{
    public void CalculatePersonalLoan() // empréstimo pessoal
    {
        Console.WriteLine("Calculating personal loan...");
    }

    public void CalculateMortgage() // hipoteca
    {
        Console.WriteLine("Calculating mortgage...");
    }
}

// Por último
// Crie uma classe de serviço para executar transações bancárias, uma para transferência outra para pagamento de cartão de crédito.
// Depois aplique o uso com o código ruim, e em seguida com o código novo.


// Crie uma classe de serviço para executar empréstimos bancários, uma para empréstimo pessoal outra para hipoteca.
// Depois aplique o uso com o código ruim, e em seguida com o código novo.
