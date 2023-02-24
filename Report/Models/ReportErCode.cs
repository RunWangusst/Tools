namespace Report.Models
{
    public  class ReportErCode
    {
        // 代码ID
        public string Id { get; set; }
        // 代码值
        public string Name { get; set; }
        // 代码值含义
        public string Value { get; set; }
        // 说明
        public string Description { get; set; }
        public int Order { get; set; }
        // 字段名称
        public string PhysicalName { get; set; }
        // 说明
        public string LogicalName { get; set; }
    }
}