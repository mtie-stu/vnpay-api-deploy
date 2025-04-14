namespace Client.Models.ViewModel
{
    public class AdminDashboardViewModel
    {
        public List<WarehouseOrderStatsViewModel> WarehouseOrderStats { get; set; }
        public WarehouseUsageViewModel WarehouseUsage { get; set; } // Thêm dòng này

    }
}
