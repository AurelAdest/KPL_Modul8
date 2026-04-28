using Aurel_Adestira_Salsabila_modul8_103082400041;


BankTransferConfig cfg = BankTransferConfig.Load();

bool isEn = cfg.Lang.ToLower() == "en";

Console.Write(isEn
    ? "Please insert the amount of money to transfer: "
    : "Masukkan jumlah uang yang akan di-transfer: ");

long amount = long.Parse(Console.ReadLine()!.Trim());

long fee = amount <= cfg.Transfer.Threshold
             ? cfg.Transfer.LowFee
             : cfg.Transfer.HighFee;
long total = amount + fee;

if (isEn)
{
    Console.WriteLine($"Transfer fee = {fee}");
    Console.WriteLine($"Total amount = {total}");
}
else
{
    Console.WriteLine($"Biaya transfer = {fee}");
    Console.WriteLine($"Total biaya = {total}");
}

Console.WriteLine(isEn ? "Select transfer method:" : "Pilih metode transfer:");

for (int i = 0; i < cfg.Methods.Count; i++)
{
    Console.WriteLine($"{i + 1}. {cfg.Methods[i]}");
}

Console.Write("> ");
Console.ReadLine();

string confirmWord = isEn ? cfg.Confirmation.En : cfg.Confirmation.Id;

Console.Write(isEn
    ? $"Please type \"{confirmWord}\" to confirm the transaction: "
    : $"Ketik \"{confirmWord}\" untuk mengkonfirmasi transaksi: ");

string userInput = Console.ReadLine()!.Trim();

if (userInput == confirmWord)
{
    Console.WriteLine(isEn ? "The transfer is completed" : "Proses transfer berhasil");
}
else
{
    Console.WriteLine(isEn ? "Transfer is cancelled" : "Transfer dibatalkan");
}