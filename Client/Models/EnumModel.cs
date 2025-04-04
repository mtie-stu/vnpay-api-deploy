namespace Client.Models
{
    public enum StatusOrder
    {
        Confirming,
        Confirmed,
        Imported,
        Exported
    }

    public enum StatusInventory
    {
        Active,
        Inactive
    }
    public enum TypeOfGoods
    {
        Balet,
        Container18ft,
        Container20ft,
        Container22ft
    }
    public enum StatusStorage
    {
        empty,
        booked,
        full
    }
    public enum InventoryStatus
    {
        Incomplete,
        Complete

    }
    public enum TypeService
    {
        Inventory18ft,
        Inventory20ft,
        Inventory22ft,
        Balet,
        Container18ft,
        Container20ft,
        Container22ft


    }
    public enum StatusService
    {
        Active,
        Inactive

    }
}
