using System.Text.Json;

namespace Aurel_Adestira_Salsabila_modul8_103082400041
{
    public class BankTransferConfig
    {
        public string Lang { get; set; } = "en";

        public TransferConfig Transfer { get; set; } = new TransferConfig();

        public List<string> Methods { get; set; } = new List<string>
        {
            "RTO (real-time)", "SKN", "RTGS", "BI FAST"
        };

        public ConfirmationConfig Confirmation { get; set; } = new ConfirmationConfig();

        public class TransferConfig
        {
            public long Threshold { get; set; } = 25000000;
            public long LowFee { get; set; } = 6500;
            public long HighFee { get; set; } = 15000;
        }

        public class ConfirmationConfig
        {
            public string En { get; set; } = "yes";
            public string Id { get; set; } = "ya";
        }

        private const string CONFIG_FILE = "bank_transfer_config.json";

        public static BankTransferConfig Load()
        {
            if (!File.Exists(CONFIG_FILE))
            {
                Console.WriteLine($"[INFO] Config file '{CONFIG_FILE}' not found. Using defaults.");
                return new BankTransferConfig();
            }

            try
            {
                string json = File.ReadAllText(CONFIG_FILE);
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                return JsonSerializer.Deserialize<BankTransferConfig>(json, options)
                       ?? new BankTransferConfig();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[WARN] Failed to parse config: {ex.Message}. Using defaults.");
                return new BankTransferConfig();
            }
        }
    }
}