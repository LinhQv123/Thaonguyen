using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanLyGV.entity
{
    public class Member
    {
        public Guid member_id { get; set; }
        public string member_name { get; set; }
        public string pass_word { get; set; }
        public string last_name { get; set; }
        public string first_name { get; set; }
        public int role { get; set; }
        public int gender { get; set; }
        public string member_code { get; set; }
        public string dateOfbirth { get; set; }
        public string hometown { get; set; }
        public string degree { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        
    }
}
