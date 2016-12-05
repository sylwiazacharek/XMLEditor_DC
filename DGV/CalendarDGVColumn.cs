using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XMLEditor.DGV
{
    class CalendarDGVColumn : DataGridViewColumn
    {
        public CalendarDGVColumn()
            : base(new CalendarDGVCell())
        {
        }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                if (value != null && !value.GetType().IsAssignableFrom(typeof(CalendarDGVCell)))
                {
                    throw new InvalidCastException("Must be a CalendarCell");
                }

                base.CellTemplate = value;
            }
        }
    }
}
