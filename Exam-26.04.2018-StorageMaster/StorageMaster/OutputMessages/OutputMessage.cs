namespace StorageMaster.OutputMessages
{
    public static class OutputMessage
    {
        public const string NegativePrice = "Price cannot be negative!";

        public const string InvalidProduct = "Invalid product type!";

        public const string InvalidStorage = "Invalid storage type!";

        public const string InvalidVehicle = "Invalid vehicle type!";

        public const string VehichleIsFull = "Vehicle is full!";

        public const string TruckIsEmpty = "No products left in vehicle!";

        public const string InvalidGarageSlot = "Invalid garage slot!";

        public const string NoVehiclesInThisGarage = "No vehicle in this garage slot!";

        public const string NoRoomInGarage = "No room in garage!";

        public const string StorageIsFull = "Storage is full!";

        public const string AddedProduct = "Added {0} to pool";

        public const string RegisteredStorage = "Registered {0}";

        public const string SelectedVehicle = "Selected {0}";

        public const string OutOfStock = "{0} is out of stock!";

        public const string LoadedProducts = "Loaded {0}/{1} products into {2}";

        public const string InvalidSourceStorage = "Invalid source storage!";

        public const string InvalidDestinationStorage = "Invalid destination storage!";

        public const string SendToStorage = "Sent {0} to {1} (slot {2})";

        public const string UnloadedProducts = "Unloaded {0}/{1} products at {2}";

        public const string StockFormat = "Stock ({0}/{1}): [{2}]";

        public const string Garage = "Garage: [{0}]";

        public const string StorageName = "{0}:";

        public const string StorageWorth = "Storage worth: ${0}";
    }
}
