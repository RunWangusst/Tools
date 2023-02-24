using System.Collections.Generic;

namespace Report.Models
{
    public class ReportView
    {       
        //视图名称 
        public string ViewName { get; set; }
        //说明 
        public string Description { get; set; }
        //序号
        public int Order { get; set; }
        //说明
        public List<ReportViewDetail> ReportViewDetails { get; set; }

    }
}