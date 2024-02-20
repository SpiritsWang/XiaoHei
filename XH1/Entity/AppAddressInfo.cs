using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH1.Entity
{
    public class AppAddressInfo
    {
        /// <summary>
        /// 完整key
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 路径
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 显示名称
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// 唯一ID名称
        /// </summary>
        public string IDName { get; set; }
        /// <summary>
        /// 索引
        /// </summary>
        public string Index { get; set; }
        /// <summary>
        /// 是否可见 1:是,0:否
        /// </summary>
        public string Visible { get; set; }
    }
}
