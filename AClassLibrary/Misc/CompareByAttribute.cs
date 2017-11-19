using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AClassLibrary.Misc {

    [AttributeUsage(AttributeTargets.Property)]
    public class CompareByAttribute : Attribute {

        public CompareByAttribute(int order) {
            this.order = order;
        }

        public bool descending { get; set; }

        private int order { get; set; }
    }
}
