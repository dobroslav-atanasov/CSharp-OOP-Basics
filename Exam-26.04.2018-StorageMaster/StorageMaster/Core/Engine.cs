namespace StorageMaster.Core
{
    using System;
    using System.Linq;

    public class Engine
    {
        private const string EndCommand = "END";

        private readonly StorageMaster storageMaster;

        public Engine()
        {
            this.storageMaster = new StorageMaster();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != EndCommand)
            {
                try
                {
                    string[] args = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    this.ProcessCommand(args);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine($"Error: {ioe.Message}");
                }
                input = Console.ReadLine();
            }

            Console.WriteLine(this.storageMaster.GetSummary());
        }

        private void ProcessCommand(string[] args)
        {
            string command = args[0];
            switch (command)
            {
                case "AddProduct":
                    Console.WriteLine(this.storageMaster.AddProduct(args[1], double.Parse(args[2])));
                    break;
                case "RegisterStorage":
                    Console.WriteLine(this.storageMaster.RegisterStorage(args[1], args[2]));
                    break;
                case "SelectVehicle":
                    Console.WriteLine(this.storageMaster.SelectVehicle(args[1], int.Parse(args[2])));
                    break;
                case "LoadVehicle":
                    string[] productNames = args.Skip(1).ToArray();
                    Console.WriteLine(this.storageMaster.LoadVehicle(productNames));
                    break;
                case "SendVehicleTo":
                    Console.WriteLine(this.storageMaster.SendVehicleTo(args[1], int.Parse(args[2]), args[3]));
                    break;
                case "UnloadVehicle":
                    Console.WriteLine(this.storageMaster.UnloadVehicle(args[1], int.Parse(args[2])));
                    break;
                case "GetStorageStatus":
                    Console.WriteLine(this.storageMaster.GetStorageStatus(args[1]));
                    break;
            }
        }
    }
}